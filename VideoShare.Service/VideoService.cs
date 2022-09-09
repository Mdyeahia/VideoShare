﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            return context.videoStore.Where(x => x.UserId == id).ToList();
        }
    }
}