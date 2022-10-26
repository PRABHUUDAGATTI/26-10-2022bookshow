using Book_Show_BLL.Services;
using Book_Show_Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShowController : ControllerBase
    {
        private BookShowServices _BookShowServices;
        public BookShowController(BookShowServices bookShowServices)
        {
            _BookShowServices= bookShowServices;
        }
        [HttpGet("GetALLBookShow")]
        public IEnumerable<BookShow> GetAllBookShow()
        {
            return _BookShowServices.GetAll();
        }
        [HttpPost("AddBookShow")]
        public IActionResult AddBookShow(BookShow bookShow)
        {
            _BookShowServices.AddBookShow(bookShow);
            return Ok("The Show Booked");
        }
        [HttpPut("UpdateBookShow")]
        public IActionResult UpdateBookShow(BookShow bookShow)
        {
            _BookShowServices.UpdateBookShow(bookShow);
            return Ok("The Book Show Updated");
        }
        [HttpDelete("DeleteBookShow")]
        public IActionResult DeleteBookShow(int BookId)
        {
            _BookShowServices.DeleteBookShow(BookId);
            return Ok("The Book Show Deleted");
        }
        [HttpGet("GetBookShowById")]
        public BookShow GetMovieById(int MovieId)
        {
            return _BookShowServices.GeBookShowById(MovieId);
        }
    }
}
