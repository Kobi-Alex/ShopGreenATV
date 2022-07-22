using Microsoft.AspNetCore.Mvc;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace Store.UI.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryMenu(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _unitOfWork.Categories.GetAll();
            return View(categories);
        }
    }
}