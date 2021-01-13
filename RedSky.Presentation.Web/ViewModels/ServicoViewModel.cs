using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class ServicoViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdDemonstrativo { get; set; }

        [Display(Name = "Código do Serviço")] public string Codigo { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [MaxLength(31, ErrorMessage = "O nome da aba no Excel não pode exceder 31 caractéres.")]
        [Display(Name = "Nome na aba do Excel")]
        public string NomePlanilha { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdUnidade { get; set; }

        public string Unidade { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C4}")]
        public decimal Valor { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdConexaoBanco { get; set; }

        [Display(Name = "Conexão com o banco")]
        public string NomeConexao { get; set; }

        public string Servidor { get; set; }

        public string Database { get; set; }

        public string Namespace { get; set; }

        [Display(Name = "Query de Rateio")] public bool HasQueryRateio { get; set; }

        [Display(Name = "Query do Rateio")]
        [DataType(DataType.MultilineText)]
        public string QueryRateio { get; set; }

        [Display(Name = "Query de Dados")] public bool HasQueryDados { get; set; }

        [Display(Name = "Query de Dados")]
        [DataType(DataType.MultilineText)]
        public string QueryDados { get; set; }

        [Required] public int Ordem { get; set; }
    }
}