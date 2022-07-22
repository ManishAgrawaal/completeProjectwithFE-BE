using BookingServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelBookingController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public CancelBookingController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        
        [HttpDelete("{Pnr}",Name ="CancelledbookingByPnr")]
        public IActionResult cancelByPnr(string Pnr)

        {
            if (db.BookingTbs.Any(x => x.Pnr == Pnr))
            {
                var data = db.BookingTbs.Where(x => x.Pnr == Pnr).FirstOrDefault();
                db.BookingTbs.Remove(data);
                db.SaveChanges();
                return Ok("Your booking has been canceled Successfully.");
            }

            return BadRequest("Record not found.");
        }


    }
}
