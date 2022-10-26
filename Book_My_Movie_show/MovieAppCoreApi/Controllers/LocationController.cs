using Book_Show_BLL.Services;
using Book_Show_Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private LocationServices _LocationServices;
        public LocationController(LocationServices locationServices)
        {
            _LocationServices = locationServices;
        }
        [HttpGet("GetLocation")]
        public IEnumerable<Location> GetLocation()
        {
            return _LocationServices.GetAll();
        }
        [HttpPost("AddLocation")]
        public IActionResult AddLocation([FromBody] Location location)
        {
            _LocationServices.AddLocation(location);
            return Ok("Location added succesfully");
        }
        [HttpDelete("DeleteLocation")]
        public IActionResult DeleteMovies(int LocationId)
        {
            _LocationServices.DeleteLocation(LocationId);
            return Ok("Location Delete Succesfully");
        }
        [HttpPut("UpdateLocation")]
        public IActionResult UpdateMovies([FromBody] Location location)
        {
            _LocationServices.UpdateLocation(location);
            return Ok("Location Upadted Succesfully");
        }
        [HttpGet("GetLocationById")]
        public Location GetMovieById(int MovieId)
        {
            return _LocationServices.GeLocationById(MovieId);
        }
    }
}
