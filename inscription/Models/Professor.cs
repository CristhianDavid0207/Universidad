namespace inscription.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string? NameProfessor { get; set; }
        public string? LastNameProfessor { get; set; }
        public string? PhoneProfessor { get; set; }
        public string? EmailProfessor { get; set; }

        public ICollection<ProfessorHasUniversity>? ProfessorHasUniversity { get; set; }
        public ICollection<SubjectHasProfessor>? SubjectHasProfessor { get; set; }

    }
}