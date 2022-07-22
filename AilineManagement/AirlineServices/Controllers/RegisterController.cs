using AirlineServices.Models;
using AirlineServices.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public RegisterController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("GetAirline")]
        public async Task <IEnumerable<AirlineRegTb>> ShowData()
        {
            return await db.AirlineRegTbs.ToListAsync();
        }
        [HttpPost]
        [Route("AddAirline")]
        public async Task<int> PostData(RegisterViewModel registerViewModel)

        {
            AirlineRegTb airlineRegTb = new AirlineRegTb();
            airlineRegTb.AirlineName = registerViewModel.AirlineName;
            airlineRegTb.Logo = registerViewModel.Logo;
            airlineRegTb.Cnum = registerViewModel.Cnum;
            airlineRegTb.Caddress = registerViewModel.Caddress;
            airlineRegTb.IsActive = registerViewModel.IsActive;
            db.AirlineRegTbs.Add(airlineRegTb);
            return await db.SaveChangesAsync();
            //return Ok("New Record Registered successfully !");
        }

        [HttpDelete]
        public IActionResult deleteById(int Id)

        {
            if (db.AirlineRegTbs.Any(x => x.Id == Id))
            {
                var data = db.AirlineRegTbs.Where(x => x.Id == Id).FirstOrDefault();
                db.AirlineRegTbs.Remove(data);
                db.SaveChanges();
                return Ok("Your coupen has been Successfully.");
            }

            return BadRequest("Record not found.");
        }

    }
}
