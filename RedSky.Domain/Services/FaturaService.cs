using System;
using System.Collections.Generic;
using System.Linq;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class FaturaService : ServiceBase<Fatura>, IFaturaService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<Fatura> Repository;

        public FaturaService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<Fatura> repository)
            : base(contextScopeFactory, repository)
        {
            ContextScopeFactory = contextScopeFactory;
            Repository = repository;
        }

        public Fatura GetById_FATURAR(Int32 id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id,
                    fat => fat.Atividade,
                    fat => fat.Atividade.Incidencia,
                    fat => fat.Atividade.ItensServico,
                    fat => fat.Atividade.Operacao,
                    fat => fat.Atividade.Tributacao,
                    fat => fat.Atividade.Utilizacao,
                    fat => fat.Prestador,
                    fat => fat.Prestador.Cidade,
                    fat => fat.Prestador.Empresa,
                    fat => fat.Faturamentos,
                    fat => fat.LocalPrestacao,
                    fat => fat.TipoRecolhimento,
                    fat => fat.Tomador,
                    fat => fat.Tomador.Cidade,
                    fat => fat.Tomador.Cidade.Estado,
                    fat => fat.Tomador.TipoBairro,
                    fat => fat.Tomador.TipoLogradouro,
                    fat => fat.RPS,
                    fat => fat.RPS.Select(l => l.LoteRPS));
            }
        }

        public Fatura GetById_SENDEMAIL(Int32 id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id,
                    f => f.Demonstrativo,
                    f => f.Demonstrativo.Cliente,
                    f => f.Demonstrativo.Cliente.TipoBairro,
                    f => f.Demonstrativo.Cliente.TipoLogradouro,
                    f => f.Prestador,
                    f => f.Prestador.Empresa,
                    f => f.Tomador.Cidade,
                    f => f.Tomador.Cidade.Estado,
                    f => f.Tomador.Empresa,
                    f => f.Tomador.TipoBairro,
                    f => f.Tomador.TipoLogradouro,
                    f => f.Tomador);
            }
        }

        public Fatura GetById_PROCESSING(int id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id, f => f.Demonstrativo,
                    f => f.Demonstrativo.Cliente,
                    f => f.Demonstrativo.Cliente.Cidade,
                    f => f.Demonstrativo.Cliente.Cidade.Estado,
                    f => f.Demonstrativo.Cliente.Empresa,
                    f => f.Demonstrativo.Cliente.TipoBairro,
                    f => f.Demonstrativo.Cliente.TipoLogradouro,
                    f => f.Demonstrativo.Servicos,
                    f => f.Demonstrativo.Servicos.Select(s => s.Unidade),
                    f => f.Faturamentos);
            }
        }

        public Fatura GetById_UPDATEVIEW(int id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id, f => f.LocalPrestacao);
            }
        }

        public Fatura GetById_CALCULATION(Int32 id)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(id, f => f.Faturamentos);
            }
        }

        public Fatura GetCopyFatura(int idFatura)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetById(idFatura);
            }
        }

        public IEnumerable<Fatura> GetAllFaturaByEmpresa_Mes_Ano_VIEW(int idEmpresa, int month, int year)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetListWithFields(f => new
                    {
                        f.Id,
                        Prestador = new
                        {
                            f.Id,
                            f.Prestador.IdEmpresa,
                            f.Prestador.Identificacao
                        },
                        RPS = f.RPS.Select(item => new
                        {
                            item.Id,
                            NotaFiscal = item.NotaFiscal.Select(nf =>
                                new
                                {
                                    nf.Id,
                                    nf.NumeroNF,
                                    nf.IsCancelada,
                                }),
                            item.IdLoteRPS,
                            LoteRPS = new
                            {
                                IdStatusLoteRPS = (int?)item.LoteRPS.IdStatusLoteRPS
                            }
                        }),
                        f.Competencia,
                        f.NomeArquivo,
                        f.Identificacao,
                        f.IdDemonstrativo,
                        f.DataVencimento,
                        f.DataRecebimento,
                        f.ValorBruto,
                        f.ValorLiquido,
                        f.ValorRecebido,
                        f.ValorDedutivel,
                        f.ValorPIS,
                        f.ValorCOFINS,
                        f.ValorINSS,
                        f.ValorCSLL,
                        f.ValorIR,
                        f.ValorISS,
                        f.IdFilial,
                        f.IsFaturado,
                        f.IsProcessado,
                        f.IsEdit,
                        f.Mes,
                        f.Ano
                    }, f => f.Prestador.IdEmpresa == idEmpresa && f.Mes == month && f.Ano == year,
                    fat => fat.Prestador,
                    fat => fat.Prestador.Cidade,
                    fat => fat.RPS,
                    fat => fat.RPS.Select(r => r.LoteRPS),
                    fat => fat.RPS.Select(r => r.NotaFiscal));
            }
        }

        public IEnumerable<Fatura> GetAllFaturaByEmpresa_Mes_Ano_COPY(int idEmpresa, int month, int year)
        {
            using (ContextScopeFactory.CreateReadOnly())
            {
                return Repository.GetList(f => f.Prestador.IdEmpresa == idEmpresa && f.Mes == month && f.Ano == year);
            }
        }
    }
}