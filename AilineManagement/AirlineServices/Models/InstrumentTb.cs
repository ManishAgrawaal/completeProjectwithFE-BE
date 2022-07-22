using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineServices.Models
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

        public virtual ICollection<InventoryTb> InventoryTbs { get; set; }
    }
}
