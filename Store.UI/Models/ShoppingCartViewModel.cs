using Store.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Store.UI.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }

    }
}
