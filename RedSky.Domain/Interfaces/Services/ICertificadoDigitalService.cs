using System;
using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface ICertificadoDigitalService : IServiceBase<CertificadoDigital>
    {
        CertificadoDigital GetLastValidCertificado(int idFilial);
        IEnumerable<CertificadoDigital> GetListCertificadoDigitalByIdFilial(Int32 idFilial);
    }
}