using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class FilialViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Display(Name = "Identificação")] public string Identificacao { get; set; }

        [Display(Name = "Nome Fantasia")] public string NomeFantasia { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdEmpresa { get; set; }

        [Display(Name = "CPF / CNPJ")] public string CPFCNPJ { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        [Display(Name = "Número")] public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public int IdEstado { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdCidade { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdTipoLogradouro { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdTipoBairro { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }

        public decimal AliquotaISS { get; set; }

        [Display(Name = "Inscrição Estadual")] public string InscricaoEstadual { get; set; }

        public string DDD { get; set; }

        [DataType(DataType.PhoneNumber)] public string Telefone { get; set; }

        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<CertificadoDigitalViewModel> CertificadosDigitais { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [Display(Name = "Tipo de logradouro")] public string TipoLogradouro { get; set; }

        [Display(Name = "Tipo de bairro")] public string TipoBairro { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco => string.IsNullOrEmpty(Complemento)
            ? TipoLogradouro + " " + Logradouro + ", " + Numero
            : TipoLogradouro + " " + Logradouro + ", " + Numero + " - " + Complemento;

        [Display(Name = "Bairro")] public string Localizacao => TipoBairro + " " + Bairro;

        [Display(Name = "Telefone")] public string DDDTelefone => DDD + " " + Telefone;

        [Display(Name = "Quantidade de RPS permitidos por Lote")] public int QuantidadeRPSPorLote { get; set; }
    }
}