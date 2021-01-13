using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IFilialService : IServiceBase<Filial>
    {
        Filial GetById_ADDLOTERPS(Int32 idFilial);
        IEnumerable<Filial> GetListFilialByIdEmpresa_INDEX(Int32 idEmpresa);
        Filial GetFilialByIdEmpresa_Nome(Int32 idEmpresa, String nome);
        int GetQuantidadeRpsPorLoteByIdFilial(int idFilial);
    }
}