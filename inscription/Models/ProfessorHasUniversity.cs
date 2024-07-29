namespace inscription.Models
{
    public class ProfessorHasUniversity
    
    {
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public int UniversityId { get; set; }
        public University? University { get; set; }

    }
}