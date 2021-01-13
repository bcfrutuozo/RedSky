using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface ILoteRPSService : IServiceBase<LoteRPS>
    {
        LoteRPS GetById_GENERATEINVOICE(int id);
        LoteRPS EnviarLoteRPSAssincrono(LoteRPS loteRps, X509Certificate2 certificado, long ultimoRPSRedSky);
        LoteRPS EnviarLoteRPSSincrono(LoteRPS loteRps, X509Certificate2 certificado, long ultimoRPSRedSky);
        LoteRPS GetById_ADDRPS_DELETE(int idLoteRps);
        IEnumerable<LoteRPS> GetListLoteRPSByIdFilial(Int32 idFilial);
        IEnumerable<LoteRPS> GetListLoteRPSByIdFilialAndStatus(Int32 idFilial, int idStatusLoteRPS);
    }
}