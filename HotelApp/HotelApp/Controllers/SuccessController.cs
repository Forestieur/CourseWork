namespace HotelApp.PL.Controllers
{
    using HotelApp.BLL.DTO;
    using System.Web.Mvc;
    using HotelApp.BLL.Interfaces;

    public class SuccessController : Controller
    {
        IBookingService db;

        public SuccessController(IBookingService service)
        {
            db = service;
        }

        public ActionResult SuccessPage(int? id)
        {
            BookingDTO bb = db.GetOrder(id);
            object[] resultTxt = new object[]
            {
                 bb.id,
                 bb.cost,
                 SuiteController.pre_fullPayed
            };
            ViewBag.arr = resultTxt;

            return View();
        }
    }
}