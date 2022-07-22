
using Store.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Store.UI.Models
{
    public class SubcategoryViewModel
    {
        public IEnumerable<string> Subcategories{ get; set; }
        public string CurrentCategoryName{ get; set; }
    }
}
