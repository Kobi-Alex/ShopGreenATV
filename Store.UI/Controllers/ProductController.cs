using Microsoft.AspNetCore.Mvc;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace GreenATV.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private ProductIndexViewModel vm;
        private SubcategoryViewModel sm;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            vm = new ProductIndexViewModel();
            sm = new SubcategoryViewModel();
        }

        public ViewResult Index(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
                return View();

            vm.Products = _unitOfWork.Products.Find(p => p.Category.Name == categoryName);
            vm.Promotions = _unitOfWork.Promotions.GetAll();
            sm.CurrentCategoryName = categoryName;
            sm.Subcategories = vm.Products.OrderBy(s => s.Subcategory).Select(f => f.Subcategory.ToLower()).Distinct();
            vm.SubcategoryViewModel = sm;

            return View(vm);

        }

        public ViewResult Subcategory(string sub, string name)
        {

            vm.Products = _unitOfWork.Products.Find(p => p.Subcategory == sub);
            sm.CurrentCategoryName = name;
            sm.Subcategories = _unitOfWork.Products
            .Find(p => p.Category.Name == name)
            .OrderBy(s => s.Subcategory)
            .Select(f => f.Subcategory.ToLower()).Distinct();
            vm.SubcategoryViewModel = sm;

            return View(vm);

        }
    }
}