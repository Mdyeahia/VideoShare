using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using VideoShare.Data;
using VideoShare.Entities;

namespace VideoShare.Service
{
    public class VideoService
    {
        #region Singleton
        public static VideoService Instance
        {
            get
            {
                if (instance == null) instance = new VideoService();

                return instance;
            }
        }
        private static VideoService instance { get; set; }

        private VideoService()
        {
        }

        #endregion
        public void SaveVideo(VideoStore data)
        {
             var context = new VideoShareDbContext();

            context.videoStore.Add(data);
            context.SaveChanges();
        }
        public List<VideoStore> VideosByUser(string id)
        {
            var context = new VideoShareDbContext();

            return context.videoStore.Where(x => x.UserId == id).Include(x=>x.Video_Details).ToList();
        }

        public Video_Detail LikeDislikeExist (string userid,int videoid)
        {
            using (var context = new VideoShareDbContext())
            {
                return context.video_Details.Where(x => x.UserId == userid && x.VideoStoreId == videoid).FirstOrDefault();
            }
        }
        public void SaveLike(Video_Detail detail)
        {
            var context = new VideoShareDbContext();
            context.video_Details.Add(detail);
            context.SaveChanges();
        }
        public void UpdateLikeDisLike(Video_Detail detail)
        {
            using (var context = new VideoShareDbContext())
            {
                context.Entry(detail).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void SaveDisLike(Video_Detail detail)
        {
            var context = new VideoShareDbContext();
            context.video_Details.Add(detail);
            context.SaveChanges();
        }
        
    }
}
