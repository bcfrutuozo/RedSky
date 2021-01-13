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
    public sealed class TransformType
    {
        private TTransformURI m_AlgorithmField;
        private string[] m_XPathField;

        [XmlElement("XPath")]
        public string[] XPath
        {
            get => m_XPathField;
            set => m_XPathField = value;
        }

        [XmlAttribute]
        public TTransformURI Algorithm
        {
            get => m_AlgorithmField;
            set => m_AlgorithmField = value;
        }
    }
}