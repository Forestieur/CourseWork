namespace HotelApp.BLL.DTO
{
    using System;
    public class UserDTO
    {
        public int id { get; set; }

        public string Surname { get; set; }

        public string Firstname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }

        public string Role { get; set; }

        public string DateRegister { get; set; }
    }
}
