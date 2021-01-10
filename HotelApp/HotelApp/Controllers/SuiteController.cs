namespace HotelApp.PL.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using HotelApp.BLL.DTO;
    using System.Collections.Generic;
    using HotelApp.BLL.Interfaces;


    public class SuiteController : Controller
    {
        public static string pre_fullPayed;
        UserDTO current;

        IBookingService db;

         public SuiteController(IBookingService service)
         {
             db = service;
             current = db.GetUser(HomeController.currentUserId);
         }

        public ActionResult ListSuite()
        {
            List<SuiteDTO> all = db.GetAllSuites().ToList();
            return View(all);
        }

        [HttpGet]
        public ActionResult DetailsSuite(int? id)
        {
            SuiteDTO suit = db.GetSuite(id);

            ViewBag.takeId = ShowBag(suit, new BookingDTO());

            return View();
        }

        [HttpPost]
        public ActionResult DetailsSuite(BookingDTO order)
        {
            string error = string.Empty;
            bool flag = false;
            List<BookingDTO> bookings = db.GetAllOrders().ToList();
            SuiteDTO suit = db.GetSuite(order.id);

            if (bookings.Count == 0)
            {
                flag = true;
            }

            foreach (BookingDTO b in bookings)
            {
                if (order.booking_from != b.booking_from && order.booking_to != b.booking_to)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                int cost = db.TotalCost(order.booking_from, order.booking_to, order.cost, suit.base_cost);

                ViewBag.Price = cost;

                order.id = 0;
                order.cost = cost;
                order.suite_id = suit.id;
                order.User_id1 = current.id;
     
                try
                {
                    db.MakeOrder(order);
                    db.Save();
                    int lastId = bookings.Count;
                    ViewBag.takeId = ShowBag(suit, order);
                    BookingDTO last = bookings.FirstOrDefault(i => i.id == lastId);
                    if(last == null)
                    {
                        return RedirectToAction($"../Success/SuccessPage/{ 1}");
                    }
                    return RedirectToAction($"../Success/SuccessPage/{last.id + 1}");
                }
                catch (Exception ex) { ViewBag.err = error = ex.Message; }
            }
            else
            {
                ViewBag.error_msg = "Unfortunately, this date is not available!";
            }

            return View();
        }

        object[] ShowBag(SuiteDTO suit, BookingDTO b )
        {
           /* b.id = 1;
            suit.id = 1;*/
            if (b.fullpayed == 1 && b.prepayed == 0)
                pre_fullPayed = "You have to pay full price.";
            else pre_fullPayed = "You have to make a prepayment.";
            string categId = suit.category.ToString();
            object[] attrs = new object[]
            {
                categId,
                HomeController.currentUserLogin
            };
            return attrs;
        }
    }
}