using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineServices.Models
{
    public partial class DiscountTb
    {
        public int Id { get; set; }
        public string CoupenCode { get; set; }
        public string DiscountPrice { get; set; }
        public string StartDate { get; set; }
        public string ExpiryDate { get; set; }
        public string IsActive { get; set; }
    }
}
