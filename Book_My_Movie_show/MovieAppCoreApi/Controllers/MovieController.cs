using Book_Show_BLL.Services;
using Book_Show_Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieServices _movieServiece;
        public MovieController(MovieServices movieServices)
        {
            _movieServiece = movieServices;
        }
        [HttpGet("GetMovies")]
        public IEnumerable<Movie> GetMovies()
        {
            return _movieServiece.GetAll();
        }
        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromBody]Movie movie)
        {
            _movieServiece.AddMovie(movie);
            return Ok("Movie created succesfully");
        }
        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovies(int movieId)
        {
            _movieServiece.DeleteMovie(movieId);
            return Ok("Movie Deleted Succesfully");
        }
        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovies([FromBody] Movie movie)
        {
            _movieServiece.UpdateMovie(movie);
            return Ok("MovieUpadtedSuccesfully");   
        
        }
        [HttpGet("GetMovieById")]
        public Movie GetMovieById(int MovieId)
        {
            return _movieServiece.GeMovieById(MovieId);
        }
    }
}
