using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class ClienteViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdEmpresa { get; set; }

        [Display(Name = "Identificação")] public string Apelido { get; set; }

        [Display(Name = "Nome / Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "CPF/CNPJ")] public string CPFCNPJ { get; set; }

        [Display(Name = "Inscrição Estadual")] public string InscricaoEstadual { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }

        [Display(Name = "Estado")] public int IdEstado { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        [Range(1, int.MaxValue)]
        public int IdCidade { get; set; }

        [Required]
        [Display(Name = "Tipo de Logradouro")]
        [Range(1, int.MaxValue)]
        public int IdTipoLogradouro { get; set; }

        [Display(Name = "Logradouro")] public string Logradouro { get; set; }

        [Required]
        [Display(Name = "Tipo de Bairro")]
        [Range(1, int.MaxValue)]
        public int IdTipoBairro { get; set; }

        [Display(Name = "Bairro")] public string Bairro { get; set; }

        [Display(Name = "Número")] public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required] public string CEP { get; set; }

        public string DDD { get; set; }

        [DataType(DataType.PhoneNumber)] public string Telefone { get; set; }

        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(60)]
        public string EmailNF { get; set; }

        [Required(ErrorMessage = @"Preencha o campo Assunto do E-Mail")]
        [MaxLength(16, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        public string Sigla { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string TipoLogradouro { get; set; }

        public string TipoBairro { get; set; }

        [Display(Name = "E-Mails para Envio")]
        [DataType(DataType.EmailAddress)]
        public string EmailsEnvio { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco => string.IsNullOrEmpty(Complemento)
            ? TipoLogradouro + " " + Logradouro + ", " + Numero
            : TipoLogradouro + " " + Logradouro + ", " + Numero + " - " + Complemento;

        [Display(Name = "Bairro")] public string Localizacao => TipoBairro + " " + Bairro;

        [Display(Name = "Telefone")] public string DDDTelefone => DDD + " " + Telefone;
    }
}