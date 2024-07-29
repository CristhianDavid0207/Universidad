namespace inscription.Models
{
    public class SubjectHasProfessor
    {
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; } 
    }
}