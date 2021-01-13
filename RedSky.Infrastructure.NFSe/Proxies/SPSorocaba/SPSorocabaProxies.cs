using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using RedSky.Infrastructure.NFSe.Proxies.Xml;
using RedSky.Infrastructure.NFSe.Proxies.Xml.v4610550;

namespace RedSky.Infrastructure.NFSe.Proxies.SPSorocaba
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class ConsultaSeqRps
    {
        private ConsultaSeqRpsCabecalho m_Cabecalho;

        [XmlAttribute("schemaLocation", Namespace = Namespaces.Xsi)]
        public string XsiSchemaLocation =
            "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ConsultaSeqRps.xsd";

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ConsultaSeqRpsCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class ConsultaSeqRpsCabecalho
    {
        private uint m_CodCid;
        private string m_CPfcnpjRemetente;
        private string m_ImPrestador;
        private sbyte m_SeriePrestacao;
        private bool m_SeriePrestacaoSpecified;
        private long m_Versao;

        public ConsultaSeqRpsCabecalho()
        {
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCid
        {
            get => m_CodCid;
            set => m_CodCid = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string IMPrestador
        {
            get => m_ImPrestador;
            set => m_ImPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CPfcnpjRemetente;
            set => m_CPfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public sbyte SeriePrestacao
        {
            get => m_SeriePrestacao;
            set => m_SeriePrestacao = value;
        }

        [XmlIgnore]
        public bool SeriePrestacaoSpecified
        {
            get => m_SeriePrestacaoSpecified;
            set => m_SeriePrestacaoSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class ReqCancelamentoNFSe
    {
        private ReqCancelamentoNFSeCabecalho m_Cabecalho;
        private tpLoteCancelamentoNFSe m_Lote;
        private SignatureType m_Signature;

        [XmlAttribute("schemaLocation", Namespace = Namespaces.Xsi)]
        public string XsiSchemaLocation =
            "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ReqCancelamentoNFSe.xsd";

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ReqCancelamentoNFSeCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpLoteCancelamentoNFSe Lote
        {
            get => m_Lote;
            set => m_Lote = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class ReqCancelamentoNFSeCabecalho
    {
        private uint m_CodCidade;
        private string m_CPfcnpjRemetente;
        private bool m_Transacao;
        private long m_Versao;

        public ReqCancelamentoNFSeCabecalho()
        {
            m_Transacao = true;
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CPfcnpjRemetente;
            set => m_CPfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public bool transacao
        {
            get => m_Transacao;
            set => m_Transacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class ReqConsultaLote
    {
        private ReqConsultaLoteCabecalho m_Cabecalho;

        [XmlAttribute("schemaLocation", Namespace = Namespaces.Xsi)]
        public string XsiSchemaLocation =
            "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ReqConsultaLote.xsd";

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ReqConsultaLoteCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class ReqConsultaLoteCabecalho
    {
        private uint m_CodCidade;
        private string m_CPfcnpjRemetente;
        private long m_NumeroLote;
        private long m_Versao;

        public ReqConsultaLoteCabecalho()
        {
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CPfcnpjRemetente;
            set => m_CPfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroLote
        {
            get => m_NumeroLote;
            set => m_NumeroLote = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class ReqConsultaNFSeRPS
    {
        private ReqConsultaNFSeRPSCabecalho m_Cabecalho;
        private tpLoteConsultaNFSe m_Lote;
        private SignatureType m_Signature;

        [XmlAttribute("schemaLocation", Namespace = Namespaces.Xsi)]
        public string XsiSchemaLocation =
            "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ReqConsultaNFSeRPS.xsd";

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ReqConsultaNFSeRPSCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpLoteConsultaNFSe Lote
        {
            get => m_Lote;
            set => m_Lote = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class ReqConsultaNFSeRPSCabecalho
    {
        private uint m_CodCidade;
        private string m_CpfcnpjRemetente;
        private bool m_Transacao;
        private long m_Versao;

        public ReqConsultaNFSeRPSCabecalho()
        {
            m_Transacao = true;
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CpfcnpjRemetente;
            set => m_CpfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public bool transacao
        {
            get => m_Transacao;
            set => m_Transacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class ReqConsultaNotas
    {
        private ReqConsultaNotasCabecalho m_Cabecalho;
        private SignatureType m_Signature;

        [XmlAttribute("schemaLocation", Namespace = Namespaces.Xsi)]
        public string XsiSchemaLocation =
            "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ReqConsultaNotas.xsd";

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ReqConsultaNotasCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class ReqConsultaNotasCabecalho
    {
        private uint m_CodCidade;
        private string m_CpfcnpjRemetente;
        private DateTime m_DtFim;
        private DateTime m_DtInicio;
        private string m_Id;
        private string m_InscricaoMunicipalPrestador;
        private long m_NotaInicial;
        private bool m_NotaInicialSpecified;
        private long m_Versao;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CpfcnpjRemetente;
            set => m_CpfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string InscricaoMunicipalPrestador
        {
            get => m_InscricaoMunicipalPrestador;
            set => m_InscricaoMunicipalPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime dtInicio
        {
            get => m_DtInicio;
            set => m_DtInicio = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime dtFim
        {
            get => m_DtFim;
            set => m_DtFim = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NotaInicial
        {
            get => m_NotaInicial;
            set => m_NotaInicial = value;
        }

        [XmlIgnore]
        public bool NotaInicialSpecified
        {
            get => m_NotaInicialSpecified;
            set => m_NotaInicialSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }

        [XmlAttribute]
        public string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class ReqEnvioLoteRPS
    {
        private ReqEnvioLoteRPSCabecalho m_Cabecalho;
        private tpLote m_Lote;
        private SignatureType m_Signature;

        [XmlAttribute("schemaLocation", Namespace = Namespaces.Xsi)]
        public string XsiSchemaLocation =
            "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ReqEnvioLoteRPS.xsd";

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ReqEnvioLoteRPSCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpLote Lote
        {
            get => m_Lote;
            set => m_Lote = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class ReqEnvioLoteRPSCabecalho
    {
        private uint m_CodCidade;
        private string m_CpfcnpjRemetente;
        private DateTime m_DtFim;
        private DateTime m_DtInicio;
        private tpMetodoEnvio m_MetodoEnvio;
        private string m_QtdRps;
        private string m_RazaoSocialRemetente;
        private bool m_Transacao;
        private decimal m_ValorTotalDeducoes;
        private decimal m_ValorTotalServicos;
        private long m_Versao;
        private string m_VersaoComponente;

        public ReqEnvioLoteRPSCabecalho()
        {
            m_Transacao = true;
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CpfcnpjRemetente;
            set => m_CpfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RazaoSocialRemetente
        {
            get => m_RazaoSocialRemetente;
            set => m_RazaoSocialRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public bool transacao
        {
            get => m_Transacao;
            set => m_Transacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified,
            DataType = "date")]
        public DateTime dtInicio
        {
            get => m_DtInicio;
            set => m_DtInicio = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified,
            DataType = "date")]
        public DateTime dtFim
        {
            get => m_DtFim;
            set => m_DtFim = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified,
            DataType = "integer")]
        public string QtdRPS
        {
            get => m_QtdRps;
            set => m_QtdRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorTotalServicos
        {
            get => m_ValorTotalServicos;
            set => m_ValorTotalServicos = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorTotalDeducoes
        {
            get => m_ValorTotalDeducoes;
            set => m_ValorTotalDeducoes = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpMetodoEnvio MetodoEnvio
        {
            get => m_MetodoEnvio;
            set => m_MetodoEnvio = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string VersaoComponente
        {
            get => m_VersaoComponente;
            set => m_VersaoComponente = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class RetornoCancelamentoNFSe
    {
        private tpEvento[] m_Alertas;
        private RetornoCancelamentoNFSeCabecalho m_Cabecalho;
        private tpEvento[] m_Erros;
        private tpNotaCancelamentoNFSe[] m_NotasCanceladas;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RetornoCancelamentoNFSeCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Nota", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpNotaCancelamentoNFSe[] NotasCanceladas
        {
            get => m_NotasCanceladas;
            set => m_NotasCanceladas = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Alerta", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Alertas
        {
            get => m_Alertas;
            set => m_Alertas = value;
        }


        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Erro", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Erros
        {
            get => m_Erros;
            set => m_Erros = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class RetornoCancelamentoNFSeCabecalho
    {
        private uint m_CodCidade;
        private string m_CpfcnpjRemetente;
        private bool m_Sucesso;
        private long m_Versao;

        public RetornoCancelamentoNFSeCabecalho()
        {
            m_Sucesso = true;
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public bool Sucesso
        {
            get => m_Sucesso;
            set => m_Sucesso = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CpfcnpjRemetente;
            set => m_CpfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class RetornoConsultaLote
    {
        private tpEvento[] m_Alertas;
        private RetornoConsultaLoteCabecalho m_Cabecalho;
        private tpEvento[] m_Erros;
        private tpConsultaNFSe[] m_ListaNfSe;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RetornoConsultaLoteCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Alerta", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Alertas
        {
            get => m_Alertas;
            set => m_Alertas = value;
        }


        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Erro", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Erros
        {
            get => m_Erros;
            set => m_Erros = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("ConsultaNFSe", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpConsultaNFSe[] ListaNFSe
        {
            get => m_ListaNfSe;
            set => m_ListaNfSe = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class RetornoConsultaLoteCabecalho
    {
        private uint m_CodCidade;
        private string m_CPfcnpjRemetente;
        private string m_DataEnvioLote;
        private long m_NumeroLote;
        private string m_QtdNotasProcessadas;
        private string m_RazaoSocialRemetente;
        private bool m_Sucesso;
        private long m_TempoProcessamento;
        private decimal m_ValorTotalDeducoes;
        private decimal m_ValorTotalServicos;
        private long m_Versao;

        public RetornoConsultaLoteCabecalho()
        {
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public bool Sucesso
        {
            get => m_Sucesso;
            set => m_Sucesso = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroLote
        {
            get => m_NumeroLote;
            set => m_NumeroLote = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CPfcnpjRemetente;
            set => m_CPfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RazaoSocialRemetente
        {
            get => m_RazaoSocialRemetente;
            set => m_RazaoSocialRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DataEnvioLote
        {
            get => m_DataEnvioLote;
            set => m_DataEnvioLote = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string QtdNotasProcessadas
        {
            get => m_QtdNotasProcessadas;
            set => m_QtdNotasProcessadas = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long TempoProcessamento
        {
            get => m_TempoProcessamento;
            set => m_TempoProcessamento = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorTotalServicos
        {
            get => m_ValorTotalServicos;
            set => m_ValorTotalServicos = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorTotalDeducoes
        {
            get => m_ValorTotalDeducoes;
            set => m_ValorTotalDeducoes = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class RetornoConsultaNFSeRPS
    {
        private tpEvento[] m_Alertas;
        private RetornoConsultaNFSeRPSCabecalho m_Cabecalho;
        private tpEvento[] m_Erros;
        private tpNFSe[] m_NotasConsultadas;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RetornoConsultaNFSeRPSCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Nota", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpNFSe[] NotasConsultadas
        {
            get => m_NotasConsultadas;
            set => m_NotasConsultadas = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Alerta", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Alertas
        {
            get => m_Alertas;
            set => m_Alertas = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Erro", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Erros
        {
            get => m_Erros;
            set => m_Erros = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class RetornoConsultaNFSeRPSCabecalho
    {
        private uint m_CodCidade;
        private string m_CpfcnpjRemetente;
        private bool m_Transacao;
        private long m_Versao;

        public RetornoConsultaNFSeRPSCabecalho()
        {
            m_Transacao = true;
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CpfcnpjRemetente;
            set => m_CpfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public bool transacao
        {
            get => m_Transacao;
            set => m_Transacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class RetornoConsultaNotas
    {
        private RetornoConsultaNotasCabecalho m_Cabecalho;
        private tpEvento[] m_Erros;
        private tpNFSe[] m_Notas;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RetornoConsultaNotasCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Nota", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpNFSe[] Notas
        {
            get => m_Notas;
            set => m_Notas = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Erro", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Erros
        {
            get => m_Erros;
            set => m_Erros = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class RetornoConsultaNotasCabecalho
    {
        private uint m_CodCidade;
        private string m_CpfcnpjRemetente;
        private DateTime m_DtFim;
        private DateTime m_DtInicio;
        private long m_InscricaoMunicipalPrestador;
        private long m_Versao;

        public RetornoConsultaNotasCabecalho()
        {
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CpfcnpjRemetente;
            set => m_CpfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long InscricaoMunicipalPrestador
        {
            get => m_InscricaoMunicipalPrestador;
            set => m_InscricaoMunicipalPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime dtInicio
        {
            get => m_DtInicio;
            set => m_DtInicio = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime dtFim
        {
            get => m_DtFim;
            set => m_DtFim = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class RetornoConsultaSeqRps
    {
        private tpEvento[] m_Alertas;
        private RetornoConsultaSeqRpsCabecalho m_Cabecalho;
        private tpEvento[] m_Erros;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RetornoConsultaSeqRpsCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Alerta", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Alertas
        {
            get => m_Alertas;
            set => m_Alertas = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Erro", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Erros
        {
            get => m_Erros;
            set => m_Erros = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class RetornoConsultaSeqRpsCabecalho
    {
        private uint m_CodCid;
        private string m_CPfcnpjRemetente;
        private string m_ImPrestador;
        private long m_NroUltimoRps;
        private sbyte m_SeriePrestacao;
        private bool m_SeriePrestacaoSpecified;
        private long m_Versao;

        public RetornoConsultaSeqRpsCabecalho()
        {
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCid
        {
            get => m_CodCid;
            set => m_CodCid = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CPfcnpjRemetente;
            set => m_CPfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string IMPrestador
        {
            get => m_ImPrestador;
            set => m_ImPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NroUltimoRps
        {
            get => m_NroUltimoRps;
            set => m_NroUltimoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public sbyte SeriePrestacao
        {
            get => m_SeriePrestacao;
            set => m_SeriePrestacao = value;
        }

        [XmlIgnore]
        public bool SeriePrestacaoSpecified
        {
            get => m_SeriePrestacaoSpecified;
            set => m_SeriePrestacaoSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    [XmlRoot(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public sealed class RetornoEnvioLoteRPS
    {
        private tpEvento[] m_Alertas;
        private RetornoEnvioLoteRPSCabecalho m_Cabecalho;
        private tpChaveNFeRPS[] m_ChavesNfseRps;
        private tpEvento[] m_Erros;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RetornoEnvioLoteRPSCabecalho Cabecalho
        {
            get => m_Cabecalho;
            set => m_Cabecalho = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Alerta", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Alertas
        {
            get => m_Alertas;
            set => m_Alertas = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Erro", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpEvento[] Erros
        {
            get => m_Erros;
            set => m_Erros = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("ChaveNFSeRPS", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpChaveNFeRPS[] ChavesNFSeRPS
        {
            get => m_ChavesNfseRps;
            set => m_ChavesNfseRps = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://localhost:8080/WsNFe2/lote")]
    public sealed class RetornoEnvioLoteRPSCabecalho
    {
        private tpAssincrono m_Assincrono;
        private uint m_CodCidade;
        private string m_CpfcnpjRemetente;
        private DateTime m_DataEnvioLote;
        private long m_NumeroLote;
        private string m_QtdNotasProcessadas;
        private bool m_Sucesso;
        private long m_TempoProcessamento;
        private decimal m_ValorTotalDeducoes;
        private decimal m_ValorTotalServicos;
        private long m_Versao;

        public RetornoEnvioLoteRPSCabecalho()
        {
            m_Versao = 1;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CodCidade
        {
            get => m_CodCidade;
            set => m_CodCidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public bool Sucesso
        {
            get => m_Sucesso;
            set => m_Sucesso = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroLote
        {
            get => m_NumeroLote;
            set => m_NumeroLote = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJRemetente
        {
            get => m_CpfcnpjRemetente;
            set => m_CpfcnpjRemetente = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataEnvioLote
        {
            get => m_DataEnvioLote;
            set => m_DataEnvioLote = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string QtdNotasProcessadas
        {
            get => m_QtdNotasProcessadas;
            set => m_QtdNotasProcessadas = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long TempoProcessamento
        {
            get => m_TempoProcessamento;
            set => m_TempoProcessamento = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorTotalServicos
        {
            get => m_ValorTotalServicos;
            set => m_ValorTotalServicos = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorTotalDeducoes
        {
            get => m_ValorTotalDeducoes;
            set => m_ValorTotalDeducoes = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpAssincrono Assincrono
        {
            get => m_Assincrono;
            set => m_Assincrono = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpAssincrono
    {
        S,
        N
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpChaveNFe
    {
        private string m_CodigoVerificacao;
        private long m_InscricaoPrestador;
        private long m_NumeroNFe;
        private string m_RazaoSocialPrestador;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long InscricaoPrestador
        {
            get => m_InscricaoPrestador;
            set => m_InscricaoPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroNFe
        {
            get => m_NumeroNFe;
            set => m_NumeroNFe = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodigoVerificacao
        {
            get => m_CodigoVerificacao;
            set => m_CodigoVerificacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RazaoSocialPrestador
        {
            get => m_RazaoSocialPrestador;
            set => m_RazaoSocialPrestador = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpChaveNFeRPS
    {
        private tpChaveNFe m_ChaveNFe;
        private tpChaveRPS m_ChaveRps;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpChaveNFe ChaveNFe
        {
            get => m_ChaveNFe;
            set => m_ChaveNFe = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpChaveRPS ChaveRPS
        {
            get => m_ChaveRps;
            set => m_ChaveRps = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpChaveRPS
    {
        private DateTime m_DataEmissaoRps;
        private long m_InscricaoPrestador;
        private long m_NumeroRps;
        private string m_RazaoSocialPrestador;
        private tpSerieRPS m_SerieRps;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long InscricaoPrestador
        {
            get => m_InscricaoPrestador;
            set => m_InscricaoPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpSerieRPS SerieRPS
        {
            get => m_SerieRps;
            set => m_SerieRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroRPS
        {
            get => m_NumeroRps;
            set => m_NumeroRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataEmissaoRPS
        {
            get => m_DataEmissaoRps;
            set => m_DataEmissaoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RazaoSocialPrestador
        {
            get => m_RazaoSocialPrestador;
            set => m_RazaoSocialPrestador = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpConsultaNFSe
    {
        private decimal m_Aliquota;
        private string m_CodigoVerificacao;
        private DateTime m_DataEmissaoRps;
        private long m_InscricaoPrestador;
        private long m_NumeroNFe;
        private long m_NumeroRps;
        private string m_RazaoSocialPrestador;
        private tpSerieRPS m_SerieRps;
        private tpTipoRecolhimento m_TipoRecolhimento;
        private decimal m_ValorDeduzir;
        private bool m_ValorDeduzirSpecified;
        private decimal m_ValorTotal;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long InscricaoPrestador
        {
            get => m_InscricaoPrestador;
            set => m_InscricaoPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroNFe
        {
            get => m_NumeroNFe;
            set => m_NumeroNFe = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodigoVerificacao
        {
            get => m_CodigoVerificacao;
            set => m_CodigoVerificacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpSerieRPS SerieRPS
        {
            get => m_SerieRps;
            set => m_SerieRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroRPS
        {
            get => m_NumeroRps;
            set => m_NumeroRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataEmissaoRPS
        {
            get => m_DataEmissaoRps;
            set => m_DataEmissaoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RazaoSocialPrestador
        {
            get => m_RazaoSocialPrestador;
            set => m_RazaoSocialPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpTipoRecolhimento TipoRecolhimento
        {
            get => m_TipoRecolhimento;
            set => m_TipoRecolhimento = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorDeduzir
        {
            get => m_ValorDeduzir;
            set => m_ValorDeduzir = value;
        }

        [XmlIgnore]
        public bool ValorDeduzirSpecified
        {
            get => m_ValorDeduzirSpecified;
            set => m_ValorDeduzirSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorTotal
        {
            get => m_ValorTotal;
            set => m_ValorTotal = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Aliquota
        {
            get => m_Aliquota;
            set => m_Aliquota = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpDeducaoPor
    {
        Valor,
        Percentual
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpDeducoes
    {
        private string m_CpfcnpjReferencia;
        private tpDeducaoPor m_DeducaoPor;
        private long m_NumeroNfReferencia;
        private bool m_NumeroNfReferenciaSpecified;
        private decimal m_PercentualDeduzir;
        private tpTipoDeducao m_TipoDeducao;
        private decimal m_ValorDeduzir;
        private decimal m_ValorTotalReferencia;
        private bool m_ValorTotalReferenciaSpecified;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpDeducaoPor DeducaoPor
        {
            get => m_DeducaoPor;
            set => m_DeducaoPor = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpTipoDeducao TipoDeducao
        {
            get => m_TipoDeducao;
            set => m_TipoDeducao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJReferencia
        {
            get => m_CpfcnpjReferencia;
            set => m_CpfcnpjReferencia = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroNFReferencia
        {
            get => m_NumeroNfReferencia;
            set => m_NumeroNfReferencia = value;
        }

        [XmlIgnore]
        public bool NumeroNFReferenciaSpecified
        {
            get => m_NumeroNfReferenciaSpecified;
            set => m_NumeroNfReferenciaSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorTotalReferencia
        {
            get => m_ValorTotalReferencia;
            set => m_ValorTotalReferencia = value;
        }

        [XmlIgnore]
        public bool ValorTotalReferenciaSpecified
        {
            get => m_ValorTotalReferenciaSpecified;
            set => m_ValorTotalReferenciaSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal PercentualDeduzir
        {
            get => m_PercentualDeduzir;
            set => m_PercentualDeduzir = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorDeduzir
        {
            get => m_ValorDeduzir;
            set => m_ValorDeduzir = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpEvento
    {
        private tpChaveNFe m_ChaveNFe;
        private tpChaveRPS m_ChaveRps;
        private short m_Codigo;
        private string m_Descricao;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public short Codigo
        {
            get => m_Codigo;
            set => m_Codigo = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Descricao
        {
            get => m_Descricao;
            set => m_Descricao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpChaveRPS ChaveRPS
        {
            get => m_ChaveRps;
            set => m_ChaveRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpChaveNFe ChaveNFe
        {
            get => m_ChaveNFe;
            set => m_ChaveNFe = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpItemTributavel
    {
        S,
        N
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpItens
    {
        private string m_DiscriminacaoServico;
        private decimal m_Quantidade;
        private tpItemTributavel m_Tributavel;
        private bool m_TributavelSpecified;
        private decimal m_ValorTotal;
        private decimal m_ValorUnitario;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DiscriminacaoServico
        {
            get => m_DiscriminacaoServico;
            set => m_DiscriminacaoServico = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Quantidade
        {
            get => m_Quantidade;
            set => m_Quantidade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorUnitario
        {
            get => m_ValorUnitario;
            set => m_ValorUnitario = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorTotal
        {
            get => m_ValorTotal;
            set => m_ValorTotal = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpItemTributavel Tributavel
        {
            get => m_Tributavel;
            set => m_Tributavel = value;
        }

        [XmlIgnore]
        public bool TributavelSpecified
        {
            get => m_TributavelSpecified;
            set => m_TributavelSpecified = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpLote
    {
        private string m_Id;
        private tpRPS[] m_RPs;

        [XmlElement("RPS", Form = XmlSchemaForm.Unqualified)]
        public tpRPS[] RPS
        {
            get => m_RPs;
            set => m_RPs = value;
        }

        [XmlAttribute]
        public string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpLoteCancelamentoNFSe
    {
        private string m_Id;
        private tpNotaCancelamentoNFSe[] m_Nota;

        [XmlElement("Nota", Form = XmlSchemaForm.Unqualified)]
        public tpNotaCancelamentoNFSe[] Nota
        {
            get => m_Nota;
            set => m_Nota = value;
        }

        [XmlAttribute]
        public string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpLoteConsultaNFSe
    {
        private string m_Id;
        private tpNotaConsultaNFSe[] m_NotaConsulta;
        private tpRPSConsultaNFSe[] m_RPsConsulta;

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Nota", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpNotaConsultaNFSe[] NotaConsulta
        {
            get => m_NotaConsulta;
            set => m_NotaConsulta = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("RPS", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpRPSConsultaNFSe[] RPSConsulta
        {
            get => m_RPsConsulta;
            set => m_RPsConsulta = value;
        }

        [XmlAttribute]
        public string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpMetodoEnvio
    {
        WS,
        DLL,
        DMS
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpNFSe
    {
        private decimal m_AliquotaAtividade;
        private decimal m_AliquotaCofins;
        private bool m_AliquotaCofinsSpecified;
        private decimal m_AliquotaCsll;
        private bool m_AliquotaCsllSpecified;
        private decimal m_AliquotaInss;
        private bool m_AliquotaInssSpecified;
        private decimal m_AliquotaIr;
        private bool m_AliquotaIrSpecified;
        private decimal m_AliquotaPis;
        private bool m_AliquotaPisSpecified;
        private byte[] m_Assinatura;
        private string m_BairroTomador;
        private string m_CepTomador;
        private uint m_CidadeTomador;
        private string m_CidadeTomadorDescricao;
        private int m_CodigoAtividade;
        private string m_CodigoVerificacao;
        private string m_ComplementoEnderecoTomador;
        private string m_CpfcnpjIntermediario;
        private string m_CPfcnpjTomador;
        private string m_DataEmissaoNfSeSubstituida;
        private DateTime m_DataEmissaoRps;
        private DateTime m_DataProcessamento;
        private bool m_DataProcessamentoSpecified;
        private string m_DddPrestador;
        private string m_DddTomador;
        private tpDeducoes[] m_Deducoes;
        private string m_DescricaoRps;
        private string m_DocTomadorEstrangeiro;
        private string m_EmailTomador;
        private long m_InscricaoMunicipalPrestador;
        private string m_InscricaoMunicipalTomador;
        private tpItens[] m_Itens;
        private string m_LogradouroTomador;
        private string m_MotCancelamento;
        private uint m_MunicipioPrestacao;
        private string m_MunicipioPrestacaoDescricao;
        private string m_NumeroEnderecoTomador;
        private long m_NumeroLote;
        private bool m_NumeroLoteSpecified;
        private long m_NumeroNfSeSubstituida;
        private bool m_NumeroNfSeSubstituidaSpecified;
        private long m_NumeroNota;
        private long m_NumeroRps;
        private long m_NumeroRpsSubstituido;
        private bool m_NumeroRpsSubstituidoSpecified;
        private tpOperacao m_Operacao;
        private string m_RazaoSocialPrestador;
        private string m_RazaoSocialTomador;
        private sbyte m_SeriePrestacao;
        private bool m_SeriePrestacaoSpecified;
        private tpSerieRPS m_SerieRps;
        private string m_SerieRpsSubstituido;
        private tpSituacaoRPS m_SituacaoRps;
        private string m_TelefonePrestador;
        private string m_TelefoneTomador;
        private string m_TipoBairroTomador;
        private string m_TipoLogradouroTomador;
        private tpTipoRecolhimento m_TipoRecolhimento;
        private tpTipoRPS m_TipoRps;
        private tpTributacao m_Tributacao;
        private decimal m_ValorCofins;
        private bool m_ValorCofinsSpecified;
        private decimal m_ValorCsll;
        private bool m_ValorCsllSpecified;
        private decimal m_ValorInss;
        private bool m_ValorInssSpecified;
        private decimal m_ValorIr;
        private bool m_ValorIrSpecified;
        private decimal m_ValorPis;
        private bool m_ValorPisSpecified;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroNota
        {
            get => m_NumeroNota;
            set => m_NumeroNota = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataProcessamento
        {
            get => m_DataProcessamento;
            set => m_DataProcessamento = value;
        }

        [XmlIgnore]
        public bool DataProcessamentoSpecified
        {
            get => m_DataProcessamentoSpecified;
            set => m_DataProcessamentoSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroLote
        {
            get => m_NumeroLote;
            set => m_NumeroLote = value;
        }

        [XmlIgnore]
        public bool NumeroLoteSpecified
        {
            get => m_NumeroLoteSpecified;
            set => m_NumeroLoteSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodigoVerificacao
        {
            get => m_CodigoVerificacao;
            set => m_CodigoVerificacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "base64Binary")]
        public byte[] Assinatura
        {
            get => m_Assinatura;
            set => m_Assinatura = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long InscricaoMunicipalPrestador
        {
            get => m_InscricaoMunicipalPrestador;
            set => m_InscricaoMunicipalPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RazaoSocialPrestador
        {
            get => m_RazaoSocialPrestador;
            set => m_RazaoSocialPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpTipoRPS TipoRPS
        {
            get => m_TipoRps;
            set => m_TipoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpSerieRPS SerieRPS
        {
            get => m_SerieRps;
            set => m_SerieRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroRPS
        {
            get => m_NumeroRps;
            set => m_NumeroRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataEmissaoRPS
        {
            get => m_DataEmissaoRps;
            set => m_DataEmissaoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpSituacaoRPS SituacaoRPS
        {
            get => m_SituacaoRps;
            set => m_SituacaoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SerieRPSSubstituido
        {
            get => m_SerieRpsSubstituido;
            set => m_SerieRpsSubstituido = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroRPSSubstituido
        {
            get => m_NumeroRpsSubstituido;
            set => m_NumeroRpsSubstituido = value;
        }

        [XmlIgnore]
        public bool NumeroRPSSubstituidoSpecified
        {
            get => m_NumeroRpsSubstituidoSpecified;
            set => m_NumeroRpsSubstituidoSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroNFSeSubstituida
        {
            get => m_NumeroNfSeSubstituida;
            set => m_NumeroNfSeSubstituida = value;
        }

        [XmlIgnore]
        public bool NumeroNFSeSubstituidaSpecified
        {
            get => m_NumeroNfSeSubstituidaSpecified;
            set => m_NumeroNfSeSubstituidaSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DataEmissaoNFSeSubstituida
        {
            get => m_DataEmissaoNfSeSubstituida;
            set => m_DataEmissaoNfSeSubstituida = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public sbyte SeriePrestacao
        {
            get => m_SeriePrestacao;
            set => m_SeriePrestacao = value;
        }

        [XmlIgnore]
        public bool SeriePrestacaoSpecified
        {
            get => m_SeriePrestacaoSpecified;
            set => m_SeriePrestacaoSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string InscricaoMunicipalTomador
        {
            get => m_InscricaoMunicipalTomador;
            set => m_InscricaoMunicipalTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJTomador
        {
            get => m_CPfcnpjTomador;
            set => m_CPfcnpjTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RazaoSocialTomador
        {
            get => m_RazaoSocialTomador;
            set => m_RazaoSocialTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DocTomadorEstrangeiro
        {
            get => m_DocTomadorEstrangeiro;
            set => m_DocTomadorEstrangeiro = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TipoLogradouroTomador
        {
            get => m_TipoLogradouroTomador;
            set => m_TipoLogradouroTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string LogradouroTomador
        {
            get => m_LogradouroTomador;
            set => m_LogradouroTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string NumeroEnderecoTomador
        {
            get => m_NumeroEnderecoTomador;
            set => m_NumeroEnderecoTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ComplementoEnderecoTomador
        {
            get => m_ComplementoEnderecoTomador;
            set => m_ComplementoEnderecoTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TipoBairroTomador
        {
            get => m_TipoBairroTomador;
            set => m_TipoBairroTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BairroTomador
        {
            get => m_BairroTomador;
            set => m_BairroTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CidadeTomador
        {
            get => m_CidadeTomador;
            set => m_CidadeTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CidadeTomadorDescricao
        {
            get => m_CidadeTomadorDescricao;
            set => m_CidadeTomadorDescricao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CEPTomador
        {
            get => m_CepTomador;
            set => m_CepTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string EmailTomador
        {
            get => m_EmailTomador;
            set => m_EmailTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int CodigoAtividade
        {
            get => m_CodigoAtividade;
            set => m_CodigoAtividade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaAtividade
        {
            get => m_AliquotaAtividade;
            set => m_AliquotaAtividade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpTipoRecolhimento TipoRecolhimento
        {
            get => m_TipoRecolhimento;
            set => m_TipoRecolhimento = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint MunicipioPrestacao
        {
            get => m_MunicipioPrestacao;
            set => m_MunicipioPrestacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MunicipioPrestacaoDescricao
        {
            get => m_MunicipioPrestacaoDescricao;
            set => m_MunicipioPrestacaoDescricao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpOperacao Operacao
        {
            get => m_Operacao;
            set => m_Operacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpTributacao Tributacao
        {
            get => m_Tributacao;
            set => m_Tributacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorPIS
        {
            get => m_ValorPis;
            set => m_ValorPis = value;
        }

        [XmlIgnore]
        public bool ValorPISSpecified
        {
            get => m_ValorPisSpecified;
            set => m_ValorPisSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorCOFINS
        {
            get => m_ValorCofins;
            set => m_ValorCofins = value;
        }

        [XmlIgnore]
        public bool ValorCOFINSSpecified
        {
            get => m_ValorCofinsSpecified;
            set => m_ValorCofinsSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorINSS
        {
            get => m_ValorInss;
            set => m_ValorInss = value;
        }

        [XmlIgnore]
        public bool ValorINSSSpecified
        {
            get => m_ValorInssSpecified;
            set => m_ValorInssSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorIR
        {
            get => m_ValorIr;
            set => m_ValorIr = value;
        }

        [XmlIgnore]
        public bool ValorIRSpecified
        {
            get => m_ValorIrSpecified;
            set => m_ValorIrSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorCSLL
        {
            get => m_ValorCsll;
            set => m_ValorCsll = value;
        }

        [XmlIgnore]
        public bool ValorCSLLSpecified
        {
            get => m_ValorCsllSpecified;
            set => m_ValorCsllSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaPIS
        {
            get => m_AliquotaPis;
            set => m_AliquotaPis = value;
        }

        [XmlIgnore]
        public bool AliquotaPISSpecified
        {
            get => m_AliquotaPisSpecified;
            set => m_AliquotaPisSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaCOFINS
        {
            get => m_AliquotaCofins;
            set => m_AliquotaCofins = value;
        }

        [XmlIgnore]
        public bool AliquotaCOFINSSpecified
        {
            get => m_AliquotaCofinsSpecified;
            set => m_AliquotaCofinsSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaINSS
        {
            get => m_AliquotaInss;
            set => m_AliquotaInss = value;
        }

        [XmlIgnore]
        public bool AliquotaINSSSpecified
        {
            get => m_AliquotaInssSpecified;
            set => m_AliquotaInssSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaIR
        {
            get => m_AliquotaIr;
            set => m_AliquotaIr = value;
        }

        [XmlIgnore]
        public bool AliquotaIRSpecified
        {
            get => m_AliquotaIrSpecified;
            set => m_AliquotaIrSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaCSLL
        {
            get => m_AliquotaCsll;
            set => m_AliquotaCsll = value;
        }

        [XmlIgnore]
        public bool AliquotaCSLLSpecified
        {
            get => m_AliquotaCsllSpecified;
            set => m_AliquotaCsllSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DescricaoRPS
        {
            get => m_DescricaoRps;
            set => m_DescricaoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DDDPrestador
        {
            get => m_DddPrestador;
            set => m_DddPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TelefonePrestador
        {
            get => m_TelefonePrestador;
            set => m_TelefonePrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DDDTomador
        {
            get => m_DddTomador;
            set => m_DddTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TelefoneTomador
        {
            get => m_TelefoneTomador;
            set => m_TelefoneTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MotCancelamento
        {
            get => m_MotCancelamento;
            set => m_MotCancelamento = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJIntermediario
        {
            get => m_CpfcnpjIntermediario;
            set => m_CpfcnpjIntermediario = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Deducao", Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public tpDeducoes[] Deducoes
        {
            get => m_Deducoes;
            set => m_Deducoes = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Item", Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public tpItens[] Itens
        {
            get => m_Itens;
            set => m_Itens = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpNotaCancelamentoNFSe
    {
        private string m_CodigoVerificacao;
        private string m_Id;
        private long m_InscricaoMunicipalPrestador;
        private string m_MotivoCancelamento;
        private long m_NumeroNota;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long InscricaoMunicipalPrestador
        {
            get => m_InscricaoMunicipalPrestador;
            set => m_InscricaoMunicipalPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroNota
        {
            get => m_NumeroNota;
            set => m_NumeroNota = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodigoVerificacao
        {
            get => m_CodigoVerificacao;
            set => m_CodigoVerificacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MotivoCancelamento
        {
            get => m_MotivoCancelamento;
            set => m_MotivoCancelamento = value;
        }

        [XmlAttribute]
        public string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpNotaConsultaNFSe
    {
        private string m_CodigoVerificacao;
        private string m_Id;
        private string m_InscricaoMunicipalPrestador;
        private long m_NumeroNota;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string InscricaoMunicipalPrestador
        {
            get => m_InscricaoMunicipalPrestador;
            set => m_InscricaoMunicipalPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroNota
        {
            get => m_NumeroNota;
            set => m_NumeroNota = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodigoVerificacao
        {
            get => m_CodigoVerificacao;
            set => m_CodigoVerificacao = value;
        }

        [XmlAttribute]
        public string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpOperacao
    {
        A,
        B,
        C,
        D,
        J
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpRPS
    {
        private decimal m_AliquotaAtividade;
        private decimal m_AliquotaCofins;
        private decimal m_AliquotaCsll;
        private decimal m_AliquotaInss;
        private decimal m_AliquotaIr;
        private decimal m_AliquotaPis;
        private byte[] m_Assinatura;
        private string m_BairroTomador;
        private int m_CepTomador;
        private uint m_CidadeTomador;
        private string m_CidadeTomadorDescricao;
        private int m_CodigoAtividade;
        private string m_ComplementoEnderecoTomador;
        private string m_CpfcnpjIntermediario;
        private string m_CpfcnpjTomador;
        private string m_DataEmissaoNfSeSubstituida;
        private DateTime m_DataEmissaoRps;
        private string m_DddPrestador;
        private string m_DddTomador;
        private tpDeducoes[] m_Deducoes;
        private string m_DescricaoRps;
        private string m_DocTomadorEstrangeiro;
        private string m_EmailTomador;
        private string m_Id;
        private string m_InscricaoMunicipalPrestador;
        private string m_InscricaoMunicipalTomador;
        private tpItens[] m_Itens;
        private string m_LogradouroTomador;
        private string m_MotCancelamento;
        private uint m_MunicipioPrestacao;
        private string m_MunicipioPrestacaoDescricao;
        private string m_NumeroEnderecoTomador;
        private long m_NumeroNfSeSubstituida;
        private bool m_NumeroNfSeSubstituidaSpecified;
        private long m_NumeroRps;
        private long m_NumeroRpsSubstituido;
        private bool m_NumeroRpsSubstituidoSpecified;
        private tpOperacao m_Operacao;
        private string m_RazaoSocialPrestador;
        private string m_RazaoSocialTomador;
        private sbyte m_SeriePrestacao;
        private tpSerieRPS m_SerieRps;
        private string m_SerieRpsSubstituido;
        private tpSituacaoRPS m_SituacaoRps;
        private string m_TelefonePrestador;
        private string m_TelefoneTomador;
        private string m_TipoBairroTomador;
        private string m_TipoLogradouroTomador;
        private tpTipoRecolhimento m_TipoRecolhimento;
        private tpTipoRPS m_TipoRps;
        private tpTributacao m_Tributacao;
        private decimal m_ValorCofins;
        private decimal m_ValorCsll;
        private decimal m_ValorInss;
        private decimal m_ValorIr;
        private decimal m_ValorPis;

        [XmlElement(Form = XmlSchemaForm.Unqualified,
            DataType = "base64Binary")]
        public byte[] Assinatura
        {
            get => m_Assinatura;
            set => m_Assinatura = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string InscricaoMunicipalPrestador
        {
            get => m_InscricaoMunicipalPrestador;
            set => m_InscricaoMunicipalPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RazaoSocialPrestador
        {
            get => m_RazaoSocialPrestador;
            set => m_RazaoSocialPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpTipoRPS TipoRPS
        {
            get => m_TipoRps;
            set => m_TipoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpSerieRPS SerieRPS
        {
            get => m_SerieRps;
            set => m_SerieRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroRPS
        {
            get => m_NumeroRps;
            set => m_NumeroRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataEmissaoRPS
        {
            get => m_DataEmissaoRps;
            set => m_DataEmissaoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpSituacaoRPS SituacaoRPS
        {
            get => m_SituacaoRps;
            set => m_SituacaoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SerieRPSSubstituido
        {
            get => m_SerieRpsSubstituido;
            set => m_SerieRpsSubstituido = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroRPSSubstituido
        {
            get => m_NumeroRpsSubstituido;
            set => m_NumeroRpsSubstituido = value;
        }

        [XmlIgnore]
        public bool NumeroRPSSubstituidoSpecified
        {
            get => m_NumeroRpsSubstituidoSpecified;
            set => m_NumeroRpsSubstituidoSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroNFSeSubstituida
        {
            get => m_NumeroNfSeSubstituida;
            set => m_NumeroNfSeSubstituida = value;
        }

        [XmlIgnore]
        public bool NumeroNFSeSubstituidaSpecified
        {
            get => m_NumeroNfSeSubstituidaSpecified;
            set => m_NumeroNfSeSubstituidaSpecified = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DataEmissaoNFSeSubstituida
        {
            get => m_DataEmissaoNfSeSubstituida;
            set => m_DataEmissaoNfSeSubstituida = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public sbyte SeriePrestacao
        {
            get => m_SeriePrestacao;
            set => m_SeriePrestacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string InscricaoMunicipalTomador
        {
            get => m_InscricaoMunicipalTomador;
            set => m_InscricaoMunicipalTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJTomador
        {
            get => m_CpfcnpjTomador;
            set => m_CpfcnpjTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RazaoSocialTomador
        {
            get => m_RazaoSocialTomador;
            set => m_RazaoSocialTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DocTomadorEstrangeiro
        {
            get => m_DocTomadorEstrangeiro;
            set => m_DocTomadorEstrangeiro = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TipoLogradouroTomador
        {
            get => m_TipoLogradouroTomador;
            set => m_TipoLogradouroTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string LogradouroTomador
        {
            get => m_LogradouroTomador;
            set => m_LogradouroTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string NumeroEnderecoTomador
        {
            get => m_NumeroEnderecoTomador;
            set => m_NumeroEnderecoTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ComplementoEnderecoTomador
        {
            get => m_ComplementoEnderecoTomador;
            set => m_ComplementoEnderecoTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TipoBairroTomador
        {
            get => m_TipoBairroTomador;
            set => m_TipoBairroTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BairroTomador
        {
            get => m_BairroTomador;
            set => m_BairroTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint CidadeTomador
        {
            get => m_CidadeTomador;
            set => m_CidadeTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CidadeTomadorDescricao
        {
            get => m_CidadeTomadorDescricao;
            set => m_CidadeTomadorDescricao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int CEPTomador
        {
            get => m_CepTomador;
            set => m_CepTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string EmailTomador
        {
            get => m_EmailTomador;
            set => m_EmailTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int CodigoAtividade
        {
            get => m_CodigoAtividade;
            set => m_CodigoAtividade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaAtividade
        {
            get => m_AliquotaAtividade;
            set => m_AliquotaAtividade = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpTipoRecolhimento TipoRecolhimento
        {
            get => m_TipoRecolhimento;
            set => m_TipoRecolhimento = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public uint MunicipioPrestacao
        {
            get => m_MunicipioPrestacao;
            set => m_MunicipioPrestacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MunicipioPrestacaoDescricao
        {
            get => m_MunicipioPrestacaoDescricao;
            set => m_MunicipioPrestacaoDescricao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpOperacao Operacao
        {
            get => m_Operacao;
            set => m_Operacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public tpTributacao Tributacao
        {
            get => m_Tributacao;
            set => m_Tributacao = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorPIS
        {
            get => m_ValorPis;
            set => m_ValorPis = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorCOFINS
        {
            get => m_ValorCofins;
            set => m_ValorCofins = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorINSS
        {
            get => m_ValorInss;
            set => m_ValorInss = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorIR
        {
            get => m_ValorIr;
            set => m_ValorIr = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ValorCSLL
        {
            get => m_ValorCsll;
            set => m_ValorCsll = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaPIS
        {
            get => m_AliquotaPis;
            set => m_AliquotaPis = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaCOFINS
        {
            get => m_AliquotaCofins;
            set => m_AliquotaCofins = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaINSS
        {
            get => m_AliquotaInss;
            set => m_AliquotaInss = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaIR
        {
            get => m_AliquotaIr;
            set => m_AliquotaIr = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaCSLL
        {
            get => m_AliquotaCsll;
            set => m_AliquotaCsll = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DescricaoRPS
        {
            get => m_DescricaoRps;
            set => m_DescricaoRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DDDPrestador
        {
            get => m_DddPrestador;
            set => m_DddPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TelefonePrestador
        {
            get => m_TelefonePrestador;
            set => m_TelefonePrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DDDTomador
        {
            get => m_DddTomador;
            set => m_DddTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TelefoneTomador
        {
            get => m_TelefoneTomador;
            set => m_TelefoneTomador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MotCancelamento
        {
            get => m_MotCancelamento;
            set => m_MotCancelamento = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CPFCNPJIntermediario
        {
            get => m_CpfcnpjIntermediario;
            set => m_CpfcnpjIntermediario = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Deducao", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpDeducoes[] Deducoes
        {
            get => m_Deducoes;
            set => m_Deducoes = value;
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Item", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public tpItens[] Itens
        {
            get => m_Itens;
            set => m_Itens = value;
        }

        [XmlAttribute]
        public string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public sealed class tpRPSConsultaNFSe
    {
        private string m_Id;
        private string m_InscricaoMunicipalPrestador;
        private long m_NumeroRps;
        private sbyte m_SeriePrestacao;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string InscricaoMunicipalPrestador
        {
            get => m_InscricaoMunicipalPrestador;
            set => m_InscricaoMunicipalPrestador = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long NumeroRPS
        {
            get => m_NumeroRps;
            set => m_NumeroRps = value;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public sbyte SeriePrestacao
        {
            get => m_SeriePrestacao;
            set => m_SeriePrestacao = value;
        }

        [XmlAttribute]
        public string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpSerieRPS
    {
        NF
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpSituacaoRPS
    {
        N,
        C
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpTipoDeducao
    {
        [XmlEnum("Despesas com Materiais")] DespesascomMateriais,

        [XmlEnum("Despesas com Subempreitada")]
        DespesascomSubempreitada,

        [XmlEnum("Despesas com Mercadorias")] DespesascomMercadorias,

        [XmlEnum("Servicos de Veiculacao e Divulgacao")]
        ServicosdeVeiculacaoeDivulgacao,

        [XmlEnum("Servicos")] Servicos,

        [XmlEnum("Mapa de Const. Civil")] MapadeConstCivil,

        [XmlEnum("")] Item
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpTipoRecolhimento
    {
        A,
        R
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpTipoRPS
    {
        RPS
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://localhost:8080/WsNFe2/tp")]
    public enum tpTributacao
    {
        C,
        F,
        K,
        E,
        T,
        H,
        G,
        N,
        M
    }
}