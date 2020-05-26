using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites.Models;
using System.Linq;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var hour = DateTime.Now.Hour;

            var msg = "Good Morning";

            if (hour >= 18 )
            {
                msg = "Good Evening";
            }
            else
            {
                msg = "Good Afternoon";
            }

            ViewBag.Greeting = msg;
            

            return View("MyView");

        }

        #region RsvpForm
        
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        /// <summary>
        /// Overloaded method for the POST request
        /// </summary>
        /// <param name="guestResponse"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (!ModelState.IsValid) return View();
            

            Repository.AddResponse(guestResponse);
            return View("Thanks",guestResponse);
        } 
        
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
        #endregion
    }
}
