using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tryingforvue.Models.VM
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public short? Stock { get; set; }
        public decimal? UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }

        public string CategoryName { get; set; }
    }
}