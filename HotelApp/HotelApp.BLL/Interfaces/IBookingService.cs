namespace HotelApp.BLL.Interfaces
{
    using System;
    using HotelApp.BLL.DTO;
    using System.Collections.Generic;

    public interface IBookingService
    {
        void AddUser(UserDTO insert);
        SuiteDTO GetSuite(int? id);
        void MakeOrder(BookingDTO d);
        BookingDTO GetOrder(int? id);
        UserDTO GetUser(int? id);
        int TotalCost(DateTime from, DateTime to, int cost, int base_cost);
        IEnumerable<SuiteDTO> GetAllSuites();
        IEnumerable<UserDTO> GetAllUsers();
        IEnumerable<BookingDTO> GetAllOrders();
        void Save();
        void Dispose();
    }
}
