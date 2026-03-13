namespace CrazyCloset.Models
{
    public class UseLogDto
    {
        public long UseLogId { get; set; }
        public DateOnly UsedDate { get; set; }
        public string ItemName { get; set; }

        public string FilePath { get; set; }
        public string Category { get; set; }
    }
}
