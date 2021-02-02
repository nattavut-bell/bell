using Microsoft.AspNetCore.Mvc;
using RPG_Project.Services;

namespace RPG_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BulkController : ControllerBase
    {
        private readonly IBulkService _bulkService;

        public BulkController(IBulkService bulkService)
        {
            _bulkService = bulkService;
        }

        [HttpGet("all")]
        public IActionResult GetBulk()
        {
            return Ok(_bulkService.GetBulks());
        }
        [HttpPost("insert")]
        public IActionResult BulkInsert()
        {
            return Ok(_bulkService.BulkInsert());
        }

        [HttpPut("update")]
        public IActionResult BulkUpdate()
        {
            return Ok(_bulkService.BulkUpdate());
        }

        [HttpPut("delete")]
        public IActionResult BulkDelete()
        {
            return Ok(_bulkService.BulkDelete());
        }
    }
}