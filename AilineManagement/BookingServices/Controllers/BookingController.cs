using BookingServices.Models;
using BookingServices.ViewModel;
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
    public class BookingController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public BookingController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("getdata")]
        public IEnumerable<BookingTb> getdata()
        {
            return db.BookingTbs;
        }
        [HttpPost]
        public IActionResult PostData(BookingViewModel bookingViewModel)

        {

            try
            {
                Random random = new Random();
                int pnr = random.Next();
                string sts = "Booked";
                BookingTb bookingTb = new BookingTb();
                bookingTb.FlightId = bookingViewModel.FlightId;
                bookingTb.Name = bookingViewModel.Name;
                bookingTb.Email = bookingViewModel.Email;
                bookingTb.NumofSeat = bookingViewModel.NumofSeat;
                bookingTb.Pname = bookingViewModel.Pname;
                bookingTb.Pgender = bookingViewModel.Pgender;
                bookingTb.Page = bookingViewModel.Page;
                bookingTb.Meal = bookingViewModel.Meal;
                bookingTb.SeatNo = bookingViewModel.SeatNo;
                bookingTb.Status = sts.ToString();
                bookingTb.BookedDate = DateTime.Now.ToString();
                bookingTb.Pnr = pnr.ToString();
                db.BookingTbs.Add(bookingTb);
                db.SaveChanges();
                return Ok("Your Ticket has been booked succefully ! Your PNR Number is : " + pnr);

            }
            catch
            {
                return Ok("Booking Failed ! Try again with valid details");
            }


            
        }
       // [HttpGet("{Email}", Name = "GetDetailsByEmail")]
        [HttpGet]
        [Route("GetByEmail")]
        public IActionResult GetByEmail(string Email)
        {
            var data = db.BookingTbs.SingleOrDefault(x => x.Email == Email);
            if (data == null)
            {
                return Ok("Record not found !");
            }
            return Ok(data);

        }
    }
}
