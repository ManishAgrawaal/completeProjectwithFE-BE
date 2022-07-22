using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketServices.Models;

namespace TicketServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public TicketController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<BookingTb> ShowData()
        {
            return db.BookingTbs;
        }
       // [HttpGet("{Pnr}", Name = "GetDetailsByPnr")]
       [HttpGet]
       [Route("GetByPnr")]
        public IActionResult GetByEmail(string Pnr)
        {
            var data = db.BookingTbs.SingleOrDefault(x => x.Pnr == Pnr);
            if (data == null)
            {
                return Ok("Record not found !");
            }
            return Ok(data);

        }
    }
}
