using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IRPSService : IServiceBase<RPS>
    {
        RPS GetRPSPorIdFatura(int idFatura);
        IEnumerable<RPS> GetRPSPorNumeroLoteRPS(string numeroLoteRPS);
        IEnumerable<RPS> GetRPSSemLote(int idFilial, params Expression<Func<RPS, object>>[] navigationProperties);

        RPS GetRPSPorNumeroEFilial(int idFilial, long numeroRPS,
            params Expression<Func<RPS, object>>[] navigationProperties);

        IEnumerable<RPS> GetListRPSByIdLoteRPS(int idLoteRPS);
        IEnumerable<RPS> GetListRPSWithNoLoteRPSByIdFilial(int idFilial);
        RPS GetById_ADDINLOTE(Int32 id);
        IEnumerable<RPS> GetListRPSByIdLoteRPS_UPDATELOTE(Int32 idLoteRPS);
        long GetHigherLongNumeroRPSByIdFatura(int idFilial);
    }
}