using Amrit.Tulya.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Amrit.Tulya.Repository
{
    public class TeaInventoryRepository : ITeaInventoryRepository
    {
        private TeaShopContext db;
        public TeaInventoryRepository(TeaShopContext _db)
        {
            db = _db;
        }
        public async Task<List<TeaInventory>> GetTeaInventoryItems()
        {
            if (db != null)
            {
                return await db.TeaInventory.OrderByDescending(t => t.CreatedDate).ToListAsync();
            }

            return null;
        }

        public async Task<TeaInventory> GetTeaInventoryItemsById(int? Id)
        {
            if (db != null)
            {
                return await db.TeaInventory.Where(x => x.TeaId == Id).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<int> AddItemToInventory(TeaInventory teaInventory)
        {
            if (db != null)
            {
                if(teaInventory.TeaImagePath == null)
                {
                    teaInventory.TeaImagePath = "Resources//Images//No-image-available.png";
                }
                await db.TeaInventory.AddAsync(teaInventory);
                await db.SaveChangesAsync();

                return teaInventory.TeaId;
            }

            return 0;
        }

        public async Task<int> DeleteItemFromInventory(int? Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var record = await db.TeaInventory.FirstOrDefaultAsync(x => x.TeaId == Id);

                if (record != null)
                {
                    //Delete that post
                    db.TeaInventory.Remove(record);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
    }
}
