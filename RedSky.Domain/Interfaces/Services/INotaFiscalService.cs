using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface INotaFiscalService : IServiceBase<NotaFiscal>
    {
        NotaFiscal GetByIdFilial_NumeroNF_SENDEMAIL(int idFilial, long numeroNf);
        NotaFiscal GetNotaFiscalByNumero_DOWNLOAD(Int32 idFilial, Int64 numeroNf);

        IEnumerable<NotaFiscal> GetAllNotaFiscalPorFilialNumero(int idFilial);
        NotaFiscal GetNotaFiscalPorFatura(int idFatura);
        NotaFiscal GetNotaFiscalPorRPS(int idRps);

        IEnumerable<NotaFiscal> ObterNotasPorLote(Filial filial, long numeroLote, X509Certificate2 certificado);
        void DownloadNFSe(Filial filial, string link, string output);
    }
}