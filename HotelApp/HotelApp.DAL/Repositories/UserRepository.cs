namespace HotelApp.DAL.Repositories
{
    using HotelApp.DAL.EF;
    using System.Data.Entity;
    using HotelApp.DAL.Entities;
    using HotelApp.DAL.Interfaces;
    using System.Collections.Generic;

    public class UserRepository: IRepository<User>
    {
        MyContext db;

        public UserRepository(MyContext db)
        {
            this.db = db;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User del = db.Users.Find(id);
            if (del != null)
                db.Users.Remove(del);
        }

        public User Get(int id)
        {
            User get = db.Users.Find(id);
            return get;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

       
    }
}
