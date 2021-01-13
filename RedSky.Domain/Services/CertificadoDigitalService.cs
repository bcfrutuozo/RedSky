using System;
using System.Collections.Generic;
using System.Linq;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class CertificadoDigitalService : ServiceBase<CertificadoDigital>, ICertificadoDigitalService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<CertificadoDigital> Repository;

        public CertificadoDigitalService(IDbContextScopeFactory contextScopeFactory,
            IRepositoryBase<CertificadoDigital> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public CertificadoDigital GetLastValidCertificado(int idFilial)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(ct => ct.IdFilial == idFilial).OrderBy(c => c.ValidDate).Last();
            }
        }

        public IEnumerable<CertificadoDigital> GetListCertificadoDigitalByIdFilial(Int32 idFilial)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(ctfx => ctfx.IdFilial == idFilial);
            }
        }
    }
}