using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;

namespace MovieCoreMVC_UI.Controllers
{
    public class AdminLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Index(Admin admin)
        {
            if(admin.AdminEmail=="prabhu@gmail.com" && admin.AdminPassword == "prabhu")
            {
                
                    ViewBag.status = "Ok";
                    ViewBag.message = "User Inserted succesfully";
                     return RedirectToAction("Index", "Home");

            }

                else
                {
                    ViewBag.status = "Error";
                    ViewBag.message = "Error Happened";

                }
            return View();
            }
        }
    }

