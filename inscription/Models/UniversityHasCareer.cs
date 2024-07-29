namespace inscription.Models
{
    public class UniversityHasCareer
    {
        public int CareerId { get; set; }
        public Career? Career { get; set; }
        public int UniversityId { get; set; }
        public University? University { get; set; } 
    }
}