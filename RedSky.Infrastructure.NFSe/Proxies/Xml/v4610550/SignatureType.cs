using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace RedSky.Infrastructure.NFSe.Proxies.Xml.v4610550
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public sealed class SignatureType
    {
        private string m_IdField;
        private KeyInfoType m_KeyInfoField;
        private SignatureValueType m_SignatureValueField;
        private SignedInfoType m_SignedInfoField;

        public SignedInfoType SignedInfo
        {
            get => m_SignedInfoField;
            set => m_SignedInfoField = value;
        }

        public SignatureValueType SignatureValue
        {
            get => m_SignatureValueField;
            set => m_SignatureValueField = value;
        }

        public KeyInfoType KeyInfo
        {
            get => m_KeyInfoField;
            set => m_KeyInfoField = value;
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get => m_IdField;
            set => m_IdField = value;
        }
    }
}