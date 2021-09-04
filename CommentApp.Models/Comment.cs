using System;
using System.Collections.Generic;
using System.Text;

namespace CommentApp.Models
{
    /// <summary>
    /// Комментарий на чей-то отзыв
    /// </summary>
    class Comment
    {
        public DateTime CreationTime { get; set; }
        public string Text { get; set; }
        public virtual Recall Recall { get; set; }
    }
}
