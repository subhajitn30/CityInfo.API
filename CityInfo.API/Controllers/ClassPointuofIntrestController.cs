using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using CityInfo.API.Services;
using CityInfo.API.Enities;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class ClassPointuofIntrestController : Controller
    {
        private ILogger<ClassPointuofIntrestController> _logger;
        private IMailServices _localmailservice;
        private CityInfoContext _cityInfoContext;
        public ClassPointuofIntrestController(ILogger<ClassPointuofIntrestController> logger,IMailServices localMailService, CityInfoContext cityInfoContext)
        {
            _logger = logger;
            _localmailservice = localMailService;
            _cityInfoContext = cityInfoContext;
        }


        [HttpGet("{CityId}/pointofintrest")]
        public IActionResult GetPointofIntrest(int Cityid)
        {
            try
            {
                 _localmailservice.Send("","");
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == Cityid);
                if (city == null)
                {
                    _logger.LogInformation($"City with id {Cityid} wsnt found");
                    return NotFound();
                }

                else { return Ok(city.PointofIntest); }
            }
            catch (Exception ex)
            {

                _logger.LogInformation($"City with id {Cityid} wsnt found because", ex);
                return StatusCode(500, "A problem has occured");
            }

            
        }
        [HttpGet("{CityId}/pointofintrest/{id}",Name = "GetPointOfIntrest")]
        public IActionResult GetPointofIntrest(int CityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == CityId);
            if (city == null)
            {
                return NotFound();
            }

            var poi = city.PointofIntest.FirstOrDefault(p => p.Id == id);
            if (poi == null)
            {
                return NotFound();
            }

            return Ok(poi);

        }
        [HttpPost("{cityid}/pointofintrest")]
        public IActionResult CreatePointofIntrest(int CityId,[FromBody] PointofIntrestforCreationDto pointofIntrestforCreation)
        {
            if (pointofIntrestforCreation == null)
            {
                return BadRequest();
            }
            var city= CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == CityId);
            if (city == null)
            {
                return NotFound();
            }
            var maxpointofIntrestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointofIntest).Max(p => p.Id);
            PointOfIntrestDto pointOfIntrestDto = new PointOfIntrestDto()
            {
                Id= maxpointofIntrestId++,
                Name=pointofIntrestforCreation.Name,
                Description=pointofIntrestforCreation.Description
            };
            city.PointofIntest.Add(pointOfIntrestDto);
            return CreatedAtRoute("GetPointOfIntrest", new
            { CityId = CityId, id = pointOfIntrestDto.Id }, pointOfIntrestDto);

        }
        [HttpPatch("{cityId}/pointofintrest/{id}")]
        public IActionResult PartiallyUpdate(int cityid,int id, [FromBody] JsonPatchDocument<PointofIntrestforCreationDto> jsonPatchDocument)
        {
            if (jsonPatchDocument == null)
            {
                return BadRequest();
            }
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityid);
            if (city == null)
            {
                return NotFound();
            }

            var pointofintrest = city.PointofIntest.FirstOrDefault(c => c.Id == id);
            if (pointofintrest == null)
            {
                return NotFound();
            }
            var pointOfIntrestPatch = new PointofIntrestforCreationDto()
            {
                
                Name = pointofintrest.Name,
                Description = pointofintrest.Description
            };
            jsonPatchDocument.ApplyTo(pointOfIntrestPatch,ModelState);
            pointofintrest.Name = pointOfIntrestPatch.Name;
            pointofintrest.Description = pointOfIntrestPatch.Description;
            return NoContent();

        }
    }
}
