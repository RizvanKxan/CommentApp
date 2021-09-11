using System;
using System.Collections.Generic;
using System.Text;

namespace CommentApp.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public virtual List<Recall> Recalls { get; set; } = new List<Recall>();
    }
}
