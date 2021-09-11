using CommentApp.BLL.VMs.Recall;
using CommentApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentApp.BLL.Interfaces
{
    public interface IRecallService
    {
        Task<Guid> CreateRecallAsync(CreateRecall recall);
        List<InfoRecall> FindRecallsByFunc(Func<Recall, bool> func);
    }
}
