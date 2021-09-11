using CommentApp.BLL.Interfaces;
using CommentApp.BLL.VMs.MediaFile;
using CommentApp.DAL.Patterns;
using CommentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentApp.BLL.Services
{
    public class MediaFileService : IMediaFileService
    {
        private readonly IUnitOfWork db;
        public MediaFileService(IUnitOfWork _db)
        {
            db = _db;
        }
        public async Task<Guid> CreateMediaFileAsync(CreateMediaFile mediaFile)
        {
            try
            {
                var dbMediaFile = new MediaFile()
                {
                    RecallId = mediaFile.RecallId.Value,
                    Name = mediaFile.Name,
                    Path = mediaFile.Path,
                    Type = mediaFile.Type
                };
                dbMediaFile = await db.MediaFiles.CreateAsync(dbMediaFile);
                return dbMediaFile.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreateMediaFile> FindMediaFilesByFunc(Func<MediaFile, bool> func)
        {
            try
            {
                var dbMediaFiles = db.MediaFiles.GetAll().Where(func).
                                                      Select(m =>
                                                      {
                                                          return new CreateMediaFile()
                                                          {
                                                              RecallId = m.RecallId,
                                                              Name = m.Name,
                                                              Path = m.Path,
                                                              Type = m.Type
                                                          };
                                                      }).ToList();
                return dbMediaFiles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
