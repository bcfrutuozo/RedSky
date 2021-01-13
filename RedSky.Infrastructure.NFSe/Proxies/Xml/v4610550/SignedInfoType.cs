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
    public sealed class SignedInfoType
    {
        private SignedInfoTypeCanonicalizationMethod m_CanonicalizationMethodField;
        private string m_IdField;
        private ReferenceType m_ReferenceField;
        private SignedInfoTypeSignatureMethod m_SignatureMethodField;

        public SignedInfoTypeCanonicalizationMethod CanonicalizationMethod
        {
            get => m_CanonicalizationMethodField;
            set => m_CanonicalizationMethodField = value;
        }

        public SignedInfoTypeSignatureMethod SignatureMethod
        {
            get => m_SignatureMethodField;
            set => m_SignatureMethodField = value;
        }

        public ReferenceType Reference
        {
            get => m_ReferenceField;
            set => m_ReferenceField = value;
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get => m_IdField;
            set => m_IdField = value;
        }
    }
}