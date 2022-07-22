using Microsoft.AspNetCore.Mvc;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.UI.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GreenATV.Controllers
{
    public class PromotionController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public PromotionController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            return View();
        }
    }

}