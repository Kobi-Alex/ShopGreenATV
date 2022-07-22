using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Domain.Interfaces;
using Store.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Store.UI.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingCart _shoppingCart;


        public ShoppingCartController(IUnitOfWork unitOfWork, ShoppingCart shoppingCart)
        {
            this._unitOfWork = unitOfWork;
            this._shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectProduct = _unitOfWork.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectProduct != null)
            {
                _shoppingCart.AddToCart(selectProduct, 1);
            }
            return RedirectToAction("Index");

        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectProduct = _unitOfWork.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectProduct);
            }
            return RedirectToAction("Index");

        }

    }
}
