using Book_Show_BLL.Services;
using Book_Show_Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimingController : ControllerBase
    {
        private ShowTimingServices _ShowTimingServices;
        public ShowTimingController(ShowTimingServices showTimingServices)
        {
            _ShowTimingServices = showTimingServices;
        }
        [HttpGet("GetShowTiming")]
        public IEnumerable<ShowTiming> GetShowTiming()
        {
            return _ShowTimingServices.GetAll();
        }
        [HttpPost("AddShowTiming")]
        public IActionResult AddShowTiming([FromBody] ShowTiming showTiming)
        {
            _ShowTimingServices.AddShowTiming(showTiming);
            return Ok("ShowTiming added succesfully");
        }
        [HttpDelete("DeleteShowTiming")]
        public IActionResult DeleteShowTiming(int movieId)
        {
            _ShowTimingServices.DeleteShowTiming(movieId);
            return Ok("ShowTiming Delete Succesfully");
        }
        [HttpPut("UpdateShowTiming")]
        public IActionResult UpdateShowTiming([FromBody] ShowTiming ShowTiming)
        {
            _ShowTimingServices.UpdateShowTiming(ShowTiming);
            return Ok("ShowTimingUpadtedSuccesfully");
        }
        [HttpGet("GetShowTimingById")]
        public ShowTiming GetMovieById(int MovieId)
        {
            return _ShowTimingServices.GeShowTimingById(MovieId);
        }
        [HttpGet("GetLastone")]
        public ShowTiming GetLastone()
        {
            return _ShowTimingServices.GetLatone();
        }
    }
}
