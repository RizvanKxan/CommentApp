using CommentApp.BLL.Interfaces;
using CommentApp.BLL.VMs.Comment;
using CommentApp.BLL.VMs.MediaFile;
using CommentApp.BLL.VMs.Product;
using CommentApp.BLL.VMs.Recall;
using CommentApp.DAL.Patterns;
using CommentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentApp.BLL.Services
{
    public class RecallService : IRecallService
    {
        private readonly IUnitOfWork db;
        private readonly IProductService productService;
        private readonly IMediaFileService mediaFileService;

        public RecallService(IUnitOfWork _db, IProductService _productService, IMediaFileService _mediaFileService)
        {
            db = _db;
            productService = _productService;
            mediaFileService = _mediaFileService;
        }
        public async Task<Guid> CreateRecallAsync(CreateRecall recall)
        {
            try
            {
                var productId = await productService.CreateProductAsync(new CreateProduct() { Name = recall.ProductName, Category = recall.ProductCategory });

                var dbRecall = new Recall()
                {
                    AuthorName = recall.AuthorName,
                    CreationDate = DateTime.Now,
                    ProductId = productId,
                    Grade = recall.Grade,
                    Text = recall.Text
                };
                dbRecall = await db.Recalls.CreateAsync(dbRecall);


                if (recall.MediaFiles != null && recall.MediaFiles.Any())
                {
                    recall.MediaFiles.Select(m => {
                        m.RecallId = dbRecall.Id;
                        return mediaFileService.CreateMediaFileAsync(m);
                    });
                }

                return dbRecall.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InfoRecall> FindRecallsByFunc(Func<Recall, bool> func)
        {
            try
            {
                List<Recall> dbFeedbacks;
                if (func == null)
                {
                    dbFeedbacks = db.Recalls.GetAll().ToList();
                }
                else
                {
                    dbFeedbacks = db.Recalls.GetAll().Where(func).ToList();
                }
                return dbFeedbacks.Select(m =>
                {
                    return new InfoRecall()
                    {
                        CreationDate = m.CreationDate,
                        AuthorName = m.AuthorName,
                        ProductName = m.Product.Name,
                        Grade = m.Grade,
                        Text = m.Text,
                        Comments = m.Comments.Select(n =>
                        {
                            return new InfoComment()
                            {
                                CreationDate = n.CreationDate,
                                AuthorName = n.AuthorName,
                                ProductName = n.Recall.Product.Name,
                                Text = n.Text,
                                RecallId = n.RecallId
                            };
                        }).ToList(),
                        MediaFiles = m.MediaFiles.Select(e =>
                        {
                            return new CreateMediaFile()
                            {
                                RecallId = e.RecallId,
                                Name = e.Name,
                                Path = e.Path,
                                Type = e.Type
                            };
                        }).ToList()
                    };
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
