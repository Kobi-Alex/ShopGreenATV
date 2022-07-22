using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Store.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IUnitOfWork unitOfWork, ShoppingCart shoppingCart)
        {
            _unitOfWork = unitOfWork;
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            order.OrderTotal = items.Sum(p => p.Amount * p.Product.Price);

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some parts first");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Complete();

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.ProductId,
                    OrderId = order.Id,
                    Price = item.Product.Price
                };

                _unitOfWork.OrderDetails.Add(orderDetail);
            }

            _unitOfWork.Complete();
        }
    }

}