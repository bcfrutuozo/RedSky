using NPOI.SS.UserModel;

namespace RedSky.Excel.Interfaces
{
    public interface IStyle
    {
        IWorkbook Workbook { get; set; }
        IDataFormat Format { get; set; }
        ICellStyle LinhaVazia { get; set; }
        ICellStyle CabecalhoRateioNome { get; set; }
        ICellStyle CabecalhoRateioInfo { get; set; }
        ICellStyle DescritivoServico { get; set; }
        ICellStyle CabecalhoRodapeServico { get; set; }
        ICellStyle RodapeRateio { get; set; }
        ICellStyle RodapeRateioValor { get; set; }
        ICellStyle RodapeServicoQuantidade { get; set; }
        ICellStyle RodapeServicoValor { get; set; }
        ICellStyle CabecalhoDados { get; set; }
        ICellStyle LinhaDados { get; set; }
        ICellStyle LinhaDadosQuantidade { get; set; }
        ICellStyle LinhaDadosQuantidade2 { get; set; }
        ICellStyle LinhaDadosPorcentagem { get; set; }
        ICellStyle LinhaDadosValor2 { get; set; }
        ICellStyle LinhaDadosValor3 { get; set; }
        ICellStyle LinhaDadosValor4 { get; set; }

        void Init();

        ICellStyle InitNulo();
        ICellStyle InitCabecalhoRateioNome();
        ICellStyle InitCabecalhoRateioInfo();
        ICellStyle InitDescritivoServico();
        ICellStyle InitCabecalhoRodapeServico();
        ICellStyle InitRodapeServicoQuantidade();
        ICellStyle InitRodapeServicoValor();
        ICellStyle InitRodapeRateio();
        ICellStyle InitRodapeRateioValor();
        ICellStyle InitCabecalhoDados();
        ICellStyle InitLinhaDados();
        ICellStyle InitLinhaDadosQuantidade();
        ICellStyle InitLinhaDadosQuantidade2();
        ICellStyle InitLinhaDadosPorcentagem();
        ICellStyle InitLinhaDadosValor2();
        ICellStyle InitLinhaDadosValor3();
        ICellStyle InitLinhaDadosValor4();
    }
}