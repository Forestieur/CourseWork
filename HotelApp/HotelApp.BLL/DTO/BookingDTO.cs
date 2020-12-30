namespace HotelApp.BLL.DTO
{
    using System;

    public class BookingDTO
    {
        public int id { get; set; }

        public int suite_id { get; set; }

        public DateTime booking_from { get; set; }

        public DateTime booking_to { get; set; }

        public int cost { get; set; }

        public int User_id1 { get; set; }

        public byte prepayed { get; set; }

        public byte fullpayed { get; set; }
    }
}
