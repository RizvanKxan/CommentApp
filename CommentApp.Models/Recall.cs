using System;
using System.Collections.Generic;
using System.Text;

namespace CommentApp.Models
{
    /// <summary>
    /// Отзыв на некоторый вид товара, услуги
    /// </summary>
    public class Recall
    {
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Grade { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
