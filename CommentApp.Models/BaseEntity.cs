using System;
using System.Collections.Generic;
using System.Text;

namespace CommentApp.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
