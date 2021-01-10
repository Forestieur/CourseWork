namespace HotelApp.DAL.Interfaces
{
    using HotelApp.DAL.Entities;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<BOOKING> Bookings { get; }
        IRepository<SUITE> Suites { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}

