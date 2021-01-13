using System.Collections.Generic;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Cliente> Repository;

        public ClienteService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Cliente> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public IEnumerable<Cliente> GetListClienteByIdEmpresa_INDEX(int idEmpresa)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetListWithFields(c => new
                    {
                        c.Id,
                        c.Apelido,
                        c.RazaoSocial,
                        c.CPFCNPJ,
                        c.InscricaoEstadual,
                        c.InscricaoMunicipal,
                        c.Sigla,
                        Cidade = new
                        {
                            c.Cidade.Nome,
                            Estado = new
                            {
                                c.Cidade.Estado.Sigla,
                            }
                        },
                        c.Bairro,
                        TipoLogradouro = new
                        {
                            c.TipoLogradouro.Descricao
                        },
                        c.Logradouro,
                        c.Complemento,
                    }, c => c.IdEmpresa == idEmpresa,
                    c => c.Cidade,
                    c => c.Cidade.Estado,
                    c => c.TipoLogradouro);
            }
        }

        public Cliente GetClienteById_CREATEUPDATE(int idCliente)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(idCliente,
                    c => c.Cidade,
                    c => c.Cidade.Estado,
                    c => c.TipoBairro,
                    c => c.TipoLogradouro);
            }
        }

        public IEnumerable<Cliente> GetListClienteByIdEmpresa_COMBOBOX(int idEmpresa)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetListWithFields(c => new
                {
                    c.Id,
                    c.Apelido
                }, c => c.IdEmpresa == idEmpresa);
            }
        }
    }
}