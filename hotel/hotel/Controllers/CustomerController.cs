using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
    
    public class CustomerController : Controller
    {
        HotelEntities context = new HotelEntities();
        // GET: Customer
        public ActionResult Index()
        {
            var cust = context.Customers.ToList();
            return View(cust);
        }

        public ActionResult Searchcust(string custname)
        {

            var sup = context.Customers.Where(x => x.cus_name == custname).ToList();

            return View("Index", sup);
        }

        public ActionResult addcust()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addcust(Customer cust)
        {
            if (!ModelState.IsValid)
            {
                return View(cust);
            }
            if(context.Customers.Any(x=>x.cus_ssn==cust.cus_ssn))
            {
                ModelState.AddModelError("", "ان رقم البطاقه موجود سابقا");
                return View(cust);
            }
            context.Customers.Add(cust);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deletecust(int id)
        {
            var cont = context.Customers.Where(x => x.id == id).FirstOrDefault();
            context.Customers.Remove(cont);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Editcust(int id)
        {
            var cont = context.Customers.Where(x => x.id == id).FirstOrDefault();
            return View(cont);
        }
        [HttpPost]
        public ActionResult Editcust(Customer cust)
        {
            var cont = context.Customers.Where(x => x.id == cust.id).FirstOrDefault();
            cont.cus_name = cust.cus_name;
            cont.cus_phone = cust.cus_phone;
            cont.cus_fax = cust.cus_fax;
            cont.cus_ssn = cust.cus_ssn;
            cont.cus_city = cust.cus_city;
            
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}