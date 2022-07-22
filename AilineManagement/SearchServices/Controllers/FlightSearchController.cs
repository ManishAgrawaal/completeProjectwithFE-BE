using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchServices.Models;
using SearchServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightSearchController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public FlightSearchController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IEnumerable<ScheduleTb> ShowData()
        {
            return db.ScheduleTbs;
        }
        [HttpPost]
        public IActionResult SearchFlight(FlightViewModel flightViewModel)
        {
            if (db.ScheduleTbs.Any(x => x.FromPlace == flightViewModel.FromPlace && x.ToPlace == flightViewModel.ToPlace && x.StartDate==flightViewModel.StartDate))
            {
                var data = db.ScheduleTbs.Where(x => x.FromPlace == flightViewModel.FromPlace && x.ToPlace == flightViewModel.ToPlace && x.StartDate == flightViewModel.StartDate).FirstOrDefault();
                return Ok(data);

            }
            return BadRequest("Record not found");
        }


        [HttpGet]
        [Route("GetDetails")]
        public IActionResult SearchFlightData(string FromPlace, string ToPlace, string StartDate)
        {
            if (db.ScheduleTbs.Any(x => x.FromPlace == FromPlace && x.ToPlace == ToPlace && x.StartDate == StartDate))
            {
                var data = db.ScheduleTbs.Where(x => x.FromPlace == FromPlace && x.ToPlace == ToPlace && x.StartDate == StartDate).FirstOrDefault();
                return Ok(data);

            }
            return BadRequest("Record not found");
        }



    }
}
