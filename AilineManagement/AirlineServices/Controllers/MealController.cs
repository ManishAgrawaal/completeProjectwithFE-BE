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
    public class MealController : ControllerBase
    {
        FLIGHTDATABASEContext db;
        public MealController(FLIGHTDATABASEContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<MealPlanTb> ShowData()
        {
            return db.MealPlanTbs;
        }
        [HttpPost]
        public IActionResult PostData(MealViewModel mealViewModel)

        {
            MealPlanTb mealPlanTb = new MealPlanTb();
            mealPlanTb.MealType= mealViewModel.MealType;
            mealPlanTb.IsActive = mealViewModel.IsActive;
            db.MealPlanTbs.Add(mealPlanTb);
            db.SaveChanges();
            return Ok("New Record Registered successfully !");
        }
    }
}
