using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using RedSky.Domain.Entities;

namespace RedSky.Infrastructure.NFSe.Interfaces
{
    public interface INFSeWS
    {
        /// <summary>
        ///     Filial que controla o acesso à prefeitura.
        /// </summary>
        Filial Filial { get; }

        /// <summary>
        ///     Envia o lote de RPS para processamento assíncrono na prefeitura.
        /// </summary>
        /// <param name="loteRPS">LoteRPS a ser enviado</param>
        /// <param name="certificado">Certificado digital para assinatura do XML</param>
        /// <param name="rpsInicial">Número do primeiro RPS que será utilizado</param>
        /// <returns>LoteRPS com número e status de processamento</returns>
        LoteRPS EnviarLoteRPSAssincrono(LoteRPS loteRPS, X509Certificate2 certificado, long numeroUltimoRps);

        /// <summary>
        ///     Envia o lote de RPS para processamento síncrono na prefeitura.
        /// </summary>
        /// <param name="loteRPS">LoteRPS a ser enviado</param>
        /// <param name="certificado">Certificado digital para assinatura do XML</param>
        /// <param name="rpsInicial">Número do primeiro RPS que será utilizado</param>
        /// <returns>LoteRPS com número e status de processamento</returns>
        LoteRPS EnviarLoteRPSSincrono(LoteRPS loteRPS, X509Certificate2 certificado, long numeroUltimoRps);

        /// <summary>
        ///     Consulta um lote de RPS já enviado na prefeitura através do seu número.
        /// </summary>
        /// <param name="numeroLote">Número do lote gerado</param>
        /// <param name="certificado">Certificado digital para assinatura do XML</param>
        /// <returns>Lista de todas as notas fiscais que foram processadas no lote</returns>
        IEnumerable<NotaFiscal> ConsultarLote(long numeroLote, X509Certificate2 certificado);

        /// <summary>
        ///     Obtém uma lista de notas fiscais emitidas em um determinado período de tempo. Essa chamada é efetuada para no
        ///     máximo 100 notas fiscais.
        ///     Se for necessário obter uma nota acima da centésima emitida no período, é preciso fornecer o número da primeira
        ///     nota que será pesquisada.
        /// </summary>
        /// <param name="inicio">Período inicial</param>
        /// <param name="fim">Período final</param>
        /// <param name="certificado">Certificado digital para assinatura do XML</param>
        /// <param name="notaInicial">Número da primera nota de todas que serão obtidas</param>
        /// <returns>Lista de todas as notas fiscais do período, iniciando-se com a nota do número fornecido, caso tenha o feito</returns>
        IEnumerable<NotaFiscal> ConsultarNotas(DateTime inicio, DateTime fim, X509Certificate2 certificado,
            long notaInicial = 0);


        /// <summary>
        ///     Consulta uma nota fiscal na prefeitura.
        /// </summary>
        /// <param name="numeroLote">Número do lote da nota fiscal</param>
        /// <param name="numeroNF">Número da nota fiscal</param>
        /// <param name="codigoVerificacao">Código de verificação da nota fiscal</param>
        /// <param name="certificado">Certificado digital para assinatura do XML</param>
        /// <returns>Nota fiscal desejada</returns>
        NotaFiscal ConsultarNFSe(long numeroLote, long numeroNF, string codigoVerificacao,
            X509Certificate2 certificado);

        /// <summary>
        ///     Consulta uma nota fiscal na prefeitura através do seu número de RPS.
        /// </summary>
        /// <param name="numeroLote">Número do lote da nota fiscal</param>
        /// <param name="numeroRPS">Número do RPS da nota fiscal</param>
        /// <param name="certificado">Certificado digital para assinatura do XML</param>
        /// <returns>Nota fiscal desejada</returns>
        NotaFiscal ConsultarRPS(long numeroLote, long numeroRPS, X509Certificate2 certificado);

        /// <summary>
        ///     Realiza o cancelamento de uma nota fiscal.
        /// </summary>
        /// <param name="numeroLote">Número do lote da nota fiscal</param>
        /// <param name="numeroNF">Número da nota fiscal</param>
        /// <param name="codigoVerificacao">Código de verificação da nota fiscal</param>
        /// <param name="motivo">Motivo do cancelamento</param>
        /// <param name="certificado">Certificado digital para assinatura do XML</param>
        /// <returns>Nota fiscal com os dados do cancelamento ou erro de processamento</returns>
        NotaFiscal CancelarNFSe(long numeroLote, long numeroNF, string codigoVerificacao, string motivo,
            X509Certificate2 certificado);

        /// <summary>
        ///     Consultar o número do último RPS enviado para a prefeitura.
        /// </summary>
        /// <returns>Número do último RPS</returns>
        long ConsultarUltimoRPS();

        /// <summary>
        ///     Efetua o download do HTML da prefeitura e já efetua a gravação em disco em PDF.
        /// </summary>
        /// <param name="link">Link de acesso da NFSe</param>
        void DownloadNFSe(string link, string output);

        /// <summary>
        ///     Obtém o link da nota fiscal.
        /// </summary>
        /// <param name="numeroNF">Número da nota fiscal</param>
        /// <param name="codigoVerificacao">Código de verificação da nota fiscal</param>
        /// <returns>Link de visualização da nota fiscal no site da prefeitura</returns>
        string ObterUrlNFSe(long numeroNF, string codigoVerificacao);
    }
}