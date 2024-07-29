namespace inscription.Models
{
    public class Career
    {
        public int Id { get; set; }
        public string? NameCareer { get; set; }
        public ICollection<UniversityHasCareer>? UniversityHasCareer { get; set; }

        public ICollection<CareerHasSubject>? CareerHasSubject { get; set; }

    }
}