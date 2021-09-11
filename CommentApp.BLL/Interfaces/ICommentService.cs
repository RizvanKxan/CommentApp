using CommentApp.BLL.VMs.Comment;
using CommentApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentApp.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> CreateCommentAsync(CreateComment comment);
        List<InfoComment> FindCommentsByFunc(Func<Comment, bool> func);
    }
}
