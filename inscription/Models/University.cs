namespace inscription.Models
{
    public class University
    {
        public int Id { get; set; }
        public string? NameUniversity { get; set; }

        public ICollection<ProfessorHasUniversity>? ProfessorHasUniversity { get; set; }

        public ICollection<UniversityDean>? UniversityDean { get; set; }
        public ICollection<UniversityHasCareer>? UniversityHasCareer { get; set; }
        public ICollection<UniversityHasStudent>? UniversityHasStudent { get; set; }

    }
}