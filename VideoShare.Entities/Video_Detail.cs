using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShare.Entities
{
    public class Video_Detail
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public VideoShareUser User { get; set; }
        public int VideoId { get; set; }
        public virtual VideoStore VideoStore { get; set; }
        public bool? Like { get; set; }
        public bool? Dislike { get; set; }
        
    }
}
