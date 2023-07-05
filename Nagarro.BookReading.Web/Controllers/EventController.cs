using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nagarro.BookReading.Web.Interfaces;
using Nagarro.BookReading.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Nagarro.BookReading.Web.Controllers
{
    public class EventController : Controller
    {

        private readonly IEventPageService _eventPageService;
        private readonly ICommentPageService _commentPageService;

        public EventController(IEventPageService eventPageService, ICommentPageService commentPageService)
        {
            this._eventPageService = eventPageService ?? throw new ArgumentNullException(nameof(eventPageService));
            this._commentPageService = commentPageService ?? throw new ArgumentNullException(nameof(commentPageService));
            ;
        }



        public IActionResult Index()
        {
            return View("Index");
        }
        [Route("Events")]
        public async Task<IActionResult> GetEvents()
        {
            var eventList = await _eventPageService.GetEvents();
            return View(eventList);
        }

        [Route("Events/{id}")]
        public async Task<IActionResult> ViewDetails(int? id)
        {
            var details = await _eventPageService.ViewDetails(id.Value);
            var ans = await _eventPageService.GetAllCommentByEventId(id.Value);
            details.Comments = ans;
            if (details == null)
            {
                return RedirectToAction("GetEvents");
            }
            return View(details);
        }

        [Authorize]
        [Route("CreateEvent")]

      
        public IActionResult CreateEvent()
        {
            return View();
        }

       [Authorize]
        [HttpPost]
        [Route("CreateEvent")]

       
        public async Task<ActionResult> CreateEvent(EventViewModel eventViewModel)
        {
            var result = await _eventPageService.CreateEvent(eventViewModel);
            if (result > 0)
            {
                return RedirectToAction(nameof(CreateEvent));
            }
            return View();
        }

        [Authorize]
        [Route("UpadteEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("GetEvents");
            }
            var ans = await _eventPageService.ViewDetails(id.Value); ;

            if (ans == null)
            {
                return RedirectToAction("GetEvents");
            }

            return View(ans);
        }

        [Authorize]
        [HttpPost]
        [Route("UpadteEvent/{id}")]
        public IActionResult UpdateEvent(EventViewModel eventViewModel)
        {
            var _id = _eventPageService.UpdateEvent(eventViewModel);

            if (_id > 0)
            {
                return RedirectToAction("ViewDetails", new { id = _id });
            }
            return View();
        }

        [Authorize]
            
        [Route("MyEvents")]
       
        public async Task<IActionResult> MyEvents()
        {
            var organiser = User.Identity.Name;
            var eventList = await _eventPageService.MyEvents(organiser);
            return View(eventList);
        }

        [Authorize]
        [Route("EventsInvitedTo")]
        public async Task<IActionResult> EventsInvitedTo()
        {
            var eventList = await _eventPageService.GetEvents();
            return View(eventList);
        }

        [Route("FetchComments/{_id}")]
        public async Task<IActionResult> GetAllCommentByEventId(int _id)
        {
            var ans = await _eventPageService.GetAllCommentByEventId(_id);
            if (ans == null)
            {
                return RedirectToAction("ViewDetails", new { id = _id });
            }
            return View(ans);
        }

        [Authorize(Roles ="Admin")]
        
        public IActionResult AllEvent()
        {
            return View();
        }

    }
}
