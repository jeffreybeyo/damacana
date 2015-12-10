using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using damacana.Models;


namespace damacana.Controllers
{
    public class PurchasesController : Controller
    {
            public User user1 = new User();
            public PurchaseDBContext db = new PurchaseDBContext();
            public static List<Purchase> PurchasesList = new List<Purchase>
            {

            };

            public int purchaseid = 0;
            public int i = 0;
            public ActionResult Purchase()
            {

                Purchase mypurchase = new Purchase();
                decimal totalprice = 0;
                mypurchase.PurchaseList = new List<Product>();
                foreach (Product p in (List<Product>)TempData["Cartlist"])
                {
                    mypurchase.PurchaseList.Add(p);
                    totalprice = p.Price + totalprice;
                }
                mypurchase.Id = purchaseid;
                purchaseid = purchaseid + 1;
                mypurchase.TotalPrice = totalprice;
                TempData["mypurchase"] = mypurchase;
                i++;
                return View(mypurchase);

            }

            public ActionResult PurchaseDone()
            {
                using (db)
                {
                    Purchase mypurchase = (Purchase)TempData["mypurchase"];
                    mypurchase.User = user1;
                    mypurchase.CreatedOn = DateTime.Now;
                    mypurchase.UserId = i;
                    i = i + 1;
                    db.Purchases.Add(mypurchase);
                    PurchasesList.Add(mypurchase);
                    db.SaveChanges();
                    return View(mypurchase);

                }

            }

            public ActionResult PurchaseHistory()
            {
                return View(db.Purchases);
            }
        }
    }