using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BookingServices.Models
{
    public partial class InstrumentTb
    {
        public InstrumentTb()
        {
            InventoryTbs = new HashSet<InventoryTb>();
        }

        public int Id { get; set; }
        public string InstrumentName { get; set; }
        public string IsActive { get; set; }
        [JsonIgnore]
        public virtual ICollection<InventoryTb> InventoryTbs { get; set; }
    }
}
