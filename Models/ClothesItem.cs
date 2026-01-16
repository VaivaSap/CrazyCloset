namespace CrazyCloset.Models
{
    public class ClothesItem
    {
        public long Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Season { get; set; }
        public string? Status { get; set; }
    }
}
