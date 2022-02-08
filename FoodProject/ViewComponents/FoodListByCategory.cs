using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.ViewComponents
{
    public class FoodListByCategory : ViewComponent
    {
        public IViewComponentResult Invoke(int Cat_id)
        {
          
            FoodRepository _foodRepository = new FoodRepository();
            var liste = _foodRepository.IlgiliList(p=>p.CategoryId == Cat_id);
            return View(liste);

        }
    }
}
