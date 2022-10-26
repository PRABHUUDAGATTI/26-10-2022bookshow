using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVC_UI.Controllers
{
    public class BookShowController : Controller
    {
        private IConfiguration _configuration;
        public BookShowController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<BookShow> users = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "BookShow/GetALLBookShow";
                using (var resonse = await client.GetAsync(endpoint))
                {
                    if (resonse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await resonse.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<IEnumerable<BookShow>>(result);
                    }
                }
            }
            return View(users);
        }

        //adding booking
        public async Task<IActionResult> BookShowEntry()
        {

            IEnumerable<ShowTiming> showone = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "ShowTiming/GetShowTiming";
                using (var resonse = await client.GetAsync(endpoint))
                {
                    if (resonse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await resonse.Content.ReadAsStringAsync();
                        showone = JsonConvert.DeserializeObject<IEnumerable<ShowTiming>>(result);
                    }
                }
            }
            BookShow bookshow = new BookShow();
           
            foreach(var show in showone)
            {
                bookshow.ShowTimingId = show.ShowTimingId;
            }
            int a =Convert.ToInt32( TempData["UserMantainceid"]);

            /*dynamic a = TempData["UserMantainceid"];*/
            bookshow.UserId=Convert.ToInt32(a);
            return View(bookshow);
        }
        [HttpPost]
        public async Task<IActionResult> BookShowEntry(BookShow bookShow)
        {
            bookShow.TicketCost = (bookShow.NoOfTickets * 200);
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookShow), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"]+ "BookShow/AddBookShow";
                using (var response = await client.PostAsync(endpoint,content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie details saved succesfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }

            return View();
        }



        //Edit BookShow
        public async Task<IActionResult> EditBookShow(int BookShowId)
        {
            BookShow BookShow = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "BookShow/GetBookShowById?MovieId=" + BookShowId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        BookShow = JsonConvert.DeserializeObject<BookShow>(result);
                    }

                }
            }
            return View(BookShow);
        }

        [HttpPost]
        public async Task<IActionResult> EditBookShow(BookShow BookShow)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(BookShow), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "BookShow/UpdateBookShow";
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
        public async Task<IActionResult> DeleteBookShow(int BookShowId)
        {
            BookShow movie = null;
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "BookShow/GetBookShowById?MovieId=" + BookShowId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<BookShow>(result);
                    }

                }
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBookShow(BookShow BookShow)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "BookShow/DeleteBookShow?BookId=" + BookShow.BookShowId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "BookShow delete succesfully";
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
