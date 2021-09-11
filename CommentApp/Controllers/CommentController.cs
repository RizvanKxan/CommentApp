using CommentApp.BLL.Interfaces;
using CommentApp.BLL.VMs.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public List<InfoComment> GetCommentByRecallId(Guid id)
        {
            return _commentService.FindCommentsByFunc(m => m.RecallId == id);
        }

        [HttpGet]
        public List<InfoComment> GetAllComments()
        {
            return _commentService.FindCommentsByFunc(null);
        }

        [HttpPost]
        public Guid Create([FromForm] CreateComment comment)
        {
            return (_commentService.CreateCommentAsync(comment)).Result;
        }
    }
}
