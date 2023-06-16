using System.ComponentModel.DataAnnotations;
using Avondspel.Domain.Enum;
using System.ComponentModel;
using DefaultValueAttribute = System.ComponentModel.DefaultValueAttribute;

namespace Avondspel.Domain
{
    public class Gebruiker
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wat is jou naam?")]
        public string Name { get; set; } = null!;
        [EmailAddress]
        [Required(ErrorMessage = "Wat is jou email?")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Wat is jou geslacht?")]
        [DefaultValue(Geslacht.LieverNiet)]
        public Geslacht Gender { get; set; }

        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Straat?")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "Stad?")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Huisnummer?")]
        public string HouseNumber { get; set; } = null!;

        [DefaultValue(false)]
        public bool Lactose { get; set; }

        [DefaultValue(false)]
        public bool Notenallergie { get; set; }

        [DefaultValue(false)]
        public bool Vega { get; set; }

        [DefaultValue(false)]
        public bool Alcohol { get; set; }

        public bool OuderDanAchtien { get; set; }

        public List<BordspellenAvond>? BordspellenAvonden { get; set; }
    }
}
