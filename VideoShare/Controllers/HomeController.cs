using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoShare.Data;
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
        public ActionResult Details(int Id)
        {
            var model =new VideoDetailsViewModel();
            model.VideoStore = VideoService.Instance.GetVideoDetailsBYId(Id);
            using (var context = new VideoShareDbContext())
            {

                model.videoDetailsViewModels = context.Database.SqlQuery<VideoDetailsViewModel>(@"select u.UserName,d.[Like],d.Dislike from Video_Detail d
                                    inner join AspNetUsers u on d.UserId=u.Id
                                    inner join VideoStores m on m.Id=d.VideoStoreId
                                    where m.Id=@videoid and d.[Like]=1 or d.Dislike=1", new SqlParameter("@videoid",Id)).ToList();
            }

            return View(model);

        }
    }
}