using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookingServices.ViewModel
{
    public class BookingViewModel
    {
        public int? FlightId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? NumofSeat { get; set; }
        public string Pname { get; set; }
        public string Pgender { get; set; }
        public int? Page { get; set; }
        public string Meal { get; set; }
        public string SeatNo { get; set; }
       

    }
}
