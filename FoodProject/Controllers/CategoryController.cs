using FoodProject.Data.Models;
using FoodProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        //[Authorize]  projede cok varsa tek tek yazmak zahmetli o yuzden bunu kullanmadım
        public IActionResult Index(string p)  // arama islemi icin parametre gonderdik
        {   
            
            if(!string.IsNullOrEmpty(p))
            {
                return View(categoryRepository.IlgiliList(x=>x.CategoryName == p));
            }

            return View(categoryRepository.List());
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if(!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }

            categoryRepository.Add(p);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category ct = new Category
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryId = x.CategoryId
            };
            return View(ct);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category c)
        {
            var x = categoryRepository.TGet(c.CategoryId);
            x.CategoryName = c.CategoryName;
            x.CategoryDescription = c.CategoryDescription;
            x.Status = true;
            categoryRepository.Update(x);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete (int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.Update(x);
            return RedirectToAction("Index");
        }


    }
}
