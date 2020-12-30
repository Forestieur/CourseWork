namespace HotelApp.BLL.Infrastructure
{
    using HotelApp.DAL.Interfaces;
    using HotelApp.DAL.Repositories;
    using Ninject.Modules;
    using System.Configuration;

    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
        }
    }
}
