using AirlineServices.Models;
using AirlineServices.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public DiscountController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<DiscountTb> ShowData()
        {
            return db.DiscountTbs;
        }
        [HttpPost]
        public IActionResult PostData(DiscountViewModel discountViewModel)

        {
            DiscountTb discountTb = new DiscountTb();
            discountTb.Id = discountViewModel.Id;
            discountTb.CoupenCode = discountViewModel.CoupenCode;
            discountTb.DiscountPrice = discountViewModel.DiscountPrice;
            discountTb.StartDate = discountViewModel.StartDate;
            discountTb.ExpiryDate = discountViewModel.ExpiryDate;
            discountTb.IsActive = discountViewModel.IsActive;
            db.DiscountTbs.Add(discountTb);
            db.SaveChanges();
            return Ok("New Record Registered successfully !");
        }

        [HttpDelete]
        public IActionResult deleteById(int Id)

        {
            if (db.DiscountTbs.Any(x => x.Id == Id))
            {
                var data = db.DiscountTbs.Where(x => x.Id == Id).FirstOrDefault();
                db.DiscountTbs.Remove(data);
                db.SaveChanges();
                return Ok("Your coupen has been Successfully.");
            }

            return BadRequest("Record not found.");
        }

        [HttpPut]
        public IActionResult updateData(DiscountViewModel discountViewModel)
        {
            if (db.DiscountTbs.Any(x => x.Id == discountViewModel.Id))
            {
                var data = db.DiscountTbs.Where(x => x.Id == discountViewModel.Id).FirstOrDefault();
                data.CoupenCode = discountViewModel.CoupenCode;
                data.DiscountPrice = discountViewModel.DiscountPrice;
                data.StartDate = discountViewModel.StartDate;
                data.ExpiryDate = discountViewModel.ExpiryDate;
                data.IsActive = discountViewModel.IsActive;
                db.DiscountTbs.Update(data);
                db.SaveChanges();
                return Ok("Record have been successfully updated.");

            }
            return BadRequest("Record not found");
        }
    }
}
