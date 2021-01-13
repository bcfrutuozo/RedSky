using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class NotaFiscalViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required]
        [Display(Name = "Nº da NF")]
        public long NumeroNF { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Código de Verificação")]
        public string CodigoVerificacao { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Nome do Arquivo da NF")]
        public string NomeArquivo { get; set; }

        [Display(Name = "Link para a NF")] public string Link { get; set; }

        [Required] public int IdRPS { get; set; }

        [Required] public bool IsCancelada { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Motivo do cancelamento")]
        public string MotivoCancelamento { get; set; }
    }
}