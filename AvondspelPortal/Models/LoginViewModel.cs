using Avondspel.Domain.DataAnnotation;
using Avondspel.Domain.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DefaultValueAttribute = System.ComponentModel.DefaultValueAttribute;

namespace Avondspel.Portal.Models
{
    public class LoginViewModel
    {
        [Required]
        [UIHint("Password")]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Wat is jou naam?")]
        public string Name { get; set; } = null!;
        [EmailAddress]
        [Required(ErrorMessage = "Wat is jou email?")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Wat is jou geslacht?")]
        [DefaultValue(Geslacht.LieverNiet)]
        public Geslacht Gender { get; set; }

        [AgeValidation]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Wanneer ben jij geboren?")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Straat?")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "Stad?")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Huisnummer?")]
        public string HouseNumber { get; set; } = null!;

        //Standaard geen lactose intollerantie
        [DefaultValue(false)]
        public bool Lactose { get; set; }

        //Standaard geen notenallergie
        [DefaultValue(false)]
        public bool Notenallergie { get; set; }

        //Standaard niet vega
        [DefaultValue(false)]
        public bool Vega { get; set; }

        //Standaard geen alcohol willen
        [DefaultValue(false)]
        public bool Alcohol { get; set; }
    }
}
