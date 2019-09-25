using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Domain.Commands.Comment;
using Okapia.Models;

namespace Okapia.Controllers
{
    public class PageViewController : Controller
    {
        private readonly IPageApplication _pageApplication;
        private readonly ICommentApplication _commentApplication;
        private readonly IPageCategoryApplication _pageCategoryApplication;
        private readonly ICookieHelper _cookieHelper;

        public PageViewController(IPageApplication pageApplication, IPageCategoryApplication pageCategoryApplication,
            ICommentApplication commentApplication, ICookieHelper cookieHelper)
        {
            _pageApplication = pageApplication;
            _pageCategoryApplication = pageCategoryApplication;
            _commentApplication = commentApplication;
            _cookieHelper = cookieHelper;
        }

        public ActionResult Index(string id)
        {
            var pageCategory = _pageCategoryApplication.GetPageCategoryForBlog(id);
            ViewData["province"] = _cookieHelper.Get("province");
            return View(pageCategory);
        }

        public ActionResult Details(string id)
        {
            var pageDetails = _pageApplication.GetPageDetailsForView(id);
            var index = new PageDetailsIndexViewModel
            {
                AddComment = new AddComment(),
                PageViewDetailsViewModel = pageDetails
            };
            ViewData["province"] = _cookieHelper.Get("province");
            return View(index);
        }


        public ActionResult AddComment(AddComment command)
        {
            command.CommentOwner = "Page";
            var result = _commentApplication.Create(command);
            if (result.Success)
                return RedirectToAction("Details", new {id = command.CommentOwnerRecordId});
            ViewData["errorMessage"] = result.Message;
            return RedirectToAction("Details", new {id = command.CommentOwnerRecordId});
        }
    }
}