using Store.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Store.UI.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}