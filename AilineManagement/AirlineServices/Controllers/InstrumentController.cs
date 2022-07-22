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
    public class InstrumentController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public InstrumentController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("ShowData")]
        public IEnumerable<InstrumentTb> ShowData()
        {
            return db.InstrumentTbs;
        }
        [HttpPost]
        public IActionResult PostData(InstrumentViewModel instrumentViewModel)

        {
            InstrumentTb instrumentTb = new InstrumentTb();
            instrumentTb.InstrumentName = instrumentViewModel.InstrumentName;
            instrumentTb.IsActive = instrumentViewModel.IsActive;
          
            db.InstrumentTbs.Add(instrumentTb);
            db.SaveChanges();
            return Ok("New Record Registered successfully !");
        }
    }
}
