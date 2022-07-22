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
    public class InventoryController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public InventoryController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<InventoryTb> ShowData()
        {
            return db.InventoryTbs;
        }
        [HttpPost]
        public IActionResult PostData(InventoryViewModel InventoryViewModel)

        {
            try
            {
                InventoryTb inventoryTb = new InventoryTb();
                inventoryTb.FlightNo = InventoryViewModel.FlightNo;
                inventoryTb.AirlineId = InventoryViewModel.AirlineId;
                inventoryTb.FromPlace = InventoryViewModel.FromPlace;
                inventoryTb.ToPlace = InventoryViewModel.ToPlace;
                inventoryTb.StartDate = InventoryViewModel.StartDate;
                inventoryTb.StartTime = InventoryViewModel.StartTime;
                inventoryTb.EndDate = InventoryViewModel.EndDate;
                inventoryTb.EndTime = InventoryViewModel.EndTime;
                inventoryTb.ScheduleId = InventoryViewModel.ScheduleId;
                inventoryTb.InstrumentId = InventoryViewModel.InstrumentId;
                inventoryTb.BusinessCseat = InventoryViewModel.BusinessCseat;
                inventoryTb.NonBcseat = InventoryViewModel.NonBcseat;
                inventoryTb.Price = InventoryViewModel.Price;
                inventoryTb.NumOfRows = InventoryViewModel.NumOfRows;
                inventoryTb.MealId = InventoryViewModel.MealId;
                inventoryTb.IsActive = InventoryViewModel.IsActive;
                db.InventoryTbs.Add(inventoryTb);
                db.SaveChanges();
                return Ok("New Record Registered successfully !");
            }
            catch(Exception e)
            {
                return Ok("inserted failed!");
            }
        }
    }
}
