using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG_Project.DTOs;
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

        [HttpGet("bulk/pagination")]
        public async Task<IActionResult> GetBulksWithPagination([FromQuery] PaginationDto pagination)
        {
            return Ok(await _bulkService.GetBulksWithPagination(pagination));
        }

        [HttpGet("bulk/filter")]
        public async Task<IActionResult> GetBulksFilter([FromQuery] BulkFilterDto filter)
        {
            return Ok(await _bulkService.GetBulksFilter(filter));
        }


        [HttpGet("bulk/inline")]
        public async Task<IActionResult> GetBulkByInlineSQL(int bulkId)
        {
            return Ok(await _bulkService.GetBulksByInlineSQL(bulkId));
        }

        [HttpGet("bulk/storeprocedure")]
        public async Task<IActionResult> GetBulksByStoreProcedure(int bulkId)
        {
            return Ok(await _bulkService.GetBulksByStoreProcedure(bulkId));
        }

    }
}