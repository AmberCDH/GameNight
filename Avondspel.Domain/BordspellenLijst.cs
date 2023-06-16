using System.ComponentModel.DataAnnotations;

namespace Avondspel.Domain
{
    public class BordspellenLijst
    {
        [Key]
        public int Id { get; set; }

        public string? GebruikerId { get; set; }

        public int BordspelId { get; set; }
        
        public int SpelAvondId { get; set; }
         
    }
}
