using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class AtividadeViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required]
        [MinLength(9, ErrorMessage = @"Tamanho mínimo permitido de {0} caracteres")]
        [MaxLength(9, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Código da Atividade")]
        public string CodigoAtividade { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required] [Display(Name = "Serviço")] public string Servico { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdIncidencia { get; set; }

        [Display(Name = "Incidência")] public string Incidencia { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdTributacao { get; set; }

        [Display(Name = "Tributação")] public string Tributacao { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdOperacao { get; set; }

        [Display(Name = "Operação")] public string Operacao { get; set; }

        [Required]
        [Display(Name = "É serviço?")]
        public bool IsServico { get; set; }

        [Required]
        [Display(Name = "É imune?")]
        public bool IsImune { get; set; }

        [Required]
        [Display(Name = "É isento?")]
        public bool IsIsento { get; set; }

        [Required] public int IdItensServico { get; set; }

        [Display(Name = "Itens do serviço")] public string ItensServico { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = @"Tamanho mínimo permitido de {0} caracteres")]
        [MaxLength(2, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        public string Grupo { get; set; }

        [Required] public int IdUtilizacao { get; set; }

        [Display(Name = "Utilização")] public string Utilizacao { get; set; }

        public string Exibicao => $"{CodigoAtividade} - {Descricao}";
    }
}