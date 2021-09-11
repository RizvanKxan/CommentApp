using CommentApp.BLL.Interfaces;
using CommentApp.BLL.VMs.Recall;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CommentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecallController : ControllerBase
    {
        private readonly IRecallService _recallService;

        public RecallController(IRecallService recallService)
        {
            _recallService = recallService;
        }

        [HttpGet]
        [Route("getbyid")]
        public List<InfoRecall> GetFeedbackById(Guid id)
        {
            return _recallService.FindRecallsByFunc(m => m.Id == id);
        }

        [HttpGet]
        [Route("getall")]
        public List<InfoRecall> GetAllFeedbacks()
        {
            return _recallService.FindRecallsByFunc(null);
        }

        [HttpPost]
        public Guid Create([FromForm] CreateRecall feedback)
        {
            return (_recallService.CreateRecallAsync(feedback)).Result;
        }
    }
}
