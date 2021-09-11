using CommentApp.BLL.Interfaces;
using CommentApp.BLL.VMs.Comment;
using CommentApp.DAL.Patterns;
using CommentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentApp.BLL.Services
{
    public class CommentService : ICommentService
    {
        public CommentService(IUnitOfWork _db)
        {
            db = _db;
        }
        private readonly IUnitOfWork db;
        public async Task<Guid> CreateCommentAsync(CreateComment comment)
        {
            try
            {
                var dbComment = new Comment()
                {
                    AuthorName = comment.AuthorName,
                    CreationDate = DateTime.Now,
                    RecallId = comment.RecallId,
                    Text = comment.Text
                };
                dbComment = await db.Comments.CreateAsync(dbComment);
                return dbComment.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InfoComment> FindCommentsByFunc(Func<Comment, bool> func)
        {
            try
            {
                var dbComments = db.Comments.GetAll().Where(func).
                                                      Select(m =>
                                                      {
                                                          return new InfoComment()
                                                          {
                                                              CreationDate = m.CreationDate,
                                                              AuthorName = m.AuthorName,
                                                              ProductName = m.Recall.Product.Name,
                                                              Text = m.Text,
                                                              RecallId = m.RecallId
                                                          };
                                                      }).ToList();
                return dbComments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
