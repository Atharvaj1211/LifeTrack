namespace LifeTrack.Api.Models
{
    public class StudyLog
    {
        public int Id { get; set; }
        
        public int StudyPlanItemId { get; set; }
        public StudyPlanItem? StudyPlanItem { get; set; } // EF Core Navigation Property

        public DateTime Date { get; set; } // The actual day being tracked
        public bool IsDone { get; set; }
        public int MinutesSpent { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}