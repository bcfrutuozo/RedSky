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
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public sealed class SignedInfoTypeCanonicalizationMethod
    {
        private string m_AlgorithmField;

        public SignedInfoTypeCanonicalizationMethod()
        {
            m_AlgorithmField = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get => m_AlgorithmField;
            set => m_AlgorithmField = value;
        }
    }
}