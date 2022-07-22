
using Store.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Store.UI.Models
{
    public class ProductIndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Promotion> Promotions { get; set; }
        public SubcategoryViewModel SubcategoryViewModel{ get; set; }
        public string CurrentCategory { get; set; }
    }
}
