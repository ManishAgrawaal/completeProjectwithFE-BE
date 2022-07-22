using System;
using System.Collections.Generic;

#nullable disable

namespace SearchServices.Models
{
    public partial class MealPlanTb
    {
        public MealPlanTb()
        {
            InventoryTbs = new HashSet<InventoryTb>();
        }

        public int Id { get; set; }
        public string MealType { get; set; }
        public string IsActive { get; set; }

        public virtual ICollection<InventoryTb> InventoryTbs { get; set; }
    }
}
