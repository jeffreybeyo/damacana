using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using damacana.Models;

namespace damacana.Controllers
{
    public class ProductsController : Controller
    {
        public static List<Product> CartProducts = new List<Product>{};

        private ProductDBContext db = new ProductDBContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult AddProduct(Product product)
        {
            return View(product);
        }

        public ActionResult SaveProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return View(product);
        }
        public ActionResult DeleteProduct(int Id)
        {
            foreach (Product p in db.Products)
            {
                if (p.Id == Id)
                {
                    db.Products.Remove(p);
                    break;
                }
            }

            db.SaveChanges();
            return View();
        }
        public ActionResult EditProduct(int Id)
        {
            Product product = new Product();
            foreach (Product p in db.Products)
            {
                if (p.Id == Id)
                {
                    product.Name = p.Name;
                    product.Price = p.Price;
                    product.Id = p.Id;

                    db.Products.Remove(p);
                    break;
                }
            }
            db.SaveChanges();
            return View(product);
        }
        public ActionResult ProductEdited(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();

            return View(product);
        }
        public ActionResult AddtoCart(int Id)
        {
            Product product = new Product();

            foreach (var p in db.Products)
            {
                if (p.Id == Id)
                {
                    product.Name = p.Name;
                    product.Id = p.Id;
                    product.Price = p.Price;
                    CartProducts.Add(p);
                }
            }
            return View(product);
        }

        public ActionResult ShowCart()
        {
            TempData["Cartlist"] = CartProducts;
            return View(CartProducts);
        }

        public ActionResult DeleteFromCart(string Name)
        {
            foreach (Product p in CartProducts)
            {
                if (p.Name == Name)
                {
                    CartProducts.Remove(p);
                    break;
                }
            }
            return View();
        }

        public ActionResult PurchaseOrder()
        {
            Purchase purchase = new Purchase();
            decimal totalprice = 0;
            purchase.PurchaseList = new List<Product>();
            foreach (Product p in CartProducts)
            {
                purchase.PurchaseList.Add(p);
                totalprice = p.Price + totalprice;
            }
            purchase.TotalPrice = totalprice;
            
            return View(purchase);
        }
    }
}
