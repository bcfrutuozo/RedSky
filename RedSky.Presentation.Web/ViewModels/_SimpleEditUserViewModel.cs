using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSky.Presentation.Web.ViewModels
{
    public class _SimpleEditUserViewModel
    {
        [Key] [Range(1, int.MaxValue)] public int Id { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Empresa")]
        public int? IdEmpresa { get; set; }

        public string Empresa { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(16, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [Compare(nameof(ConfirmaSenha))]
        public string Senha { get; set; }

        [MinLength(8, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(16, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Confirma senha")]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha))]
        [NotMapped]
        public string ConfirmaSenha { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(128, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        public string Nome { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(128, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public byte[] Picture { get; set; }
    }
}
