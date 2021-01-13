using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using Newtonsoft.Json;

namespace RedSky.Common
{
    public static class Extensions
    {
        
        public static string GetFinalRedirectedUrl(this string url)
        {
            var result = string.Empty;

            try
            {
                var req = (HttpWebRequest) WebRequest.Create(url);
                req.Method = "HEAD";
                req.AllowAutoRedirect = false;

                var myResp = (HttpWebResponse) req.GetResponse();
                if (myResp.StatusCode == HttpStatusCode.Redirect)
                {
                    var temp = myResp.GetResponseHeader("Location");
                    myResp.Dispose(); // Disposes the web response object to prevent application from stopping.
                    result = GetFinalRedirectedUrl(temp); // Recursive call
                }
                else
                {
                    result = url;
                }

                req.Abort();
            }
            catch (UriFormatException ex)
            {
                return url;
            }

            return result;
        }

        /// <summary>
        ///     Sign a xml with certificate.
        /// </summary>
        /// <param name="xmlMessage">The xml message which will be signed</param>
        /// <param name="certificate">The digital certificate</param>
        /// <returns></returns>
        public static void SignXml(this XmlDocument xmlDoc, X509Certificate2 certificate)
        {
            var keyInfo = new KeyInfo();
            var key = (RSACryptoServiceProvider) certificate.PrivateKey;
            keyInfo.AddClause(new KeyInfoX509Data(certificate));

            var signedDocument = new SignedXml(xmlDoc)
            {
                SigningKey = key,
                KeyInfo = keyInfo
            };

            var reference = new Reference
            {
                Uri = string.Empty
            };

            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigC14NTransform(false));
            signedDocument.AddReference(reference);
            signedDocument.ComputeSignature();
            var xmlDigitalSignature = signedDocument.GetXml();
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
        }

        /// <summary>
        ///     Gets an image from a byte array
        /// </summary>
        /// <param name="data">Image data</param>
        /// <returns>Image object</returns>
        public static Image ToImage(this byte[] data)
        {
            if (data == null)
                return null;

            using (var ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        ///     Clones an generic list.
        /// </summary>
        /// <typeparam name="T">Type of generic list</typeparam>
        /// <param name="listToClone">The list which will be cloned</param>
        /// <returns>A new list cloned from the parameter list</returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T) item.Clone()).ToList();
        }

        /// <summary>
        ///     Checks if a file is opened.
        /// </summary>
        /// <param name="f">File to be checked</param>
        /// <returns>True if the file is open and locked and false if the file is not in use</returns>
        public static bool IsOpen(this FileInfo f)
        {
            FileStream stream = null;

            try
            {
                stream = f.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                stream?.Close();
            }

            return false;
        }

        /// <summary>
        ///     Checks if the string is a valid e-mail address.
        /// </summary>
        /// <param name="emailString">String to be verified</param>
        /// <returns>True if the string is a valid e-mail address, or false if it isn't</returns>
        public static bool IsValidEmail(this string emailString)
        {
            if (string.IsNullOrEmpty(emailString))
                return false;

            try
            {
                var addr = new MailAddress(emailString);
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Saves the byte array to the output file (This method does not identity the file extension. It must be passed in the
        ///     end of the file name string.).
        /// </summary>
        /// <param name="data">Data to be saved</param>
        /// <param name="output">Output filename</param>
        public static void ToFile(this byte[] data, string output)
        {
            using (var fs = new FileStream(output, FileMode.Create, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        ///     Gets a byte array of raw data from an image file.
        /// </summary>
        /// <param name="img">Image object</param>
        /// <returns>Byte array with image raw data</returns>
        public static byte[] ToByteArray(this Image img)
        {
            if (img == null)
                return new byte[0];

            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        /// <summary>
        ///     Truncates the string with the desired size.
        /// </summary>
        /// <param name="str">String to be truncated</param>
        /// <param name="maxLength">The amount of chars to be accepted</param>
        /// <returns></returns>
        public static string TruncateLongString(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= maxLength)
                return str;

            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(this string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }

        /// <summary>
        ///     Floor a decimal value specifying its precision amount.
        /// </summary>
        /// <param name="value">Value to be downed</param>
        /// <param name="decimals">Precision</param>
        /// <returns></returns>
        public static decimal DecimalTowardZero(this decimal value, int decimals)
        {
            // rounding away from zero
            var rounded = decimal.Round(value, decimals, MidpointRounding.AwayFromZero);

            // if the absolute rounded result is greater 
            // than the absolute source number we need to correct result
            if (Math.Abs(rounded) > Math.Abs(value))
                return rounded - new decimal(1, 0, 0, value < 0, (byte) decimals);
            return rounded;
        }

        /// <summary>
        ///     Returns the input string with the first character converted to uppercase
        /// </summary>
        public static string FirstLetterToUpperCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("There is no first letter");

            var a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}