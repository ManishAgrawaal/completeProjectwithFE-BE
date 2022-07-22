using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineServices.ViewModel
{
    public class DiscountViewModel
    {
        public int Id { get; set; }
        public string CoupenCode { get; set; }
        public string DiscountPrice { get; set; }
        public string StartDate { get; set; }
        public string ExpiryDate { get; set; }
        public string IsActive { get; set; }
    }
}
