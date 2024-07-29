namespace inscription.Models
{
    public class SubjectHasInscription
    {
       public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public int InscriptionId { get; set; }
        public Inscription? Inscription { get; set; } 
    }
}