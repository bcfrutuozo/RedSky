using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class ConexaoBancoViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required(ErrorMessage = @"Preencha o campo Identificação")]
        [MinLength(4, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(32, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        public string Nome { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = @"O campo servidor não pode ter mais de {0} caractéres.")]
        [StringLength(64, ErrorMessage = "O campo servidor não pode ultrapassar {0} caractéres.")]
        public string Servidor { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = @"O campo Database não pode ter mais de {0} caractéres.")]
        [StringLength(32, ErrorMessage = "O campo Database não pode ultrapassar {0} caractéres.")]
        public string Database { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = @"O campo Usuário Banco não pode ultrapassar mais de ter mais de {0} caractéres.")]
        [StringLength(32, ErrorMessage = "O campo Usuário Banco não pode ultrapassar {0} caractéres.")]
        [Display(Name = "Usuário do banco")]
        public string UsuarioBanco { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = @"A senha precisa ter mais de {0} caractéres.")]
        [StringLength(16, ErrorMessage = "A senha não pode ultrapassar {0} caractéres.")]
        [Display(Name = "Senha do banco")]
        public string SenhaBanco { get; set; }

        [DataType(DataType.Password)]
        [Compare("SenhaBanco")]
        [Display(Name = "Confirma a senha do banco")]
        public string ConfirmaSenhaBanco { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdEmpresa { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdDBProvider { get; set; }

        public string Namespace { get; set; }

        public string DescricaoProvider { get; set; }
    }
}