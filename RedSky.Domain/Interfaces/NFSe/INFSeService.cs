using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.NFSe
{
    public interface INFSeService
    {
        LoteRPS EnviarLoteRPSAssincrono(LoteRPS loteRPS, X509Certificate2 certificado, long numeroUltimoRps);
        LoteRPS EnviarLoteRPSSincrono(LoteRPS loteRPS, X509Certificate2 certificado, long numeroUltimoRps);
        IEnumerable<NotaFiscal> ConsultarLote(Filial filial, long numeroLote, X509Certificate2 certificado);
        long ConsultarUltimoRPS(Filial filial);

        IEnumerable<NotaFiscal> ConsultarNotas(Filial filial, DateTime inicio, DateTime fim,
            X509Certificate2 certificado, long notaInicial = 0);

        NotaFiscal ConsultarNFSe(Filial filial, long numeroLote, long numeroNF, string codigoVerificacao,
            X509Certificate2 certificado);

        NotaFiscal ConsultarRPS(Filial filial, long numeroLote, long numeroRPS, X509Certificate2 certificado);

        NotaFiscal CancelarNFSe(Filial filial, long numeroLote, long numeroNF, string codigoVerificacao, string motivo,
            X509Certificate2 certificado);

        string ObterUrlNFSe(Filial filial, long numeroNF, string codigoVerificacao);
        void DownloadNFSe(Filial filial, string link, string output);
    }
}