using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController:Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
           return Ok(CitiesDataStore.Current.Cities);

        }

        [HttpGet("{Id}")]
        public IActionResult GetCities(int Id)
        {
            var sity= new JsonResult(CitiesDataStore.Current.Cities.Where(x=>x.Id==Id).FirstOrDefault());
            if (sity == null)
            { return NotFound(); }
            return Ok(sity);
        }
    }
}
