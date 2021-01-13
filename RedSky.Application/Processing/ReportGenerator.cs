using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RedSky.Application.Processing.Interfaces;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.Services;
using RedSky.Excel;
using RedSky.Excel.Interfaces;
using RedSky.Infrastructure.Data.Base;
using RedSky.Utilities;

namespace RedSky.Application.Processing
{
    public class ReportGenerator : IReportGenerator
    {
        private AccountingPeriod AccoutingPeriod;
        private readonly IConexaoBancoService ConexaoBancoService;
        private Demonstrativo Demonstrativo;
        private IWriter ExcelGenerator;
        private Action<int, string> OnProgressChanged;
        private string OutputPath;
        private IList<Servico> Servicos;
        private int TotalTasks;
        private float ProcessedTasks;
        public Fatura Fatura { get; private set; }
        private string FileName => Path.GetFileNameWithoutExtension(OutputPath);
        private IList<Faturamento> Faturamentos;

        public ReportGenerator(IConexaoBancoService conexaoBancoService)
        {
            ConexaoBancoService = conexaoBancoService;
        }

        public Fatura Execute(Fatura fatura)
        {
            ExcelGenerator = new XLSXWriter(fatura.Demonstrativo, new Style());
            AccoutingPeriod = new AccountingPeriod(fatura.Competencia);
            Faturamentos = new List<Faturamento>();

            Fatura = fatura;
            Demonstrativo = fatura.Demonstrativo;
            Servicos = fatura.Demonstrativo.Servicos.ToList();
            TotalTasks = 4; // Inicializar + Gerar Cabeçalho + Gerar Rodapé + Finalizar
            TotalTasks += Servicos.Count; // Quantidade de serviços

            ProcessedTasks = 1;

            // Prepara a saída do arquivo para realizar o armazenamento da fatura no diretório correto.
            if (string.IsNullOrEmpty(Demonstrativo.Departamento))
                OutputPath = Path.Combine(fatura.Demonstrativo.Cliente.Empresa.CaminhoRelatorio,
                    $"CLIENTE-{Demonstrativo.Cliente.Sigla.Split('-')[0]}",
                    "Faturamento",
                    AccoutingPeriod.Year.ToString(),
                    $"{AccoutingPeriod.Month:D2} - {AccoutingPeriod.FullMonthName}",
                    $"FAT_{Demonstrativo.Cliente.Sigla}_{new string(Demonstrativo.Cliente.CPFCNPJ.Where(char.IsDigit).ToArray())}_{AccoutingPeriod.Month:D2}_{AccoutingPeriod.Year}.xlsx");
            else
                OutputPath = Path.Combine(fatura.Demonstrativo.Cliente.Empresa.CaminhoRelatorio,
                    $"CLIENTE-{Demonstrativo.Cliente.Sigla.Split('-')[0]}",
                    "Faturamento",
                    AccoutingPeriod.Year.ToString(),
                    $"{AccoutingPeriod.Month:D2} - {AccoutingPeriod.FullMonthName}",
                    Demonstrativo.Cliente.Sigla.Split('-')[1],
                    $"FAT_{Demonstrativo.Cliente.Sigla}_{Demonstrativo.Departamento.Replace(@"\", string.Empty).Replace(@"/", string.Empty)}_{AccoutingPeriod.Month:D2}_{AccoutingPeriod.Year}.xlsx");

            // Cria o diretório final da fatura caso o mesmo não exista.
            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath) ?? throw new InvalidOperationException());

            if (File.Exists(OutputPath))
                File.Delete(OutputPath);

            if (Servicos.Count == 0 && Demonstrativo.ValorMinimo == 0)
                throw new ApplicationException(
                    @"O demonstrativo da fatura está com erro. O mesmo não possuí serviços cadastrados e não pode ser processado como fixo pois o valor de faturamento mínimo é 0.");

            ExcelGenerator.Inicializar();
            //this.Callback.Send(new CallbackDTO
            //{
            //    Message =
            //        $@"{DateTime.Now} | {this.Demonstrativo.Id} - {this.Demonstrativo.Nome} -> Iniciada a geração da fatura. Os objetos com os estilos foram instanciados com sucesso.",
            //    Progress = Convert.ToInt32(ProcessedTasks++ / TotalTasks * 100)
            //});

            ExcelGenerator.GerarCabecalho();
            //this.Callback.Send(new CallbackDTO
            //{
            //    Message =
            //        $@"{DateTime.Now} | {this.Demonstrativo.Id} - {this.Demonstrativo.Nome} -> Cabeçalho da fatura gerado. Prosseguindo para a inclusão dos serviços.",
            //    Progress = Convert.ToInt32(ProcessedTasks++ / TotalTasks * 100)
            //});

            var valorTotalFatura = ProcessarServicos();

            //this.Callback.Send(new CallbackDTO
            //{
            //    Message =
            //        $@"{DateTime.Now} | {this.Demonstrativo.Id} - {this.Demonstrativo.Nome} -> Iniciando processo de geração do rodapé verificando se a fatura será computada com valor de faturamento mínimo.",
            //    Progress = Convert.ToInt32((ProcessedTasks / TotalTasks) * 100)
            //});

            ExcelGenerator.GerarRodape(valorTotalFatura, Demonstrativo.ValorMinimo);

            //this.Callback.Send(new CallbackDTO
            //{
            //    Message =
            //        $@"{DateTime.Now} | {this.Demonstrativo.Id} - {this.Demonstrativo.Nome} -> Rodapé da fatura gerado com sucesso.",
            //    Progress = Convert.ToInt32((ProcessedTasks++ / TotalTasks) * 100)
            //});

            //this.Callback.Send(new CallbackDTO
            //{
            //    Message =
            //        $@"{DateTime.Now} | {this.Demonstrativo.Id} - {this.Demonstrativo.Nome} -> Finalizando e formatando a fatura.",
            //    Progress = Convert.ToInt32((ProcessedTasks / TotalTasks) * 100)
            //});

            ExcelGenerator.Finalizar();

            //this.Callback.Send(new CallbackDTO
            //{
            //    Message =
            //        $@"{DateTime.Now} | {this.Demonstrativo.Id} - {this.Demonstrativo.Nome} -> Fatura finalizada.",
            //    Progress = Convert.ToInt32((ProcessedTasks++ / TotalTasks) * 100)
            //});

            ExcelGenerator.Save(OutputPath);

            var comp = string.Concat(AccoutingPeriod.Month.ToString("D2"), AccoutingPeriod.Year.ToString());

            if (Fatura.Id == 0)
            {
                Fatura.IdDemonstrativo = Demonstrativo.Id;
                Fatura.Competencia = comp;
                Fatura.IdCliente = Demonstrativo.Cliente.Id;
            }

            Fatura.NomeArquivo = FileName;
            Fatura.ValorBruto = Faturamentos.Sum(obj => obj.ValorTotal);

            if (Fatura.ValorBruto <= Demonstrativo.ValorMinimo)
            {
                Fatura.ValorBruto = Demonstrativo.ValorMinimo;
                Fatura.Faturamentos = new List<Faturamento>
                {
                    new Faturamento
                    {
                        Descritivo = "Serviços Prestados",
                        Quantidade = 1.0000m,
                        ValorTotal = Demonstrativo.ValorMinimo,
                        ValorUnitario = Demonstrativo.ValorMinimo,
                        IdFatura = Fatura.Id
                    }
                };
            }
            else
            {
                foreach (var f in Faturamentos) f.IdFatura = Fatura.Id;

                Fatura.Faturamentos = Faturamentos;
            }

            Fatura.ValorINSS = Fatura.ValorBruto * (Fatura.AliquotaINSS / 100);
            Fatura.ValorISS = Fatura.ValorBruto * (Fatura.AliquotaISS / 100);
            Fatura.ValorCOFINS = Fatura.ValorBruto * (Fatura.AliquotaCOFINS / 100);
            Fatura.ValorPIS = Fatura.ValorBruto * (Fatura.AliquotaPIS / 100);
            Fatura.ValorIR = Fatura.ValorBruto * (Fatura.AliquotaIR / 100);
            Fatura.ValorCSLL = Fatura.ValorBruto * (Fatura.AliquotaCSLL / 100);
            Fatura.ValorLiquido = Fatura.ValorBruto - Fatura.ValorINSS - Fatura.ValorCOFINS - Fatura.ValorPIS -
                                  Fatura.ValorIR - Fatura.ValorCSLL;

            Fatura.ValorISS = Fatura.ValorBruto * (Fatura.AliquotaISS / 100);

            Fatura.IsFaturado = false;
            Fatura.IsProcessado = true;

            return Fatura;
        }

        private decimal ProcessarServicos()
        {
            var valorTotalFatura = decimal.Zero;

            if (Servicos.Count > 0)
            {
                foreach (var s in Servicos.OrderBy(s => s.Ordem))
                {
                    // Cria a conexão para cada serviço de acordo com as informações fornecidas na configuração da empresa.
                    var mapper = new DBMapper(ConexaoBancoService.GetById(s.IdConexaoBanco, c => c.DBProvider));

                    // Insere a planilha de dados
                    if (!string.IsNullOrWhiteSpace(s.NomePlanilha))
                        ExcelGenerator.InserirDados(s.NomePlanilha,
                            mapper.Query(s.QueryDados, AccoutingPeriod.Start, AccoutingPeriod.End));

                    // Pula o serviço e vai para o próximo caso somente a query de dados esteja preenchida.
                    if (string.IsNullOrEmpty(s.QueryRateio)) continue;

                    var servicoComputado = ExcelGenerator.Ratear(s,
                        //mapper.Query(s.QueryRateio, AccoutingPeriod.Start, AccoutingPeriod.End));
                        mapper.Query(s.QueryRateio, AccoutingPeriod.Start, AccoutingPeriod.End));

                    if (servicoComputado == null) continue;
                    valorTotalFatura += servicoComputado.ValorTotal;

                    // Transforma o valor obtido no valor unitário do serviço para futura emissão de NF.
                    Faturamentos.Add(servicoComputado);

                    //this.Callback.Send(new CallbackDTO
                    //{
                    //    Message = $@"Computado o serviço ""{s.Descricao}"".",
                    //    Progress = Convert.ToInt32((ProcessedTasks++ / TotalTasks) * 100)
                    //});
                }
            }
            else
            {
                Faturamentos.Add(new Faturamento
                {
                    Descritivo = "Serviços Prestados",
                    Quantidade = 1.0000m,
                    ValorTotal = Demonstrativo.ValorMinimo,
                    ValorUnitario = Demonstrativo.ValorMinimo,
                    IdFatura = Fatura.Id
                });

                valorTotalFatura = Demonstrativo.ValorMinimo;
            }

            return valorTotalFatura;
        }
    }
}