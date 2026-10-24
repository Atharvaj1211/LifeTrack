namespace LifeTrack.Api.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty; // Links to Identity User
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = "#3f51b5"; // Default Material primary color
    }
}