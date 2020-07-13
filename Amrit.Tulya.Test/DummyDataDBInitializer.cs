using Amrit.Tulya.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amrit.Tulya.Test
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(TeaShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.TeaInventory.AddRange(
                new TeaInventory() {  TeaName = "Orange Juice", TeaDescription = "Orange Tree", TeaPrice = "50" },
                new TeaInventory() { TeaName = "Mango Juice", TeaDescription = "Mango Tree", TeaPrice = "250" },
                new TeaInventory() { TeaName = "Apple Juice", TeaDescription = "Apple Tree", TeaPrice = "150" },
                new TeaInventory() { TeaName = "Ice Tea", TeaDescription = "ice Tea", TeaPrice = "90" },
                new TeaInventory() { TeaName = "Cold Coffee", TeaDescription = "Orange Tree", TeaPrice = "140" }
            );
            context.SaveChanges();
        }
    }
}
