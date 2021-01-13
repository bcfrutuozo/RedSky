using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.NFSe;
using RedSky.Exceptions;
using RedSky.Infrastructure.NFSe.Interfaces;

namespace RedSky.Infrastructure.NFSe
{
    public class NFSeService : INFSeService
    {
        private readonly INFSeWSFactory NFCore;

        public NFSeService(INFSeWSFactory nfseWeb)
        {
            NFCore = nfseWeb;
        }

        public LoteRPS EnviarLoteRPSAssincrono(LoteRPS loteRPS, X509Certificate2 certificado, long ultimoRPSRedSky)
        {
            long numeroUltimoRps = ValidarNumeroRPS(loteRPS.Filial, ultimoRPSRedSky);
            return NFCore.GetWS(loteRPS.Filial).EnviarLoteRPSAssincrono(loteRPS, certificado, numeroUltimoRps);
        }

        public LoteRPS EnviarLoteRPSSincrono(LoteRPS loteRPS, X509Certificate2 certificado, long ultimoRPSRedSky)
        {
            long numeroUltimoRps = ValidarNumeroRPS(loteRPS.Filial, ultimoRPSRedSky);
            return NFCore.GetWS(loteRPS.Filial).EnviarLoteRPSSincrono(loteRPS, certificado, numeroUltimoRps);
        }

        private long ValidarNumeroRPS(Filial filial, long ultimoRPSRedSky)
        {
            // Obtém o número do último RPS no sistema da prefeitura.
            long ultimoRPS = this.ConsultarUltimoRPS(filial);

            if (ultimoRPS > ultimoRPSRedSky)
                throw new InvalidProvisionalInvoiceNumberException(
                    "O número do último RPS na prefeitura é maior do que o da base de dados. Portanto, existem inconsistências que devem ser adicionadas à base de dados.");
            else if (ultimoRPS < ultimoRPSRedSky)
                throw new InvalidProvisionalInvoiceNumberException(
                    "O número do último RPS na base de dados é maior do que o último RPS da prefeitura. Portanto, é necessário baixar as informações dos lotes que foram processados e tiveram problemas em sua atualização.");
            else
                return ultimoRPS;
        }

        public IEnumerable<NotaFiscal> ConsultarLote(Filial filial, long numeroLote, X509Certificate2 certificado)
        {
            return NFCore.GetWS(filial).ConsultarLote(numeroLote, certificado);
        }

        public long ConsultarUltimoRPS(Filial filial)
        {
            return NFCore.GetWS(filial).ConsultarUltimoRPS();
        }

        public IEnumerable<NotaFiscal> ConsultarNotas(Filial filial, DateTime inicio, DateTime fim,
            X509Certificate2 certificado, long notaInicial = 0)
        {
            return NFCore.GetWS(filial).ConsultarNotas(inicio, fim, certificado, notaInicial);
        }

        public NotaFiscal ConsultarNFSe(Filial filial, long numeroLote, long numeroNF, string codigoVerificacao,
            X509Certificate2 certificado)
        {
            return NFCore.GetWS(filial).ConsultarNFSe(numeroLote, numeroNF, codigoVerificacao, certificado);
        }

        public NotaFiscal ConsultarRPS(Filial filial, long numeroLote, long numeroRPS, X509Certificate2 certificado)
        {
            return NFCore.GetWS(filial).ConsultarRPS(numeroLote, numeroRPS, certificado);
        }

        public NotaFiscal CancelarNFSe(Filial filial, long numeroLote, long numeroNF, string codigoVerificacao,
            string motivo, X509Certificate2 certificado)
        {
            return NFCore.GetWS(filial).CancelarNFSe(numeroLote, numeroNF, codigoVerificacao, motivo, certificado);
        }

        public string ObterUrlNFSe(Filial filial, long numeroNF, string codigoVerificacao)
        {
            return NFCore.GetWS(filial).ObterUrlNFSe(numeroNF, codigoVerificacao);
        }

        public void DownloadNFSe(Filial filial, string link, string output)
        {
            var nfService = NFCore.GetWS(filial);

            nfService.DownloadNFSe(link, output);
        }
    }
}
