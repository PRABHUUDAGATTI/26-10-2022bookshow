using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVC_UI.Controllers
{
    public class LocationController : Controller
    {
        private IConfiguration _configuration;
        
        public LocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Location> users = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Location/GetLocation";
                using (var resonse = await client.GetAsync(endpoint))
                {
                    if (resonse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await resonse.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<IEnumerable<Location>>(result);
                    }
                }
            }
            return View(users);
        }
        public IActionResult LocationEntry()
        {
            return View();    
        }
        [HttpPost]
        public async Task<IActionResult> LocationEntry(Location location)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Location/AddLocation";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location details saved succesfully";
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

        //Edit Location
        public async Task<IActionResult> EditLocation(int LocationId)
        {
            Location location = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Location/GetLocationById?MovieId=" + LocationId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        location = JsonConvert.DeserializeObject<Location>(result);
                    }

                }
            }
            return View(location);
        }

        [HttpPost]
        public async Task<IActionResult> EditLocation(Location location)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Location/UpdateLocation";
                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie details saved succesfully";
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

        //delete movie
        public async Task<IActionResult> DeleteLocation(int LocationId)
        {
            Location movie = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Location/GetLocationById?MovieId=" + LocationId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<Location>(result);
                    }

                }
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLocation(Location location)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Location/DeleteLocation?LocationId=" + location.LocationId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location delete succesfully";
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
    }
}
