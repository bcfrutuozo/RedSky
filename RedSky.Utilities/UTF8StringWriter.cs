using System.IO;
using System.Text;

namespace RedSky.Utilities
{
    public class UTF8StringWriter : StringWriter
    {
        public override Encoding Encoding => UpperCaseUTF8Encoding.UpperCaseUTF8;
    }
}