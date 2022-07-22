using System;
using System.Collections.Generic;

#nullable disable

namespace ScheduleFlightService.Models
{
    public partial class ScheduleTb
    {
        public int Id { get; set; }
        public int? AirlineId { get; set; }
        public string FlightNum { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string SchDays { get; set; }
        public string InstrumentType { get; set; }
        public string BclassSeat { get; set; }
        public string NbclassSeat { get; set; }
        public string Price { get; set; }
        public string NoOfRows { get; set; }
        public string MealPlan { get; set; }
        public string Status { get; set; }
    }
}
