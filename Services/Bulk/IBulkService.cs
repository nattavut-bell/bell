using System.Collections.Generic;
using System.Threading.Tasks;
using RPG_Project.DTOs;
using RPG_Project.Models;

namespace RPG_Project.Services
{
    public interface IBulkService
    {
        List<Bulk> BulkInsert();
        List<Bulk> BulkUpdate();
        List<Bulk> BulkDelete();
        List<Bulk> GetBulks();

        Task<ServiceResponseWithPagination<List<Bulk>>> GetBulksWithPagination(PaginationDto pagination);
        Task<ServiceResponseWithPagination<List<Bulk>>> GetBulksFilter(BulkFilterDto filter);
        Task<ServiceResponse<List<Bulk>>> GetBulksByInlineSQL(int bulkId);
        Task<ServiceResponse<List<Bulk>>> GetBulksByStoreProcedure(int bulkId);
    }
}