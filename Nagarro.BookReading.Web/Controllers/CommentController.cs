using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nagarro.BookReading.Web.Interfaces;
using Nagarro.BookReading.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentPageService _commentPageService;

        public CommentController(ICommentPageService commentPageService)
        {
            this._commentPageService = commentPageService;
        }

        // GET: CommentController
        public ActionResult Index()
        {
            return View("Index");
        }

        public async Task<ActionResult> GetComments()
        {
            var commentList = await _commentPageService.GetComments();
            return View(commentList);
        }

        public async Task<ActionResult> ViewComment(int id)
        {
            var comment = await _commentPageService.ViewComment(id);
            if(comment == null)
            {
                return RedirectToAction("GetComments");
            }
            return View(comment);
        }

    
        [HttpPost]
        public async Task<IActionResult> PostComment(CommentViewModel commentViewModel)
        {
            var result = await _commentPageService.PostComment(commentViewModel);
            return RedirectToAction("ViewDetails","Event", new { id = commentViewModel.EventId });
        }

        //GET: CommentController/Edit/5
        public async Task<ActionResult> EditComment(int id)
        {
            var ans = await _commentPageService.ViewComment(id); ;
            if (ans == null)
            {
                return RedirectToAction("GetComments");
            }

            return View(ans);
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        public ActionResult EditComment(CommentViewModel commentViewModel)
        {
            var _id = _commentPageService.EditComment(commentViewModel);
            if (_id > 0)
            {
                return RedirectToAction("ViewComment", new { id = _id });
            }
            return View();
        }

        
    }
}
