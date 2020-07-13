using Amrit.Tulya.Controllers;
using Amrit.Tulya.Models;
using Amrit.Tulya.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Amrit.Tulya.Test
{
    public class TeaInventoryFakeController
    {
        private TeaInventoryRepository repository;
        public static DbContextOptions<TeaShopContext> dbContextOptions { get; }
        public static string connectionString = "Data Source=(localdb)\\db;Initial Catalog=TeaShop;Integrated Security=True";

        static TeaInventoryFakeController()
        {
            dbContextOptions = new DbContextOptionsBuilder<TeaShopContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        public TeaInventoryFakeController()
        {
            var context = new TeaShopContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new TeaInventoryRepository(context);
        }
        #region Get Items By Id  

        [Fact]
        public async void Task_GetItemsById_Return_OkResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            var teaId = 2;

            //Act  
            var data = await controller.GetItemsById(teaId);

            //Assert  
            Assert.IsType<OkObjectResult>(data.Result);
        }

        [Fact]
        public async void Task_GetItemsById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            var teaId = 30;

            //Act  
            var data = await controller.GetItemsById(teaId);

            //Assert  
            Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        public async void Task_GetItemsById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            int? teaId = null;

            //Act  
            var data = await controller.GetItemsById(teaId);

            //Assert  
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public async void Task_GetItemsById_MatchResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            int? teaId = 1;

            //Act  
            var data = await controller.GetItemsById(teaId);

            //Assert  
            Assert.IsType<OkObjectResult>(data.Result);

            var okResult = data.Result.Should().BeOfType<OkObjectResult>().Subject;
            var tea = okResult.Value.Should().BeAssignableTo<TeaInventory>().Subject;

            Assert.Equal("Orange Juice", tea.TeaName);
            Assert.Equal("Orange Tree", tea.TeaDescription);
        }

        #endregion

        #region Get All Items 

        [Fact]
        public async void Task_GetItems_Return_OkResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);

            //Act  
            var data = await controller.GetItems();

            //Assert  
            Assert.IsType<OkObjectResult>(data.Result);
        }

        [Fact]
        public async void Task_GetItems_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);

            //Act  
            var data = await controller.GetItems();
            data = null;

            if (data != null)
                //Assert  
                Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public async void Task_GetItems_MatchResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);

            //Act  
            var data = await controller.GetItems();

            //Assert  
            Assert.IsType<OkObjectResult>(data.Result);

            var okResult = data.Result.Should().BeOfType<OkObjectResult>().Subject;
            var tea = okResult.Value.Should().BeAssignableTo<List<TeaInventory>>().Subject;

            Assert.Equal("Orange Juice", tea[0].TeaName);
            Assert.Equal("Orange Tree", tea[0].TeaDescription);

            Assert.Equal("Mango Juice", tea[1].TeaName);
            Assert.Equal("Mango Tree", tea[1].TeaDescription);

        }

        #endregion

        #region Add New Item

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            var teaInventory= new TeaInventory() { TeaName = "Test Title 3", TeaDescription = "Test Description 3", TeaPrice = "2", CreatedDate = DateTime.Now };

            //Act  
            var data = await controller.AddItems(teaInventory);

            //Assert  
            Assert.IsType<OkObjectResult>(data.Result);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            var teaInventory = new TeaInventory() { TeaId = 0, TeaName = "Test Invalid Title", TeaDescription = "Test Description", TeaPrice = "25", CreatedDate = DateTime.Now };
            teaInventory.TeaId /= 0;
            //Act  
            var data = await controller.AddItems(teaInventory);

            //Assert  
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public async void Task_Add_ValidData_MatchResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            var teaInventory = new TeaInventory() { TeaName = "Valid Test Title ", TeaDescription = "Valid Test Description", TeaPrice = "92", CreatedDate = DateTime.Now };

            //Act  
            var data = await controller.AddItems(teaInventory);

            //Assert  
            Assert.IsType<OkObjectResult>(data.Result);

            var okResult = data.Result.Should().BeOfType<OkObjectResult>().Subject;
            // var result = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;  

            Assert.Equal(6, okResult.Value);
        }

        #endregion

        #region Delete Item  

        [Fact]
        public async void Task_Delete_Item_Return_OkResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            var teaId = 2;

            //Act  
            var data = await controller.DeleteItems(teaId);

            //Assert  
            Assert.IsType<OkResult>(data.Result);
        }

        [Fact]
        public async void Task_Delete_Item_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            var teaId = 10;

            //Act  
            var data = await controller.DeleteItems(teaId);

            //Assert  
            Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        public async void Task_Delete_Item_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new TeaInventoryController(repository);
            int? teaId = null;

            //Act  
            var data = await controller.DeleteItems(teaId);

            //Assert  
            Assert.IsType<BadRequestResult>(data.Result);
        }

        #endregion

    }
}
