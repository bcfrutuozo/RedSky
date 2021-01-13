using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using RedSky.Infrastructure.NFSe.Proxies.Xml.v4610550;

namespace RedSky.Infrastructure.NFSe.Proxies.SPTatui
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class RetCancelamento
    {
        private tcCancelamentoNfse[] m_NfseCancelamento;

        [XmlElement("NfseCancelamento")]
        internal tcCancelamentoNfse[] NfseCancelamento
        {
            get => m_NfseCancelamento;
            set => m_NfseCancelamento = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcCancelamentoNfse
    {
        private tcConfirmacaoCancelamento m_Confirmacao;
        private SignatureType m_Signature;
        private string m_Versao;

        internal tcConfirmacaoCancelamento Confirmacao
        {
            get => m_Confirmacao;
            set => m_Confirmacao = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        internal SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }

        [XmlAttribute(DataType = "token")]
        internal string Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcConfirmacaoCancelamento
    {
        private DateTime m_DataHora;
        private string m_Id;
        private tcPedidoCancelamento m_Pedido;

        internal tcPedidoCancelamento Pedido
        {
            get => m_Pedido;
            set => m_Pedido = value;
        }

        internal DateTime DataHora
        {
            get => m_DataHora;
            set => m_DataHora = value;
        }

        [XmlAttribute]
        internal string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcPedidoCancelamento
    {
        private tcInfPedidoCancelamento m_InfPedidoCancelamento;
        private SignatureType m_Signature;

        internal tcInfPedidoCancelamento InfPedidoCancelamento
        {
            get => m_InfPedidoCancelamento;
            set => m_InfPedidoCancelamento = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        internal SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcInfPedidoCancelamento
    {
        private sbyte m_CodigoCancelamento;
        private bool m_CodigoCancelamentoSpecified;
        private string m_Id;
        private tcIdentificacaoNfse m_IdentificacaoNfse;

        internal tcIdentificacaoNfse IdentificacaoNfse
        {
            get => m_IdentificacaoNfse;
            set => m_IdentificacaoNfse = value;
        }

        internal sbyte CodigoCancelamento
        {
            get => m_CodigoCancelamento;
            set => m_CodigoCancelamento = value;
        }

        [XmlIgnore]
        internal bool CodigoCancelamentoSpecified
        {
            get => m_CodigoCancelamentoSpecified;
            set => m_CodigoCancelamentoSpecified = value;
        }

        [XmlAttribute]
        internal string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcIdentificacaoNfse
    {
        private int m_CodigoMunicipio;
        private tcCpfCnpj m_CpfCnpj;
        private string m_InscricaoMunicipal;
        private string m_Numero;

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string Numero
        {
            get => m_Numero;
            set => m_Numero = value;
        }

        internal tcCpfCnpj CpfCnpj
        {
            get => m_CpfCnpj;
            set => m_CpfCnpj = value;
        }

        internal string InscricaoMunicipal
        {
            get => m_InscricaoMunicipal;
            set => m_InscricaoMunicipal = value;
        }

        internal int CodigoMunicipio
        {
            get => m_CodigoMunicipio;
            set => m_CodigoMunicipio = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcCpfCnpj
    {
        private string m_Item;
        private ItemChoiceType m_ItemElementName;

        [XmlElement("Cnpj", typeof(string))]
        [XmlElement("Cpf", typeof(string))]
        [XmlChoiceIdentifier("ItemElementName")]
        internal string Item
        {
            get => m_Item;
            set => m_Item = value;
        }

        [XmlIgnore]
        internal ItemChoiceType ItemElementName
        {
            get => m_ItemElementName;
            set => m_ItemElementName = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd", IncludeInSchema = false)]
    internal enum ItemChoiceType
    {
        Cnpj,
        Cpf
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ListaMensagemRetornoLote
    {
        private tcMensagemRetornoLote[] m_MensagemRetorno;

        [XmlElement("MensagemRetorno")]
        internal tcMensagemRetornoLote[] MensagemRetorno
        {
            get => m_MensagemRetorno;
            set => m_MensagemRetorno = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcMensagemRetornoLote
    {
        private string m_Codigo;
        private tcIdentificacaoRps m_IdentificacaoRps;
        private string m_Mensagem;

        internal tcIdentificacaoRps IdentificacaoRps
        {
            get => m_IdentificacaoRps;
            set => m_IdentificacaoRps = value;
        }

        internal string Codigo
        {
            get => m_Codigo;
            set => m_Codigo = value;
        }

        internal string Mensagem
        {
            get => m_Mensagem;
            set => m_Mensagem = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcIdentificacaoRps
    {
        private string m_Numero;
        private string m_Serie;
        private sbyte m_Tipo;

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string Numero
        {
            get => m_Numero;
            set => m_Numero = value;
        }

        internal string Serie
        {
            get => m_Serie;
            set => m_Serie = value;
        }

        internal sbyte Tipo
        {
            get => m_Tipo;
            set => m_Tipo = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ListaMensagemRetorno
    {
        private tcMensagemRetorno[] m_MensagemRetorno;

        [XmlElement("MensagemRetorno")]
        internal tcMensagemRetorno[] MensagemRetorno
        {
            get => m_MensagemRetorno;
            set => m_MensagemRetorno = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcMensagemRetorno
    {
        private string m_Codigo;
        private string m_Correcao;
        private string m_Mensagem;

        internal string Codigo
        {
            get => m_Codigo;
            set => m_Codigo = value;
        }

        internal string Mensagem
        {
            get => m_Mensagem;
            set => m_Mensagem = value;
        }

        internal string Correcao
        {
            get => m_Correcao;
            set => m_Correcao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ListaMensagemAlertaRetorno
    {
        private tcMensagemRetorno[] m_MensagemRetorno;

        [XmlElement("MensagemRetorno")]
        internal tcMensagemRetorno[] MensagemRetorno
        {
            get => m_MensagemRetorno;
            set => m_MensagemRetorno = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class cabecalho
    {
        private string m_Versao;
        private string m_VersaoDados;

        [XmlElement(DataType = "token")]
        internal string VersaoDados
        {
            get => m_VersaoDados;
            set => m_VersaoDados = value;
        }

        [XmlAttribute(DataType = "token")]
        internal string Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot("CompNfse", Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class tcCompNfse
    {
        private tcNfse m_Nfse;
        private tcCancelamentoNfse m_NfseCancelamento;
        private tcSubstituicaoNfse m_NfseSubstituicao;

        internal tcNfse Nfse
        {
            get => m_Nfse;
            set => m_Nfse = value;
        }

        internal tcCancelamentoNfse NfseCancelamento
        {
            get => m_NfseCancelamento;
            set => m_NfseCancelamento = value;
        }

        internal tcSubstituicaoNfse NfseSubstituicao
        {
            get => m_NfseSubstituicao;
            set => m_NfseSubstituicao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcNfse
    {
        private tcInfNfse m_InfNfse;
        private SignatureType m_Signature;
        private string m_Versao;

        internal tcInfNfse InfNfse
        {
            get => m_InfNfse;
            set => m_InfNfse = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        internal SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }

        [XmlAttribute(DataType = "token")]
        internal string Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcInfNfse
    {
        private string m_CodigoVerificacao;
        private DateTime m_DataEmissao;
        private tcDeclaracaoPrestacaoServico m_DeclaracaoPrestacaoServico;
        private tcEndereco m_EnderecoPrestadorServico;
        private string m_Id;
        private string m_NfseSubstituida;
        private string m_Numero;
        private tcIdentificacaoOrgaoGerador m_OrgaoGerador;
        private string m_OutrasInformacoes;
        private decimal m_ValorCredito;
        private bool m_ValorCreditoSpecified;
        private tcValoresNfse m_ValoresNfse;

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string Numero
        {
            get => m_Numero;
            set => m_Numero = value;
        }

        internal string CodigoVerificacao
        {
            get => m_CodigoVerificacao;
            set => m_CodigoVerificacao = value;
        }

        internal DateTime DataEmissao
        {
            get => m_DataEmissao;
            set => m_DataEmissao = value;
        }

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string NfseSubstituida
        {
            get => m_NfseSubstituida;
            set => m_NfseSubstituida = value;
        }

        internal string OutrasInformacoes
        {
            get => m_OutrasInformacoes;
            set => m_OutrasInformacoes = value;
        }

        internal tcValoresNfse ValoresNfse
        {
            get => m_ValoresNfse;
            set => m_ValoresNfse = value;
        }

        internal decimal ValorCredito
        {
            get => m_ValorCredito;
            set => m_ValorCredito = value;
        }

        [XmlIgnore]
        internal bool ValorCreditoSpecified
        {
            get => m_ValorCreditoSpecified;
            set => m_ValorCreditoSpecified = value;
        }

        internal tcEndereco EnderecoPrestadorServico
        {
            get => m_EnderecoPrestadorServico;
            set => m_EnderecoPrestadorServico = value;
        }

        internal tcIdentificacaoOrgaoGerador OrgaoGerador
        {
            get => m_OrgaoGerador;
            set => m_OrgaoGerador = value;
        }

        internal tcDeclaracaoPrestacaoServico DeclaracaoPrestacaoServico
        {
            get => m_DeclaracaoPrestacaoServico;
            set => m_DeclaracaoPrestacaoServico = value;
        }

        [XmlAttribute]
        internal string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcValoresNfse
    {
        private decimal m_Aliquota;
        private bool m_AliquotaSpecified;
        private decimal m_BaseCalculo;
        private bool m_BaseCalculoSpecified;
        private decimal m_ValorIss;
        private bool m_ValorIssSpecified;
        private decimal m_ValorLiquidoNfse;

        internal decimal BaseCalculo
        {
            get => m_BaseCalculo;
            set => m_BaseCalculo = value;
        }

        [XmlIgnore]
        internal bool BaseCalculoSpecified
        {
            get => m_BaseCalculoSpecified;
            set => m_BaseCalculoSpecified = value;
        }

        internal decimal Aliquota
        {
            get => m_Aliquota;
            set => m_Aliquota = value;
        }

        [XmlIgnore]
        internal bool AliquotaSpecified
        {
            get => m_AliquotaSpecified;
            set => m_AliquotaSpecified = value;
        }

        internal decimal ValorIss
        {
            get => m_ValorIss;
            set => m_ValorIss = value;
        }

        [XmlIgnore]
        internal bool ValorIssSpecified
        {
            get => m_ValorIssSpecified;
            set => m_ValorIssSpecified = value;
        }

        internal decimal ValorLiquidoNfse
        {
            get => m_ValorLiquidoNfse;
            set => m_ValorLiquidoNfse = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcEndereco
    {
        private string m_Bairro;
        private string m_Cep;
        private int m_CodigoMunicipio;
        private bool m_CodigoMunicipioSpecified;
        private int m_CodigoPais;
        private bool m_CodigoPaisSpecified;
        private string m_Complemento;
        private string m_Endereco;
        private string m_Numero;
        private string m_Uf;

        internal string Endereco
        {
            get => m_Endereco;
            set => m_Endereco = value;
        }

        internal string Numero
        {
            get => m_Numero;
            set => m_Numero = value;
        }

        internal string Complemento
        {
            get => m_Complemento;
            set => m_Complemento = value;
        }

        internal string Bairro
        {
            get => m_Bairro;
            set => m_Bairro = value;
        }

        internal int CodigoMunicipio
        {
            get => m_CodigoMunicipio;
            set => m_CodigoMunicipio = value;
        }

        [XmlIgnore]
        internal bool CodigoMunicipioSpecified
        {
            get => m_CodigoMunicipioSpecified;
            set => m_CodigoMunicipioSpecified = value;
        }

        internal string Uf
        {
            get => m_Uf;
            set => m_Uf = value;
        }

        internal int CodigoPais
        {
            get => m_CodigoPais;
            set => m_CodigoPais = value;
        }


        [XmlIgnore]
        internal bool CodigoPaisSpecified
        {
            get => m_CodigoPaisSpecified;
            set => m_CodigoPaisSpecified = value;
        }

        internal string Cep
        {
            get => m_Cep;
            set => m_Cep = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcIdentificacaoOrgaoGerador
    {
        private int m_CodigoMunicipio;
        private string m_Uf;

        internal int CodigoMunicipio
        {
            get => m_CodigoMunicipio;
            set => m_CodigoMunicipio = value;
        }

        internal string Uf
        {
            get => m_Uf;
            set => m_Uf = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcDeclaracaoPrestacaoServico
    {
        private tcInfDeclaracaoPrestacaoServico m_InfDeclaracaoPrestacaoServico;
        private SignatureType m_Signature;

        internal tcInfDeclaracaoPrestacaoServico InfDeclaracaoPrestacaoServico
        {
            get => m_InfDeclaracaoPrestacaoServico;
            set => m_InfDeclaracaoPrestacaoServico = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        internal SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcInfDeclaracaoPrestacaoServico
    {
        private DateTime m_Competencia;
        private tcDadosConstrucaoCivil m_ConstrucaoCivil;
        private sbyte m_IncentivoFiscal;
        private tcDadosIntermediario m_Intermediario;
        private sbyte m_OptanteSimplesNacional;
        private tcIdentificacaoPrestador m_Prestador;
        private sbyte m_RegimeEspecialTributacao;
        private bool m_RegimeEspecialTributacaoSpecified;
        private tcInfRps m_Rps;
        private tcDadosServico m_Servico;
        private tcDadosTomador m_Tomador;

        internal tcInfRps Rps
        {
            get => m_Rps;
            set => m_Rps = value;
        }

        internal DateTime Competencia
        {
            get => m_Competencia;
            set => m_Competencia = value;
        }

        internal tcDadosServico Servico
        {
            get => m_Servico;
            set => m_Servico = value;
        }

        internal tcIdentificacaoPrestador Prestador
        {
            get => m_Prestador;
            set => m_Prestador = value;
        }

        internal tcDadosTomador Tomador
        {
            get => m_Tomador;
            set => m_Tomador = value;
        }

        internal tcDadosIntermediario Intermediario
        {
            get => m_Intermediario;
            set => m_Intermediario = value;
        }

        internal tcDadosConstrucaoCivil ConstrucaoCivil
        {
            get => m_ConstrucaoCivil;
            set => m_ConstrucaoCivil = value;
        }

        internal sbyte RegimeEspecialTributacao
        {
            get => m_RegimeEspecialTributacao;
            set => m_RegimeEspecialTributacao = value;
        }

        [XmlIgnore]
        internal bool RegimeEspecialTributacaoSpecified
        {
            get => m_RegimeEspecialTributacaoSpecified;
            set => m_RegimeEspecialTributacaoSpecified = value;
        }

        internal sbyte OptanteSimplesNacional
        {
            get => m_OptanteSimplesNacional;
            set => m_OptanteSimplesNacional = value;
        }

        internal sbyte IncentivoFiscal
        {
            get => m_IncentivoFiscal;
            set => m_IncentivoFiscal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcInfRps
    {
        private DateTime m_DataEmissao;
        private string m_Id;
        private tcIdentificacaoRps m_IdentificacaoRps;
        private tcIdentificacaoRps m_RpsSubstituido;
        private sbyte m_Status;

        internal tcIdentificacaoRps IdentificacaoRps
        {
            get => m_IdentificacaoRps;
            set => m_IdentificacaoRps = value;
        }

        internal DateTime DataEmissao
        {
            get => m_DataEmissao;
            set => m_DataEmissao = value;
        }

        internal sbyte Status
        {
            get => m_Status;
            set => m_Status = value;
        }

        internal tcIdentificacaoRps RpsSubstituido
        {
            get => m_RpsSubstituido;
            set => m_RpsSubstituido = value;
        }

        [XmlAttribute]
        internal string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcDadosServico
    {
        private int m_CodigoCnae;
        private bool m_CodigoCnaeSpecified;
        private int m_CodigoMunicipio;
        private string m_CodigoPais;
        private string m_CodigoTributacaoMunicipio;
        private string m_Discriminacao;
        private sbyte m_ExigibilidadeIss;
        private sbyte m_IssRetido;
        private string m_ItemListaServico;
        private int m_MunicipioIncidencia;
        private bool m_MunicipioIncidenciaSpecified;
        private string m_NumeroProcesso;
        private sbyte m_ResponsavelRetencao;
        private bool m_ResponsavelRetencaoSpecified;
        private tcValoresDeclaracaoServico m_Valores;

        internal tcValoresDeclaracaoServico Valores
        {
            get => m_Valores;
            set => m_Valores = value;
        }

        internal sbyte IssRetido
        {
            get => m_IssRetido;
            set => m_IssRetido = value;
        }

        internal sbyte ResponsavelRetencao
        {
            get => m_ResponsavelRetencao;
            set => m_ResponsavelRetencao = value;
        }

        [XmlIgnore]
        internal bool ResponsavelRetencaoSpecified
        {
            get => m_ResponsavelRetencaoSpecified;
            set => m_ResponsavelRetencaoSpecified = value;
        }

        internal string ItemListaServico
        {
            get => m_ItemListaServico;
            set => m_ItemListaServico = value;
        }

        internal int CodigoCnae
        {
            get => m_CodigoCnae;
            set => m_CodigoCnae = value;
        }

        [XmlIgnore]
        internal bool CodigoCnaeSpecified
        {
            get => m_CodigoCnaeSpecified;
            set => m_CodigoCnaeSpecified = value;
        }

        internal string CodigoTributacaoMunicipio
        {
            get => m_CodigoTributacaoMunicipio;
            set => m_CodigoTributacaoMunicipio = value;
        }

        internal string Discriminacao
        {
            get => m_Discriminacao;
            set => m_Discriminacao = value;
        }

        internal int CodigoMunicipio
        {
            get => m_CodigoMunicipio;
            set => m_CodigoMunicipio = value;
        }

        internal string CodigoPais
        {
            get => m_CodigoPais;
            set => m_CodigoPais = value;
        }

        internal sbyte ExigibilidadeISS
        {
            get => m_ExigibilidadeIss;
            set => m_ExigibilidadeIss = value;
        }

        internal int MunicipioIncidencia
        {
            get => m_MunicipioIncidencia;
            set => m_MunicipioIncidencia = value;
        }

        [XmlIgnore]
        internal bool MunicipioIncidenciaSpecified
        {
            get => m_MunicipioIncidenciaSpecified;
            set => m_MunicipioIncidenciaSpecified = value;
        }

        internal string NumeroProcesso
        {
            get => m_NumeroProcesso;
            set => m_NumeroProcesso = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcValoresDeclaracaoServico
    {
        private decimal m_Aliquota;
        private bool m_AliquotaSpecified;
        private decimal m_DescontoCondicionado;
        private bool m_DescontoCondicionadoSpecified;
        private decimal m_DescontoIncondicionado;
        private bool m_DescontoIncondicionadoSpecified;
        private decimal m_OutrasRetencoes;
        private bool m_OutrasRetencoesSpecified;
        private decimal m_ValorCofins;
        private bool m_ValorCofinsSpecified;
        private decimal m_ValorCsll;
        private bool m_ValorCsllSpecified;
        private decimal m_ValorDeducoes;
        private bool m_ValorDeducoesSpecified;
        private decimal m_ValorInss;
        private bool m_ValorInssSpecified;
        private decimal m_ValorIr;
        private bool m_ValorIrSpecified;
        private decimal m_ValorIss;
        private bool m_ValorIssSpecified;
        private decimal m_ValorPis;
        private bool m_ValorPisSpecified;
        private decimal m_ValorServicos;

        internal decimal ValorServicos
        {
            get => m_ValorServicos;
            set => m_ValorServicos = value;
        }

        internal decimal ValorDeducoes
        {
            get => m_ValorDeducoes;
            set => m_ValorDeducoes = value;
        }

        [XmlIgnore]
        internal bool ValorDeducoesSpecified
        {
            get => m_ValorDeducoesSpecified;
            set => m_ValorDeducoesSpecified = value;
        }

        internal decimal ValorPis
        {
            get => m_ValorPis;
            set => m_ValorPis = value;
        }

        [XmlIgnore]
        internal bool ValorPisSpecified
        {
            get => m_ValorPisSpecified;
            set => m_ValorPisSpecified = value;
        }

        internal decimal ValorCofins
        {
            get => m_ValorCofins;
            set => m_ValorCofins = value;
        }

        [XmlIgnore]
        internal bool ValorCofinsSpecified
        {
            get => m_ValorCofinsSpecified;
            set => m_ValorCofinsSpecified = value;
        }

        internal decimal ValorInss
        {
            get => m_ValorInss;
            set => m_ValorInss = value;
        }

        [XmlIgnore]
        internal bool ValorInssSpecified
        {
            get => m_ValorInssSpecified;
            set => m_ValorInssSpecified = value;
        }

        internal decimal ValorIr
        {
            get => m_ValorIr;
            set => m_ValorIr = value;
        }

        [XmlIgnore]
        internal bool ValorIrSpecified
        {
            get => m_ValorIrSpecified;
            set => m_ValorIrSpecified = value;
        }

        internal decimal ValorCsll
        {
            get => m_ValorCsll;
            set => m_ValorCsll = value;
        }

        [XmlIgnore]
        internal bool ValorCsllSpecified
        {
            get => m_ValorCsllSpecified;
            set => m_ValorCsllSpecified = value;
        }

        internal decimal OutrasRetencoes
        {
            get => m_OutrasRetencoes;
            set => m_OutrasRetencoes = value;
        }

        [XmlIgnore]
        internal bool OutrasRetencoesSpecified
        {
            get => m_OutrasRetencoesSpecified;
            set => m_OutrasRetencoesSpecified = value;
        }

        internal decimal ValorIss
        {
            get => m_ValorIss;
            set => m_ValorIss = value;
        }

        [XmlIgnore]
        internal bool ValorIssSpecified
        {
            get => m_ValorIssSpecified;
            set => m_ValorIssSpecified = value;
        }

        internal decimal Aliquota
        {
            get => m_Aliquota;
            set => m_Aliquota = value;
        }

        [XmlIgnore]
        internal bool AliquotaSpecified
        {
            get => m_AliquotaSpecified;
            set => m_AliquotaSpecified = value;
        }

        internal decimal DescontoIncondicionado
        {
            get => m_DescontoIncondicionado;
            set => m_DescontoIncondicionado = value;
        }

        [XmlIgnore]
        internal bool DescontoIncondicionadoSpecified
        {
            get => m_DescontoIncondicionadoSpecified;
            set => m_DescontoIncondicionadoSpecified = value;
        }

        internal decimal DescontoCondicionado
        {
            get => m_DescontoCondicionado;
            set => m_DescontoCondicionado = value;
        }

        [XmlIgnore]
        internal bool DescontoCondicionadoSpecified
        {
            get => m_DescontoCondicionadoSpecified;
            set => m_DescontoCondicionadoSpecified = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcIdentificacaoPrestador
    {
        private tcCpfCnpj m_CpfCnpj;
        private string m_InscricaoMunicipal;

        internal tcCpfCnpj CpfCnpj
        {
            get => m_CpfCnpj;
            set => m_CpfCnpj = value;
        }

        internal string InscricaoMunicipal
        {
            get => m_InscricaoMunicipal;
            set => m_InscricaoMunicipal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcDadosTomador
    {
        private tcContato m_Contato;
        private tcEndereco m_Endereco;
        private tcIdentificacaoTomador m_IdentificacaoTomador;
        private string m_RazaoSocial;

        internal tcIdentificacaoTomador IdentificacaoTomador
        {
            get => m_IdentificacaoTomador;
            set => m_IdentificacaoTomador = value;
        }

        internal string RazaoSocial
        {
            get => m_RazaoSocial;
            set => m_RazaoSocial = value;
        }

        internal tcEndereco Endereco
        {
            get => m_Endereco;
            set => m_Endereco = value;
        }

        internal tcContato Contato
        {
            get => m_Contato;
            set => m_Contato = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcIdentificacaoTomador
    {
        private tcCpfCnpj m_CpfCnpj;
        private string m_InscricaoMunicipal;

        internal tcCpfCnpj CpfCnpj
        {
            get => m_CpfCnpj;
            set => m_CpfCnpj = value;
        }

        internal string InscricaoMunicipal
        {
            get => m_InscricaoMunicipal;
            set => m_InscricaoMunicipal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcContato
    {
        private string m_Email;
        private string m_Telefone;

        internal string Telefone
        {
            get => m_Telefone;
            set => m_Telefone = value;
        }

        internal string Email
        {
            get => m_Email;
            set => m_Email = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcDadosIntermediario
    {
        private tcIdentificacaoIntermediario m_IdentificacaoIntermediario;
        private string m_RazaoSocial;

        internal tcIdentificacaoIntermediario IdentificacaoIntermediario
        {
            get => m_IdentificacaoIntermediario;
            set => m_IdentificacaoIntermediario = value;
        }

        internal string RazaoSocial
        {
            get => m_RazaoSocial;
            set => m_RazaoSocial = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcIdentificacaoIntermediario
    {
        private tcCpfCnpj m_CpfCnpj;
        private string m_InscricaoMunicipal;

        internal tcCpfCnpj CpfCnpj
        {
            get => m_CpfCnpj;
            set => m_CpfCnpj = value;
        }

        internal string InscricaoMunicipal
        {
            get => m_InscricaoMunicipal;
            set => m_InscricaoMunicipal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcDadosConstrucaoCivil
    {
        private string m_Art;
        private string m_CodigoObra;

        internal string CodigoObra
        {
            get => m_CodigoObra;
            set => m_CodigoObra = value;
        }

        internal string Art
        {
            get => m_Art;
            set => m_Art = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcSubstituicaoNfse
    {
        private SignatureType[] m_Signature;
        private tcInfSubstituicaoNfse m_SubstituicaoNfse;
        private string m_Versao;

        internal tcInfSubstituicaoNfse SubstituicaoNfse
        {
            get => m_SubstituicaoNfse;
            set => m_SubstituicaoNfse = value;
        }

        [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        internal SignatureType[] Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }

        [XmlAttribute(DataType = "token")]
        internal string Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcInfSubstituicaoNfse
    {
        private string m_Id;
        private string m_NfseSubstituidora;

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string NfseSubstituidora
        {
            get => m_NfseSubstituidora;
            set => m_NfseSubstituidora = value;
        }

        [XmlAttribute]
        internal string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class EnviarLoteRpsEnvio
    {
        private tcLoteRps m_LoteRps;
        private SignatureType m_Signature;

        internal tcLoteRps LoteRps
        {
            get => m_LoteRps;
            set => m_LoteRps = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        internal SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcLoteRps
    {
        private tcCpfCnpj m_CpfCnpj;
        private string m_Id;
        private string m_InscricaoMunicipal;
        private tcLoteRpsListaRps m_ListaRps;
        private string m_NumeroLote;
        private int m_QuantidadeRps;
        private string m_Versao;

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string NumeroLote
        {
            get => m_NumeroLote;
            set => m_NumeroLote = value;
        }

        internal tcCpfCnpj CpfCnpj
        {
            get => m_CpfCnpj;
            set => m_CpfCnpj = value;
        }

        internal string InscricaoMunicipal
        {
            get => m_InscricaoMunicipal;
            set => m_InscricaoMunicipal = value;
        }

        internal int QuantidadeRps
        {
            get => m_QuantidadeRps;
            set => m_QuantidadeRps = value;
        }

        internal tcLoteRpsListaRps ListaRps
        {
            get => m_ListaRps;
            set => m_ListaRps = value;
        }

        [XmlAttribute]
        internal string Id
        {
            get => m_Id;
            set => m_Id = value;
        }

        [XmlAttribute(DataType = "token")]
        internal string Versao
        {
            get => m_Versao;
            set => m_Versao = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcLoteRpsListaRps
    {
        private tcDeclaracaoPrestacaoServico m_Rps;

        internal tcDeclaracaoPrestacaoServico Rps
        {
            get => m_Rps;
            set => m_Rps = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class EnviarLoteRpsResposta
    {
        private object[] m_Items;
        private ItemsChoiceType[] m_ItemsElementName;

        [XmlElement("DataRecebimento", typeof(DateTime))]
        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        [XmlElement("NumeroLote", typeof(string), DataType = "nonNegativeInteger")]
        [XmlElement("Protocolo", typeof(string))]
        [XmlChoiceIdentifier("ItemsElementName")]
        internal object[] Items
        {
            get => m_Items;
            set => m_Items = value;
        }

        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        internal ItemsChoiceType[] ItemsElementName
        {
            get => m_ItemsElementName;
            set => m_ItemsElementName = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd", IncludeInSchema = false)]
    internal enum ItemsChoiceType
    {
        DataRecebimento,
        ListaMensagemRetorno,
        NumeroLote,
        Protocolo
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class EnviarLoteRpsSincronoEnvio
    {
        private tcLoteRps m_LoteRps;
        private SignatureType m_Signature;

        internal tcLoteRps LoteRps
        {
            get => m_LoteRps;
            set => m_LoteRps = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        internal SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class EnviarLoteRpsSincronoResposta
    {
        private DateTime m_DataRecebimento;
        private bool m_DataRecebimentoSpecified;
        private object m_Item;
        private string m_NumeroLote;
        private string m_Protocolo;

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string NumeroLote
        {
            get => m_NumeroLote;
            set => m_NumeroLote = value;
        }

        internal DateTime DataRecebimento
        {
            get => m_DataRecebimento;
            set => m_DataRecebimento = value;
        }

        [XmlIgnore]
        internal bool DataRecebimentoSpecified
        {
            get => m_DataRecebimentoSpecified;
            set => m_DataRecebimentoSpecified = value;
        }

        internal string Protocolo
        {
            get => m_Protocolo;
            set => m_Protocolo = value;
        }

        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        [XmlElement("ListaMensagemRetornoLote", typeof(ListaMensagemRetornoLote))]
        [XmlElement("ListaNfse", typeof(EnviarLoteRpsSincronoRespostaListaNfse))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class EnviarLoteRpsSincronoRespostaListaNfse
    {
        private tcCompNfse m_CompNfse;
        private tcMensagemRetorno[] m_ListaMensagemAlertaRetorno;

        internal tcCompNfse CompNfse
        {
            get => m_CompNfse;
            set => m_CompNfse = value;
        }

        [XmlArrayItem("MensagemRetorno", IsNullable = false)]
        internal tcMensagemRetorno[] ListaMensagemAlertaRetorno
        {
            get => m_ListaMensagemAlertaRetorno;
            set => m_ListaMensagemAlertaRetorno = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class GerarNfseEnvio
    {
        private tcDeclaracaoPrestacaoServico m_Rps;

        internal tcDeclaracaoPrestacaoServico Rps
        {
            get => m_Rps;
            set => m_Rps = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class GerarNfseResposta
    {
        private object m_Item;

        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        [XmlElement("ListaNfse", typeof(GerarNfseRespostaListaNfse))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class GerarNfseRespostaListaNfse
    {
        private tcCompNfse m_CompNfse;
        private tcMensagemRetorno[] m_ListaMensagemAlertaRetorno;

        internal tcCompNfse CompNfse
        {
            get => m_CompNfse;
            set => m_CompNfse = value;
        }

        [XmlArrayItem("MensagemRetorno", IsNullable = false)]
        internal tcMensagemRetorno[] ListaMensagemAlertaRetorno
        {
            get => m_ListaMensagemAlertaRetorno;
            set => m_ListaMensagemAlertaRetorno = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class CancelarNfseEnvio
    {
        private tcPedidoCancelamento m_Pedido;

        internal tcPedidoCancelamento Pedido
        {
            get => m_Pedido;
            set => m_Pedido = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class CancelarNfseResposta
    {
        private object m_Item;

        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        [XmlElement("RetCancelamento", typeof(RetCancelamento))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class SubstituirNfseEnvio
    {
        private SignatureType m_Signature;
        private SubstituirNfseEnvioSubstituicaoNfse m_SubstituicaoNfse;

        internal SubstituirNfseEnvioSubstituicaoNfse SubstituicaoNfse
        {
            get => m_SubstituicaoNfse;
            set => m_SubstituicaoNfse = value;
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        internal SignatureType Signature
        {
            get => m_Signature;
            set => m_Signature = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class SubstituirNfseEnvioSubstituicaoNfse
    {
        private string m_Id;
        private tcPedidoCancelamento m_Pedido;
        private tcDeclaracaoPrestacaoServico m_Rps;

        internal tcPedidoCancelamento Pedido
        {
            get => m_Pedido;
            set => m_Pedido = value;
        }

        internal tcDeclaracaoPrestacaoServico Rps
        {
            get => m_Rps;
            set => m_Rps = value;
        }

        [XmlAttribute]
        internal string Id
        {
            get => m_Id;
            set => m_Id = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class SubstituirNfseResposta
    {
        private object m_Item;

        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        [XmlElement("RetSubstituicao", typeof(SubstituirNfseRespostaRetSubstituicao))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class SubstituirNfseRespostaRetSubstituicao
    {
        private SubstituirNfseRespostaRetSubstituicaoNfseSubstituida m_NfseSubstituida;
        private SubstituirNfseRespostaRetSubstituicaoNfseSubstituidora m_NfseSubstituidora;

        internal SubstituirNfseRespostaRetSubstituicaoNfseSubstituida NfseSubstituida
        {
            get => m_NfseSubstituida;
            set => m_NfseSubstituida = value;
        }

        internal SubstituirNfseRespostaRetSubstituicaoNfseSubstituidora NfseSubstituidora
        {
            get => m_NfseSubstituidora;
            set => m_NfseSubstituidora = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class SubstituirNfseRespostaRetSubstituicaoNfseSubstituida
    {
        private tcCompNfse m_CompNfse;
        private tcMensagemRetorno[] m_ListaMensagemAlertaRetorno;

        internal tcCompNfse CompNfse
        {
            get => m_CompNfse;
            set => m_CompNfse = value;
        }

        [XmlArrayItem("MensagemRetorno", IsNullable = false)]
        internal tcMensagemRetorno[] ListaMensagemAlertaRetorno
        {
            get => m_ListaMensagemAlertaRetorno;
            set => m_ListaMensagemAlertaRetorno = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class SubstituirNfseRespostaRetSubstituicaoNfseSubstituidora
    {
        private tcCompNfse m_CompNfse;

        internal tcCompNfse CompNfse
        {
            get => m_CompNfse;
            set => m_CompNfse = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarLoteRpsEnvio
    {
        private tcIdentificacaoPrestador m_Prestador;
        private string m_Protocolo;

        internal tcIdentificacaoPrestador Prestador
        {
            get => m_Prestador;
            set => m_Prestador = value;
        }

        internal string Protocolo
        {
            get => m_Protocolo;
            set => m_Protocolo = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarLoteRpsResposta
    {
        private object m_Item;
        private sbyte m_Situacao;

        internal sbyte Situacao
        {
            get => m_Situacao;
            set => m_Situacao = value;
        }

        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        [XmlElement("ListaMensagemRetornoLote", typeof(ListaMensagemRetornoLote))]
        [XmlElement("ListaNfse", typeof(ConsultarLoteRpsRespostaListaNfse))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class ConsultarLoteRpsRespostaListaNfse
    {
        private tcCompNfse[] m_CompNfse;
        private tcMensagemRetorno[] m_ListaMensagemAlertaRetorno;

        [XmlElement("CompNfse")]
        internal tcCompNfse[] CompNfse
        {
            get => m_CompNfse;
            set => m_CompNfse = value;
        }

        [XmlArrayItem("MensagemRetorno", IsNullable = false)]
        internal tcMensagemRetorno[] ListaMensagemAlertaRetorno
        {
            get => m_ListaMensagemAlertaRetorno;
            set => m_ListaMensagemAlertaRetorno = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarNfseRpsEnvio
    {
        private tcIdentificacaoRps m_IdentificacaoRps;
        private tcIdentificacaoPrestador m_Prestador;

        internal tcIdentificacaoRps IdentificacaoRps
        {
            get => m_IdentificacaoRps;
            set => m_IdentificacaoRps = value;
        }

        internal tcIdentificacaoPrestador Prestador
        {
            get => m_Prestador;
            set => m_Prestador = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarNfseRpsResposta
    {
        private object m_Item;

        [XmlElement("CompNfse", typeof(tcCompNfse))]
        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarNfseServicoPrestadoEnvio
    {
        private tcIdentificacaoIntermediario m_Intermediario;
        private object m_Item;
        private string m_NumeroNfse;
        private string m_Pagina;
        private tcIdentificacaoPrestador m_Prestador;
        private tcIdentificacaoTomador m_Tomador;

        internal tcIdentificacaoPrestador Prestador
        {
            get => m_Prestador;
            set => m_Prestador = value;
        }

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string NumeroNfse
        {
            get => m_NumeroNfse;
            set => m_NumeroNfse = value;
        }

        [XmlElement("PeriodoCompetencia", typeof(ConsultarNfseServicoPrestadoEnvioPeriodoCompetencia))]
        [XmlElement("PeriodoEmissao", typeof(ConsultarNfseServicoPrestadoEnvioPeriodoEmissao))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }

        internal tcIdentificacaoTomador Tomador
        {
            get => m_Tomador;
            set => m_Tomador = value;
        }

        internal tcIdentificacaoIntermediario Intermediario
        {
            get => m_Intermediario;
            set => m_Intermediario = value;
        }

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string Pagina
        {
            get => m_Pagina;
            set => m_Pagina = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class ConsultarNfseServicoPrestadoEnvioPeriodoCompetencia
    {
        private DateTime m_DataFinal;
        private DateTime m_DataInicial;

        [XmlElement(DataType = "date")]
        internal DateTime DataInicial
        {
            get => m_DataInicial;
            set => m_DataInicial = value;
        }

        [XmlElement(DataType = "date")]
        internal DateTime DataFinal
        {
            get => m_DataFinal;
            set => m_DataFinal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class ConsultarNfseServicoPrestadoEnvioPeriodoEmissao
    {
        private DateTime m_DataFinal;
        private DateTime m_DataInicial;

        [XmlElement(DataType = "date")]
        internal DateTime DataInicial
        {
            get => m_DataInicial;
            set => m_DataInicial = value;
        }

        [XmlElement(DataType = "date")]
        internal DateTime DataFinal
        {
            get => m_DataFinal;
            set => m_DataFinal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarNfseServicoPrestadoResposta
    {
        private object m_Item;

        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        [XmlElement("ListaNfse", typeof(ConsultarNfseServicoPrestadoRespostaListaNfse))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class ConsultarNfseServicoPrestadoRespostaListaNfse
    {
        private tcCompNfse[] m_CompNfse;
        private string m_ProximaPagina;

        [XmlElement("CompNfse")]
        internal tcCompNfse[] CompNfse
        {
            get => m_CompNfse;
            set => m_CompNfse = value;
        }

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string ProximaPagina
        {
            get => m_ProximaPagina;
            set => m_ProximaPagina = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarNfseServicoTomadoEnvio
    {
        private tcIdentificacaoConsulente m_Consulente;
        private tcIdentificacaoIntermediario m_Intermediario;
        private object m_Item;
        private string m_NumeroNfse;
        private string m_Pagina;
        private tcIdentificacaoPrestador m_Prestador;
        private tcIdentificacaoTomador m_Tomador;

        internal tcIdentificacaoConsulente Consulente
        {
            get => m_Consulente;
            set => m_Consulente = value;
        }

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string NumeroNfse
        {
            get => m_NumeroNfse;
            set => m_NumeroNfse = value;
        }

        [XmlElement("PeriodoCompetencia", typeof(ConsultarNfseServicoTomadoEnvioPeriodoCompetencia))]
        [XmlElement("PeriodoEmissao", typeof(ConsultarNfseServicoTomadoEnvioPeriodoEmissao))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }

        internal tcIdentificacaoPrestador Prestador
        {
            get => m_Prestador;
            set => m_Prestador = value;
        }

        internal tcIdentificacaoTomador Tomador
        {
            get => m_Tomador;
            set => m_Tomador = value;
        }

        internal tcIdentificacaoIntermediario Intermediario
        {
            get => m_Intermediario;
            set => m_Intermediario = value;
        }

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string Pagina
        {
            get => m_Pagina;
            set => m_Pagina = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class tcIdentificacaoConsulente
    {
        private tcCpfCnpj m_CpfCnpj;
        private string m_InscricaoMunicipal;

        internal tcCpfCnpj CpfCnpj
        {
            get => m_CpfCnpj;
            set => m_CpfCnpj = value;
        }

        internal string InscricaoMunicipal
        {
            get => m_InscricaoMunicipal;
            set => m_InscricaoMunicipal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class ConsultarNfseServicoTomadoEnvioPeriodoCompetencia
    {
        private DateTime m_DataFinal;
        private DateTime m_DataInicial;

        [XmlElement(DataType = "date")]
        internal DateTime DataInicial
        {
            get => m_DataInicial;
            set => m_DataInicial = value;
        }

        [XmlElement(DataType = "date")]
        internal DateTime DataFinal
        {
            get => m_DataFinal;
            set => m_DataFinal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class ConsultarNfseServicoTomadoEnvioPeriodoEmissao
    {
        private DateTime m_DataFinal;
        private DateTime m_DataInicial;

        [XmlElement(DataType = "date")]
        internal DateTime DataInicial
        {
            get => m_DataInicial;
            set => m_DataInicial = value;
        }

        [XmlElement(DataType = "date")]
        internal DateTime DataFinal
        {
            get => m_DataFinal;
            set => m_DataFinal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarNfseServicoTomadoResposta
    {
        private object m_Item;

        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        [XmlElement("ListaNfse", typeof(ConsultarNfseServicoTomadoRespostaListaNfse))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class ConsultarNfseServicoTomadoRespostaListaNfse
    {
        private tcCompNfse[] m_CompNfse;
        private string m_ProximaPagina;

        [XmlElement("CompNfse")]
        internal tcCompNfse[] CompNfse
        {
            get => m_CompNfse;
            set => m_CompNfse = value;
        }

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string ProximaPagina
        {
            get => m_ProximaPagina;
            set => m_ProximaPagina = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarNfseFaixaEnvio
    {
        private ConsultarNfseFaixaEnvioFaixa m_Faixa;
        private string m_Pagina;
        private tcIdentificacaoPrestador m_Prestador;

        internal tcIdentificacaoPrestador Prestador
        {
            get => m_Prestador;
            set => m_Prestador = value;
        }

        internal ConsultarNfseFaixaEnvioFaixa Faixa
        {
            get => m_Faixa;
            set => m_Faixa = value;
        }

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string Pagina
        {
            get => m_Pagina;
            set => m_Pagina = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class ConsultarNfseFaixaEnvioFaixa
    {
        private string m_NumeroNfseFinal;
        private string m_NumeroNfseInicial;

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string NumeroNfseInicial
        {
            get => m_NumeroNfseInicial;
            set => m_NumeroNfseInicial = value;
        }

        [XmlElement(DataType = "nonNegativeInteger")]
        internal string NumeroNfseFinal
        {
            get => m_NumeroNfseFinal;
            set => m_NumeroNfseFinal = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    [XmlRoot(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
    internal sealed class ConsultarNfseFaixaResposta
    {
        private object m_Item;

        [XmlElement("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
        [XmlElement("ListaNfse", typeof(ConsultarNfseFaixaRespostaListaNfse))]
        internal object Item
        {
            get => m_Item;
            set => m_Item = value;
        }
    }

    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
    internal sealed class ConsultarNfseFaixaRespostaListaNfse
    {
        private tcCompNfse[] m_CompNfse;
        private string m_ProximaPagina;

        [XmlElement("CompNfse")]
        internal tcCompNfse[] CompNfse
        {
            get => m_CompNfse;
            set => m_CompNfse = value;
        }


        [XmlElement(DataType = "nonNegativeInteger")]
        internal string ProximaPagina
        {
            get => m_ProximaPagina;
            set => m_ProximaPagina = value;
        }
    }
}