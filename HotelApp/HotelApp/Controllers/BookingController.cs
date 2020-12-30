namespace HotelApp.PL.Controllers
{
    using System.Web.Mvc;
    using HotelApp.BLL.Services;
    using System.Configuration;
    using HotelApp.BLL.Interfaces;

    public class BookingController : Controller
    {
        IBookingService db;

        public BookingController(IBookingService service)
        {
            db = service;
        }
    }
}