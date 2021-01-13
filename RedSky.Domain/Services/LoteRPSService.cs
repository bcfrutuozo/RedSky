using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.NFSe;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class LoteRPSService : ServiceBase<LoteRPS>, ILoteRPSService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly INFSeService NFSe;
        private readonly IRepositoryBase<LoteRPS> Repository;

        public LoteRPSService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<LoteRPS> repository,
            INFSeService nfse)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
            NFSe = nfse;
        }

        public LoteRPS GetById_GENERATEINVOICE(Int32 id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id,
                    l => l.RPS,
                    l => l.RPS.Select(i => i.ItensRPS),
                    l => l.RPS.Select(d => d.DeducaoRPS),
                    l => l.Filial,
                    l => l.Filial.Cidade);
            }
        }

        public LoteRPS EnviarLoteRPSAssincrono(LoteRPS loteRPS, X509Certificate2 certificado, long ultimoRPSRedSky)
        {
            return NFSe.EnviarLoteRPSAssincrono(loteRPS, certificado, ultimoRPSRedSky);
        }

        public LoteRPS EnviarLoteRPSSincrono(LoteRPS loteRPS, X509Certificate2 certificado, long ultimoRPSRedSky)
        {
            return NFSe.EnviarLoteRPSSincrono(loteRPS, certificado, ultimoRPSRedSky);
        }

        public LoteRPS GetById_ADDRPS_DELETE(Int32 idLoteRps)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(idLoteRps,
                    l => l.RPS,
                    l => l.RPS.Select(i => i.ItensRPS),
                    l => l.RPS.Select(d => d.DeducaoRPS));
            }
        }

        public IEnumerable<LoteRPS> GetListLoteRPSByIdFilial(Int32 idFilial)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetListWithFields(l =>
                    new
                    {
                        l.Id,
                        l.NumeroLote,
                        l.CPFCNPJRemetente,
                        l.DataPrimeiroRPS,
                        l.DataUltimoRPS,
                        l.QuantidadeRPS,
                        l.ValorTotalServicos,
                        l.ValorTotalDeducoes,
                        l.IdStatusLoteRPS,
                        StatusLoteRPS = new
                        {
                            l.StatusLoteRPS.Descricao
                        }

                    }, l => l.IdFilial == idFilial,
                    l => l.StatusLoteRPS);
            }
        }

        public IEnumerable<LoteRPS> GetListLoteRPSByIdFilialAndStatus(Int32 idFilial, int idStatusLoteRPS)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetListWithFields(l =>
                        new
                        {
                            l.Id,
                            l.NumeroLote,
                            l.CPFCNPJRemetente,
                            l.DataPrimeiroRPS,
                            l.DataUltimoRPS,
                            l.QuantidadeRPS,
                            l.ValorTotalServicos,
                            l.ValorTotalDeducoes,
                            l.IdStatusLoteRPS,
                            StatusLoteRPS = new
                            {
                                l.StatusLoteRPS.Descricao
                            }

                        }, l => l.IdFilial == idFilial && l.IdStatusLoteRPS == idStatusLoteRPS,
                    l => l.StatusLoteRPS);
            }
        }
    }
}