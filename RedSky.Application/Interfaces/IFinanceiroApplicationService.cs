using System;
using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Application.Interfaces
{
    public interface IFinanceiroApplicationService
    {
        #region EMail

        void SendFaturaEmail(int id);

        void SendNotaFiscalEmail(int idFilial, long numeroNF);

        #endregion

        #region Fatura

        Fatura AddFatura(Fatura fatura);

        Fatura GetFaturaById_Update(int id);

        IEnumerable<Fatura> GetAllFaturaByEmpresa_Mes_Ano(int idEmpresa, int month, int year);

        Fatura UpdateFatura(Fatura fatura);

        Fatura DeleteFatura(int idFatura, bool deleteFaturamentos);

        Fatura EmitirFatura(int id);

        IEnumerable<Fatura> DuplicarCompetencia(int idEmpresa, int monthSource, int yearSource, int monthTarget,
            int yearTarget);

        Fatura CancelarRPS(int idRPS);

        Fatura DeleteFaturamentosFromFatura(int id);

        string GetFaturaNomeArquivo(int id);

        byte[] DownloadFatura(int id);

        #endregion

        #region Faturamento

        Faturamento AddFaturamento(Faturamento faturamento, bool isUserEdit);

        IEnumerable<Faturamento> AddFaturamento(IEnumerable<Faturamento> faturamentos, bool isUserEdit);

        Faturamento UpdateFaturamento(Faturamento faturamento, bool isUserEdit);

        Faturamento DeleteFaturamento(Faturamento faturamento, bool isUserEdit);

        IEnumerable<Faturamento> DeleteFaturamento(IEnumerable<Faturamento> faturamentos, bool isUserEdit);

        IEnumerable<Faturamento> GetListFaturamentoByIdFatura(int idFatura);

        #endregion

        #region LoteRPS

        LoteRPS EnviarLoteRPS(Int32 idLoteRps, Boolean synchronous);

        void DownloadNFSeByIdLoteRPS(int idLoteRPS);

        LoteRPS AddLoteRPS(int idFilial);

        LoteRPS GetLoteRPSById_DELETE(Int32 idLoteRps);

        LoteRPS DeleteLoteRPS(LoteRPS loteRPS);

        LoteRPS AddRangeRPSInLoteRPS(Int32 idLoteRPS, IEnumerable<Int32> lstRPS);

        IEnumerable<LoteRPS> GetListLoteRPSByIdFilial(Int32 idFilial, int idStatusLoteRPS);

        LoteRPS DeleteRangeRPSFromLoteRPS(IEnumerable<Int32> lstRPS);

        #endregion

        #region NotaFiscal

        void DownloadNFSe(int idFilial, long numeroNF);

        #endregion

        #region RPS

        RPS Faturar(int idFatura);

        IEnumerable<RPS> GetListRPSWithNoLoteRPSByIdFilial(int idFilial);

        IEnumerable<RPS> GetListRPSByIdLoteRPS(int idLoteRPS);

        RPS GetRPSPorIdFatura(int idFatura);

        #endregion
    }
}