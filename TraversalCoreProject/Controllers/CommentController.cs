using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProject.Controllers
{
	public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment) 
        {
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.Status = true;
            _commentService.Add(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
