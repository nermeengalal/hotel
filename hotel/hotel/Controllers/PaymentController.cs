using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
   
    public class PaymentController : Controller
    {
        HotelEntities context = new HotelEntities();
        // GET: Payment
        public ActionResult Index(string id)
        {
            ViewBag.CompanyId = new SelectList(context.Customers, "id", " cus_name", id);
            if (id == null)
            {
                List<Billing> model = new List<Billing>();
                return View(model);
            }
            else
            {
                var sup = context.Billings.Where(x => x.cus_id.ToString() == id).ToList();

                return View(sup);
            }
        }

        public List<SelectListItem> Getcust()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var emp = context.Customers.ToList();
            foreach (var item in emp)
            {
                list.Add(new SelectListItem { Value = item.id.ToString(), Text = item.cus_name });
            }
            return list;
        }
        public ActionResult addcustpay()
        {
            ViewBag.customerlist = Getcust();
            return View();
        }

        [HttpPost]
        public ActionResult addcustpay(Billing bill)
        {
            context.Billings.Add(bill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var cust = context.Billings.Where(x => x.id == id).FirstOrDefault();
            context.Billings.Remove(cust);
            return RedirectToAction("Index");
        }
    }
}