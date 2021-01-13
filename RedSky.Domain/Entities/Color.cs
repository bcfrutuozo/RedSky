using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Color")]
    public class Color : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdColor")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MinLength(6)]
        [MaxLength(6)]
        public string Hex { get; set; }

        #region Defined Colors

        public static Color MountainMeadow =>
            new Color
            {
                Id = 1,
                Name = "Mountain Meadow",
                Hex = "1FC777"
            };

        public static Color FuchsiaBlue =>
            new Color
            {
                Id = 2,
                Name = "Fuchsia Blue",
                Hex = "7750CE"
            };

        public static Color Turmeric =>
            new Color
            {
                Id = 3,
                Name = "Turmeric",
                Hex = "CAB54B"
            };
        public static Color Jewel =>
            new Color
            {
                Id = 4,
                Name = "Jewel",
                Hex = "117E4D"
            };
        public static Color OutrageousOrange =>
        new Color
        {
            Id = 5,
            Name = "Outrageous Orange",
            Hex = "FC6439"
        };
        public static Color YellowOrange =>
        new Color
        {
            Id = 6,
            Name = "Yellow Orange",
            Hex = "FBAA49"
        };
        public static Color HotPink =>
            new Color
            {
                Id = 7,
                Name = "Hot Pink",
                Hex = "FD5EC3"
            };
        public static Color Mine =>
            new Color
            {
                Id = 8,
                Name = "Mine Shaft",
                Hex = "333333"
            };
        public static Color Persian =>
            new Color
            {
                Id = 9,
                Name = "Persian Rose",
                Hex = "FC228A"
            };
        public static Color Roman =>
            new Color
            {
                Id = 10,
                Name = "Roman Coffee",
                Hex = "7E5348"
            };
        public static Color Mandy =>
            new Color
            {
                Id = 11,
                Name = "Mandy",
                Hex = "E0465E"
            };
        public static Color Silver =>
            new Color
            {
                Id = 12,
                Name = "Silver",
                Hex = "C4C4C4"
            };
        public static Color NightShadz =>
            new Color
            {
                Id = 13,
                Name = "Night Shadz",
                Hex = "B93555"
            };
        public static Color MediumPurple =>
            new Color
            {
                Id = 14,
                Name = "Medium Purple",
                Hex = "A161D9"
            };
        public static Color Gray =>
            new Color
            {
                Id = 15,
                Name = "Gray",
                Hex = "808080"
            };
        public static Color Cornflower =>
            new Color
            {
                Id = 16,
                Name = "Cornflower Blue",
                Hex = "5A9DF9"
            };
        public static Color Denim =>
            new Color
            {
                Id = 17,
                Name = "Denim",
                Hex = "1487BE"
            };
        public static Color Sunglow =>
            new Color
            {
                Id = 18,
                Name = "Sunglow",
                Hex = "FECA2F"
            };
        public static Color Atlantis =>
            new Color
            {
                Id = 19,
                Name = "Atlantis",
                Hex = "9DD139"
            };
        public static Color Malibu =>
            new Color
            {
                Id = 20,
                Name = "Malibu",
                Hex = "6ACDFD"
            };

        #endregion
    }
}
