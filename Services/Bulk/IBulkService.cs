using System.Collections.Generic;
using RPG_Project.Models;

namespace RPG_Project.Services
{
    public interface IBulkService
    {
        List<Bulk> BulkInsert();
        List<Bulk> BulkUpdate();
        List<Bulk> BulkDelete();
        List<Bulk> GetBulks();

    }
}