using System;
using CzechifyNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CzechifyNetCore.Controllers
{
    [Route("recent")]
    [ApiController]
    public class RecentController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public RecentController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ret = _historyService.ListRecentRequests().Select(x => x.ToString());
            return Ok(ret);
        }
    }
}
