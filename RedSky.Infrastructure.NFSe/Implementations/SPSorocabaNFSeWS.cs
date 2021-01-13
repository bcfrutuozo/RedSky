using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using mshtml;
using RedSky.Common;
using RedSky.Domain.Entities;
using RedSky.Infrastructure.NFSe.Interfaces;
using RedSky.Infrastructure.NFSe.Proxies.SPSorocaba;
using RedSky.Infrastructure.NFSe.SPSorocabaNFSe;
using RedSky.Utilities;

namespace RedSky.Infrastructure.NFSe.Implementations
{
    public sealed class SPSorocabaNFSeWS : INFSeWS
    {
        private const string BaseUrlAddress = "https://www.issdigitalsod.com.br/nfse/";
        private readonly LoteRpsClient m_ConexaoWsSorocaba;

        public SPSorocabaNFSeWS(Filial filial)
        {
            Filial = filial;
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            var endpoint = new EndpointAddress("https://issdigital.sorocaba.sp.gov.br/WsNFe2/LoteRps.jws");
            m_ConexaoWsSorocaba = new LoteRpsClient(binding, endpoint);
        }

        public Filial Filial { get; }

        public LoteRPS EnviarLoteRPSAssincrono(LoteRPS loteRPS, X509Certificate2 certificado, long numeroUltimoRps)
        {
            var requisicao = new ReqEnvioLoteRPS
            {
                Cabecalho = new ReqEnvioLoteRPSCabecalho
                {
                    CodCidade = Convert.ToUInt32(loteRPS.CodCidade),
                    CPFCNPJRemetente = loteRPS.CPFCNPJRemetente.PadLeft(14, '0'),
                    RazaoSocialRemetente = loteRPS.RazaoSocialRemetente,
                    transacao = loteRPS.Transacao,
                    dtInicio = loteRPS.DataPrimeiroRPS,
                    dtFim = loteRPS.DataUltimoRPS,
                    QtdRPS = loteRPS.QuantidadeRPS.ToString(),
                    ValorTotalServicos = loteRPS.ValorTotalServicos,
                    ValorTotalDeducoes = loteRPS.ValorTotalDeducoes,
                    Versao = Convert.ToInt64(loteRPS.Versao),
                    MetodoEnvio = loteRPS.MetodoEnvio.Equals("WS") ? tpMetodoEnvio.WS :
                        loteRPS.MetodoEnvio.Equals("DLL") ? tpMetodoEnvio.DLL : tpMetodoEnvio.DMS
                },
                Lote = new tpLote
                {
                    Id = $"lote:{loteRPS.Id}",
                    RPS = PopularRPS(loteRPS, numeroUltimoRps)
                }
            };

            var ns = new XmlSerializerNamespaces();
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("tipos", "http://localhost:8080/WsNFe2/tp");
            ns.Add("ns1", "http://localhost:8080/WsNFe2/lote");

            var xml = new XmlSerializer(typeof(ReqEnvioLoteRPS));
            string request;
            using (var writer = new UTF8StringWriter())
            {
                xml.Serialize(writer, requisicao, ns);
                request = writer.ToString();
            }

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(request);
            xmlFile.SignXml(certificado);

            var response = m_ConexaoWsSorocaba.enviar(xmlFile.OuterXml);

            var res =
                (RetornoEnvioLoteRPS)new XmlSerializer(typeof(RetornoEnvioLoteRPS)).Deserialize(
                    XmlReader.Create(new StringReader(response)));

            // Preenche o retorno com o numero do lote e o status de processamento.
            loteRPS.NumeroLote = Convert.ToUInt32(res.Cabecalho.NumeroLote);
            loteRPS.IdStatusLoteRPS =
                res.Cabecalho.Sucesso
                    ? 1     // RETORNA SUCESSO = 1
                    : 4;    // RETORNA ERRO = 4

            // Preenche a lista de erros para cada RPS caso o lote tenha erros.
            foreach (var evento in res.Erros)
            {
                if (evento.ChaveRPS != null)
                {
                    var rpsFalha = loteRPS.RPS.First(r => r.NumeroRPS == evento.ChaveRPS.NumeroRPS);
                    if (rpsFalha.StatusProcessamento == null)
                        rpsFalha.StatusProcessamento = string.Empty;

                    rpsFalha.StatusProcessamento += "<Codigo>" + evento.Codigo + "</Codigo><Descricao>" +
                                                    evento.Descricao + "</Descricao>";
                }
            }

            return loteRPS;
        }

        public LoteRPS EnviarLoteRPSSincrono(LoteRPS loteRPS, X509Certificate2 certificado, long numeroUltimoRps)
        {
            var requisicao = new ReqEnvioLoteRPS
            {
                Cabecalho = new ReqEnvioLoteRPSCabecalho
                {
                    CodCidade = Convert.ToUInt32(loteRPS.CodCidade),
                    CPFCNPJRemetente = loteRPS.CPFCNPJRemetente.PadLeft(14, '0'),
                    RazaoSocialRemetente = loteRPS.RazaoSocialRemetente,
                    transacao = loteRPS.Transacao,
                    dtInicio = loteRPS.DataPrimeiroRPS,
                    dtFim = loteRPS.DataUltimoRPS,
                    QtdRPS = loteRPS.QuantidadeRPS.ToString(),
                    ValorTotalServicos = loteRPS.ValorTotalServicos,
                    ValorTotalDeducoes = loteRPS.ValorTotalDeducoes,
                    Versao = Convert.ToInt64(loteRPS.Versao),
                    MetodoEnvio = loteRPS.MetodoEnvio.Equals("WS") ? tpMetodoEnvio.WS :
                        loteRPS.MetodoEnvio.Equals("DLL") ? tpMetodoEnvio.DLL : tpMetodoEnvio.DMS
                },
                Lote = new tpLote
                {
                    Id = $"lote:{loteRPS.Id}",
                    RPS = PopularRPS(loteRPS, numeroUltimoRps)
                }
            };

            var ns = new XmlSerializerNamespaces();
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("tipos", "http://localhost:8080/WsNFe2/tp");
            ns.Add("ns1", "http://localhost:8080/WsNFe2/lote");

            var xml = new XmlSerializer(typeof(ReqEnvioLoteRPS));
            string request;
            using (var writer = new UTF8StringWriter())
            {
                xml.Serialize(writer, requisicao, ns);
                request = writer.ToString();
            }

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(request);
            xmlFile.SignXml(certificado);

            var response = m_ConexaoWsSorocaba.enviarSincrono(xmlFile.OuterXml);

            var res =
                (RetornoEnvioLoteRPS)new XmlSerializer(typeof(RetornoEnvioLoteRPS)).Deserialize(
                    XmlReader.Create(new StringReader(response)));

            // Preenche o retorno com o numero do lote e o status de processamento.
            loteRPS.NumeroLote = Convert.ToUInt32(res.Cabecalho.NumeroLote);
            loteRPS.IdStatusLoteRPS =
                res.Cabecalho.Sucesso
                    ? 1     // RETORNA SUCESSO = 1
                    : 4;    // RETORNA ERRO = 4

            // Preenche a lista de erros para cada RPS caso o lote tenha erros.
            foreach (var evento in res.Erros)
            {
                if (evento.ChaveRPS != null)
                {
                    var rpsFalha = loteRPS.RPS.First(r => r.NumeroRPS == evento.ChaveRPS.NumeroRPS);
                    if (rpsFalha.StatusProcessamento == null)
                        rpsFalha.StatusProcessamento = string.Empty;

                    rpsFalha.StatusProcessamento += "<Codigo>" + evento.Codigo + "</Codigo><Descricao>" +
                                                    evento.Descricao + "</Descricao>";
                }
            }

            return loteRPS;
        }

        public IEnumerable<NotaFiscal> ConsultarLote(long numeroLote, X509Certificate2 certificado)
        {
            var requisicao = new ReqConsultaLote
            {
                Cabecalho = new ReqConsultaLoteCabecalho
                {
                    CodCidade = Convert.ToUInt32(Filial.Cidade.Codigo),
                    CPFCNPJRemetente = Filial.CPFCNPJ.PadLeft(14, '0'),
                    NumeroLote = numeroLote,
                    Versao = 1
                }
            };

            var ns = new XmlSerializerNamespaces();
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("tipos", "http://localhost:8080/WsNFe2/tp");
            ns.Add("ns1", "http://localhost:8080/WsNFe2/lote");

            var xml = new XmlSerializer(typeof(ReqConsultaLote));
            string request;
            using (var writer = new UTF8StringWriter())
            {
                xml.Serialize(writer, requisicao, ns);
                request = writer.ToString();
            }

            var response = m_ConexaoWsSorocaba.consultarLote(request);

            var res =
                (RetornoConsultaLote)new XmlSerializer(typeof(RetornoConsultaLote)).Deserialize(
                    XmlReader.Create(new StringReader(response)));

            var listNf = new List<NotaFiscal>(res.ListaNFSe.Length);

            //TODO: VERIFICAR ERRO NA CONSULTA DO LOTE

            // Popula os objetos NotaFiscal para retornar os dados completo para o cliente.
            foreach (var nf in res.ListaNFSe)
            {
                // Efetua nova consulta para obter os dados principais da NF.
                var nova = ConsultarNFSe(numeroLote, Convert.ToUInt32(nf.NumeroNFe), nf.CodigoVerificacao,
                    certificado);

                // Atualiza o codigo de verificação com o código completo.
                nova.CodigoVerificacao = nf.CodigoVerificacao;

                if (string.IsNullOrEmpty(nova.MotivoCancelamento))
                    nova.MotivoCancelamento = null;

                // Atualiza a data de processamento do RPS que gerou a NFSe.
                nova.DataProcessamento = DateTime.ParseExact(res.Cabecalho.DataEnvioLote, "yyyy-MM-ddThh:mm:ss",
                    CultureInfo.InvariantCulture);

                listNf.Add(nova);
            }

            return listNf;
        }

        public IEnumerable<NotaFiscal> ConsultarNotas(DateTime inicio, DateTime fim, X509Certificate2 certificado,
            long notaInicial = 0)
        {
            var j = new ReqConsultaNotas
            {
                Cabecalho = new ReqConsultaNotasCabecalho
                {
                    CodCidade = Convert.ToUInt32(Filial.Cidade.Codigo),
                    CPFCNPJRemetente = Filial.CPFCNPJ.PadLeft(14, '0'),
                    dtInicio = inicio,
                    dtFim = fim,
                    InscricaoMunicipalPrestador = Filial.InscricaoMunicipal.PadLeft(9, '0'),
                    NotaInicial = notaInicial,
                    NotaInicialSpecified = true,
                    Versao = 1
                }
            };

            var ns = new XmlSerializerNamespaces();
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("tipos", "http://localhost:8080/WsNFe2/tp");
            ns.Add("ns1", "http://localhost:8080/WsNFe2/lote");

            var xml = new XmlSerializer(typeof(ReqConsultaNotas));
            string request;
            using (var writer = new UTF8StringWriter())
            {
                xml.Serialize(writer, j, ns);
                request = writer.ToString();
            }

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(request);
            xmlFile.SignXml(certificado);

            var response = m_ConexaoWsSorocaba.consultarNota(xmlFile.OuterXml);

            var res =
                (RetornoConsultaNotas)new XmlSerializer(typeof(RetornoConsultaNotas)).Deserialize(
                    XmlReader.Create(new StringReader(response)));

            return PopularNotasFiscais(Filial, res.Notas);
        }

        public NotaFiscal ConsultarNFSe(long numeroLote, long numeroNF, string codigoVerificacao,
            X509Certificate2 certificado)
        {
            var j = new ReqConsultaNFSeRPS
            {
                Cabecalho = new ReqConsultaNFSeRPSCabecalho
                {
                    CodCidade = Convert.ToUInt32(Filial.Cidade.Codigo),
                    CPFCNPJRemetente = Filial.CPFCNPJ.PadLeft(14, '0'),
                    transacao = true,
                    Versao = 1
                },
                Lote = new tpLoteConsultaNFSe
                {
                    Id = $"lote:{numeroLote}",
                    NotaConsulta = new[]
                    {
                        new tpNotaConsultaNFSe
                        {
                            Id = $"nota:{numeroNF}",
                            InscricaoMunicipalPrestador = Filial.InscricaoMunicipal.PadLeft(9, '0'),
                            NumeroNota = numeroNF,
                            CodigoVerificacao = codigoVerificacao
                        }
                    }
                }
            };

            var ns = new XmlSerializerNamespaces();
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("tipos", "http://localhost:8080/WsNFe2/tp");
            ns.Add("ns1", "http://localhost:8080/WsNFe2/lote");

            var xml = new XmlSerializer(typeof(ReqConsultaNFSeRPS));
            string request;
            using (var writer = new UTF8StringWriter())
            {
                xml.Serialize(writer, j, ns);
                request = writer.ToString();
            }

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(request);
            xmlFile.SignXml(certificado);

            var response = m_ConexaoWsSorocaba.consultarNFSeRps(xmlFile.OuterXml);

            var res =
                (RetornoConsultaNFSeRPS)new XmlSerializer(typeof(RetornoConsultaNFSeRPS)).Deserialize(
                    XmlReader.Create(new StringReader(response)));

            return PopularNotasFiscais(Filial, res.NotasConsultadas).First();
        }

        public NotaFiscal ConsultarRPS(long numeroLote, long numeroRPS, X509Certificate2 certificado)
        {
            var j = new ReqConsultaNFSeRPS
            {
                Cabecalho = new ReqConsultaNFSeRPSCabecalho
                {
                    CodCidade = Convert.ToUInt32(Filial.Cidade.Codigo),
                    CPFCNPJRemetente = Filial.CPFCNPJ.PadLeft(14, '0'),
                    transacao = true,
                    Versao = 1
                },

                Lote = new tpLoteConsultaNFSe
                {
                    Id = $"lote:{numeroLote}",
                    RPSConsulta = new[]
                    {
                        new tpRPSConsultaNFSe
                        {
                            Id = $"rps:{numeroRPS}",
                            InscricaoMunicipalPrestador = Filial.InscricaoMunicipal.PadLeft(9, '0'),
                            NumeroRPS = numeroRPS,
                            SeriePrestacao = 99
                        }
                    }
                }
            };

            var ns = new XmlSerializerNamespaces();
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("tipos", "http://localhost:8080/WsNFe2/tp");
            ns.Add("ns1", "http://localhost:8080/WsNFe2/lote");

            var xml = new XmlSerializer(typeof(ReqConsultaNFSeRPS));
            string request;
            using (var writer = new UTF8StringWriter())
            {
                xml.Serialize(writer, j, ns);
                request = writer.ToString();
            }

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(request);
            xmlFile.SignXml(certificado);

            var response = m_ConexaoWsSorocaba.consultarNFSeRps(xmlFile.OuterXml);

            var res =
                (RetornoConsultaNFSeRPS)new XmlSerializer(typeof(RetornoConsultaNFSeRPS)).Deserialize(
                    XmlReader.Create(new StringReader(response)));

            return PopularNotasFiscais(Filial, res.NotasConsultadas).First();
        }

        public NotaFiscal CancelarNFSe(long numeroLote, long numeroNF, string codigoVerificacao, string motivo,
            X509Certificate2 certificado)
        {
            if (motivo.Length > 80)
                throw new ApplicationException("O campo motivo não pode ultrapassar 80 caractéres.");

            var requisicao = new ReqCancelamentoNFSe
            {
                Cabecalho = new ReqCancelamentoNFSeCabecalho
                {
                    CodCidade = Convert.ToUInt32(Filial.Cidade.Codigo),
                    CPFCNPJRemetente = Filial.CPFCNPJ.PadLeft(14, '0'),
                    transacao = true,
                    Versao = 1
                },
                Lote = new tpLoteCancelamentoNFSe
                {
                    Id = "lote:1ABCDZ",
                    Nota = new[]
                    {
                        new tpNotaCancelamentoNFSe
                        {
                            Id = $"nota:{numeroNF}",
                            InscricaoMunicipalPrestador = Convert.ToInt64(Filial.InscricaoMunicipal.PadLeft(9, '0')),
                            NumeroNota = numeroNF,
                            CodigoVerificacao = codigoVerificacao,
                            MotivoCancelamento = motivo
                        }
                    }
                }
            };

            var ns = new XmlSerializerNamespaces();
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("tipos", "http://localhost:8080/WsNFe2/tp");
            ns.Add("ns1", "http://localhost:8080/WsNFe2/lote");

            var xml = new XmlSerializer(typeof(ReqCancelamentoNFSe));
            string request;

            using (var writer = new UTF8StringWriter())
            {
                xml.Serialize(writer, requisicao, ns);
                request = writer.ToString();
            }

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(request);
            xmlFile.SignXml(certificado);

            var response = m_ConexaoWsSorocaba.consultarSequencialRps(xmlFile.OuterXml);

            var res =
                (RetornoCancelamentoNFSe)new XmlSerializer(typeof(RetornoCancelamentoNFSe)).Deserialize(
                    XmlReader.Create(new StringReader(response)));

            // Carrega as propriedades da nota fiscal.
            var retNf = ConsultarNFSe(numeroLote, numeroNF, codigoVerificacao, certificado);

            if (res.Cabecalho.Sucesso)
            {
                // Preenche o motivo de cancelamento e a flag de cancelamento da nota fiscal.
                retNf.MotivoCancelamento = res.NotasCanceladas[0].MotivoCancelamento;
                retNf.IsCancelada = true;
            }
            else
            {
                // Caso ocorra algum erro no cancelamento da nota fiscal, não preenche o motivo e a flag, e retorna a lista de erros.
                foreach (var evento in res.Erros)
                    retNf.Eventos.Add(new EventoNFSe { Codigo = evento.Codigo, Descricao = evento.Descricao });
            }

            return retNf;
        }

        public long ConsultarUltimoRPS()
        {
            var j = new ConsultaSeqRps
            {
                Cabecalho = new ConsultaSeqRpsCabecalho
                {
                    CodCid = Convert.ToUInt32(Filial.Cidade.Codigo),
                    IMPrestador = Filial.InscricaoMunicipal.PadLeft(9, '0'),
                    CPFCNPJRemetente = Filial.CPFCNPJ.PadLeft(14, '0'),
                    SeriePrestacao = 99,
                    Versao = 1
                }
            };

            var ns = new XmlSerializerNamespaces();
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("tipos", "http://localhost:8080/WsNFe2/tp");
            ns.Add("ns1", "http://localhost:8080/WsNFe2/lote");

            var xml = new XmlSerializer(typeof(ConsultaSeqRps));
            string request;
            using (var writer = new UTF8StringWriter())
            {
                xml.Serialize(writer, j, ns);
                request = writer.ToString();
            }

            var response = m_ConexaoWsSorocaba.consultarSequencialRps(request);

            var res =
                (RetornoConsultaSeqRps)new XmlSerializer(typeof(RetornoConsultaSeqRps)).Deserialize(
                    XmlReader.Create(new StringReader(response)));

            return res.Cabecalho.NroUltimoRps;
        }

        public void DownloadNFSe(string link, string output)
        {
            // Realiza o download do HTML com o link de visualização.
            var htmlData = DownloadHTML(link);

            // Formata o HTML eliminando informação desnecessária que não convém para a NF.
            var htmlProcessedData = FormatHTML(htmlData);

            if (!Directory.Exists(Path.GetDirectoryName(output)))
                Directory.CreateDirectory(Path.GetDirectoryName(output));

            // Converte o HTML em PDF e grava em disco
            Pdf.ConvertFromHtml(htmlProcessedData, "NFSe", output);
        }

        public string ObterUrlNFSe(long numeroNF, string codigoVerificacao)
        {
            // Chave padrão na string de consulta da nota fiscal pelo link do QRCode.
            var baseDecodedInfo =
                $@"num_nota={numeroNF:D8}&cnpj_prest={Filial.CPFCNPJ.PadLeft(14, '0')}&cod_verif={
                        codigoVerificacao
                    }&im={Filial.InscricaoMunicipal.PadLeft(9, '0')}&codCidIni={Filial.Cidade.Codigo}";

            var key = Convert.ToBase64String(Encoding.UTF8.GetBytes(baseDecodedInfo));

            // URL de consulta de nota fiscal pelo QRCode.
            var addressSearch =
                $@"https://www.issdigitalsod.com.br/nfse/action/notaFiscal/checkQrCode.php?key={key}&codCidIni={
                        Filial.Cidade.Codigo
                    }";

            // Busca o link final após o redirect.
            var redirectedUrl = addressSearch.GetFinalRedirectedUrl();
            var queryString = redirectedUrl.Split('?')[1];
            var parameters = queryString.Split('&');

            // Obtém o link final de visualização da NF já com o id da nota fiscal no sistema da prefeitura.
            return
                $@"https://www.issdigitalsod.com.br/nfse/visualizarNota.php?{
                        parameters.First(p => p.StartsWith("id_nota_fiscal"))
                    }&temPrestador=Tg==&codCidIni={Filial.Cidade.Codigo}&rDecId={
                        Filial.InscricaoMunicipal.PadLeft(9, '0')
                    }";
        }

        private string DownloadHTML(string url)
        {
            string htmlDom = null;

            var t = new Thread(() =>
            {
                var wb = new WebBrowser();

                wb.DocumentCompleted += delegate
                {
                // attach to subscribe to DOM onload event
                wb.Document.Window.AttachEventHandler("onload",
                    delegate { SynchronizationContext.Current.Post(delegate { }, null); });

                // attach to subscribe to DOM onload event
                wb.Document.Window.AttachEventHandler("ready",
                    delegate { SynchronizationContext.Current.Post(delegate { }, null); });

                // attach to subscribe to DOM onload event
                wb.Document.Window.AttachEventHandler("print",
                    delegate { SynchronizationContext.Current.Post(delegate { }, null); });

                    Application.ExitThread();
                };

                wb.Navigate(url);

                Application.Run();

            // the document has been fully loaded, can access DOM here
            var html = (IHTMLDocument3)wb.Document.DomDocument;
                htmlDom = html.documentElement.outerHTML;
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return htmlDom;
        }

        private string FormatHTML(string htmlDom)
        {
            // Elimina todos os espaços e paragrafos do HTML diminuindo assim o tamanho do arquivo e destruindo a formatação.
            htmlDom = htmlDom.Replace("\n", string.Empty).Replace("\r", string.Empty);

            //string header =
            //    @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">";

            // QueryString de consulta do logo da empresa.
            var queryLogo = @"logotipoEmpresa.php?";

            // Trecho do código que contém uma calculadora em javascript e deve ser eliminado.
            var jQueryIndexHtml = htmlDom.IndexOf("jQuery", StringComparison.Ordinal);
            var calculadora =
                @"<DIV id=calculadora class=ui-draggable style=""BORDER-TOP: medium none; BORDER-RIGHT: medium none; BORDER-BOTTOM: medium none; POSITION: ; ZOOM: 1; BORDER-LEFT: medium none"" jQueryXXXXXXXXXXXXX=""10""><DIV class=jquery-corner style=""WIDTH: 0px; RIGHT: 0px; POSITION: absolute; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; LEFT: 0px; MARGIN: 0px; TOP: 0px; PADDING-RIGHT: 0px""><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 2px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 2px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 1px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 0px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 0px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 0px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 0px solid; BACKGROUND-COLOR: transparent""></DIV></DIV><DIV id=fecharCalculadora><IMG alt=close src=""imagens/close.png""></DIV><TEXTAREA id=tela style=""MAX-WIDTH: 110%; HEIGHT: 70px; WIDTH: 110%; MIN-WIDTH: 110%; MIN-HEIGHT: 70px; MAX-HEIGHT: 70px"" cols=4></TEXTAREA> <DIV class=botoes style=""WIDTH: 110%""><DIV class=operacoes style=""BORDER-TOP: medium none; BORDER-RIGHT: medium none; BORDER-BOTTOM: medium none; POSITION: ; ZOOM: 1; BORDER-LEFT: medium none""><DIV class=jquery-corner style=""WIDTH: 0px; RIGHT: 0px; POSITION: absolute; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; LEFT: 0px; MARGIN: 0px; TOP: 0px; PADDING-RIGHT: 0px""><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 2px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 2px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 1px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 1px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV></DIV><INPUT id=adicao title=Adição type=button value=+> <INPUT id=subtracao title=Subtração type=button value=-> <INPUT id=multiplicacao title=Multiplicação type=button value=*> <INPUT id=divisao title=Divisão type=button value=/> <INPUT id=% title=Porcentagem style=""BACKGROUND-COLOR: #d6093c"" type=button value=%> <INPUT id=C title=C style=""BACKGROUND-COLOR: #668bf2"" type=button value=C> <DIV class=jquery-corner style=""WIDTH: 0px; POSITION: absolute; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; LEFT: 0px; MARGIN: 0px; PADDING-RIGHT: 0px; BOTTOM: 0px""><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 1px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 1px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 2px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 2px solid; BACKGROUND-COLOR: transparent""></DIV></DIV></DIV>";
            calculadora = calculadora.Replace("jQueryXXXXXXXXXXXXX", htmlDom.Substring(jQueryIndexHtml, 19));

            // Trecho do código que contém o botão para efetuar a impressão no navegado.
            var cabecalhoImpressao =
                @"<DIV id=principal class=divPrincipal align=center name=""principal""><BR><DIV id=email name=""email""><TABLE cellPadding=0 width=""100%"" border=0 cellspaing=""0""><TBODY><TR class=impressaoTitulo><TD width=""100%"" align=center>Clique aqui para imprimir a NFSe</TD></TR></TBODY></TABLE></DIV><BR><DIV id=email name=""email""><TABLE cellPadding=0 width=""100%"" border=0 cellspaing=""0""><TBODY><TR><TD width=""100%"" align=center><DIV id=impressao name=""impressao""><INPUT onclick=window.print(); id=btnImprimir class=botao style=""WIDTH: 100px; BACKGROUND: url(https://www.issdigitalsod.com.br/nfse/imagens/botao/botao.gif)"" type=button value=Imprimir name=btnImprimir></DIV>";

            // Trecho do código que contém os números utilizados na calculadora javascript.
            var thrash =
                @"<DIV class=numeros style=""BORDER-TOP: medium none; BORDER-RIGHT: medium none; BORDER-BOTTOM: medium none; POSITION: ; ZOOM: 1; BORDER-LEFT: medium none"" align=center><DIV class=jquery-corner style=""WIDTH: 0px; RIGHT: 0px; POSITION: absolute; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; LEFT: 0px; MARGIN: 0px; TOP: 0px; PADDING-RIGHT: 0px""><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 2px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 2px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 1px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 1px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV></DIV><INPUT id=1 title=1 class=botaoNumero type=button value=1 name=numero><INPUT id=2 title=2 class=botaoNumero type=button value=2 name=numero><INPUT id=3 title=3 class=botaoNumero type=button value=3 name=numero><INPUT id=4 title=4 class=botaoNumero type=button value=4 name=numero><INPUT id=5 title=5 class=botaoNumero type=button value=5 name=numero><INPUT id=6 title=6 class=botaoNumero type=button value=6 name=numero><INPUT id=7 title=7 class=botaoNumero type=button value=7 name=numero><INPUT id=8 title=8 class=botaoNumero type=button value=8 name=numero><INPUT id=9 title=9 class=botaoNumero type=button value=9 name=numero><INPUT id=. title=. class=botaoNumero type=button value=. name=numero><INPUT id=0 title=0 class=botaoNumero type=button value=0 name=numero><INPUT id=resultado title=Resultado class=botaoNumero style=""BACKGROUND-COLOR: #f0951f"" type=button value==><DIV class=jquery-corner style=""WIDTH: 0px; POSITION: absolute; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; LEFT: 0px; MARGIN: 0px; PADDING-RIGHT: 0px; BOTTOM: 0px""><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 0px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 1px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 1px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #b5b5b5 0px; HEIGHT: 1px; BORDER-RIGHT: #b5b5b5 2px solid; BORDER-BOTTOM: #b5b5b5 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #b5b5b5 2px solid; BACKGROUND-COLOR: transparent""></DIV></DIV></DIV></DIV><DIV class=jquery-corner style=""WIDTH: 0px; POSITION: absolute; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; LEFT: 0px; MARGIN: 0px; PADDING-RIGHT: 0px; BOTTOM: 0px""><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 0px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 0px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 0px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 0px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 1px solid; BACKGROUND-COLOR: transparent""></DIV><DIV style=""FONT-SIZE: 1px; OVERFLOW: hidden; BORDER-TOP: #ffffff 0px; HEIGHT: 1px; BORDER-RIGHT: #ffffff 2px solid; BORDER-BOTTOM: #ffffff 0px; MIN-HEIGHT: 1px; BORDER-LEFT: #ffffff 2px solid; BACKGROUND-COLOR: transparent""></DIV></DIV></DIV>";

            // Efetua a eliminação de todos os dados citados anteriormente.
            htmlDom = htmlDom.Replace(queryLogo, BaseUrlAddress + queryLogo).Replace(calculadora, string.Empty)
                .Replace(cabecalhoImpressao, string.Empty).Replace(thrash, string.Empty);

            // Omite o campo de número de RPS da nota fiscal.
            int indexRps = htmlDom.IndexOf("RPS/SÉRIE", StringComparison.InvariantCulture);
            int endRps = htmlDom.IndexOf('<', indexRps);
            htmlDom = htmlDom.Remove(indexRps, endRps - indexRps);

            return htmlDom;
        }

        private tpRPS[] PopularRPS(LoteRPS loterps, long numeroUltimoRps)
        {
            IList<tpRPS> rpslTpRpss = new List<tpRPS>();

            int incrementoRps = 1;
            foreach (var rpsBase in loterps.RPS)
            {
                rpsBase.NumeroRPS = numeroUltimoRps + incrementoRps;

                rpsBase.AssinarRPS();
                rpslTpRpss.Add(new tpRPS
                {
                    Id = $"rps: {rpsBase.NumeroRPS}",
                    Assinatura = Convert.FromBase64String(rpsBase.Assinatura),
                    InscricaoMunicipalPrestador = rpsBase.InscricaoMunicipalPrestador,
                    RazaoSocialPrestador = rpsBase.RazaoSocialPrestador,
                    TipoRPS = (tpTipoRPS)Enum.Parse(typeof(tpTipoRPS), rpsBase.TipoRPS),
                    SerieRPS = (tpSerieRPS)Enum.Parse(typeof(tpSerieRPS), rpsBase.SerieRPS),
                    NumeroRPS = rpsBase.NumeroRPS.Value,
                    DataEmissaoRPS = rpsBase.DataEmissaoRPS,
                    SituacaoRPS = (tpSituacaoRPS)Enum.Parse(typeof(tpSituacaoRPS), rpsBase.SituacaoRPS),
                    SeriePrestacao = Convert.ToSByte(rpsBase.SeriePrestacao),
                    InscricaoMunicipalTomador = rpsBase.InscricaoMunicipalTomador,
                    CPFCNPJTomador = rpsBase.CPFCNPJTomador,
                    RazaoSocialTomador = rpsBase.RazaoSocialTomador,
                    DocTomadorEstrangeiro = rpsBase.DocTomadorEstrangeiro,
                    TipoLogradouroTomador = rpsBase.TipoLogradouroTomador,
                    LogradouroTomador = rpsBase.LogradouroTomador,
                    NumeroEnderecoTomador = rpsBase.NumeroEnderecoTomador,
                    ComplementoEnderecoTomador = rpsBase.ComplementoEnderecoTomador,
                    TipoBairroTomador = rpsBase.TipoBairroTomador,
                    BairroTomador = rpsBase.BairroTomador,
                    CidadeTomador = Convert.ToUInt32(rpsBase.CidadeTomador),
                    CidadeTomadorDescricao = rpsBase.CidadeTomadorDescricao,
                    CEPTomador = Convert.ToInt32(rpsBase.CEPTomador),
                    EmailTomador = rpsBase.EmailTomador,
                    CodigoAtividade = Convert.ToInt32(rpsBase.CodigoAtividade),
                    AliquotaAtividade =
                        rpsBase.AliquotaAtividade, // TODO: ATUALIZAR PARA CADASTRO DE ALIQUOTA/SERVICO/CIDADE !!!
                    TipoRecolhimento =
                        (tpTipoRecolhimento)Enum.Parse(typeof(tpTipoRecolhimento), rpsBase.TipoRecolhimento),
                    MunicipioPrestacao = Convert.ToUInt32(rpsBase.MunicipioPrestacao),
                    MunicipioPrestacaoDescricao = rpsBase.MunicipioPrestacaoDescricao,
                    Operacao = (tpOperacao)Enum.Parse(typeof(tpOperacao), rpsBase.Operacao),
                    Tributacao = (tpTributacao)Enum.Parse(typeof(tpTributacao), rpsBase.Tributacao),
                    ValorPIS = rpsBase.ValorPIS,
                    ValorCOFINS = rpsBase.ValorCOFINS,
                    ValorINSS = rpsBase.ValorINSS,
                    ValorIR = rpsBase.ValorIR,
                    ValorCSLL = rpsBase.ValorCSLL,
                    AliquotaPIS = rpsBase.AliquotaPIS,
                    AliquotaCOFINS = rpsBase.AliquotaCOFINS,
                    AliquotaINSS = rpsBase.AliquotaINSS,
                    AliquotaIR = rpsBase.AliquotaIR,
                    AliquotaCSLL = rpsBase.AliquotaCSLL,
                    DescricaoRPS = rpsBase.DescricaoRPS,
                    DDDPrestador = rpsBase.DDDPrestador,
                    TelefonePrestador = rpsBase.TelefonePrestador,
                    DDDTomador = rpsBase.DDDTomador,
                    TelefoneTomador = rpsBase.TelefoneTomador,
                    MotCancelamento = rpsBase.MotivoCancelamento,
                    CPFCNPJIntermediario = rpsBase.CPFCNPJIntermediario,
                    DataEmissaoNFSeSubstituida = rpsBase.DataEmissaoNFSeSubstituida.HasValue
                        ? rpsBase.DataEmissaoNFSeSubstituida.Value.ToString("yyyy-MM-dd")
                        : @"1900-01-01",
                    NumeroNFSeSubstituida =
                        rpsBase.NumeroNFSeSubstituida.HasValue ? rpsBase.NumeroNFSeSubstituida.Value : 0,
                    NumeroRPSSubstituido =
                        rpsBase.NumeroRPSSubstituido.HasValue ? rpsBase.NumeroRPSSubstituido.Value : 0,
                    SerieRPSSubstituido = rpsBase.SerieRPSSubstituido,
                    Deducoes = ObterDeducoesRPS(rpsBase),
                    Itens = ObterItensRPS(rpsBase)
                });

                incrementoRps += 1;
            }

            return rpslTpRpss.ToArray();
        }

        private IEnumerable<NotaFiscal> PopularNotasFiscais(Filial filial, tpNFSe[] nfsPrefeitura)
        {
            var listNFs = new List<NotaFiscal>(nfsPrefeitura.Length);

            foreach (var nf in nfsPrefeitura)
                listNFs.Add(new NotaFiscal
                {
                    MotivoCancelamento = nf.MotCancelamento,
                    CodigoVerificacao = nf.CodigoVerificacao,
                    NumeroRPS = nf.NumeroRPS,
                    DataProcessamento = nf.DataProcessamento,
                    Link = ObterUrlNFSe(nf.NumeroNota, nf.CodigoVerificacao),
                    NumeroNF = nf.NumeroNota
                });

            return listNFs;
        }

        private tpDeducoes[] ObterDeducoesRPS(RPS rps)
        {
            var deducoesServico = new List<tpDeducoes>();

            foreach (var deducao in rps.DeducaoRPS)
                deducoesServico.Add(new tpDeducoes
                {
                    CPFCNPJReferencia = deducao.CPFCNPJReferencia,
                    DeducaoPor = (tpDeducaoPor)Enum.Parse(typeof(tpDeducaoPor), deducao.DeducaoPor),
                    ValorDeduzir = deducao.ValorDeduzir,
                    NumeroNFReferencia = Convert.ToInt64(deducao.NumeroNFReferencia),
                    PercentualDeduzir = deducao.PercentualDeduzir,
                    TipoDeducao = (tpTipoDeducao)Enum.Parse(typeof(tpDeducoes), deducao.TipoDeducao),
                    ValorTotalReferencia = deducao.ValorTotalReferencia.HasValue
                        ? deducao.ValorTotalReferencia.Value
                        : 0.00m
                });

            return deducoesServico.ToArray();
        }

        private tpItens[] ObterItensRPS(RPS rps)
        {
            var itensServico = new List<tpItens>();

            foreach (var servico in rps.ItensRPS)
                itensServico.Add(new tpItens
                {
                    Quantidade = servico.Quantidade,
                    DiscriminacaoServico = servico.DiscriminacaoServico.ToUpper(),
                    Tributavel =
                        (tpItemTributavel)Enum.Parse(typeof(tpItemTributavel),
                            servico.Tributavel), // Para sorocaba todos os itens são tributáveis.
                    ValorUnitario = servico.ValorUnitario,
                    ValorTotal = servico.ValorTotal
                });

            return itensServico.ToArray();
        }
    }
}