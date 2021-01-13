using System.Text;

namespace RedSky.Utilities
{
    public class UpperCaseUTF8Encoding : UTF8Encoding
    {
        private static UpperCaseUTF8Encoding upperCaseUtf8Encoding;
        public override string WebName => base.WebName.ToUpper();

        public static UpperCaseUTF8Encoding UpperCaseUTF8 =>
            upperCaseUtf8Encoding ?? (upperCaseUtf8Encoding = new UpperCaseUTF8Encoding());
    }
}