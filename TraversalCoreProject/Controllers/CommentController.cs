using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentDal _commentDal;

        public CommentController(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment) 
        {
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.Status = true;
            _commentDal.Insert(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
