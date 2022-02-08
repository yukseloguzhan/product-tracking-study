using FoodProject.Data.Models;
using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FoodProject.Controllers // sayfalama yapmak icin x.paged.mvc.corre nuGET İNDİR
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context context = new Context();


        public IActionResult Index(int page=1)
        {
            
            return View(foodRepository.TList("Category").ToPagedList(page,3)); //sayfalama 1.sayfadan baslasın her sayfada 3 kayıt
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> categorylist = (from x in context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.v1 = categorylist;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food f)
        {
            foodRepository.Add(f);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
            foodRepository.Delete(new Food {  FoodId=id});
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);

            List<SelectListItem> categorylist = (from y in context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = y.CategoryName,
                                                     Value = y.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.v2 = categorylist;


            Food f = new Food
            {
                FoodId = x.FoodId,
                FoodName = x.FoodName,
                FoodPrice = x.FoodPrice,
                CategoryId = x.CategoryId,
                FoodDescription = x.FoodDescription,
                FoodStock = x.FoodStock,
                ImageURL = x.ImageURL
            };

            return View(f);
        }

        [HttpPost]
        public IActionResult FoodUpdate (Food p)
        {
            var x = foodRepository.TGet(p.FoodId);
            x.FoodName = p.FoodName;
            x.FoodStock = p.FoodStock;
            x.FoodPrice = p.FoodPrice;
            x.FoodDescription = p.FoodDescription;
            x.ImageURL = p.ImageURL;
            x.CategoryId = p.CategoryId;

            foodRepository.Update(x);
            return RedirectToAction("Index");


        }

    }
}
