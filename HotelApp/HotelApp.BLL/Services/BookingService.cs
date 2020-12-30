namespace HotelApp.BLL.Services
{
    using System;
    using System.Linq;
    using HotelApp.BLL.DTO;
    using HotelApp.DAL.Entities;
    using HotelApp.BLL.Interfaces;
    using HotelApp.DAL.Interfaces;
    using HotelApp.DAL.Repositories;
    using HotelApp.BLL.Infrastructure;
    using System.Collections.Generic;

    public class BookingService : IBookingService
    {
        IUnitOfWork Database { get; set; }

        public BookingService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void Save()
        {
            Database.Save();
        }

        public void AddUser(UserDTO insert)
        {
            User u = new User
            {
                id = insert.id,
                Firstname = insert.Firstname,
                Surname = insert.Surname,
                Login = insert.Login,
                DateRegister = insert.DateRegister,
                Email = insert.Email,
                Password = insert.Password,
                Phone = insert.Phone,
                RePassword = insert.RePassword,
                Role = insert.Role
            };
            Database.Users.Create(u);
        }

        public void MakeOrder(BookingDTO b)
        {
            BOOKING bOOKING = new BOOKING
            {
                suite_id = b.suite_id,
                id = b.id,
                booking_from = b.booking_from,
                booking_to = b.booking_to,
                cost = b.cost,
                fullpayed = b.fullpayed,
                prepayed = b.prepayed,
                User_id1 = b.User_id1
            };
            Database.Bookings.Create(bOOKING);
        }

        public int TotalCost(DateTime from, DateTime to, int cost, int base_cost)
        {
            TimeSpan totalDays = to - from;
            int days = totalDays.Days;
            return cost = days * base_cost;
        }

        public BookingDTO GetOrder(int? id)
        {
            if (id == null)
                throw new Validation("Не встановлено id", "");
            BOOKING b = Database.Bookings.Get(id.Value);
            if (b == null)
                throw new Validation("Не можемо знайти booking", "");

            return new BookingDTO
            {
                suite_id = b.suite_id,
                id = b.id,
                booking_from = b.booking_from,
                booking_to = b.booking_to,
                cost = b.cost,
                fullpayed = b.fullpayed,
                prepayed = b.prepayed,
                User_id1 = b.User_id1
            };
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new Validation("Не встановлено id", "");
            User b = Database.Users.Get(id.Value);
            if (b == null)
                throw new Validation("Не можемо знайти user", "");

            return new UserDTO
            {
                id = b.id,
                Surname = b.Surname,
                Firstname = b.Firstname,
                Email = b.Email,
                Phone = b.Phone,
                Login = b.Login,
                Password = b.Password,
                RePassword = b.RePassword,
                Role = b.Role,
                DateRegister = b.DateRegister
            };
        }

        public SuiteDTO GetSuite(int? id)
        {
            if (id == null)
                throw new Validation("Не встановлено id", "");
            SUITE b = Database.Suites.Get(id.Value);
            if (b == null)
                throw new Validation("Не можемо знайти user", "");

            return new SuiteDTO
            {
                id = b.id,
                base_cost = b.base_cost,
                category = b.category,
                max_quantity = b.max_quantity
            };
        }

        public void EditSuite(SuiteDTO it)
        {
            SUITE s = new SUITE
            {
                base_cost = it.base_cost,
                category = it.category,
                max_quantity = it.max_quantity
            };
            Database.Suites.Update(s);
        }

        public IEnumerable<BookingDTO> GetAllOrders()
        {
            List<BOOKING> bookings = Database.Bookings.GetAll().ToList();
            List<BookingDTO> bDTO = new List<BookingDTO>();
            for (int i = 0; i < bookings.Count(); i++)
            {
                bDTO.Add(new BookingDTO());
                bDTO[i].booking_from = bookings[i].booking_from;
                bDTO[i].booking_to = bookings[i].booking_to;
                bDTO[i].cost = bookings[i].cost;
                bDTO[i].fullpayed = bookings[i].fullpayed;
                bDTO[i].prepayed = bookings[i].prepayed;
                bDTO[i].suite_id = bookings[i].suite_id;
                bDTO[i].id = bookings[i].id;
                bDTO[i].User_id1 = bookings[i].User_id1;
            }
            return bDTO;
        }

        public IEnumerable<SuiteDTO> GetAllSuites()
        {
            List<SUITE> suite = Database.Suites.GetAll().ToList();
            List<SuiteDTO> bSuite = new List<SuiteDTO>();
            for (int i = 0; i < suite.Count(); i++)
            {
                bSuite.Add(new SuiteDTO());
                bSuite[i].base_cost = suite[i].base_cost;
                bSuite[i].category = suite[i].category;
                bSuite[i].id = suite[i].id;
                bSuite[i].max_quantity = suite[i].max_quantity;
            }
            return bSuite;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            Database.Users.Create(new User { id = 0, Login = "Kostya1", Password = "123", RePassword = "123" });

            List<User> users = Database.Users.GetAll().ToList();
            List<UserDTO> bUser = new List<UserDTO>();
            for (int i = 0; i < users.Count(); i++)
            {
                bUser.Add(new UserDTO());
                bUser[i].id = users[i].id;
                bUser[i].DateRegister = users[i].DateRegister;
                bUser[i].Email = users[i].Email;
                bUser[i].Firstname = users[i].Firstname;
                bUser[i].Surname = users[i].Surname;
                bUser[i].Role = users[i].Role;
                bUser[i].Phone = users[i].Phone;
                bUser[i].Password = users[i].Password;
                bUser[i].RePassword = users[i].RePassword;
                bUser[i].Login = users[i].Login;
            }
            return bUser;
        }
     /*   public void Seed()
        {

        }*/
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
