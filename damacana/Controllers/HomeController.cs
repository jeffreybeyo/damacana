using damacana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace damacana.Controllers
{
    public class HomeController : Controller
    {
        public static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Erikli 19L",
                Price = (decimal)4.90
            },

            new Product
            {
                Id = 2,
                Name = "Hayat 19L",
                Price = (decimal)5.90
            },

            new Product()
            {
                Id = 3,
                Name = "Nestle Pure 500 mL",
                Price = (decimal)0.90
            },
        };

        public ActionResult Index()
        {

            return View(products);
        }


        public ActionResult SaveProduct(Product product)
        {
            products.Add(product);
            return View(product);
        }

        public ActionResult DeleteProduct(int Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}