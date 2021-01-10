namespace HotelApp.DAL.EF
{
    using System.Data.Entity;
    using HotelApp.DAL.Entities;

    public partial class MyContext : DbContext
    {
        public MyContext(string conn) : base(conn) { }

        public virtual DbSet<SUITE> SUITES { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BOOKING> BOOKINGS { get; set; }

       
    }
}
