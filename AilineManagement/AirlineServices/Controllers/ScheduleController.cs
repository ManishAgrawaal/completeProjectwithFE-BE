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
    public class ScheduleController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public ScheduleController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<ScheduledDaysTb> ShowData()
        {
            return db.ScheduledDaysTbs;
        }
        [HttpPost]
        public IActionResult PostData(ScheduleViewModel scheduleViewModel)

        {
           ScheduledDaysTb scheduledDaysTb = new ScheduledDaysTb();
            scheduledDaysTb.Days = scheduleViewModel.Days;
            scheduledDaysTb.IsActive = scheduleViewModel.IsActive;
            db.ScheduledDaysTbs.Add(scheduledDaysTb);
            db.SaveChanges();
            return Ok("New Record Registered successfully !");
        }
    }
}
