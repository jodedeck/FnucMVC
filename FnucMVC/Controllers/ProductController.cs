using FnucMVC.Models;
using FnucMVC.Services;
using FnucMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FnucMVC.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService(new UrlBuilder());
   
        // GET: Product
        public async Task<ActionResult> Index()
        {          
            var products = await productService.GetProducts();
            return View("GetProducts", products);
        }

        
        //public async Task<List<ProductViewModel>> GetProducts()
        //{
            
        //    var products = await productService.GetProducts();
        //    return products;
        //}



        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public  ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                // transformer la collection en ProductViewModel
                ProductViewModel productViewModel = productService.CreateProductViewModel(collection);
                //faire l'appel à l'API avec le json correcte
                Task.Run(async () => await productService.PostProduct(productViewModel));
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
