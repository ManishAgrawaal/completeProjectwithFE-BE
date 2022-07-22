using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace TicketServices.Models
{
    public partial class ScheduledDaysTb
    {
        public ScheduledDaysTb()
        {
            InventoryTbs = new HashSet<InventoryTb>();
        }

        public int Id { get; set; }
        public string Days { get; set; }
        public string IsActive { get; set; }
        [JsonIgnore]
        public virtual ICollection<InventoryTb> InventoryTbs { get; set; }
    }
}
