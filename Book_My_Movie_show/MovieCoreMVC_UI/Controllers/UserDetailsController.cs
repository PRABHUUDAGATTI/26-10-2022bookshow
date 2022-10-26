using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVC_UI.Controllers
{
    public class UserDetailsController : Controller
    {
        private IConfiguration _configuration;
        public UserDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable < UserDetails > users= null;
            
            using(HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "User/GetUser";
                using(var resonse = await client.GetAsync(endpoint))
                {
                    if(resonse.StatusCode==System.Net.HttpStatusCode.OK){
                        var result=await resonse.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<IEnumerable<UserDetails>>(result);
                    }
                }
            }
            return View(users);
        }
        public IActionResult UserDetailsEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserDetailsEntry(UserDetails userDetails)
        {
            ViewBag.staus = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent Content = new StringContent(JsonConvert.SerializeObject(userDetails), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "User/AddUser";
                using (var response = await client.PostAsync(endpoint, Content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "User Inserted succesfully";
                        
                    }
                    
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Error Happened";

                    }
                }
            }
            /*return RedirectToAction("UserLogin", "UserDetails");*/

            return View();
        }

        //edit User
        public async Task<IActionResult> EditUser(int UserId)
        {
            UserDetails userDetails = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "User/GetUserById?movieId=" + UserId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        userDetails = JsonConvert.DeserializeObject<UserDetails>(result);
                    }

                }
            }
            return View(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserDetails movie)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "User/UpdateUser";
                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "User details saved succesfully";
                    }
                    else
                    {
                        ViewBag.staus = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }




        //Delete User
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            UserDetails userDetails = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "User/GetUserById?movieId=" + UserId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        userDetails = JsonConvert.DeserializeObject<UserDetails>(result);
                    }

                }
            }
            return View(userDetails);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(UserDetails userDetails)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                
                string endpoint = _configuration["WebApiBaseUrl"] + "User/DeletdUser?movieId="+userDetails.UserId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "User details Deleted succesfully";
                    }
                    else
                    {
                        ViewBag.staus = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }




        public async Task<IActionResult> UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserDetails user)
        {
            ViewBag.status = "";

          /*var uemail= TempData["dabbaemail"] = user.UserEmail;
            TempData.Keep();*/

            using (HttpClient client = new HttpClient())
            {
                int userid = 0;
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "User/UserLogin";
                using(var response = await client.PostAsync(endpoint,content))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        userid = JsonConvert.DeserializeObject<int>(result);

                        //creating the temp data
                        /*var UserMantainceid =*/
                            TempData["UserMantainceid"] = userid.ToString();
                        TempData.Keep();


                        return RedirectToAction("Index", "UserView");
                        /* ViewBag.status = "Ok";
                         ViewBag.message = "User Login succesfully";
                         ;
                     }
                     else{
                         ViewBag.status = "Error";
                         ViewBag.message = "Wrong Entries";*/
                    }
                }
                

            }

            return View();
        }
    }
}
