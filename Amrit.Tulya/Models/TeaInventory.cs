using System;
using System.Collections.Generic;

namespace Amrit.Tulya.Models
{
    public partial class TeaInventory
    {
        public int TeaId { get; set; }
        public string TeaName { get; set; }
        public string TeaDescription { get; set; }
        public string TeaPrice { get; set; }
        public string TeaImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
