using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoShare.Entities
{
    public class VideoStore
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public VideoShareUser User { get; set; }
        public  string Video_Link { get; set; }
        public int ViewCount { get; set; }
        public virtual List<Video_Detail> Video_Details { get; set; }

    }
}