namespace LifeTrack.Api.Models
{
    public class StudyLink
    {
        public int Id { get; set; }
        
        public int StudyPlanItemId { get; set; }
        
        public string Label { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}