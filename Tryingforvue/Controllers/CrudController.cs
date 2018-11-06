using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tryingforvue.Models.DTO;
using Tryingforvue.Models.VM;
using Vue.BussinessLayer.Services;
using Vue.DataLayer;

namespace Tryingforvue.Controllers
{
    public class CrudController : Controller
    {
        // GET: Crud
        public JsonResult GetAllProducts()
        {

            IEnumerable<ProductDTO> Products = ProductService.GetInstance.GetAll().Take(20).Select(x =>
            {

                return new ProductDTO
                {
                    CategoryName = x.Category.CategoryName,
                    Id = x.ProductID,
                    ProductName = x.ProductName,
                    QuantityPerUnit = x.QuantityPerUnit,
                    UnitPrice = x.UnitPrice,
                    Stock = x.UnitsInStock
                };
            });



            return Json(Products, JsonRequestBehavior.AllowGet);



        }

        public JsonResult GetAllCategories()
        {
            IEnumerable<CategoryDTO> Categories = CategoryService.GetInstance.GetAll().Select(x=>{
                return new CategoryDTO
                {
                 CategoryId=x.CategoryID,
                 CategoryName=x.CategoryName,
                 Desc=x.Description

                };
            });

            return Json(Categories, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateCategory(int id, Category data)
        {
            if(data.CategoryName==null)
            {
                Category cat = CategoryService.GetInstance.GetById(id);
                return View(cat);
            }
            else
            {
                data.CategoryID = id;
                CategoryService.GetInstance.Update(data);
                return RedirectToAction("Category", "Home");
            }


        }


        public ActionResult AddCategory(Category cat)
        {
            if (cat.CategoryName == null)
            {
                return View();

            }

            else
            {
                CategoryService.GetInstance.Add(cat);
                return RedirectToAction("Category", "Home");
            }
        }

        public JsonResult Increase(int id)
        {
            ProductService.GetInstance.increase(id);

            return Json("");

        }

        public JsonResult decrease(int id)
        {
            ProductService.GetInstance.decrease(id);
            return Json("");
        }
    }
}