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
    public sealed class X509DataType
    {
        private byte[] m_X509CertificateField;

        [XmlElement(DataType = "base64Binary")]
        public byte[] X509Certificate
        {
            get => m_X509CertificateField;
            set => m_X509CertificateField = value;
        }
    }
}