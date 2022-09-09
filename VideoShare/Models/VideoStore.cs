using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoShare.Models
{
    public class VideoStore
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public  string Video_Link { get; set; }
        public int Like_count { get; set; }
        public int Dislike_count { get; set; }
        public int View_count { get; set; }


    }
}