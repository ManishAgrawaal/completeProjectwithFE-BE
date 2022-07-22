using System;
using System.Collections.Generic;

#nullable disable

namespace LoginService.Models
{
    public partial class BookingTb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? NumofSeat { get; set; }
        public string Pname { get; set; }
        public string Pgender { get; set; }
        public int? Page { get; set; }
        public string Meal { get; set; }
        public string SeatNo { get; set; }
        public string Pnr { get; set; }
        public string Status { get; set; }
        public string BookedDate { get; set; }
        public int? FlightId { get; set; }

        public virtual InventoryTb Flight { get; set; }
    }
}
