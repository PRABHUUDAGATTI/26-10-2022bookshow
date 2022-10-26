using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVC_UI.Controllers
{
    public class TheaterController : Controller
    {
        private IConfiguration _configuration;
        public TheaterController(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Theater> movieresult = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Theater/GetTheater";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movieresult = JsonConvert.DeserializeObject<IEnumerable<Theater>>(result);
                    }

                }
            }
            return View(movieresult);
        }


        //add Theater Action
        public async Task<IActionResult> TheaterEntryAsync()
        {
            List<Location> locations = new List<Location>();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Location/GetLocation";
                using (var resonse = await client.GetAsync(endpoint))
                {
                    if (resonse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await resonse.Content.ReadAsStringAsync();
                        locations = JsonConvert.DeserializeObject<List<Location>>(result);
                    }
                }
            }
            List<SelectListItem> language = new List<SelectListItem>();
          

            language.Add(new SelectListItem { Value = "select", Text = "select" });
            foreach (var item in locations)
            {
                language.Add(new SelectListItem { Value = item.LocationId.ToString(), Text = item.LocationDesc });
            }

            ViewBag.Locationlist = language;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TheaterEntry(Theater theater)
        {
            ViewBag.staus = "";
            using(HttpClient client=new HttpClient())
            {
                StringContent Content=new StringContent(JsonConvert.SerializeObject(theater),Encoding.UTF8,"application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Theater/AddTheater";
                using(var response=await client.PostAsync(endpoint, Content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theater Inserted succesfully";
                    }
                    else{
                        ViewBag.status = "Error";
                        ViewBag.message = "Error Happened";

                    }
                }
            }

            return View();
        }


        //Edit Theater
        public async Task<IActionResult> EditTheater(int TheaterId)
        {
            Theater theater = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Theater/GetTheaterById?MovieId=" + TheaterId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theater = JsonConvert.DeserializeObject<Theater>(result);
                    }

                }
            }
            return View(theater);
        }

        [HttpPost]
        public async Task<IActionResult> EditTheater(Theater theater)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theater), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Theater/UpdateTheater";
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
        public async Task<IActionResult> DeleteTheater(int TheaterId)
        {
            Theater theater = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Theater/GetTheaterById?MovieId=" + TheaterId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theater = JsonConvert.DeserializeObject<Theater>(result);
                    }

                }
            }
            return View(theater);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTheater(Theater theater)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Theater/DeleteTheater?movieId=" + theater.TheatreId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theater delete succesfully";
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
