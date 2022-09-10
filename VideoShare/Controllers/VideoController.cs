using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoShare.Entities;
using VideoShare.ViewModels;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using VideoShare.Service;

namespace VideoShare.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult VideoList()
        {
            var model = new VideoListViewModel();
            model.UserByVideos = VideoService.Instance.VideosByUser(User.Identity.GetUserId());
            return PartialView(model);
        }
        public ActionResult Create()
        {
            VideoAddViewModel model = new VideoAddViewModel();

            return PartialView(model);
        }
        [HttpPost]
        public JsonResult Create(VideoAddViewModel model)
        {
            JsonResult result = new JsonResult();

            var newVideo = new VideoStore();

            
            newVideo.UserId = User.Identity.GetUserId();
            newVideo.Video_Link = model.Video_Link;

            VideoService.Instance.SaveVideo(newVideo);
            result.Data = new { success = true };
            return result;
        }
    }
}