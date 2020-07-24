using hotel.Models;
using hotel.Models.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
    
    public class SupplierController : Controller
    {
        HotelEntities context = new HotelEntities();
        // GET: Supplier
        public ActionResult Index()
        {
            var model = context.Suppliers.ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Supplier sup)
        {
            if (!ModelState.IsValid)
            {
                return View(sup);
            }
            
            context.Suppliers.Add(sup);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deletesup(int id)
        {
            var sup = context.Suppliers.Where(x=>x.id==id).FirstOrDefault();
            context.Suppliers.Remove(sup);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Editsup(int id)
        {
            var sup = context.Suppliers.Where(x => x.id == id).FirstOrDefault();
            return View(sup);
        }

        [HttpPost]
        public ActionResult Editsup(Supplier sup)
        {
            var supp = context.Suppliers.Where(x => x.id == sup.id).FirstOrDefault();
            supp.sup_name = sup.sup_name;
            supp.sup_phone = sup.sup_phone;
            supp.type_of_service = sup.type_of_service;
            supp.date_of_recive = sup.date_of_recive;
            supp.name_of_mandob = sup.name_of_mandob;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Searchsup(string supName)
        {

            var sup = context.Suppliers.Where(x => x.sup_name == supName).ToList();

            return View("Index", sup);
        }


        public ActionResult suppreport(string id)
        {
            ViewBag.CompanyId = new SelectList(context.Suppliers, "id", " sup_name", id);
            if (id == null)
            {
                List<Supplier> model = new List<Supplier>();
                return View(model);
            }
            else
            {
                var sup = context.Suppliers.Where(x => x.id.ToString() == id).ToList();

                return View(sup);
            }
        }

        public ActionResult Reservation()
        {
            List<ReservationMV> empmodel = new List<ReservationMV>();
            
            empmodel = (from a in context.Reservations
                        join e in context.Customers
                        on a.cus_id equals e.id
                        where a.cus_id == e.id
                        select new ReservationMV
                        {
                           id=a.id,
                            cus_name=e.cus_name,
                            room_num = a.room_num,
                            checkin_date = a.checkin_date,
                            checkout_date = a.checkout_date,
                            price = a.price,
                            days_num = a.days_num,
                            discount = a.discount,
                            total = a.total,
                            date_of_reserve = a.date_of_reserve

                        }).ToList();

            return View(empmodel);
        }

        public ActionResult Searchrese(string supName)
        {

            List<ReservationMV> empmodel = new List<ReservationMV>();

            empmodel = (from a in context.Reservations
                        join e in context.Customers
                        on a.cus_id equals e.id
                        where a.cus_id == e.id
                        select new ReservationMV
                        {
                            id = a.id,
                            cus_name = e.cus_name,
                            room_num = a.room_num,
                            checkin_date = a.checkin_date,
                            checkout_date = a.checkout_date,
                            price = a.price,
                            days_num = a.days_num,
                            discount = a.discount,
                            total = a.total,
                            date_of_reserve = a.date_of_reserve

                        }).Where(x => x.cus_name == supName).ToList();

            return View("Reservation", empmodel);
        }

        public ActionResult Deleteresevation(int id)
        {
            var resevation = context.Reservations.Where(x => x.id == id).FirstOrDefault();
            context.Reservations.Remove(resevation);
            context.SaveChanges();
            return RedirectToAction("Reservation");
        }
        public ActionResult Editresevation(int id)
        {
            var rese = context.Reservations.Where(x => x.id == id).FirstOrDefault();
            return View(rese);
        }
        [HttpPost]
        public ActionResult Editresevation(Reservation res)
        {
            var rese = context.Reservations.Where(x => x.id == res.id).FirstOrDefault();
            rese.room_num = res.room_num;
            rese.checkin_date = res.checkin_date;
            rese.checkout_date = res.checkout_date;
            rese.price = res.price;
            rese.days_num = res.days_num;
            rese.discount = res.discount;
            rese.total = res.total;
            rese.date_of_reserve = res.date_of_reserve;
            context.SaveChanges();
            return RedirectToAction("Reservation");
        }
    }
}