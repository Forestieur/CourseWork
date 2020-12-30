namespace HotelApp
{
    using HotelApp.BLL.Interfaces;
    using HotelApp.BLL.Services;
    using Ninject.Modules;
    public class HotelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookingService>().To<BookingService>();
        }
    }
}