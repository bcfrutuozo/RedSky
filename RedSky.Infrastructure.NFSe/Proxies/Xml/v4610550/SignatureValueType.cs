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
    public sealed class SignatureValueType
    {
        private string m_IdField;
        private byte[] m_ValueField;

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get => m_IdField;
            set => m_IdField = value;
        }

        [XmlText(DataType = "base64Binary")]
        public byte[] Value
        {
            get => m_ValueField;
            set => m_ValueField = value;
        }
    }
}