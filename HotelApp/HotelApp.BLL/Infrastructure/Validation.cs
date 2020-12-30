namespace HotelApp.BLL.Infrastructure
{
    using System;

    public class Validation : Exception
    {
        public string Property { get; protected set; }
        public Validation(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
