using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Xml;
using System.Xml.Serialization;
using RedSky.Common;
using RedSky.Common.Exceptions;
using RedSky.Domain.Entities;
using RedSky.Infrastructure.NFSe.Interfaces;
using RedSky.Infrastructure.NFSe.Proxies.SPSorocaba;
using RedSky.Infrastructure.NFSe.Proxies.SPTatui;
using RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe;
using RedSky.Infrastructure.NFSe.SPTatuiNFSeConsultarNFSePorRPS;
using RedSky.Infrastructure.NFSe.SPTatuiNFSeRecepcionarLoteRPSSincrono;
using RedSky.Utilities;

namespace RedSky.Infrastructure.NFSe.Implementations
{
    public sealed class SPTatuiNFSeWS : INFSeWS
    {
        private readonly CancelarNfseSoapPortClient m_ConexaoWsCancelar;
        private readonly ConsultarNfsePorRpsSoapPortClient m_ConexaoWsConsultar;
        private readonly RecepcionarLoteRpsSincronoSoapPortClient m_ConexaoWsRecepcionar;

        public SPTatuiNFSeWS(Filial filial)
        {
            Filial = filial;

            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);

            m_ConexaoWsCancelar = new CancelarNfseSoapPortClient(binding,
                new EndpointAddress("http://tatui.sistemas4r.com.br/abrasf/acancelarnfse.aspx"));
            m_ConexaoWsConsultar = new ConsultarNfsePorRpsSoapPortClient(binding,
                new EndpointAddress("http://tatui.sistemas4r.com.br/abrasf/acancelarnfse.aspx"));
            m_ConexaoWsRecepcionar = new RecepcionarLoteRpsSincronoSoapPortClient(binding,
                new EndpointAddress("http://tatui.sistemas4r.com.br/abrasf/acancelarnfse.aspx"));
        }

        public Filial Filial { get; }

        public LoteRPS EnviarLoteRPSAssincrono(LoteRPS loteRPS, X509Certificate2 certificado, long numeroUltimoRps)
        {
            // Serviço indisponível na prefeitura.
            throw new UnavailableServiceException();
        }

        public LoteRPS EnviarLoteRPSSincrono(LoteRPS loteRPS, X509Certificate2 certificado, long numeroUltimoRps)
        {
            var lote = new EnviarLoteRpsEnvio
            {
                LoteRps = new tcLoteRps
                {
                    CpfCnpj = new tcCpfCnpj
                    {
                        Item = loteRPS.CPFCNPJRemetente,
                        ItemElementName =
                            loteRPS.CPFCNPJRemetente.Length < 12 ? ItemChoiceType.Cpf : ItemChoiceType.Cnpj
                    },
                    InscricaoMunicipal = loteRPS.RPS.First().InscricaoMunicipalPrestador,
                    QuantidadeRps = loteRPS.QuantidadeRPS,
                    Versao = loteRPS.Versao,
                    ListaRps = new tcLoteRpsListaRps
                    {
                        Rps = new tcDeclaracaoPrestacaoServico
                        {
                            InfDeclaracaoPrestacaoServico = new tcInfDeclaracaoPrestacaoServico
                            {
                                Competencia = DateTime.Parse("01/" + loteRPS.RPS.First().Fatura.Competencia),
                                Rps = new tcInfRps
                                {
                                    DataEmissao = loteRPS.RPS.First().DataEmissaoRPS,
                                    IdentificacaoRps = new tcIdentificacaoRps
                                    {
                                        Numero = loteRPS.RPS.First().NumeroRPS.ToString(),
                                        Serie = loteRPS.RPS.First().SerieRPS,
                                        Tipo = Convert.ToSByte(loteRPS.RPS.First().TipoRPS)
                                    },
                                    RpsSubstituido = new tcIdentificacaoRps
                                    {
                                        Numero = loteRPS.RPS.First().NumeroRPSSubstituido.ToString(),
                                        Serie = loteRPS.RPS.First().SerieRPSSubstituido,
                                        Tipo = Convert.ToSByte(loteRPS.RPS.First().TipoRPS)
                                    }
                                },
                                Servico = new tcDadosServico
                                {
                                    CodigoCnae = Convert.ToInt32(loteRPS.RPS.First().Fatura.Atividade.CodigoAtividade),
                                    CodigoMunicipio = Convert.ToInt32(loteRPS.CodCidade),
                                    CodigoPais = @"1058", //TODO: Registro dos países
                                    Discriminacao = loteRPS.RPS.First().DescricaoRPS,
                                    ExigibilidadeISS = 1, //TODO: VERIFICAR ELIGIBILIDADE
                                    IssRetido = 1, //TODO: RETENCAO DO SERVICO
                                    MunicipioIncidencia = Convert.ToInt32(loteRPS.RPS.First().MunicipioPrestacao),
                                    Valores = new tcValoresDeclaracaoServico
                                    {
                                        Aliquota = loteRPS.RPS.First().AliquotaAtividade,
                                        ValorDeducoes = loteRPS.RPS.First().DeducaoRPS.Sum(v => v.ValorDeduzir),
                                        ValorCofins = loteRPS.RPS.First().ValorCOFINS,
                                        ValorCsll = loteRPS.RPS.First().ValorCSLL,
                                        ValorInss = loteRPS.RPS.First().ValorINSS,
                                        ValorIr = loteRPS.RPS.First().ValorIR,
                                        ValorPis = loteRPS.RPS.First().ValorPIS,
                                        ValorIss = loteRPS.RPS.First().ItensRPS.Sum(v => v.ValorTotal) *
                                                   (loteRPS.RPS.First().AliquotaAtividade / 100),
                                        ValorServicos = loteRPS.RPS.First().ItensRPS.Sum(v => v.ValorTotal)
                                        // Todo: DescontoCondicionado
                                        // TODO: DescontoIncondicionado =
                                        // TODO: OutrasRetencoes =
                                    }
                                    // TODO: NUMERO DO PROCESSO
                                    // TODO: CODIGO DE TRIBUTACAO DO MUNICIPIO
                                    // TODO: ResponsavelRetencao
                                    // TODO: ItemListaServico = 
                                },
                                Prestador = new tcIdentificacaoPrestador
                                {
                                    CpfCnpj = new tcCpfCnpj
                                    {
                                        Item = loteRPS.CPFCNPJRemetente,
                                        ItemElementName = loteRPS.CPFCNPJRemetente.Length < 12
                                            ? ItemChoiceType.Cpf
                                            : ItemChoiceType.Cnpj
                                    },
                                    InscricaoMunicipal = loteRPS.RPS.First().InscricaoMunicipalPrestador
                                },
                                Tomador = new tcDadosTomador
                                {
                                    RazaoSocial = loteRPS.RPS.First().RazaoSocialTomador,
                                    Contato = new tcContato
                                    {
                                        Email = loteRPS.RPS.First().EmailTomador,
                                        Telefone = loteRPS.RPS.First().DDDTomador + loteRPS.RPS.First().TelefoneTomador
                                    },
                                    Endereco = new tcEndereco
                                    {
                                        CodigoMunicipio = Convert.ToInt32(loteRPS.RPS.First().CidadeTomador),
                                        Bairro = loteRPS.RPS.First().TipoBairroTomador + " " +
                                                 loteRPS.RPS.First().BairroTomador,
                                        Endereco = loteRPS.RPS.First().TipoLogradouroTomador + " " +
                                                   loteRPS.RPS.First().LogradouroTomador,
                                        CodigoPais = 1058, // TODO: Implementar codigo do pais
                                        Numero = loteRPS.RPS.First().NumeroEnderecoTomador,
                                        Cep = loteRPS.RPS.First().CEPTomador,
                                        Complemento = loteRPS.RPS.First().ComplementoEnderecoTomador
                                        // TODO: Uf = loteRPS.RPS.First().EstadoTomador
                                    },
                                    IdentificacaoTomador = new tcIdentificacaoTomador
                                    {
                                        CpfCnpj = new tcCpfCnpj
                                        {
                                            Item = loteRPS.RPS.First().CPFCNPJTomador,
                                            ItemElementName = loteRPS.RPS.First().CPFCNPJTomador.Length < 12
                                                ? ItemChoiceType.Cpf
                                                : ItemChoiceType.Cnpj
                                        },
                                        InscricaoMunicipal = loteRPS.RPS.First().InscricaoMunicipalTomador
                                    }
                                }
                                // TODO: RegimeEspecialTributacao
                                // TODO: Intermediario = 
                                // TODO: OptanteSimplesNacional =
                                // TODO: IncentivoFiscal =
                                // TODO: ConstrucaoCivil =
                            }
                        }
                    }
                }
            };

            // TODO: VERIFICAR OS NAMESPACES DO XML PARA TATUI
            //XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            //ns.Add("tipos", "http://localhost:8080/WsNFe2/tp");
            //ns.Add("ns1", "http://localhost:8080/WsNFe2/lote");

            var xml = new XmlSerializer(typeof(ReqEnvioLoteRPS));
            string request;
            using (var writer = new UTF8StringWriter())
            {
                // Adiciona os namespaces - xml.Serialize(write, lote, ns);
                xml.Serialize(writer, lote);
                request = writer.ToString();
            }

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(request);
            xmlFile.SignXml(certificado);

            var response = m_ConexaoWsRecepcionar.Execute(xmlFile.OuterXml);

            var res =
                (EnviarLoteRpsResposta) new XmlSerializer(typeof(EnviarLoteRpsResposta)).Deserialize(
                    XmlReader.Create(new StringReader(response)));

            loteRPS.NumeroLote = Convert.ToInt64(res.Items[2]);

            return loteRPS;
        }

        public IEnumerable<NotaFiscal> ConsultarLote(long numeroLote, X509Certificate2 certificado)
        {
            // Serviço indisponível na prefeitura.
            throw new UnavailableServiceException();
        }

        public IEnumerable<NotaFiscal> ConsultarNotas(DateTime inicio, DateTime fim, X509Certificate2 certificado,
            long notaInicial = 0)
        {
            // Serviço indisponível na prefeitura.
            throw new UnavailableServiceException();
        }

        public NotaFiscal ConsultarNFSe(long numeroLote, long numeroNF, string codigoVerificacao,
            X509Certificate2 certificado)
        {
            // Serviço indisponível na prefeitura.
            throw new UnavailableServiceException();
        }

        public NotaFiscal ConsultarRPS(long numeroLote, long numeroRPS, X509Certificate2 certificado)
        {
            throw new NotImplementedException();
        }

        public NotaFiscal CancelarNFSe(long numeroLote, long numeroNF, string codigoVerificacao, string motivo,
            X509Certificate2 certificado)
        {
            throw new NotImplementedException();
        }

        public long ConsultarUltimoRPS()
        {
            // Serviço indisponível na prefeitura.
            throw new UnavailableServiceException();
        }

        public void DownloadNFSe(string link, string output)
        {
            throw new NotImplementedException();
        }

        public string ObterUrlNFSe(long numeroNF, string codigoVerificacao)
        {
            throw new NotImplementedException();
        }
    }
}