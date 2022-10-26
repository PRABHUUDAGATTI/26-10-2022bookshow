using Book_Show_BLL.Services;
using Book_Show_Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserServices _UserServices;
        public UserController(UserServices userServices)
        {
            _UserServices = userServices;
        }
        [HttpGet("GetUser")]
        public IEnumerable<UserDetails> GetUserDetails()
        {
            return _UserServices.GetAll();
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] UserDetails User)
        {
            _UserServices.AddUserDetails(User);
            return Ok("User added succesfully");
        }
        [HttpDelete("DeletdUser")]
        public IActionResult DeleteMovies(int movieId)
        {
            _UserServices.DeleteUserDetails(movieId);
            return Ok("User Delete Succesfully");
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserDetails User)
        {
            _UserServices.UpdateUserDetails(User);
            return Ok("User Upadted Succesfully");
        }
        [HttpGet("GetUserById")]
        public UserDetails GetUserById(int movieId)
        {
            return _UserServices.GeUserDetailsById(movieId);
        }
        [HttpPost("UserLogin")]
        public int UserLogin(UserDetails userDetails)
        {
            int flag = _UserServices.UserLogin(userDetails);
            if (flag != 0)
            {
                return flag;
            }
            return flag;
          /*  if (flag != 0)
            {
                return Ok(flag);
            }
            return BadRequest(flag);*/
            
        }
       
    }
}
