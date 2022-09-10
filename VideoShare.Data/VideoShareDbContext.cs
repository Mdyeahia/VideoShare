using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoShare.Entities;

namespace VideoShare.Data
{
    public class VideoShareDbContext : IdentityDbContext<VideoShareUser>
    {
        public VideoShareDbContext(): base("VideoShareConnection")
        {
        }

        public DbSet<VideoStore> videoStore { get; set; }
        public DbSet<Video_Detail>  video_Details { get; set; }

        public static VideoShareDbContext Create()
        {
            return new VideoShareDbContext();
        }
    }
}
