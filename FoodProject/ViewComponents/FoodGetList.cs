using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.ViewComponents
{
    public class FoodGetList : ViewComponent
    {
        public IViewComponentResult Invoke ()
        {
            FoodRepository _foodRepository = new FoodRepository();
            var liste = _foodRepository.List();
            return View(liste);

        }
    }
}
