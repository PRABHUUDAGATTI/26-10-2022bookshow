using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Location = Book_Show_Entity.Location;

namespace MovieCoreMVC_UI.Controllers
{
    public class UserViewController : Controller
    {
        private IConfiguration _configuration;
        public UserViewController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> movieresult = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Movie/GetMovies";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK) 
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movieresult = JsonConvert.DeserializeObject<IEnumerable<Movie>>(result);
                    }

                }
            }
            return View(movieresult);
        }



        //Show timings user
        public async Task<IActionResult> ShowTimingEntryUser(int MovieId)
        {
            ShowTiming show=new ShowTiming();
            

            //Movie Name Priniting
            Movie movie = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Movie/GetMovieById?MovieId=" + MovieId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<Movie>(result);
                    }

                }
            }
            show.MovieId = movie.MovieId;
            
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

            return View(show);
        }


        
        public IActionResult SelectTheater(ShowTiming show,int LocationId)
        {
            show.Theater.Location.LocationId = LocationId;
            return View(show);
        }



        //for selecting theater

        [HttpPost]

        public async Task<IActionResult> SelectTheater(ShowTiming show)
        {
            /*show.Theater.Location.LocationId= LocationId;*/
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

            List<SelectListItem> Theater = new List<SelectListItem>();


            Theater.Add(new SelectListItem { Value = "select", Text = "select" });
            foreach (var item in movieresult)
            {
                Theater.Add(new SelectListItem { Value = item.LocationId.ToString(), Text = item.Name});
            }
            ViewBag.Theaterlist = Theater;

            //list of showtiming
            List<ShowTiming> users = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "ShowTiming/GetShowTiming";
                using (var resonse = await client.GetAsync(endpoint))
                {
                    if (resonse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await resonse.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<List<ShowTiming>>(result);
                    }
                }
            }

            List<SelectListItem> Showtimings = new List<SelectListItem>();


            Showtimings.Add(new SelectListItem { Value = "select", Text = "select" });
            foreach (var item in users)
            {
                Showtimings.Add(new SelectListItem { Value = item.ShowTime.ToString(), Text = item.ShowTime.ToString() });
            }

            ViewBag.ShowTimeList = Showtimings;
            return View(show);
        }

        //Creating show timings 


        [HttpPost]
        public async Task<IActionResult> ShowTimingEntryUser(ShowTiming show)
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
                        return RedirectToAction("BookShowEntry", "BookShow");
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


        //UserProfile

        public async Task<IActionResult> UserProfile()
        {
            int userProfileId = Convert.ToInt32(TempData["UserMantainceid"]);
            UserDetails userDetails = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "User/GetUserById?movieId=" + userProfileId;
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

        //my bookings
        
        public async Task<IActionResult> MyBookings()
        {
            return View();
        }

            //pick the last data
            /*  public async Task<IActionResult> GetLastShow()
              {
                  ShowTiming showone = null;

                  using (HttpClient client = new HttpClient())
                  {
                      string endpoint = _configuration["WebApiBaseUrl"] + "ShowTiming/GetShowTiming";
                      using (var resonse = await client.GetAsync(endpoint))
                      {
                          if (resonse.StatusCode == System.Net.HttpStatusCode.OK)
                          {
                              var result = await resonse.Content.ReadAsStringAsync();
                              showone = JsonConvert.DeserializeObject<ShowTiming>(result);
                          }
                      }
                  }
                  return View(showone);
              }*/

        }
    }
