namespace HotelApp.DAL.Repositories
{
    using HotelApp.DAL.EF;
    using System.Data.Entity;
    using HotelApp.DAL.Entities;
    using HotelApp.DAL.Interfaces;
    using System.Collections.Generic;
    public class BookingRepository : IRepository<BOOKING>
    {
        MyContext db;

        public BookingRepository(MyContext db)
        {
            this.db = db;
        }

        public void Create(BOOKING item)
        {
            db.BOOKINGS.Add(item);
        }

        public void Delete(int id)
        {
            BOOKING del = db.BOOKINGS.Find(id);
            if(del != null)
                db.BOOKINGS.Remove(del);
        }

        public BOOKING Get(int id)
        {
            BOOKING get = db.BOOKINGS.Find(id);
            return get;
        }

        public IEnumerable<BOOKING> GetAll()
        {
            return db.BOOKINGS;
        }

        public void Update(BOOKING item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
