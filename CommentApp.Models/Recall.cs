﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommentApp.Models
{
    /// <summary>
    /// Отзыв на некоторый вид товара, услуги
    /// </summary>
    public class Recall : BaseEntity
    {
        public string AuthorName { get; set; }
        public DateTime CreationTime { get; set; }
        public string Text { get; set; }
        public Guid ProductId { get; set; }
        public int Grade { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        public virtual List<MediaFiles> MediaFiles { get; set; } = new List<MediaFiles>();
    }
}
