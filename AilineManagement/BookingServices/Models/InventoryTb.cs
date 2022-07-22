using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BookingServices.Models
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
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int? ScheduleId { get; set; }
        public int? InstrumentId { get; set; }
        public string BusinessCseat { get; set; }
        public string NonBcseat { get; set; }
        public decimal? Price { get; set; }
        public int? NumOfRows { get; set; }
        public int? MealId { get; set; }
        public string IsActive { get; set; }
        [JsonIgnore]
        public virtual AirlineRegTb Airline { get; set; }
        [JsonIgnore]
        public virtual InstrumentTb Instrument { get; set; }
        [JsonIgnore]
        public virtual MealPlanTb Meal { get; set; }
        [JsonIgnore]
        public virtual ScheduledDaysTb Schedule { get; set; }
        [JsonIgnore]
        public virtual ICollection<BookingTb> BookingTbs { get; set; }
    }
}
