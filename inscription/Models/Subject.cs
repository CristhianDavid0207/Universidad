namespace inscription.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string? NameSubject { get; set; }


        public ICollection<SubjectHasInscription>? SubjectHasInscription { get; set; }
        public ICollection<SubjectHasProfessor>? SubjectHasProfessor { get; set; }
        public ICollection<CareerHasSubject>? CareerHasSubject { get; set; }

    }
}