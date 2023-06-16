using System.ComponentModel.DataAnnotations;
using Avondspel.Domain.DataAnnotation;
using System.ComponentModel;
using DefaultValueAttribute = System.ComponentModel.DefaultValueAttribute;

namespace Avondspel.Domain
{
    public class BordspellenAvond
    {
        [Key]
        public int Id { get; set; }

        [TimeValidation]
        [Required(ErrorMessage = "Vul een datum in voor de bordspellen avond")]
        public DateTime Planning { get; set; }

        [Required]
        public string? GebruikerId { get; set; } = null!;

        [Required(ErrorMessage = "Straat?")]
        public string Straat { get; set; } = null!;

        [Required(ErrorMessage = "Stad?")]
        public string Stad { get; set; } = null!;

        [Required(ErrorMessage = "Huisnummer?")]
        public string Huisnummer { get; set; } = null!;

        [Required(ErrorMessage = "Aantal spelers?")]
        public int AantalSpelers { get; set; }

        [Required(ErrorMessage = "Moeten spelers ouder dan 18 zijn?")]
        [DefaultValue(false)]
        public bool AchtienPlus { get; set; }

        [DefaultValue(false)]
        public bool PotLuck { get; set; }

        public List<Eten>? EtenLijst { get; set; }
        public List<Gebruiker>? Gebruikers { get; set; }
    }
}
