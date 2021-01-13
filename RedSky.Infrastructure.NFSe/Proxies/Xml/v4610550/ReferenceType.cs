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
    public sealed class ReferenceType
    {
        private ReferenceTypeDigestMethod m_DigestMethodField;
        private byte[] m_DigestValueField;
        private string m_IdField;
        private TransformType[] m_TransformsField;
        private string m_TypeField;
        private string m_URIField;

        [XmlArrayItem("Transform", IsNullable = false)]
        public TransformType[] Transforms
        {
            get => m_TransformsField;
            set => m_TransformsField = value;
        }

        public ReferenceTypeDigestMethod DigestMethod
        {
            get => m_DigestMethodField;
            set => m_DigestMethodField = value;
        }

        [XmlElement(DataType = "base64Binary")]
        public byte[] DigestValue
        {
            get => m_DigestValueField;
            set => m_DigestValueField = value;
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get => m_IdField;
            set => m_IdField = value;
        }

        [XmlAttribute(DataType = "anyURI")]
        public string URI
        {
            get => m_URIField;
            set => m_URIField = value;
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Type
        {
            get => m_TypeField;
            set => m_TypeField = value;
        }
    }
}