using System;

namespace CommentApp.BLL.VMs.MediaFile
{
    public class CreateMediaFile
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public Guid? RecallId { get; set; }
    }
}
