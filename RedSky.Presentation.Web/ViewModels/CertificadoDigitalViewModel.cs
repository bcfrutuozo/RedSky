using System;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class CertificadoDigitalViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required] public byte[] X509CertificateData { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdFilial { get; set; }

        [DataType(DataType.Password)] public string SenhaCertificado { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(SenhaCertificado))]
        public string ConfirmaSenhaCertificado { get; set; }

        public string Subject { get; set; }

        public string Issuer { get; set; }

        public int Version { get; set; }

        [Display(Name = "Data de Validade")] public DateTime ValidDate { get; set; }

        [Display(Name = "Data de Expiração")] public DateTime ExpiryDate { get; set; }

        public string Thumbprint { get; set; }

        [Display(Name = "Número Serial")] public string SerialNumber { get; set; }

        public string FriendlyName { get; set; }

        public string PublicKeyFormat { get; set; }

        public int RawDataLength { get; set; }

        [Display(Name = "Nome Empresarial")] public string NomeEmpresarial { get; set; }
    }
}