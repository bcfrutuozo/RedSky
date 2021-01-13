using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class EmpresaViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required(ErrorMessage = @"Preencha o campo Identificação")]
        [MinLength(4, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(64, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; }

        [Required(ErrorMessage = @"Preencha o campo Razão Social")]
        [MaxLength(128, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required]
        [Display(Name = "Está Ativa?")]
        public bool Ativo { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:n2} %", ApplyFormatInEditMode = true)]
        [Display(Name = "Aliquota do PIS")]
        public decimal AliquotaPIS { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:n2} %", ApplyFormatInEditMode = true)]
        [Display(Name = "Aliquota do COFINS")]
        public decimal AliquotaCOFINS { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:n2} %", ApplyFormatInEditMode = true)]
        [Display(Name = "Aliquota do CSLL")]
        public decimal AliquotaCSLL { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:n2} %", ApplyFormatInEditMode = true)]
        [Display(Name = "Aliquota do IR")]
        public decimal AliquotaIR { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:n2} %", ApplyFormatInEditMode = true)]
        [Display(Name = "Aliquota do INSS")]
        public decimal AliquotaINSS { get; set; }

        [Required] public int IdRegimeTributario { get; set; }

        [Display(Name = "Regime tributário")] public string RegimeTributario { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Caminho para relatórios")]
        public string CaminhoRelatorio { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Servidor SMTP")]
        public string ServidorSMTP { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha do E-Mail")]
        public string SenhaEmail { get; set; }

        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("SenhaEmail")]
        [Display(Name = "Confirma a senha do E-Mail")]
        public string ConfirmaSenhaEmail { get; set; }

        [Required]
        [Display(Name = "Porta SMTP")]
        public int Port { get; set; }

        [Required]
        [Display(Name = "Timeout para envio")]
        public int TimeOut { get; set; }

        [Required]
        [Display(Name = "Usar credenciais padrão?")]
        public bool UseDefaultCredentials { get; set; }

        [Required]
        [Display(Name = "Habilitar SSL?")]
        public bool EnableSSL { get; set; }

        [Display(Name = "Assinatura do E-Mail")]
        public byte[] LogoEmail { get; set; }

        [Display(Name = "Conexões com banco de dados")]
        public ICollection<ConexaoBancoViewModel> ConexoesBanco { get; set; }

        public ICollection<AtividadeViewModel> Atividades { get; set; }
    }
}