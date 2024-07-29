namespace inscription.Models
{
    public class Inscription
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public int SemesterId { get; set; }
        public Semester? Semester { get; set; }
        public ICollection<SubjectHasInscription>? SubjectHasInscription { get; set; }
  
    }
}