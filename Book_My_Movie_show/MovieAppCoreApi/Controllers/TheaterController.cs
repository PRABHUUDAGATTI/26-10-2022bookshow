using Book_Show_BLL.Services;
using Book_Show_Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private TheaterServices _theaterServices;
        public TheaterController(TheaterServices theaterServices)
        {
            _theaterServices = theaterServices;
        }
        [HttpGet("GetTheater")]
        public IEnumerable<Theater> GetTheater()
        {
            return _theaterServices.GetAll();
        }
        [HttpPost("AddTheater")]
        public IActionResult AddTheater([FromBody] Theater theater)
        {
            _theaterServices.AddTheater(theater);
            return Ok("Theater added succesfully");
        }
        [HttpDelete("DeleteTheater")]
        public IActionResult DeleteMovies(int movieId)
        {
            _theaterServices.DeleteTheater(movieId);
            return Ok("Theater Delete Succesfully");
        }
        [HttpPut("UpdateTheater")]
        public IActionResult UpdateTheater([FromBody] Theater theater)
        {
            _theaterServices.UpdateTheater(theater);
            return Ok("MovieUpadtedSuccesfully");
        }
        [HttpGet("GetTheaterById")]
        public Theater GetMovieById(int MovieId)
        {
            return _theaterServices.GeTheaterById(MovieId);
        }
    }
}

