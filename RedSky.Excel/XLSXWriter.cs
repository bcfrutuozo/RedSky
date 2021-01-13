using System;
using System.Data;
using System.Globalization;
using System.IO;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using RedSky.Domain.Entities;
using RedSky.Excel.Interfaces;

namespace RedSky.Excel
{
    public class XLSXWriter : IWriter
    {
        public XLSXWriter(Demonstrativo demonstrativo, IStyle style)
        {
            var x = new XSSFWorkbook();
            POIXMLProperties xmlProps = x.GetProperties();    
            CoreProperties coreProps =  xmlProps.CoreProperties;
            coreProps.Creator =  @"Bruno Corrêa Frutuozo";

            Workbook = x;
            Style = style;
            Style.Workbook = Workbook;
            
            Demonstrativo = demonstrativo;
        }

        private Demonstrativo Demonstrativo { get; }
        public int Line { get; set; }
        public IWorkbook Workbook { get; set; }
        public IStyle Style { get; set; }

        public void Inicializar()
        {
            // Carrega todos os estilos do reporting.
            Style.Init();
            Workbook.CreateSheet("Rateio");
        }

        public void GerarCabecalho()
        {
            var formatoCabecalho = new CultureInfo("pt-BR", false).TextInfo;

            var planilha = Workbook.GetSheet("Rateio");

            //TODO: PINTAR FUNDO DA PLANILHA DE BRANCO.

            for (Line = 0; Line < 3; Line++)
            {
                planilha.CreateRow(Line);
                for (var j = 0; j < 7; j++)
                {
                    planilha.GetRow(Line).CreateCell(j);
                    if (Line == 0)
                        planilha.GetRow(Line).Cells[j].CellStyle = Style.CabecalhoRateioNome;
                    else
                        planilha.GetRow(Line).Cells[j].CellStyle = Style.CabecalhoRateioInfo;
                }

                switch (Line)
                {
                    // Escreve a razão social no cabeçalho do rateio
                    case 0:
                        planilha.GetRow(Line).Cells[0]
                            .SetCellValue(formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.RazaoSocial));
                        break;
                    // Escreve o registro do cliente no cabeçalho do rateio.
                    case 1:
                        // Para pessoa física.
                        if (Demonstrativo.Cliente.CPFCNPJ.Length == 11)
                            planilha.GetRow(Line).Cells[0]
                                .SetCellValue(
                                    $@"CPF: {Convert.ToUInt64(Demonstrativo.Cliente.CPFCNPJ):000\.000\.000\-00}");
                        // Para empresas.
                        else if (Demonstrativo.Cliente.CPFCNPJ.Length == 14)
                            planilha.GetRow(Line).Cells[0]
                                .SetCellValue(
                                    $@"CNPJ: {Convert.ToUInt64(Demonstrativo.Cliente.CPFCNPJ):00\.000\.000\/0000\-00}");
                        // Sem máscara caso a quantidade de digitos não seja 11 ou 14.
                        else
                            planilha.GetRow(Line).Cells[0].SetCellValue(Demonstrativo.Cliente.CPFCNPJ);
                        break;
                    case 2:
                        // Preenche a linha do endereço COM formatada com dados de complemento.
                        if (string.IsNullOrEmpty(Demonstrativo.Cliente.Complemento))

                            planilha.GetRow(Line).Cells[0].SetCellValue(
                                $@"Endereço: {formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.TipoLogradouro.Descricao)} {
                                        formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.Logradouro)
                                    }, Nº {Demonstrativo.Cliente.Numero}, {
                                        formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.TipoBairro.Descricao)
                                    } {formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.Bairro)} - {
                                        formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.Cidade.Nome)
                                    }/{Demonstrativo.Cliente.Cidade.Estado.Sigla} - CEP: {
                                        Convert.ToUInt64(Demonstrativo.Cliente.CEP):00\.000\-000}");
                        // Preenche a linha do endereço SEM formatada com dados de complemento.
                        else
                            planilha.GetRow(Line).Cells[0].SetCellValue(
                                $@"Endereço: {formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.TipoLogradouro.Descricao)} {
                                        formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.Logradouro)
                                    }, Nº {Demonstrativo.Cliente.Numero}, {
                                        formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.Complemento)
                                    }, {formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.TipoBairro.Descricao)} {
                                        formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.Bairro)
                                    } - {formatoCabecalho.ToTitleCase(Demonstrativo.Cliente.Cidade.Nome)}/{
                                        Demonstrativo.Cliente.Cidade.Estado.Sigla
                                    } - CEP: {Convert.ToUInt64(Demonstrativo.Cliente.CEP):00\.000\-000}");
                        break;
                }

                var mergido = new CellRangeAddress(Line, Line, 0, 6);
                planilha.AddMergedRegion(mergido);
            }

            Line--;
        }

        public Faturamento Ratear(Servico s, DataTable data)
        {
            var nfdados = new Faturamento
            {
                Descritivo = s.Descricao,
                ValorUnitario = s.Valor
            };

            var stg = s.Valor.ToString("#.####", CultureInfo.InvariantCulture);
            var digitosValorUnitario = stg.Substring(stg.IndexOf(".") + 1).Length;

            // Caso não exista rateio.
            if (data.Rows.Count == 0)
                return null;

            var planilha = Workbook.GetSheet("Rateio");
            Line++;
            var linha = planilha.CreateRow(Line);

            CellRangeAddress mergido;

            // Descritivo do Serviço
            if (string.IsNullOrEmpty(s.Codigo))
            {
                for (var j = 0; j < 7; j++)
                {
                    var celula = planilha.GetRow(Line).CreateCell(j);
                    celula.CellStyle = Style.DescritivoServico;
                }

                linha.Cells[0].SetCellValue(s.Descricao);
                mergido = new CellRangeAddress(Line, Line, 0, 6);
                planilha.AddMergedRegion(mergido);
            }
            else
            {
                for (var j = 0; j < 7; j++)
                {
                    var celula = planilha.GetRow(Line).CreateCell(j);
                    celula.CellStyle = Style.DescritivoServico;
                }

                linha.Cells[0].SetCellValue("Código do Serviço: " + s.Codigo);
                linha.Cells[2].SetCellValue(s.Descricao);
                mergido = new CellRangeAddress(Line, Line, 0, 1);
                planilha.AddMergedRegion(mergido);
                mergido = new CellRangeAddress(Line, Line, 2, 6);
                planilha.AddMergedRegion(mergido);
            }

            Line++;
            planilha.CreateRow(Line);
            var inicioGrupo = Line;

            // Cabeçalho do Serviço
            for (var j = 0; j < 7; j++)
            {
                var celula = planilha.GetRow(Line).CreateCell(j);
                celula.CellStyle = Style.CabecalhoRodapeServico;
                switch (j)
                {
                    case 0:
                        celula.SetCellValue("Centro de Custo");
                        break;
                    case 1:
                        celula.SetCellValue("Departamento");
                        break;
                    case 2:
                        celula.SetCellValue("Quantidade");
                        break;
                    case 3:
                        celula.SetCellValue("Porcentagem");
                        break;
                    case 4:
                        celula.SetCellValue("Unidade");
                        break;
                    case 5:
                        celula.SetCellValue("Valor Unitário");
                        break;
                    case 6:
                        celula.SetCellValue("Subtotal");
                        break;
                }
            }

            // Linhas do Serviço
            for (var i = 0; i < data.Rows.Count; i++)
            {
                // Arredonda o valor de quantidade para eliminar decimais por se tratar de unidades.
                var qtde = Math.Round(Convert.ToDecimal(data.Rows[i]["Quantidade"]), 0, MidpointRounding.AwayFromZero);

                if (qtde == decimal.Zero)
                    continue;

                var cc = Convert.ToString(data.Rows[i]["CentroCusto"]);
                var dept = Convert.ToString(data.Rows[i]["Departamento"]);
                var pct = Convert.ToDecimal(data.Rows[i]["Porcentagem"]);

                Line++;
                planilha.CreateRow(Line);

                for (var j = 0; j < 7; j++)
                {
                    var celula = planilha.GetRow(Line).CreateCell(j);

                    switch (j)
                    {
                        case 0: // Centro de Custo
                            celula.CellStyle = Style.LinhaDados;
                            celula.SetCellValue(cc);
                            break;
                        case 1: // Departamento
                            celula.CellStyle = Style.LinhaDados;
                            celula.SetCellValue(dept);
                            break;
                        case 2: // Quantidade
                            if (qtde % 1 == 0)
                                celula.CellStyle = Style.LinhaDadosQuantidade;
                            else
                                celula.CellStyle = Style.LinhaDadosQuantidade2;
                            celula.SetCellValue(Convert.ToDouble(qtde));
                            nfdados.Quantidade += qtde;
                            break;
                        case 3: // Porcentagem
                            celula.SetCellType(CellType.Numeric);
                            celula.CellStyle = Style.LinhaDadosPorcentagem;
                            celula.SetCellValue(Convert.ToDouble(pct));
                            break;
                        case 4: // Unidade
                            celula.CellStyle = Style.LinhaDados;
                            celula.SetCellValue(s.Unidade.Descricao);
                            break;
                        case 5: // Valor Unitário
                            if (digitosValorUnitario < 3)
                                celula.CellStyle = Style.LinhaDadosValor2;
                            else if (digitosValorUnitario == 3)
                                celula.CellStyle = Style.LinhaDadosValor3;
                            else
                                celula.CellStyle = Style.LinhaDadosValor4;
                            celula.SetCellValue(Convert.ToDouble(s.Valor));
                            break;
                        case 6: // Subtotal
                            var vTotal = (qtde * s.Valor);  // NÃO SE PODE ARREDONDAR AQUI PARA NÃO SE TER PROBLEMA COM VALOR UNITARIO NO CAMPO DA NF
                            celula.CellStyle = Style.LinhaDadosValor2;
                            celula.SetCellValue(Convert.ToDouble(vTotal));
                            nfdados.ValorTotal += vTotal; /////
                            break;
                    }
                }
            }

            Line++;
            planilha.CreateRow(Line);
            var fimGrupo = Line;

            // Rodapé do Serviço
            for (var j = 0; j < 7; j++)
            {
                var celula = planilha.GetRow(Line).CreateCell(j);
                celula.CellStyle = Style.CabecalhoRodapeServico;
                switch (j)
                {
                    case 0:
                        celula.SetCellValue("TOTAL");
                        break;
                    case 2:
                        celula.SetCellValue(Convert.ToDouble(nfdados.Quantidade));
                        celula.CellStyle = Style.RodapeServicoQuantidade;
                        break;
                    case 6:
                        celula.SetCellValue(Convert.ToDouble(nfdados.ValorTotal));
                        celula.CellStyle = Style.RodapeServicoValor;
                        break;
                }
            }

            planilha.GroupRow(inicioGrupo, fimGrupo);

            return nfdados;
        }

        public void InserirDados(string sheetName, DataTable data)
        {
            if (data.Rows.Count == 0)
                return;

            var planilha = Workbook.CreateSheet(sheetName);

            for (var i = -1; i < data.Rows.Count; i++)
            {
                planilha.CreateRow(i + 1);
                for (var j = 0; j < data.Columns.Count; j++)
                {
                    // Cria as colunas dos dados obtidos.
                    var celula = planilha.GetRow(i + 1).CreateCell(j);
                    celula.SetCellType(CellType.String);

                    // Escreve cabeçalho dos dados.
                    if (i == -1)
                    {
                        celula.CellStyle = Style.CabecalhoDados;
                        celula.SetCellValue(data.Columns[j].ColumnName);
                    }
                    // Escreve os dados.
                    else
                    {
                        celula.CellStyle = Style.LinhaDados;
                        celula.SetCellValue(data.Rows[i][j].ToString());
                    }
                }
            }

            GC.Collect();
        }

        public void GerarRodape(decimal valorTotal, decimal valorMinimo = 0.00m)
        {
            Line++;

            var planilha = Workbook.GetSheet("Rateio");

            var i = 1;
            // Cliente com valor minimo
            if (valorMinimo > valorTotal)
                i = 0;

            for (; i < 2; i++, Line++)
            {
                var linha = planilha.CreateRow(Line);
                for (var j = 0; j < 7; j++)
                {
                    var celula = linha.CreateCell(j);
                    celula.CellStyle = Style.RodapeRateio;
                    switch (j)
                    {
                        case 0:
                            celula.SetCellValue(i == 0
                                ? @"Valor de Faturamento Mínimo"
                                : @"Valor Total dos Serviços Prestados");
                            break;
                        case 6:
                            celula.CellStyle = Style.RodapeRateioValor;
                            celula.SetCellValue(i == 0 ? Convert.ToDouble(valorMinimo) : Convert.ToDouble(valorTotal));
                            break;
                    }
                }

                var mergido = new CellRangeAddress(Line, Line, 0, 5);
                planilha.AddMergedRegion(mergido);
            }
        }

        public void Finalizar()
        {
            // Auto ajustar colunas
            for (var i = 0; i < Workbook.NumberOfSheets; i++)
            {
                var planilha = Workbook.GetSheetAt(i);
                int columnNumber = planilha.GetRow(0).LastCellNum;
                for (var j = 0; j < columnNumber; j++)
                {
                    planilha.AutoSizeColumn(j);
                    GC.Collect();
                    var prior = planilha.GetColumnWidth(j);
                    if (prior >= 64768)
                        planilha.SetColumnWidth(j, 65280);
                    else
                        planilha.SetColumnWidth(j, prior + 512);
                }
            }
        }

        public void Save(string path)
        {
            // Salva fatura na saída principal.
            using (var fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            {
                Workbook.Write(fs);
            }

            Workbook.Close();
        }
    }
}