using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.NFSe;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class NotaFiscalService : ServiceBase<NotaFiscal>, INotaFiscalService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly INFSeService NFSe;
        private readonly IRepositoryBase<NotaFiscal> Repository;

        public NotaFiscalService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<NotaFiscal> repository,
            INFSeService nfse)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
            NFSe = nfse;
        }

        public NotaFiscal GetByIdFilial_NumeroNF_SENDEMAIL(int idFilial, long numeroNf)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(nf => nf.RPS.Fatura.Prestador.Id == idFilial && nf.NumeroNF == numeroNf,
                    nf => nf.RPS,
                    nf => nf.RPS.Fatura,
                    nf => nf.RPS.Fatura.Demonstrativo,
                    nf => nf.RPS.Fatura.Demonstrativo.Cliente,
                    nf => nf.RPS.Fatura.Prestador,
                    nf => nf.RPS.Fatura.Prestador.Empresa,
                    nf => nf.RPS.Fatura.Tomador);
            }
        }

        public NotaFiscal GetNotaFiscalByNumero_DOWNLOAD(Int32 idFilial, Int64 numeroNf)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(nf => nf.NumeroNF == numeroNf && nf.RPS.Fatura.IdFilial == idFilial,
                    n => n.RPS,
                    n => n.RPS.Fatura,
                    n => n.RPS.Fatura.Demonstrativo,
                    n => n.RPS.Fatura.Demonstrativo.Cliente,
                    n => n.RPS.Fatura.Prestador,
                    n => n.RPS.Fatura.Prestador.Empresa,
                    n => n.RPS.Fatura.Prestador.Cidade,
                    n => n.RPS.Fatura.Tomador);
            }
        }

        public IEnumerable<NotaFiscal> GetAllNotaFiscalPorFilialNumero(int idFilial)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(n => n.RPS.Fatura.IdFilial == idFilial, 
                    nf => nf.RPS,
                    nf => nf.RPS.Fatura);
            }
        }

        public NotaFiscal GetNotaFiscalPorFatura(int idFatura)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(n => n.RPS.Fatura.Id == idFatura, 
                    nf => nf.RPS,
                    nf => nf.RPS.Fatura);
            }
        }

        public NotaFiscal GetNotaFiscalPorRPS(int idRps)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.Get(n => n.IdRPS == idRps,
                    nf => nf.RPS);
            }
        }

        public IEnumerable<NotaFiscal> ObterNotasPorLote(Filial filial, long numeroLote, X509Certificate2 certificado)
        {
            return NFSe.ConsultarLote(filial, numeroLote, certificado);
        }

        public void DownloadNFSe(Filial filial, string link, string output)
        {
            NFSe.DownloadNFSe(filial, link, output);
        }
    }
}