using System.Drawing.Printing;
using RedSky.Common;
using TuesPechkin;

namespace RedSky.Utilities
{
    public static class Pdf
    {
        public static void ConvertFromHtml(string htmlData, string documentTitle, string output)
        {
            // Configura a API para exportar os dados do HTML para PDF.
            var document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    DocumentTitle = documentTitle,
                    PaperSize = PaperKind.A4,
                    ImageDPI = 300,
                    DPI = 300,
                    Margins = new MarginSettings(25, 0, 0, 0)
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        HtmlText = htmlData,
                        WebSettings = new WebSettings
                        {
                            DefaultEncoding = "UTF-8",
                            LoadImages = true,
                            PrintBackground = true
                        }
                    }
                }
            };

            // Instancia a engine de conversão da API.
            var folderDeployment = new TempFolderDeployment();
            var embeddeddeployment = new WinAnyCPUEmbeddedDeployment(folderDeployment);
            var remotingToolset = new RemotingToolset<PdfToolset>(embeddeddeployment);
            var tsConverter = new ThreadSafeConverter(remotingToolset);

            IConverter converter = tsConverter;

            // Realiza a conversão do HTML para PDF e retorna o mesmo em byte[].
            var data = converter.Convert(document);

            // Descarrega a DLL.
            remotingToolset.Unload();

            // Grava o arquivo em disco.
            data.ToFile(output);
        }
    }
}