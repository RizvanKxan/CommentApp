using CommentApp.Models;
using System;
using System.Threading.Tasks;

namespace CommentApp.DAL.Patterns
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<MediaFile> MediaFiles { get; }
        IRepository<Recall> Recalls { get; }
        IRepository<Comment> Comments { get; }

        Task SaveAsync();
    }
}
