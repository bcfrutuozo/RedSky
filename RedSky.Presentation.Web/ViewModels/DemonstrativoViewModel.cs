using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RedSky.Presentation.Web.ViewModels
{
    public class DemonstrativoViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdEmpresa { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

        public string Cliente { get; set; }

        [Required(ErrorMessage = @"Preencha o campo Identificação")]
        [MinLength(4, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(128, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Valor Mínimo")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorMinimo { get; set; }

        [Required]
        [Display(Name = "Envia E-Mail?")]
        public bool EnviaEmail { get; set; }

        [Required(ErrorMessage = @"Preencha o campo Assunto do E-Mail")]
        [MinLength(4, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(128, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Assunto do E-Mail")]
        public string AssuntoEmail { get; set; }

        [Required(ErrorMessage = @"Preencha o destinatários do E-Mail")]
        [Display(Name = "Destinatários")]
        public string DestinatariosEmail { get; set; }

        [Required(ErrorMessage = @"Preencha o mensagem do E-Mail")]
        [Display(Name = "Corpo do E-Mail")]
        [AllowHtml]
        public string MensagemEmail { get; set; }

        [Required(ErrorMessage = @"Preencha o campo Assunto do E-Mail")]
        [MinLength(4, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(64, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        public string Departamento { get; set; }


        [Required]
        [Display(Name = "É faturável?")]
        public bool IsFaturavel { get; set; }

        public ICollection<ServicoViewModel> Servicos { get; set; }

        public bool HasFaturas { get; set; }
    }
}