namespace HotelApp.DAL.Repositories
{
    using HotelApp.DAL.EF;
    using HotelApp.DAL.Entities;
    using HotelApp.DAL.Interfaces;

    public class EFUnitOfWork : IUnitOfWork
    {
        MyContext db;
        BookingRepository bookingRepository;
        SuiteRepository suiteRepository;
        UserRepository userRepository;

        public EFUnitOfWork(string conn)
        {
            db = new MyContext(conn);
        }

        public IRepository<BOOKING> Bookings
        {
            get
            {
                if (bookingRepository == null)
                    bookingRepository = new BookingRepository(db);
                return bookingRepository;
            }
        }

        public IRepository<SUITE> Suites
        {
            get
            {
                if (suiteRepository == null)
                    suiteRepository = new SuiteRepository(db);
                return suiteRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        bool disposed = false;

        public virtual void Dispose(bool disposing) 
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this); 
        }

        public void Save()
        {
            db.Users.Add(new User {id=2,Login ="Kostya", Password = "123", RePassword = "123" });
        }
    }
}
