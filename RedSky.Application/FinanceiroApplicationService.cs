using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using RedSky.Application.Interfaces;
using RedSky.Application.Processing.Interfaces;
using RedSky.Common.Exceptions;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.Services;
using RedSky.Utilities;

namespace RedSky.Application
{
    public class FinanceiroApplicationService : IFinanceiroApplicationService
    {
        private readonly ICertificadoDigitalService CertificadoDigitalService;
        private readonly IDeducaoRPSService DeducaoRPSService;
        private readonly IFaturaService FaturaService;
        private readonly IFaturamentoService FaturamentoService;
        private readonly IFilialService FilialService;
        private readonly IItemRPSService ItemRPSService;
        private readonly ILoteRPSService LoteRPSService;
        private readonly INotaFiscalService NotaFiscalService;
        private readonly IReportGenerator ReportGenerator;
        private readonly IRPSService RPSService;

        public FinanceiroApplicationService(
            ICertificadoDigitalService certificadoDigitalService,
            IDeducaoRPSService deducaoRPSService,
            IReportGenerator reportGenerator,
            IFaturaService faturaService,
            IFaturamentoService faturamentoService,
            IFilialService filialService,
            IItemRPSService itemRPSService,
            ILoteRPSService loteRPSService,
            INotaFiscalService notaFiscalService,
            IRPSService rprService)
        {
            CertificadoDigitalService = certificadoDigitalService;
            DeducaoRPSService = deducaoRPSService;
            FaturaService = faturaService;
            FaturamentoService = faturamentoService;
            FilialService = filialService;
            ItemRPSService = itemRPSService;
            LoteRPSService = loteRPSService;
            NotaFiscalService = notaFiscalService;
            ReportGenerator = reportGenerator;
            RPSService = rprService;
        }

        #region EMail

        public void SendFaturaEmail(int id)
        {
            var fatura = FaturaService.GetById_SENDEMAIL(id);

            #region Email construction

            var p = new AccountingPeriod(fatura.Competencia.Substring(0, 2).PadLeft(2, '0') + "/" +
                                         fatura.Competencia.Substring(2, 4));

            var htmlBody = fatura.Demonstrativo.MensagemEmail.Replace("@NOMEDEMONSTRATIVO", fatura.Demonstrativo.Nome)
                .Replace("@COMPETENCIA", p.FullPeriod);

            LinkedResource res = null;

            if (htmlBody.Contains("@ASSINATURA"))
            {
                if (fatura.Prestador.Empresa.LogoEmail.Length != 0)
                    res =
                        new LinkedResource(new MemoryStream(fatura.Prestador.Empresa.LogoEmail),
                            MediaTypeNames.Image.Jpeg)
                        {
                            ContentId = Guid.NewGuid().ToString()
                        };

                if (res != null)
                    htmlBody = htmlBody.Replace("@ASSINATURA", "<img src='cid:" + res.ContentId + @"'/>");
            }

            var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

            if (res != null)
                alternateView.LinkedResources.Add(res);

            var msg = new MailMessage
            {
                From = new MailAddress(fatura.Prestador.Empresa.Email),
                Subject = fatura.Demonstrativo.AssuntoEmail.Replace("@NOMEDEMONSTRATIVO", fatura.Demonstrativo.Nome)
                    .Replace("@COMPETENCIA", p.FullPeriod),
                Attachments = { new Attachment(Fatura.GetBillingFullName(fatura)) },
                SubjectEncoding = Encoding.GetEncoding("ISO-8859-1"),
                BodyEncoding = Encoding.GetEncoding("ISO-8859-1"),
                Priority = MailPriority.Normal,
                IsBodyHtml = true,
                AlternateViews = { alternateView }
            };

            msg.Bcc.Add(fatura.Prestador.Empresa.Email);
            msg.To.Add(fatura.Demonstrativo.DestinatariosEmail.Replace(" ", ",").Replace(";", ","));

            #endregion

            Email.Send(msg, fatura.Prestador.Empresa.GetSmtpClientConfiguration());
        }

        public void SendNotaFiscalEmail(int idFilial, long numeroNF)
        {
            var nf = NotaFiscalService.GetByIdFilial_NumeroNF_SENDEMAIL(idFilial, numeroNF);

            #region Email construction

            var baseHtml =
                @"Prezado cliente.<br />Você está recebendo a fatura de @DESCRITIVONF<br /><br />Segue o arquivo anexo, se quiser visualizá-la para verificar a veracidade, acesse o link a seguir:<br />@LINKNF<br /><br /><strong>Estamos à disposição para qualquer dúvida ou problema encontrado.</strong><br />Sem mais.<br /><br />Cordialmente,<br />@ASSINATURA";

            var htmlBody = baseHtml.Replace("@DESCRITIVONF", nf.RPS.DescricaoRPS).Replace(Environment.NewLine, "<br />")
                .Replace("@LINKNF", nf.Link);

            var startImportante = htmlBody.IndexOf("IMPORTANTE");
            if (startImportante != -1)
            {
                var fimImportante = htmlBody.IndexOf("<br />", startImportante);

                var bold =
                    $"<br /><strong>{htmlBody.Substring(startImportante, fimImportante - startImportante)}</strong>";
                htmlBody = htmlBody.Replace(htmlBody.Substring(startImportante, fimImportante - startImportante), bold);
            }

            htmlBody = $@"
<html>
    <head>
        <meta http-equiv=""Content - Type"" content=""text / html; charset = us - ascii"">
    </head>
    <body>
        <span style=""font-family: Calibri; font-size: 11pt;"">
            {htmlBody}
        </span>
    </body>
</html>".Replace("<br /><br /><br />", "<br /><br />");

            LinkedResource res = null;

            if (htmlBody.Contains("@ASSINATURA"))
            {
                if (nf.RPS.Fatura.Prestador.Empresa.LogoEmail.Length != 0)
                    res =
                        new LinkedResource(new MemoryStream(nf.RPS.Fatura.Prestador.Empresa.LogoEmail),
                            MediaTypeNames.Image.Jpeg)
                        {
                            ContentId = Guid.NewGuid().ToString()
                        };

                if (res != null)
                    htmlBody = htmlBody.Replace("@ASSINATURA", "<img src='cid:" + res.ContentId + @"'/>");
            }

            var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

            if (res != null)
                alternateView.LinkedResources.Add(res);

            MailMessage msg;
            if (nf.RPS.Fatura.IdDemonstrativo.HasValue)
                msg = new MailMessage
                {
                    From = new MailAddress(nf.RPS.Fatura.Prestador.Empresa.Email),
                    Subject = @"Faturamento de Serviços Prestados - @NOMEDEMONSTRATIVO".Replace("@NOMEDEMONSTRATIVO",
                        nf.RPS.Fatura.Identificacao),
                    Attachments =
                    {
                        new Attachment(Fatura.GetBillingFullName(nf.RPS.Fatura)),
                        new Attachment(NotaFiscal.GetInvoiceFullName(nf))
                    },
                    SubjectEncoding = Encoding.GetEncoding("ISO-8859-1"),
                    BodyEncoding = Encoding.GetEncoding("ISO-8859-1"),
                    Priority = MailPriority.Normal,
                    IsBodyHtml = true,
                    AlternateViews = { alternateView }
                };
            else
            {
                msg = new MailMessage
                {
                    From = new MailAddress(nf.RPS.Fatura.Prestador.Empresa.Email),
                    Subject = @"Faturamento de Serviços Prestados - @NOMEDEMONSTRATIVO".Replace("@NOMEDEMONSTRATIVO",
                        nf.RPS.Fatura.Identificacao),
                    Attachments =
                    {
                        new Attachment(NotaFiscal.GetInvoiceFullName(nf))
                    },
                    SubjectEncoding = Encoding.GetEncoding("ISO-8859-1"),
                    BodyEncoding = Encoding.GetEncoding("ISO-8859-1"),
                    Priority = MailPriority.Normal,
                    IsBodyHtml = true,
                    AlternateViews = { alternateView }
                };
            }

            var caminhoBoleto = Path.Combine(Path.GetDirectoryName(NotaFiscal.GetInvoiceFullName(nf)),
                Path.GetFileNameWithoutExtension(NotaFiscal.GetInvoiceFullName(nf)) + " - Boleto.pdf");
            if (File.Exists(caminhoBoleto))
                msg.Attachments.Add(new Attachment(caminhoBoleto));

            msg.Bcc.Add(nf.RPS.Fatura.Prestador.Empresa.Email);

            // Adiciona o e-mail do Financeiro para a EcoStorage.
            if (nf.RPS.Fatura.IdFilial == 2)
                msg.CC.Add("financeiro@ecostorage.com.br");

            if(nf.RPS.Fatura.IdDemonstrativo.HasValue)
                msg.To.Add(nf.RPS.Fatura.Demonstrativo.DestinatariosEmail.Replace(" ", ",").Replace(";", ","));
            else
                msg.To.Add(nf.RPS.Fatura.Tomador.EmailsEnvio.Replace(" ", ",").Replace(";", ","));
            #endregion

            Email.Send(msg, nf.RPS.Fatura.Prestador.Empresa.GetSmtpClientConfiguration());
        }

        #endregion

        #region Fatura

        public Fatura AddFatura(Fatura fatura)
        {
            return FaturaService.Add(fatura).FirstOrDefault();
        }

        public Fatura GetFaturaById_Update(Int32 id)
        {
            return FaturaService.GetById_UPDATEVIEW(id);
        }

        public IEnumerable<Fatura> GetAllFaturaByEmpresa_Mes_Ano(Int32 idEmpresa, Int32 month, Int32 year)
        {
            return FaturaService.GetAllFaturaByEmpresa_Mes_Ano_VIEW(idEmpresa, month, year);
        }

        public Fatura UpdateFatura(Fatura fatura)
        {
            return FaturaService.Update(fatura).FirstOrDefault();
        }

        public Fatura DeleteFatura(int idFatura, bool deleteFaturamentos)
        {
            var lstFaturamentos = FaturamentoService.GetList(f => f.IdFatura == idFatura).ToArray();

            if (lstFaturamentos.Length > 0)
            {
                if (deleteFaturamentos)
                    FaturamentoService.Delete(lstFaturamentos);
                else
                    return FaturaService.GetById(idFatura);  // Retorna o mesmo objeto da fatura sem alteração nenhuma.
            }

            return FaturaService.Delete(FaturaService.GetById(idFatura)).FirstOrDefault();
        }

        public Fatura EmitirFatura(Int32 id)
        {
            var fatura = FaturaService.GetById_PROCESSING(id);

            // Delete todos os faturamentos para reprocessar os dados, caso a fatura já tenha sido processada anteriormente.
            FaturamentoService.Delete(FaturamentoService.GetFaturamentosPorFatura(id).ToArray());

            // Processa a fatura.
            fatura = ReportGenerator.Execute(fatura);

            // Zera as subentidades para atualização.
            fatura.Demonstrativo = null;

            // Atualiza a fatura e os faturamentos
            FaturamentoService.Add(fatura.Faturamentos.ToArray());
            fatura.Faturamentos = null;
            fatura.IsProcessado = true;
            fatura.IsEdit = false; // Coloca a flag de atualização manual para negativo, pois foi recalculada pelo sistema.
            FaturaService.Update(fatura);

            return fatura;
        }

        public IEnumerable<Fatura> DuplicarCompetencia(Int32 idEmpresa, Int32 monthSource, Int32 yearSource, Int32 monthTarget, Int32 yearTarget)
        {
            var lstFatura = FaturaService.GetAllFaturaByEmpresa_Mes_Ano_COPY(idEmpresa, monthSource, yearSource).ToArray();

            foreach (var fatura in lstFatura)
            {
                DateTime competenciaChanger = new DateTime(Convert.ToInt32(fatura.Competencia.Substring(2, 4)),
                    Convert.ToInt32(fatura.Competencia.Substring(0, 2)), 1);

                competenciaChanger = competenciaChanger.AddMonths(1);
                fatura.Competencia = competenciaChanger.ToString("MMyyyy");

                fatura.DataVencimento = fatura.DataVencimento.AddMonths(1);
                if (fatura.DataVencimento.DayOfWeek == DayOfWeek.Saturday)
                    fatura.DataVencimento = fatura.DataVencimento.AddDays(-1);

                if (fatura.DataVencimento.DayOfWeek == DayOfWeek.Sunday)
                    fatura.DataVencimento = fatura.DataVencimento.AddDays(1);

                fatura.Mes = monthTarget;
                fatura.Ano = yearTarget;

                fatura.ValorINSS = fatura.ValorLiquido = fatura.ValorIR = fatura.ValorPIS = fatura.ValorRecebido =
                    fatura.ValorCOFINS = fatura.ValorBruto =
                        fatura.ValorDedutivel = fatura.ValorCSLL = fatura.ValorISS = decimal.Zero;

                fatura.DataRecebimento = null;
                fatura.Faturamentos = null;
                fatura.NomeArquivo = null;
                fatura.Id = 0; // Nula o ID para adicionar novamente.
                fatura.IsProcessado = fatura.IsFaturado = fatura.IsEdit = false;
            }

            return FaturaService.Add(lstFatura);
        }

        public Fatura CancelarRPS(Int32 idRPS)
        {
            var objRps = RPSService.GetById(idRPS, rp => rp.ItensRPS, rp => rp.DeducaoRPS);

            if (objRps == null)
                return null;

            var objFat = FaturaService.GetById(objRps.IdFatura);

            ItemRPSService.Delete(ItemRPSService.GetList(it => it.IdRPS == idRPS).ToArray());
            DeducaoRPSService.Delete(DeducaoRPSService.GetList(dd => dd.IdRPS == idRPS).ToArray());

            objRps.ItensRPS = null;
            objRps.DeducaoRPS = null;
            RPSService.Delete(objRps);

            objFat.IsFaturado = false;

            return FaturaService.Update(objFat).FirstOrDefault();
        }

        public Fatura DeleteFaturamentosFromFatura(Int32 id)
        {
            FaturamentoService.Delete(FaturamentoService.GetList(fat => fat.IdFatura == id).ToArray());

            var objFatura = FaturaService.GetById(id);

            objFatura.ValorCOFINS = 0.00m;
            objFatura.ValorCSLL = 0.00m;
            objFatura.ValorINSS = 0.00m;
            objFatura.ValorIR = 0.00m;
            objFatura.ValorPIS = 0.00m;
            objFatura.ValorISS = 0.00m;

            objFatura.ValorBruto =
                objFatura.ValorLiquido = objFatura.ValorDedutivel = objFatura.ValorRecebido = 0.00m;

            objFatura.IsEdit = false;
            objFatura.IsProcessado = false;

            return FaturaService.Update(objFatura).FirstOrDefault();
        }

        public String GetFaturaNomeArquivo(Int32 id)
        {
            return Path.GetFileName(Fatura.GetBillingFullName(FaturaService.GetById(id,
                f => f.Demonstrativo,
                f => f.Demonstrativo.Cliente,
                f => f.Prestador,
                f => f.Prestador.Empresa)));
        }

        public Byte[] DownloadFatura(Int32 id)
        {
            var fileName = this.GetFaturaNomeArquivo(id);

            byte[] fileData = null;

            using (var fs = File.OpenRead(fileName))
            {
                var binaryReader = new BinaryReader(fs);
                fileData = binaryReader.ReadBytes((int)fs.Length);
            }

            return fileData;
        }

        #endregion

        #region Faturamento

        public Faturamento AddFaturamento(Faturamento faturamento, bool isUserEdit)
        {
            var fat = FaturamentoService.Add(faturamento).FirstOrDefault();
            RecalculateFaturaValues(FaturaService.GetById_CALCULATION(fat.IdFatura), isUserEdit);
            return fat;
        }

        public IEnumerable<Faturamento> AddFaturamento(IEnumerable<Faturamento> faturamentos, bool isUserEdit)
        {
            var fat = FaturamentoService.Add(faturamentos.ToArray());

            Stack<int> idFaturasRecalc = new Stack<Int32>();

            foreach (var faturamento in fat)
                if (!idFaturasRecalc.Contains(faturamento.IdFatura))
                    idFaturasRecalc.Push(faturamento.IdFatura);

            while (idFaturasRecalc.Count > 0)
                RecalculateFaturaValues(FaturaService.GetById_CALCULATION(idFaturasRecalc.Pop()), isUserEdit);

            return fat;
        }

        public Faturamento UpdateFaturamento(Faturamento faturamento, bool isUserEdit)
        {
            var fat = FaturamentoService.Update(faturamento).FirstOrDefault();
            RecalculateFaturaValues(FaturaService.GetById_CALCULATION(fat.IdFatura), isUserEdit);
            return fat;
        }

        public Faturamento DeleteFaturamento(Faturamento faturamento, bool isUserEdit)
        {
            var fat = FaturamentoService.Delete(faturamento).FirstOrDefault();
            RecalculateFaturaValues(FaturaService.GetById_CALCULATION(fat.IdFatura), isUserEdit);
            return fat;
        }

        public IEnumerable<Faturamento> DeleteFaturamento(IEnumerable<Faturamento> faturamentos, bool isUserEdit)
        {
            var fat = FaturamentoService.Delete(faturamentos.ToArray());

            Stack<int> idFaturasRecalc = new Stack<Int32>();

            foreach (var faturamento in fat)
                if (!idFaturasRecalc.Contains(faturamento.IdFatura))
                    idFaturasRecalc.Push(faturamento.IdFatura);

            while (idFaturasRecalc.Count > 0)
                RecalculateFaturaValues(FaturaService.GetById_CALCULATION(idFaturasRecalc.Pop()), isUserEdit);

            return fat;
        }

        public IEnumerable<Faturamento> GetListFaturamentoByIdFatura(Int32 idFatura)
        {
            return FaturamentoService.GetList(fat => fat.IdFatura == idFatura);
        }

        #endregion

        #region LoteRPS

        public LoteRPS EnviarLoteRPS(int idLoteRPS, bool synchronous)
        {
            var lote = LoteRPSService.GetById_GENERATEINVOICE(idLoteRPS);

            var cert = CertificadoDigitalService.GetLastValidCertificado(lote.IdFilial);

            long ultimoRPSRedSky = RPSService.GetHigherLongNumeroRPSByIdFatura(lote.IdFilial);

            if (!synchronous)
            {
                return LoteRPSService.EnviarLoteRPSAssincrono(lote, cert.Certificado, ultimoRPSRedSky);
            }

            lote = LoteRPSService.EnviarLoteRPSSincrono(lote, cert.Certificado, ultimoRPSRedSky);

            if (!lote.NumeroLote.HasValue)
                throw new InvalidBatchNumberException("Número de lote inválido.");

            // Atualiza os RPS do lote que foi enviado para processamento.
            foreach (var rps in lote.RPS)
            {
                rps.ItensRPS = null;
                rps.DeducaoRPS = null;
                rps.LoteRPS = null;

                if (lote.IdStatusLoteRPS != 1)
                {
                    rps.NumeroRPS = null;   // Invalida o número do RPS para evitar problemas com repetição.
                    rps.Assinatura = null;
                    var fatura = FaturaService.GetById(rps.IdFatura);
                    fatura.IsFaturado = false; //Zera o status de faturado para a fatura, pois teve problema.
                    FaturaService.Update(fatura);
                }

                RPSService.Update(rps);
            }

            if (lote.IdStatusLoteRPS == 1)  // SUCESSO
            {
                // Efetua uma consulta individual para cada NotaFiscal gerada na prefeitura e obtém os seus dados.
                var nfsPrefeitura = NotaFiscalService.ObterNotasPorLote(lote.Filial, lote.NumeroLote.Value, cert.Certificado).ToList();

                foreach (var nf in nfsPrefeitura)
                {
                    // Vincula a NotaFiscal ao seu respectivo RPS.
                    var rpsNf = RPSService.GetRPSPorNumeroEFilial(lote.IdFilial, nf.NumeroRPS,
                        f => f.Fatura);

                    nf.IdRPS = rpsNf.Id;
                    nf.RPS = rpsNf;
                    // Popula o campo com o nome do arquivo e número NF
                    nf.NomeArquivo = Path.GetFileNameWithoutExtension(NotaFiscal.GetInvoiceFullName(nf));
                    // Elimina o RPS da NF para remover o eager loading.
                    nf.RPS = null;

                    // Salva as informações da NotaFiscal no banco de dados.
                    NotaFiscalService.Add(nf);

                    // Efetua o download da NotaFiscal na pasta de configuração da empresa.
                        DownloadNFSe(lote.IdFilial, nf.NumeroNF);
                }
            }

            lote.RPS = null;
            lote.Filial = null;

            return LoteRPSService.Update(lote).First();
        }

        public void DownloadNFSeByIdLoteRPS(int idLoteRPS)
        {
            var lote = LoteRPSService.GetById_GENERATEINVOICE(idLoteRPS);
            var cert = CertificadoDigitalService.GetLastValidCertificado(lote.IdFilial);

            // Efetua uma consulta individual para cada NotaFiscal gerada na prefeitura e obtém os seus dados.
            var nfsPrefeitura = NotaFiscalService.ObterNotasPorLote(lote.Filial, lote.NumeroLote.Value, cert.Certificado).ToList();

            foreach (var nf in nfsPrefeitura)
            {
                // Vincula a NotaFiscal ao seu respectivo RPS.
                var rpsNf = RPSService.GetRPSPorNumeroEFilial(lote.IdFilial, nf.NumeroRPS,
                    f => f.Fatura);

                nf.IdRPS = rpsNf.Id;
                nf.RPS = rpsNf;
                // Popula o campo com o nome do arquivo e número NF
                nf.NomeArquivo = Path.GetFileNameWithoutExtension(NotaFiscal.GetInvoiceFullName(nf));
                // Elimina o RPS da NF para remover o eager loading.
                nf.RPS = null;

                // Salva as informações da NotaFiscal no banco de dados caso ainda não esteja salva.
                if(NotaFiscalService.GetNotaFiscalPorRPS(nf.IdRPS) == null)
                    NotaFiscalService.Add(nf);

                // Efetua o download da NotaFiscal na pasta de configuração da empresa.
                DownloadNFSe(lote.IdFilial, nf.NumeroNF);
            }
        }

        public LoteRPS AddLoteRPS(Int32 idFilial)
        {
            var f = FilialService.GetById_ADDLOTERPS(idFilial);

            return LoteRPSService.Add(new LoteRPS
            {
                IdFilial = f.Id,
                IdStatusLoteRPS = 3, // STATUS = ABERTO!
                CPFCNPJRemetente = f.CPFCNPJ,
                CodCidade = f.Cidade.Codigo,
                RazaoSocialRemetente = f.Empresa.RazaoSocial,
                MetodoEnvio = "WS",
                Versao = "1",
                Transacao = true
            }).First();
        }

        public LoteRPS GetLoteRPSById_DELETE(Int32 idLoteRps)
        {
            return LoteRPSService.GetById_ADDRPS_DELETE(idLoteRps);
        }

        public LoteRPS DeleteLoteRPS(LoteRPS loteRPS)
        {
            return LoteRPSService.Delete(loteRPS).First();
        }

        public LoteRPS AddRangeRPSInLoteRPS(Int32 idLoteRPS, IEnumerable<Int32> lstRPS)
        {
            var loteRPS = LoteRPSService.GetById_ADDRPS_DELETE(idLoteRPS);

            foreach (var rpsId in lstRPS)
            {
                var entityRPS = RPSService.GetById_ADDINLOTE(rpsId);

                entityRPS.IdLoteRPS = loteRPS.Id;
                loteRPS.RPS.Add(entityRPS);
            }

            loteRPS.DataPrimeiroRPS = loteRPS.RPS.Min(r => r.DataEmissaoRPS);
            loteRPS.DataUltimoRPS = loteRPS.RPS.Max(r => r.DataEmissaoRPS);
            loteRPS.ValorTotalServicos = loteRPS.RPS.Sum(r => r.ItensRPS.Sum(i => i.ValorTotal));
            loteRPS.ValorTotalDeducoes = loteRPS.RPS.Sum(r => r.DeducaoRPS.Sum(i => i.ValorDeduzir));
            loteRPS.QuantidadeRPS = loteRPS.RPS.Count;

            foreach (var rps in loteRPS.RPS)
            {
                rps.ItensRPS = null;
                rps.DeducaoRPS = null;
                RPSService.Update(rps);
            }

            // Delete eager loading for update.
            loteRPS.RPS = null;
            LoteRPSService.Update(loteRPS);

            // Retorna o Lote de RPS com após a nova inserção de RPS.
            return LoteRPSService.GetById_ADDRPS_DELETE(idLoteRPS);
        }

        public IEnumerable<LoteRPS> GetListLoteRPSByIdFilial(Int32 idFilial, int idStatusLoteRPS)
        {
            return idStatusLoteRPS == 0
                ? LoteRPSService.GetListLoteRPSByIdFilial(idFilial)
                : LoteRPSService.GetListLoteRPSByIdFilialAndStatus(idFilial, idStatusLoteRPS);
        }

        public LoteRPS DeleteRangeRPSFromLoteRPS(IEnumerable<Int32> lstRPS)
        {
            var batchId = 0;

            foreach (var rpsId in lstRPS)
            {
                var rpsObj = RPSService.GetById(rpsId);

                if (rpsObj.IdLoteRPS.HasValue && batchId == 0)
                    batchId = rpsObj.IdLoteRPS.Value;

                rpsObj.IdLoteRPS = null;
                RPSService.Update(rpsObj);
            }

            if (batchId == 0)
                return null;


            var lote = LoteRPSService.GetById(batchId);
            var rpsRemains = RPSService.GetListRPSByIdLoteRPS_UPDATELOTE(lote.Id);

            if (rpsRemains.Any())
            {
                lote.DataPrimeiroRPS = rpsRemains.Min(d => d.DataEmissaoRPS);
                lote.DataUltimoRPS = rpsRemains.Max(d => d.DataEmissaoRPS);
                lote.ValorTotalServicos = rpsRemains.Sum(r => r.ItensRPS.Sum(v => v.ValorTotal));
                lote.ValorTotalDeducoes = rpsRemains.Sum(r => r.DeducaoRPS.Sum(v => v.ValorDeduzir));
                lote.QuantidadeRPS = rpsRemains.Count();
            }
            else
            {
                lote.DataPrimeiroRPS = lote.DataUltimoRPS = DateTime.MinValue;
                lote.ValorTotalServicos = lote.ValorTotalDeducoes = 0.00m;
                lote.QuantidadeRPS = 0;
            }

            return LoteRPSService.Update(lote).First();
        }

        #endregion

        #region NotaFiscal

        public void DownloadNFSe(int idFilial, long numeroNF)
        {
            var nf = NotaFiscalService.GetNotaFiscalByNumero_DOWNLOAD(idFilial, numeroNF);
            NotaFiscalService.DownloadNFSe(nf.RPS.Fatura.Prestador, nf.Link, NotaFiscal.GetInvoiceFullName(nf));
        }

        #endregion

        #region RPS

        public RPS Faturar(int idFatura)
        {
            var obj = FaturaService.GetById_FATURAR(idFatura);

            var ultimoRPS = obj.RPS.LastOrDefault();

            // Força o retorno do RPS já existente caso a fatura ordenada para processamento já tenha sido processada.
            if (obj.IsFaturado && ultimoRPS != null && (ultimoRPS.LoteRPS.IdStatusLoteRPS != 4 && ultimoRPS.LoteRPS.IdStatusLoteRPS != 5))
                return obj.RPS.Last();

            var rps = obj.CriarRPS();

            // Anula as entradas de eager loading para atualizar a fatuara.
            obj.Atividade = null;
            obj.Prestador = null;
            obj.Faturamentos = null;
            obj.LocalPrestacao = null;
            obj.TipoRecolhimento = null;
            obj.Tomador = null;
            obj.IsFaturado = true;

            // Adiciona o novo rps.
            var rpsRetorno = RPSService.Add(rps).First();
            
            // Atualiza a fatura somente após a criação concreta do RPS.
            FaturaService.Update(obj);

            return rpsRetorno;
        }

        public IEnumerable<RPS> GetListRPSWithNoLoteRPSByIdFilial(int idFilial)
        {
            return RPSService.GetListRPSWithNoLoteRPSByIdFilial(idFilial);
        }

        public IEnumerable<RPS> GetListRPSByIdLoteRPS(int idLoteRPS)
        {
            return RPSService.GetListRPSByIdLoteRPS(idLoteRPS);
        }

        public RPS GetRPSPorIdFatura(int idFatura)
        {
            return RPSService.GetRPSPorIdFatura(idFatura);
        }

        #endregion

        #region Helpers

        private Fatura RecalculateFaturaValues(Fatura fatura, bool isUserEdit)
        {
            // Atualiza os dados da fatura.
            var valorTotal = fatura.Faturamentos.Sum(v => v.ValorTotal);

            fatura.ValorCOFINS = valorTotal * (fatura.AliquotaCOFINS / 100);
            fatura.ValorCSLL = valorTotal * (fatura.AliquotaCSLL / 100);
            fatura.ValorINSS = valorTotal * (fatura.AliquotaINSS / 100);
            fatura.ValorPIS = valorTotal * (fatura.AliquotaPIS / 100);
            fatura.ValorIR = valorTotal * (fatura.AliquotaIR / 100);

            fatura.ValorBruto = valorTotal;
            fatura.ValorLiquido = valorTotal - fatura.ValorCOFINS - fatura.ValorCSLL -
                                        fatura.ValorINSS - fatura.ValorPIS - fatura.ValorIR;
            fatura.ValorISS = valorTotal * (fatura.AliquotaISS / 100);

            fatura.IsEdit = isUserEdit;

            return FaturaService.Update(fatura).FirstOrDefault();
        }

        #endregion
    }
}
