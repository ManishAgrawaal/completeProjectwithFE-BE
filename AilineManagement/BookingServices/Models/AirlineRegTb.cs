using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BookingServices.Models
{
    public partial class AirlineRegTb
    {
        public AirlineRegTb()
        {
            InventoryTbs = new HashSet<InventoryTb>();
        }

        public int Id { get; set; }
        public string AirlineName { get; set; }
        public string Logo { get; set; }
        public string Cnum { get; set; }
        public string Caddress { get; set; }
        public string IsActive { get; set; }
        [JsonIgnore]
        public virtual ICollection<InventoryTb> InventoryTbs { get; set; }
    }
}
