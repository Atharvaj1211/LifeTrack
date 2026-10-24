namespace LifeTrack.Api.Models
{
    public class StudyPlanItem
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; } // EF Core Navigation Property

        public string Title { get; set; } = string.Empty;
        public string? Notes { get; set; }
        
        // Use 0-6 for Sunday-Saturday, or leave null if using SpecificDate
        public int? Weekday { get; set; } 
        public DateTime? SpecificDate { get; set; }
        
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<StudyLink> Links { get; set; } = new();
    }
}