using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVC_UI.Controllers
{
    public class ShowTimingController : Controller
    {
        private IConfiguration _configuration;
        public ShowTimingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ShowTiming> users = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "ShowTiming/GetShowTiming";
                using (var resonse = await client.GetAsync(endpoint))
                {
                    if (resonse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await resonse.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<IEnumerable<ShowTiming>>(result);
                    }
                }
            }
            return View(users);
        }
        public async Task<IActionResult> ShowTimingEntry(int movieId)
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
            List<SelectListItem> language = new List<SelectListItem>();
            /*{
                *//* foreach (var item in movieresult)
                  {
                      new SelectListItem { Value = item.Location.LocationDesc, Text = item.Name },
                  }*//*
                new SelectListItem{Value="Select",Text="select"},
                new SelectListItem{Value="Tamil",Text="Tamil"},
                new SelectListItem{Value="English",Text="English"},
                new SelectListItem{Value="Kannada",Text="Kannada"},
            };*/

            language.Add(new SelectListItem { Value = "select", Text = "select" });
                  foreach (var item in movieresult)
            {
                language.Add(new SelectListItem { Value= item.TheatreId.ToString(), Text = item.Name+" "+item.Location.LocationDesc });
            }
        
        ViewBag.Theaterlist = language;
            /*   Movie movie = null;
               using (HttpClient client = new HttpClient())
               {

                   string endpoint = _configuration["WebApiBaseUrl"] + "Movie/GetMovieById?MovieId=" + movieId;
                   using (var response = await client.GetAsync(endpoint))
                   {
                       if (response.StatusCode == System.Net.HttpStatusCode.OK)
                       {
                           var result = await response.Content.ReadAsStringAsync();
                           movie = JsonConvert.DeserializeObject<Movie>(result);
                       }

                   }

               }*/
            ShowTiming showTiming = new ShowTiming();
            showTiming.MovieId=movieId;
            return View(showTiming);
        }
        [HttpPost]
        public async Task<IActionResult> ShowTimingEntry(ShowTiming show)
        {
            ViewBag.staus = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent Content = new StringContent(JsonConvert.SerializeObject(show), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "ShowTiming/AddShowTiming";
                using (var response = await client.PostAsync(endpoint, Content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ShowTiming Inserted succesfully";
                        /*return RedirectToAction("BookShowEntry", "BookShow");*/
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Error Happened";

                    }
                }
            }

            return View();
        }




        //Edit ShowTiming
        public async Task<IActionResult> EditShowTiming(int ShowTimingId)
        {
            ShowTiming showTiming = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "ShowTiming/GetShowTimingById?MovieId=" + ShowTimingId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTiming = JsonConvert.DeserializeObject<ShowTiming>(result);
                    }

                }
            }
            return View(showTiming);
        }

        [HttpPost]
        public async Task<IActionResult> EditShowTiming(ShowTiming showTiming)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(showTiming), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "ShowTiming/UpdateShowTiming";
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
        public async Task<IActionResult> DeleteShowTiming(int ShowTimingId)
        {
            ShowTiming showTiming = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "ShowTiming/GetShowTimingById?MovieId=" + ShowTimingId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTiming = JsonConvert.DeserializeObject<ShowTiming>(result);
                    }

                }
            }
            return View(showTiming);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShowTiming(ShowTiming showTiming)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "ShowTiming/DeleteShowTiming?movieId=" + showTiming.ShowTimingId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ShowTiming delete succesfully";
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
