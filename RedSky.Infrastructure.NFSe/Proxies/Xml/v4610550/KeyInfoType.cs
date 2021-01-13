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
    public sealed class KeyInfoType
    {
        private string m_IdField;
        private X509DataType m_X509DataField;

        public X509DataType X509Data
        {
            get => m_X509DataField;
            set => m_X509DataField = value;
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get => m_IdField;
            set => m_IdField = value;
        }
    }
}