using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Nagarro.BookReading.Web.Interfaces;
using Nagarro.BookReading.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventPageService _eventPageService;
       
        public HomeController(IEventPageService eventPageService)
        {
            this._eventPageService = eventPageService;
        }


        [Route("")]
        public async Task<IActionResult> Index()
        {
            var eventList = await _eventPageService.GetEvents();
            return View(eventList);
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }


        public IActionResult Customer()
        {
            return View("Customer");
        }


        public IActionResult About()
        {
            return View("About");
        }






    }
}
