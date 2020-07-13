using Amrit.Tulya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amrit.Tulya.Repository
{
    public interface ITeaInventoryRepository
    {
        Task<List<TeaInventory>> GetTeaInventoryItems();
        Task<TeaInventory> GetTeaInventoryItemsById(int? Id);

        Task<int> AddItemToInventory (TeaInventory teaInventory);

        Task<int> DeleteItemFromInventory(int? userId);

        //Task UpdateUser(TeaInventory teaInventory);
    }
}
