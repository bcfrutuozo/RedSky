using System.Collections.Generic;
using System.Linq;
using RedSky.Common;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Usuario> Repository;

        public UsuarioService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Usuario> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public Usuario GetAuthentication(string empresa, string login, string senha)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return login.IsValidEmail()
                    ? Repository.GetWithFields(usr => new
                        {
                            usr.Id,
                            usr.IdEmpresa,
                            usr.Nome,
                            usr.Login,
                            usr.Senha,
                            usr.Hash,
                            usr.Parametrizador,
                        },
                        u => u.Email == login && u.Empresa.Identificacao == empresa, 
                        u => u.Empresa,
                        u => u.UsuarioPermissao)
                    : Repository.GetWithFields(usr => new
                    {
                        usr.Id,
                        usr.IdEmpresa,
                        usr.Nome,
                        usr.Login,
                        usr.Senha,
                        usr.Hash,
                        Permissoes = usr.UsuarioPermissao,
                        usr.Parametrizador,
                    }, 
                        u => u.Login == login && u.Empresa.Identificacao == empresa, 
                        u => u.Empresa,
                        u => u.UsuarioPermissao);
            }
        }

        public Usuario GetUsuarioByLogin(string login)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetWithFields(usr => new {
                        usr.Id,
                        usr.IdEmpresa,
                        usr.Login,
                        usr.Nome,
                    },
                    u => u.Login == login);
            }
        }

        public IEnumerable<Usuario> GetAllUsuario_INDEX()
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetListWithFields(usr => new
                {
                    usr.Id,
                    usr.Nome,
                    usr.Login,
                    usr.Parametrizador,
                    usr.Picture,
                    Empresa = new
                    {
                        usr.Empresa.Identificacao,
                    }
                }, null, usr => usr.Empresa);
            }
        }

        public IEnumerable<Usuario> GetAllUsuarioByEmpresa(int idEmpresa)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(u => u.IdEmpresa == idEmpresa);
            }
        }

        public Usuario GetUsuarioById_UPDATE(int idUsuario)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetWithFields(usr => new
                    {
                        usr.Id,
                        usr.Nome,
                        usr.IdEmpresa,
                        usr.Login,
                        usr.Parametrizador,
                        usr.Email,
                        usr.Picture,
                        Empresa = new
                        {
                            usr.Empresa.Identificacao
                        },
                        UsuarioPermissao = usr.UsuarioPermissao.Select(x => new
                        {
                            x.Id,
                            x.IdPermissao,
                            x.Permissao 
                        })
                    },
                    u => u.Id == idUsuario,
                    usr => usr.UsuarioPermissao.Select(p => p.Permissao));
            }
        }

        public byte[] GetPictureById(int idUsuario)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetWithFields(usr => usr.Picture, usr => usr.Id == idUsuario).Picture;
            }
        }

        public Usuario GetAuthenticatedUserByLogin(string login)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetWithFields(usr => new
                {
                    usr.Id,
                    usr.Nome,
                    usr.Picture
                }, usr => usr.Login == login);
            }
        }
    }
}