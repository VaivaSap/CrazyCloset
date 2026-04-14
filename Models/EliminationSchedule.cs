namespace CrazyCloset.Models
{
    public class EliminationSchedule
    { 
        public long Id { get; set; }
        public DateOnly ScheduledEliminationDate { get; set; } 
        public bool IsActive { get; set; }
        //public int WinsSpent { get; set; }
    }
}
