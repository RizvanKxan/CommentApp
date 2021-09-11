using CommentApp.BLL.VMs.MediaFile;
using CommentApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentApp.BLL.Interfaces
{
    public interface IMediaFileService
    {
        Task<Guid> CreateMediaFileAsync(CreateMediaFile mediaFile);
        List<CreateMediaFile> FindMediaFilesByFunc(Func<MediaFile, bool> func);
    }
}
