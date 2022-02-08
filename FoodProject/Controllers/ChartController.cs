   using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
    public class ChartController : Controller
    {
        Context context1 = new Context();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult() // sonucları gorsellestir
        {
            return Json(ProList());
        }

        private List<Class2> ProList()
        {
            List<Class2> cs = new List<Class2>();
            cs.Add(new Class2
            {
                 ProductName="Computer",
                 Stock=150
            });

            cs.Add(new Class2
            {
                ProductName = "Lcd",
                Stock = 125
            });

            cs.Add(new Class2
            {
                ProductName = "Disk",
                Stock = 234
            });

            return cs;
        }
        
        public IActionResult Index3 ()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }

        private List<Class3> FoodList()
        {
            List<Class3> cs2 = new List<Class3>();

            using (var context = new Context())
            {
                cs2 = context.Foods.Select(x => new Class3
                {
                     FoodName = x.FoodName,
                     FStock = x.FoodStock 

                }).ToList();
            }

            return cs2;
           
        }

        public IActionResult Statistics ()
        {

            var deger1 = context1.Foods.Count();
            ViewBag.dgr1 = deger1;

            var deger2 = context1.Categories.Count();
            ViewBag.dgr2 = deger2;


            var fruitId = context1.Categories.Where(x => x.CategoryName == "Meyveler").Select(y => y.CategoryId).FirstOrDefault();
            var deger3 = context1.Foods.Where(x => x.CategoryId == fruitId).Count();
            ViewBag.dgr3 = deger3;

            var deger4 = context1.Foods.Where(x => x.CategoryId == 2).Count();
            ViewBag.dgr4 = deger4;

            var deger5 = context1.Foods.Sum(x => x.FoodStock);
            ViewBag.dgr5 = deger5;

            var deger6 = context1.Foods.OrderByDescending(x => x.FoodStock).Select(y=>y.FoodName).FirstOrDefault();
            ViewBag.dgr6 = deger6;

            var deger7 = context1.Foods.Average(x => x.FoodPrice).ToString("0.00");
            ViewBag.dgr7 = deger7;


            return View();
        }

    }
}
