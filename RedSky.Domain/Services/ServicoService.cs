using System;
using System.Collections.Generic;
using System.Linq;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class ServicoService : ServiceBase<Servico>, IServicoService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Servico> Repository;

        public ServicoService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Servico> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<Servico> GetListServicoByIdDemonstrativo_INDEX(int idDemonstrativo)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetListWithFields(s => new
                {
                    s.Id,
                    s.Descricao,
                    s.Codigo,
                    s.NomePlanilha,
                    s.Valor,
                    s.HasQueryRateio,
                    s.HasQueryDados,
                    s.Ordem,
                    Unidade = new
                    {
                        s.Unidade.Descricao
                    }
                }, s => s.IdDemonstrativo == idDemonstrativo);
            }
        }

        public IEnumerable<Servico> GetListServicoByIdFatura(Int32 idFatura)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                // Não seleciona os campos de query para diminuir o tamanho do objeto.
                return Repository.GetListWithFields(s => new
                    {
                        s.Id,
                        s.Codigo,
                        s.Descricao,
                        s.HasQueryDados,
                        s.HasQueryRateio,
                        s.IdConexaoBanco,
                        s.IdDemonstrativo,
                        s.IdUnidade,
                        s.NomePlanilha,
                        s.Ordem,
                        s.Valor
                    },
                    s => s.Demonstrativo.Faturas.Any(f => f.Id == idFatura),
                    s => s.Demonstrativo,
                    s => s.Demonstrativo.Servicos);
            }
        }

        public Servico GetServicoById_CREATEEDIT(int id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id, svc => svc.ConexaoBanco,
                    svc => svc.ConexaoBanco.DBProvider,
                    svc => svc.Unidade);
            }
        }
    }
}