using System.Data;
using NPOI.SS.UserModel;
using RedSky.Domain.Entities;

namespace RedSky.Excel.Interfaces
{
    public interface IWriter
    {
        int Line { get; set; }
        IWorkbook Workbook { get; set; }
        IStyle Style { get; set; }

        void Inicializar();

        void GerarCabecalho();

        Faturamento Ratear(Servico s, DataTable data);

        void InserirDados(string sheetName, DataTable data);

        void GerarRodape(decimal valorTotal, decimal valorMinimo = 0.00m);

        void Finalizar();

        void Save(string path);
    }
}