namespace inscription.Models
{
    public class UniversityHasStudent
    {
        public int UniversityId { get; set; }
        public University? University { get; set; }
        public int StudentId { get; set; }  
        public Student? Student { get; set; }        
    }
}