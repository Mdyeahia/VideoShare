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
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            foreach(var vio in model.UserByVideos)
            {
                var json = new WebClient().DownloadString("https://www.googleapis.com/youtube/v3/videos?part=statistics&id=" + vio.Video_Link + "&key=AIzaSyB0QTPOgQ3qqwLW2dp0x10D8voNAuGDHeo");
                var kk = (JObject)JsonConvert.DeserializeObject(json, new JsonSerializerSettings());
                vio.ViewCount = ((int)kk["items"][0]["statistics"]["viewCount"]);
            }
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
        [HttpPost]
        public JsonResult Like(int id)
        {
            JsonResult result = new JsonResult();
            var exist = VideoService.Instance.LikeDislikeExist(User.Identity.GetUserId(),id);
            if(exist==null)
            {
                var newVideoDetail= new Video_Detail();
                newVideoDetail.UserId = User.Identity.GetUserId();
                newVideoDetail.VideoStoreId = id;
                newVideoDetail.Like = true;
                newVideoDetail.Dislike = null;

                VideoService.Instance.SaveLike(newVideoDetail);
                result.Data = new { success = true, message = "Liked" };
                return result;
            }
            else
            {
                if(exist.Like == null)
                {
                    exist.Like = true;
                    exist.Dislike = null;
                }
                else
                {
                    exist.Like = null;
                    exist.Dislike = null;
                }
                

                VideoService.Instance.UpdateLikeDisLike(exist);
                result.Data = new { success = true, message = exist.Like != null ? "Liked" : "Liked Remove" };
                return result;
            }
        }
        [HttpPost]
        public JsonResult DisLike(int id)
        {
            JsonResult result = new JsonResult();
            var exist = VideoService.Instance.LikeDislikeExist(User.Identity.GetUserId(), id);
            if (exist==null)
            {
                var newVideoDetail = new Video_Detail();
                newVideoDetail.UserId = User.Identity.GetUserId();
                newVideoDetail.VideoStoreId = id;
                newVideoDetail.Like = null;
                newVideoDetail.Dislike = true;

                VideoService.Instance.SaveDisLike(newVideoDetail);
                result.Data = new { success = true, message = "DisLiked" };
                return result;
            }
            else
            {
                if (exist.Dislike == null)
                {
                    
                    exist.Dislike = true;
                    exist.Like = null;
                }
                else
                {
                    exist.Like = null;
                    exist.Dislike = null;
                }

                VideoService.Instance.UpdateLikeDisLike(exist);
                result.Data = new { success = true, message=exist.Dislike!=null? "DisLiked":"DisLiked Remove" };
                return result;
            }
        }
    }
}