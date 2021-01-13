using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class ColorDisplayViewModel
    {
        [Key]
        [Range(1, 20)]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string Hex { get; set; }
    }
}