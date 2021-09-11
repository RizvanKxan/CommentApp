using CommentApp.BLL.VMs.Comment;
using CommentApp.BLL.VMs.MediaFile;
using System;
using System.Collections.Generic;

namespace CommentApp.BLL.VMs.Recall
{
    public class InfoRecall
    {
        public DateTime CreationDate { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }
        public string ProductName { get; set; }
        public List<InfoComment> Comments { get; set; } = new List<InfoComment>();
        public List<CreateMediaFile> MediaFiles { get; set; } = new List<CreateMediaFile>();
    }
}
