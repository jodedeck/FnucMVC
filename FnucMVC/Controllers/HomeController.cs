using FnucMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FnucMVC.Controllers
{
    public class HomeController : Controller
    {
        private string _baseUri;

        public HomeController()
        {

        }
        public HomeController(IUriServices uriServices)
        {
            _baseUri = uriServices.ApiURL;
        }

        public ActionResult Index()
        {

            ViewBag.Message = _baseUri;
            return View();
           
        }

        public ActionResult About()
        {
          

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}