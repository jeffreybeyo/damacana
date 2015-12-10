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
        // GET: Purchases
        public User myuser = new User();
        public PurchaseDBContext db = new PurchaseDBContext();
        public static List<Purchase> PurchasesTem = new List<Purchase>
        {

        };

        public int PurchaseId = 0;
        public int i = 0;
        public ActionResult Purchase()
        {

            Purchase siparis = new Purchase();
            decimal totalprice = 0;
            siparis.PurchaseList = new List<Product>();
            foreach (Product p in (List<Product>)TempData["Cartlist"])
            {
                siparis.PurchaseList.Add(p);
                totalprice = p.Price + totalprice;
            }
            siparis.Id = PurchaseId;
            PurchaseId = PurchaseId + 1;
            siparis.TotalPrice = totalprice;
            TempData["Siparis"] = siparis;
            i++;
            return View(siparis);

        }
    }
}