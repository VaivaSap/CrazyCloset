namespace CrazyCloset.Models
{
    public class UseLog
    {
        public long UseLogId { get; set; }
        public long ItemId { get; set; }
        public ClothesItem Item { get; set; }
        public DateOnly UsedDate { get; set; }
    }
}
