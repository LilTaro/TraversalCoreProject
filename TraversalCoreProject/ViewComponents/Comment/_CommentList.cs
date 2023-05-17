using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.Comment
{
	public class _CommentList:ViewComponent
    {
        private readonly ICommentService _commentService;
        Context context = new Context();
        public _CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentcount = context.Comments.Where(X => X.DestinationID == id).Count();
            var values = _commentService.GetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
