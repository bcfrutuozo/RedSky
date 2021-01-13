using System.Data.Entity.ModelConfiguration;
using RedSky.Domain.Entities;

namespace RedSky.Infrastructure.Data.EntityConfiguration
{
    public class CertificadoDigitalConfiguration : EntityTypeConfiguration<CertificadoDigital>
    {
        public CertificadoDigitalConfiguration()
        {
            Property(p => p.X509CertificateData);
        }
    }
}