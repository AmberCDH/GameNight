using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DefaultValueAttribute = System.ComponentModel.DefaultValueAttribute;

namespace Avondspel.Domain
{
    public class Eten
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [DefaultValue(false)]
        public bool Lactose { get; set; }

        [DefaultValue(false)]
        public bool Notenallergie { get; set; }

        [DefaultValue(true)]
        public bool Vega { get; set; }

        [DefaultValue(false)]
        public bool Alcohol { get; set; }
        public List<BordspellenAvond>? BordspellenAvonden { get; set; }
    }
}
