using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleFlightService.Models;
using ScheduleFlightService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleFlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleFlightController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public ScheduleFlightController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<ScheduleTb> ShowData()
        {
            return db.ScheduleTbs;
        }
        [HttpPost]
        public IActionResult PostData(ScheduleViewModel scheduleViewModel)

        {
                ScheduleTb scheduleTb = new ScheduleTb();
                scheduleTb.AirlineId = scheduleViewModel.AirlineId;
                scheduleTb.FlightNum = scheduleViewModel.FlightNum;
                scheduleTb.FromPlace = scheduleViewModel.FromPlace;
                scheduleTb.ToPlace = scheduleViewModel.ToPlace;
                scheduleTb.StartDate = scheduleViewModel.StartDate;
                scheduleTb.StartTime = scheduleViewModel.StartTime;
                scheduleTb.EndDate = scheduleViewModel.EndDate;
                scheduleTb.EndTime = scheduleViewModel.EndTime;
                scheduleTb.SchDays = scheduleViewModel.SchDays;
                scheduleTb.InstrumentType = scheduleViewModel.InstrumentType;
                scheduleTb.BclassSeat = scheduleViewModel.BclassSeat;
                scheduleTb.NbclassSeat = scheduleViewModel.NbclassSeat;
                scheduleTb.Price = scheduleViewModel.Price;
                scheduleTb.Price = scheduleViewModel.Price;
                scheduleTb.NoOfRows = scheduleViewModel.NoOfRows;
                scheduleTb.MealPlan = scheduleViewModel.MealPlan;
                scheduleTb.Status = scheduleViewModel.Status;
                db.ScheduleTbs.Add(scheduleTb);
                db.SaveChanges();
                return Ok("New Record Registered successfully !");
             }

        }

    
}
