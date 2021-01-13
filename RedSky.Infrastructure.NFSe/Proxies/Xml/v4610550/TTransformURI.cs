using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace RedSky.Infrastructure.NFSe.Proxies.Xml.v4610550
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public enum TTransformURI
    {
        [XmlEnum("http://www.w3.org/2000/09/xmldsig#enveloped-signature")]
        Httpwwww3Org200009Xmldsigenvelopedsignature,

        [XmlEnum("http://www.w3.org/TR/2001/REC-xml-c14n-20010315")]
        Httpwwww3Orgtr2001Recxmlc14N20010315,

        [XmlEnum("http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments")]
        Httpwwww3Orgtr2001Recxmlc14N20010315Withcomments,

        [XmlEnum("http://www.w3.org/TR/1999/REC-xpath-19991116")]
        Httpwwww3Orgtr1999Recxpath19991116
    }
}