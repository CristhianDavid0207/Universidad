namespace inscription.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? NameStudent { get; set; }
        public string? LastNameStudent { get; set; }
        public string? EmailStudent { get; set; }
        public string? PhoneStudent { get; set; }
        public int SemesterId { get; set; }
        public Semester? Semester { get; set; }

        public ICollection<UniversityHasStudent>? UniversityHasStudent { get; set; }

    }
}