using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoShare.Entities;

namespace VideoShare.ViewModels
{
    public class VideoAddViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Video_Link { get; set; }
        public int Like_count { get; set; }
        public int Dislike_count { get; set; }
        public int View_count { get; set; }
    }
    public class VideoListViewModel
    {
        public List<VideoStore> UserByVideos { get; set; }
        public List<VideoStore> AllVideos { get; set; }

    }
    public class VideoDetailsViewModel
    {
       public  VideoStore VideoStore { get; set; }
       public string UserName { get; set; }
        public bool? Like { get; set; }
        public bool? Dislike { get; set; }

        public List<VideoDetailsViewModel> videoDetailsViewModels { get; set; }

    }
}