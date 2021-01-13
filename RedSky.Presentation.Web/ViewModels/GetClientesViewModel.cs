using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class GetClientesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Identificação")]
        public string Apelido { get; set; }

        [Display(Name = "Nome / Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string CPFCNPJ { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }


        [Display(Name = "Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Sigla { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string TipoLogradouro { get; set; }


        [Display(Name = "Endereço")]
        public string Endereco => string.IsNullOrEmpty(Complemento)
            ? TipoLogradouro + " " + Logradouro + ", " + Numero
            : TipoLogradouro + " " + Logradouro + ", " + Numero + " - " + Complemento;
    }
}