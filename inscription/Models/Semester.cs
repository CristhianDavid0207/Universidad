namespace inscription.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string? NameSemester { get; set; }

        public ICollection<Inscription>? Inscription { get; set; }
        public ICollection<Student>? Student { get; set; }        
    }
}