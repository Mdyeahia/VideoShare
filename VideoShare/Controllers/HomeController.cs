using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoShare.Service;
using VideoShare.ViewModels;

namespace VideoShare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new VideoListViewModel();
            model.AllVideos = VideoService.Instance.GetAllVideo();
            foreach (var vio in model.AllVideos)
            {
                var json = new WebClient().DownloadString("https://www.googleapis.com/youtube/v3/videos?part=statistics&id=" + vio.Video_Link + "&key=AIzaSyB0QTPOgQ3qqwLW2dp0x10D8voNAuGDHeo");
                var kk = (JObject)JsonConvert.DeserializeObject(json, new JsonSerializerSettings());
                vio.ViewCount = ((int)kk["items"][0]["statistics"]["viewCount"]);
            }
            return View(model);
        }
    }
}