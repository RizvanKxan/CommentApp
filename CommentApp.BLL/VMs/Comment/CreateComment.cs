using System;

namespace CommentApp.BLL.VMs.Comment
{
    public class CreateComment
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public Guid RecallId { get; set; }
    }
}
