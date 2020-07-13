using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Amrit.Tulya.Models;
using Amrit.Tulya.Repository;

namespace Amrit.Tulya.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class TeaInventoryController : ControllerBase
    {
        private ITeaInventoryRepository teaInventoryRepository;
        public TeaInventoryController(ITeaInventoryRepository _teaInventoryRepository)
        {
            teaInventoryRepository = _teaInventoryRepository;
        }

        // GET: api/GetItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeaInventory>>> GetItems()
        {
            try
            {
                var records = await teaInventoryRepository.GetTeaInventoryItems();
                if (records == null)
                {
                    return NotFound();
                }

                return Ok(records);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/GetItemsById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeaInventory>> GetItemsById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await teaInventoryRepository.GetTeaInventoryItemsById(id);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/TeaInventory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TeaInventory>> AddItems(TeaInventory teaInventory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await teaInventoryRepository.AddItemToInventory(teaInventory);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        // DELETE: api/TeaInventory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeaInventory>> DeleteItems(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await teaInventoryRepository.DeleteItemFromInventory(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        //[HttpPut]
        //public async Task<IActionResult> UpdateTeaInventory(TeaInventory TeaInventory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await teaInventoryRepository.UpdateUser(TeaInventory);

        //            return Ok();
        //        }
        //        catch (Exception ex)
        //        {
        //            if (ex.GetType().FullName ==
        //                     "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
        //            {
        //                return NotFound();
        //            }

        //            return BadRequest();
        //        }
        //    }

        //    return BadRequest();
        //}
    }
}
