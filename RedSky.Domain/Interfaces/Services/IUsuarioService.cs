using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario GetAuthentication(string empresa, string login, string senha);

        Usuario GetUsuarioByLogin(string login);

        IEnumerable<Usuario> GetAllUsuario_INDEX();

        IEnumerable<Usuario> GetAllUsuarioByEmpresa(int idEmpresa);
        Usuario GetUsuarioById_UPDATE(int idUsuario);
        byte[] GetPictureById(int idUsuario);
        Usuario GetAuthenticatedUserByLogin(string login);
    }
}