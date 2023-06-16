using System.ComponentModel.DataAnnotations;
using Avondspel.Domain.Enum;
using System.ComponentModel;
using DefaultValueAttribute = System.ComponentModel.DefaultValueAttribute;

namespace Avondspel.Domain
{
    public class Bordspel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Voeg de naam toe van het spel")]
        public string Naam { get; set; } = string.Empty;

        [Required(ErrorMessage = "Geef een uitleg van het spel")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Geef een genre op voor het spel")]
        public Genre genre { get; set; }

        [DisplayName("foto")]
        public string? foto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Geef het soort spel op")]
        public SoortSpel soortSpel { get; set; }

        [Required]
        public string? GebruikerId { get; set; }

        [Required(ErrorMessage = "Moeten spelers ouder dan 18 zijn?")]
        [DefaultValue(false)]
        public bool AchtienPlus { get; set; }
    }
}