namespace RPG_Project.DTOs
{
    public class BulkFilterDto : PaginationDto
    {
        //Filter
        public string BulkName { get; set; }
        public string BulkCode { get; set; }

        //Ordering
        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; } = true;
    }
}