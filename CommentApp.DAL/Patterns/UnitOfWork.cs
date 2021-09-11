using CommentApp.Models;
using System;
using System.Threading.Tasks;

namespace CommentApp.DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        private IRepository<Product> _products;
        private IRepository<MediaFile> _mediaFiles;
        private IRepository<Recall> _recalls;
        private IRepository<Comment> _comments;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }
        public IRepository<Product> Products => _products ??= new Repository<Product>(_db);

        public IRepository<MediaFile> MediaFiles => _mediaFiles ??= new Repository<MediaFile>(_db);

        public IRepository<Recall> Recalls => _recalls ??= new Repository<Recall>(_db);

        public IRepository<Comment> Comments => _comments ??= new Repository<Comment>(_db);

        private bool _disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                _db.Dispose();
            }
            _disposed = true;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
