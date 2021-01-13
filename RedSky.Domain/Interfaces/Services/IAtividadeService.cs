using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IAtividadeService : IServiceBase<Atividade>
    {
        Atividade GetById(int id);

        IEnumerable<Atividade> GetAll();

        IEnumerable<Atividade> GetListAtividadeByIdEmpresa(int idEmpresa,
            params Expression<Func<Atividade, object>>[] navigationProperties);
    }
}