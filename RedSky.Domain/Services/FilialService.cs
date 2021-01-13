using System;
using System.Collections.Generic;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class FilialService : ServiceBase<Filial>, IFilialService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Filial> Repository;

        public FilialService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Filial> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public Filial GetById_ADDLOTERPS(Int32 idFilial)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetByIdWithFields(idFilial, f => new
                    {
                    f.Id,
                    f.CPFCNPJ,
                    f.QuantidadeRPSPorLote,
                    Cidade = new
                    {
                        f.Cidade.Id,
                        f.Cidade.IdEstado,
                        f.Cidade.Codigo
                    },
                    Empresa = new 
                    {
                        f.Empresa.RazaoSocial,
                    },
                    }, fl => fl.Empresa,
                    fl => fl.Cidade);
            }
        }

        public IEnumerable<Filial> GetListFilialByIdEmpresa_INDEX(Int32 idEmpresa)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetListWithFields(f => new
                    {
                        f.Id,
                        f.Identificacao,
                        f.NomeFantasia,
                        f.CPFCNPJ,
                        f.QuantidadeRPSPorLote,
                        Cidade = new
                        {
                            f.Cidade.Id,
                            f.Cidade.IdEstado,
                            f.Cidade.Nome,
                            Estado = new
                            {
                                f.Cidade.Estado.Sigla
                            }
                        },
                        f.Logradouro,
                        f.Bairro,
                        f.Numero,
                        f.Complemento,
                        f.CEP,
                        f.DDD,
                        f.Telefone,
                        f.Email,
                        f.AliquotaISS
                    }, fl => fl.IdEmpresa == idEmpresa,
                    fl => fl.Cidade,
                    fl => fl.Cidade.Estado);
            }
        }

        public Filial GetFilialByIdEmpresa_Nome(Int32 idEmpresa, String nome)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetWithFields(f => new
                    {
                        f.Id,
                        f.Identificacao,
                        f.NomeFantasia,
                        f.CPFCNPJ,
                        f.QuantidadeRPSPorLote,
                        Cidade = new
                        {
                            f.Cidade.IdEstado,
                            f.Cidade.Id,
                            f.Cidade.Nome,
                            Estado = new
                            {
                                f.Cidade.Estado.Sigla
                            }
                        },
                        f.Logradouro,
                        f.Bairro,
                        f.Numero,
                        f.Complemento,
                        f.CEP,
                        f.DDD,
                        f.Telefone,
                        f.Email,
                        f.AliquotaISS
                    }, fl => fl.IdEmpresa == idEmpresa,
                    fl => fl.Cidade,
                    fl => fl.Cidade.Estado);
            }
        }

        public int GetQuantidadeRpsPorLoteByIdFilial(int idFilial)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetWithFields(f => new
                {
                    f.QuantidadeRPSPorLote
                }, fl => fl.Id == idFilial).QuantidadeRPSPorLote;
            }
        }
    }
}