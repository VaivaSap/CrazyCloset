namespace CrazyCloset.Models
{
    public class EliminationLog
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public DateOnly EliminationDate { get; set; }
    }
}
