using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineServices.Models
{
    public partial class InventoryTb
    {
        public InventoryTb()
        {
            BookingTbs = new HashSet<BookingTb>();
        }

        public int Id { get; set; }
        public string FlightNo { get; set; }
        public int? AirlineId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public int? ScheduleId { get; set; }
        public int? InstrumentId { get; set; }
        public string BusinessCseat { get; set; }
        public string NonBcseat { get; set; }
        public decimal? Price { get; set; }
        public int? NumOfRows { get; set; }
        public int? MealId { get; set; }
        public string IsActive { get; set; }

        public virtual InstrumentTb Instrument { get; set; }
        public virtual MealPlanTb Meal { get; set; }
        public virtual ScheduledDaysTb Schedule { get; set; }
        public virtual ICollection<BookingTb> BookingTbs { get; set; }
    }
}
