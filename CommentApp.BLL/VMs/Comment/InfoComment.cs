using System;

namespace CommentApp.BLL.VMs.Comment
{
    public class InfoComment
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid RecallId { get; set; }
        public string ProductName { get; set; }
    }
}
