using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using RedSky.Excel.Interfaces;

namespace RedSky.Excel
{
    public class Style : IStyle
    {
        public IWorkbook Workbook { get; set; }
        public IDataFormat Format { get; set; }
        public ICellStyle LinhaVazia { get; set; }
        public ICellStyle CabecalhoRateioNome { get; set; }
        public ICellStyle CabecalhoRateioInfo { get; set; }
        public ICellStyle DescritivoServico { get; set; }
        public ICellStyle CabecalhoRodapeServico { get; set; }
        public ICellStyle RodapeRateio { get; set; }
        public ICellStyle RodapeRateioValor { get; set; }
        public ICellStyle RodapeServicoQuantidade { get; set; }
        public ICellStyle RodapeServicoValor { get; set; }
        public ICellStyle CabecalhoDados { get; set; }
        public ICellStyle LinhaDados { get; set; }
        public ICellStyle LinhaDadosQuantidade { get; set; }
        public ICellStyle LinhaDadosQuantidade2 { get; set; }
        public ICellStyle LinhaDadosPorcentagem { get; set; }
        public ICellStyle LinhaDadosValor2 { get; set; }
        public ICellStyle LinhaDadosValor3 { get; set; }
        public ICellStyle LinhaDadosValor4 { get; set; }

        public void Init()
        {
            Format = Workbook.CreateDataFormat();
            LinhaVazia = InitNulo();
            CabecalhoRateioNome = InitCabecalhoRateioNome();
            CabecalhoRateioInfo = InitCabecalhoRateioInfo();
            DescritivoServico = InitDescritivoServico();
            CabecalhoRodapeServico = InitCabecalhoRodapeServico();
            RodapeServicoQuantidade = InitRodapeServicoQuantidade();
            RodapeServicoValor = InitRodapeServicoValor();
            RodapeRateio = InitRodapeRateio();
            RodapeRateioValor = InitRodapeRateioValor();
            CabecalhoDados = InitCabecalhoDados();
            LinhaDados = InitLinhaDados();
            LinhaDadosQuantidade = InitLinhaDadosQuantidade();
            LinhaDadosQuantidade2 = InitLinhaDadosQuantidade2();
            LinhaDadosPorcentagem = InitLinhaDadosPorcentagem();
            LinhaDadosValor2 = InitLinhaDadosValor2();
            LinhaDadosValor3 = InitLinhaDadosValor3();
            LinhaDadosValor4 = InitLinhaDadosValor4();
        }

        public ICellStyle InitNulo()
        {
            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Branco));
            s.FillPattern = FillPattern.SolidForeground;

            return s;
        }

        public ICellStyle InitCabecalhoRateioNome()
        {
            var boldFont = (XSSFFont) Workbook.CreateFont();
            boldFont.Boldweight = (short) FontBoldWeight.Bold;
            boldFont.SetColor(new XSSFColor(Color.Branco));
            boldFont.FontHeightInPoints = 14;

            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.SetFont(boldFont);
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Verde));
            s.FillPattern = FillPattern.SolidForeground;

            return s;
        }

        public ICellStyle InitCabecalhoRateioInfo()
        {
            var boldFont = (XSSFFont) Workbook.CreateFont();
            boldFont.Boldweight = (short) FontBoldWeight.Bold;
            boldFont.SetColor(new XSSFColor(Color.Branco));
            boldFont.FontHeightInPoints = 11;

            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.SetFont(boldFont);
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Verde));
            s.FillPattern = FillPattern.SolidForeground;

            return s;
        }

        public ICellStyle InitDescritivoServico()
        {
            var boldFont = (XSSFFont) Workbook.CreateFont();
            boldFont.Boldweight = (short) FontBoldWeight.Bold;
            boldFont.SetColor(new XSSFColor(Color.Branco));
            boldFont.FontHeightInPoints = 14;

            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.SetFont(boldFont);
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Azul));
            s.FillPattern = FillPattern.SolidForeground;

            return s;
        }

        public ICellStyle InitCabecalhoRodapeServico()
        {
            var boldFont = (XSSFFont) Workbook.CreateFont();
            boldFont.SetColor(new XSSFColor(Color.Branco));
            boldFont.FontHeightInPoints = 11;

            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.SetFont(boldFont);
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Preto));
            s.FillPattern = FillPattern.SolidForeground;

            return s;
        }

        public ICellStyle InitRodapeServicoQuantidade()
        {
            var boldFont = (XSSFFont) Workbook.CreateFont();
            boldFont.SetColor(new XSSFColor(Color.Branco));
            boldFont.FontHeightInPoints = 11;

            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.SetFont(boldFont);
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Preto));
            s.FillPattern = FillPattern.SolidForeground;
            s.DataFormat = Format.GetFormat("#,##0");

            return s;
        }

        public ICellStyle InitRodapeServicoValor()
        {
            var boldFont = (XSSFFont) Workbook.CreateFont();
            boldFont.SetColor(new XSSFColor(Color.Branco));
            boldFont.FontHeightInPoints = 11;

            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.SetFont(boldFont);
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Preto));
            s.FillPattern = FillPattern.SolidForeground;
            s.DataFormat = Format.GetFormat(@"_(R$* #,##0.00_);_($* (#,##0.00);_(R$* ""-""??_);_(@_)");

            return s;
        }

        public ICellStyle InitRodapeRateio()
        {
            var boldFont = (XSSFFont) Workbook.CreateFont();
            boldFont.Boldweight = (short) FontBoldWeight.Bold;
            boldFont.SetColor(new XSSFColor(Color.Branco));
            boldFont.FontHeightInPoints = 11;

            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.SetFont(boldFont);
            s.BorderTop = BorderStyle.Double;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderBottom = BorderStyle.Double;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Double;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Double;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Cinza));
            s.FillPattern = FillPattern.SolidForeground;

            return s;
        }

        public ICellStyle InitRodapeRateioValor()
        {
            var boldFont = (XSSFFont) Workbook.CreateFont();
            boldFont.Boldweight = (short) FontBoldWeight.Bold;
            boldFont.SetColor(new XSSFColor(Color.Branco));
            boldFont.FontHeightInPoints = 11;

            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.SetFont(boldFont);
            s.BorderTop = BorderStyle.Double;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderBottom = BorderStyle.Double;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Double;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Double;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Cinza));
            s.FillPattern = FillPattern.SolidForeground;
            s.DataFormat = Format.GetFormat(@"_(R$* #,##0.00_);_($* (#,##0.00);_(R$* ""-""??_);_(@_)");

            return s;
        }

        public ICellStyle InitCabecalhoDados()
        {
            var boldFont = (XSSFFont) Workbook.CreateFont();
            boldFont.Boldweight = (short) FontBoldWeight.Bold;
            boldFont.SetColor(new XSSFColor(Color.Preto));
            boldFont.FontHeightInPoints = 11;

            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.SetFont(boldFont);
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.SetFillForegroundColor(new XSSFColor(Color.Verde));
            s.FillPattern = FillPattern.SolidForeground;

            return s;
        }

        public ICellStyle InitLinhaDados()
        {
            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;

            return s;
        }

        public ICellStyle InitLinhaDadosQuantidade()
        {
            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.DataFormat = Format.GetFormat("#,##0");

            return s;
        }

        public ICellStyle InitLinhaDadosQuantidade2()
        {
            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.DataFormat = Format.GetFormat("#,##0.00");

            return s;
        }

        public ICellStyle InitLinhaDadosPorcentagem()
        {
            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.DataFormat = Format.GetFormat("0.00%");

            return s;
        }

        public ICellStyle InitLinhaDadosValor2()
        {
            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.DataFormat = Format.GetFormat(@"_(R$* #,##0.00_);_($* (#,##0.00);_(R$* ""-""??_);_(@_)");

            return s;
        }

        public ICellStyle InitLinhaDadosValor3()
        {
            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.DataFormat = Format.GetFormat(@"_(R$* #,###0.000_);_($* (#,###0.000);_(R$* ""-""??_);_(@_)");

            return s;
        }

        public ICellStyle InitLinhaDadosValor4()
        {
            var s = (XSSFCellStyle) Workbook.CreateCellStyle();
            s.BorderBottom = BorderStyle.Thin;
            s.SetBottomBorderColor(new XSSFColor(Color.Preto));
            s.BorderTop = BorderStyle.Thin;
            s.SetTopBorderColor(new XSSFColor(Color.Preto));
            s.BorderLeft = BorderStyle.Thin;
            s.SetLeftBorderColor(new XSSFColor(Color.Preto));
            s.BorderRight = BorderStyle.Thin;
            s.SetRightBorderColor(new XSSFColor(Color.Preto));
            s.Alignment = HorizontalAlignment.Center;
            s.VerticalAlignment = VerticalAlignment.Center;
            s.DataFormat = Format.GetFormat(@"_(R$* #,####0.0000_);_($* (#,####0.0000);_(R$* ""-""??_);_(@_)");

            return s;
        }
    }
}