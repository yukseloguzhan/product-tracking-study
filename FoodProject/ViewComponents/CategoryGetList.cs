using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FoodProject.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository _categoryrepository = new CategoryRepository();
            var categoryList = _categoryrepository.List();
            return View(categoryList);

        }


    }
}