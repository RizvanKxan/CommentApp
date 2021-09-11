using System;
using System.Collections.Generic;
using System.Text;

namespace CommentApp.Models
{
    /// <summary>
    /// Комментарий на чей-то отзыв
    /// </summary>
    public class Comment : BaseEntity
    {
        public DateTime CreationTime { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public Guid RecallId { get; set; }
        public virtual Recall Recall { get; set; }
    }
}
