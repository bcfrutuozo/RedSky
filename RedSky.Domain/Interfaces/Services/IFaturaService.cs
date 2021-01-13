using System;
using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Domain.Interfaces.Services
{
    public interface IFaturaService : IServiceBase<Fatura>
    {
        Fatura GetById_FATURAR(int id);

        Fatura GetById_SENDEMAIL(int id);

        Fatura GetById_PROCESSING(int id);

        Fatura GetById_UPDATEVIEW(int id);

        Fatura GetById_CALCULATION(int id);

        Fatura GetCopyFatura(int idFatura);

        IEnumerable<Fatura> GetAllFaturaByEmpresa_Mes_Ano_VIEW(Int32 idEmpresa, Int32 month, Int32 year);

        IEnumerable<Fatura> GetAllFaturaByEmpresa_Mes_Ano_COPY(int idEmpresa, int month, int year);
    }
}