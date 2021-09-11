using CommentApp.BLL.VMs.MediaFile;
using System.Collections.Generic;

namespace CommentApp.BLL.VMs.Recall
{
    public class CreateRecall
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public List<CreateMediaFile> MediaFiles { get; set; }
    }
}
