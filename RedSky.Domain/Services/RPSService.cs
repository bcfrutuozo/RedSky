using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RedSky.Domain.Entities;
using RedSky.Domain.Enums.DbContextScope;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.NFSe;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class RPSService : ServiceBase<RPS>, IRPSService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly INFSeService NFSe;
        private readonly IRepositoryBase<RPS> Repository;

        public RPSService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<RPS> repository, INFSeService nfse)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
            NFSe = nfse;
        }

        public RPS GetRPSPorIdFatura(int idFatura)
        {
            using (ContextScopeFactory.CreateReadOnly(DbContextScopeOption.ForceCreateNew))
            {
                return Repository.Get(r => r.IdFatura == idFatura);
            }
        }

        public IEnumerable<RPS> GetRPSPorNumeroLoteRPS(string numeroLoteRPS)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(r => r.NumeroRPS == Convert.ToInt64(numeroLoteRPS));
            }
        }

        public IEnumerable<RPS> GetRPSSemLote(int idFilial, params Expression<Func<RPS, object>>[] navigationProperties)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(r => r.Fatura.IdFilial == idFilial, r=> r.Fatura);
            }
        }

        public RPS GetRPSPorNumeroEFilial(int idFilial, long numeroRPS,
            params Expression<Func<RPS, object>>[] navigationProperties)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(r => r.Fatura.IdFilial == idFilial && r.NumeroRPS == numeroRPS,
                    r => r.Fatura,
                    r => r.Fatura.Demonstrativo,
                    r => r.Fatura.Prestador,
                    r => r.Fatura.Prestador.Empresa,
                    r => r.Fatura.Tomador);
            }
        }

        public IEnumerable<RPS> GetListRPSByIdLoteRPS(int idLoteRPS)
        {
            using (ContextScopeFactory.CreateReadOnly(DbContextScopeOption.ForceCreateNew))
            {
                return Repository.GetList(r => r.IdLoteRPS == idLoteRPS,
                    rps => rps.ItensRPS,
                    rps => rps.DeducaoRPS,
                    rps => rps.Fatura);
            }
        }

        public IEnumerable<RPS> GetListRPSWithNoLoteRPSByIdFilial(int idFilial)
        {
            using (ContextScopeFactory.CreateReadOnly(DbContextScopeOption.ForceCreateNew))
            {
                return Repository.GetList(r => r.Fatura.IdFilial == idFilial && r.IdLoteRPS == null,
                    r => r.Fatura,
                    r => r.ItensRPS, 
                    r => r.DeducaoRPS);
            }
        }

        public RPS GetById_ADDINLOTE(Int32 id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id, r => r.ItensRPS,
                    r => r.DeducaoRPS);
            }
        }

        public IEnumerable<RPS> GetListRPSByIdLoteRPS_UPDATELOTE(Int32 idLoteRPS)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(r => r.IdLoteRPS == idLoteRPS,
                    rps => rps.ItensRPS,
                    rps => rps.DeducaoRPS);
            }
        }

        public long GetHigherLongNumeroRPSByIdFatura(int idFilial)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(rps => rps.Fatura.IdFilial == idFilial, rps => rps.Fatura).Max(rps => rps.NumeroRPS) ?? 0;
            }
        }
    }
}