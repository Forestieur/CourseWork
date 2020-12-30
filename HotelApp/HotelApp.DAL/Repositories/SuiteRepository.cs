namespace HotelApp.DAL.Repositories
{
    using HotelApp.DAL.EF;
    using System.Data.Entity;
    using HotelApp.DAL.Entities;
    using HotelApp.DAL.Interfaces;
    using System.Collections.Generic;

    public class SuiteRepository: IRepository<SUITE>
    {
        MyContext db;

        public SuiteRepository(MyContext db)
        {
            this.db = db;
        }

        public void Create(SUITE item)
        {
            db.SUITES.Add(item);
        }

        public void Delete(int id)
        {
            SUITE del = db.SUITES.Find(id);
            if (del != null)
                db.SUITES.Remove(del);
        }

        public SUITE Get(int id)
        {
            SUITE get = db.SUITES.Find(id);
            return get;
        }

        public IEnumerable<SUITE> GetAll()
        {
            return db.SUITES;
        }

        public void Update(SUITE item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
