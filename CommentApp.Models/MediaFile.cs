using System;
using System.Collections.Generic;
using System.Text;

namespace CommentApp.Models
{
    public class MediaFile : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public Guid RecallId { get; set; }
        public virtual Recall Recall{ get; set; }
    }
}
