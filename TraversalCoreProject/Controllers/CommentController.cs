using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
