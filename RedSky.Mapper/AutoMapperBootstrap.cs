using System;
using AutoMapper;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Services.DTOs;
using RedSky.Services.Interfaces;

namespace RedSky.Services.Mapping
{
    public static class AutomapperBootstrap
    {
        public static bool IsInitialized { get; private set; }

        public static void InitializeMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DBNull, object>().ConvertUsing(obj => obj = null);

                // Entities to DTO
                cfg.CreateMap<IEntity, IDataTransferObject>();

                cfg.CreateMap<Arquivo, ArquivoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Atividade, AtividadeDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<CertificadoDigital, CertificadoDigitalDTO>()
                    .ForMember(ct => ct.X509CertificateData, opt => opt.Ignore())
                    .ForMember(ct => ct.SenhaCertificado, opt => opt.Ignore())
                    .ForMember(ct => ct.HashCertificado, opt => opt.Ignore())
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<ConexaoBanco, ConexaoBancoDTO>()
                    .ForMember(co => co.SenhaBanco, opt => opt.Ignore())
                    .ForMember(co => co.Hash, opt => opt.Ignore())
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Cidade, CidadeDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Cliente, ClienteDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<DBProvider, DBProviderDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<DeducaoRPS, DeducaoRPSDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Demonstrativo, DemonstrativoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Empresa, EmpresaDTO>()
                    .ForMember(em => em.SenhaEmail, opt => opt.Ignore())
                    .ForMember(em => em.HashEmail, opt => opt.Ignore())
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Estado, EstadoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<EtapaVenda, EtapaVendaDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Fatura, FaturaDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Faturamento, FaturamentoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Filial, FilialDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Incidencia, IncidenciaDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<ItemRPS, ItemRPSDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<ItensServico, ItensServicoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<LoteRPS, LoteRPSDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Negocio, NegocioDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<NotaFiscal, NotaFiscalDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<NotaNegocio, NotaNegocioDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Operacao, OperacaoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Permissao, PermissaoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<RegimeTributario, RegimeTributarioDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<RPS, RPSDTO>()
                    .ForMember(tgt => tgt.Identificacao, opt => opt.MapFrom(src => src.Fatura.Identificacao))
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Servico, ServicoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<StatusLoteRPS, StatusLoteRPSDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<TipoBairro, TipoBairroDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<TipoLogradouro, TipoLogradouroDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<TipoRecolhimento, TipoRecolhimentoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Tributacao, TributacaoDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Unidade, UnidadeDTO>()
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Usuario, UsuarioDTO>()
                    .ForMember(us => us.Empresa, opt => opt.MapFrom(src => src.Empresa.Identificacao))
                    .ForMember(us => us.Senha, opt => opt.Ignore())
                    .ForMember(us => us.Hash, opt => opt.Ignore())
                    .IncludeBase<IEntity, IDataTransferObject>();

                cfg.CreateMap<Utilizacao, UtilizacaoDTO>();

                // DTO to Entities
                cfg.CreateMap<IDataTransferObject, IEntity>();

                cfg.CreateMap<ArquivoDTO, Arquivo>();
                cfg.CreateMap<AtividadeDTO, Atividade>();
                cfg.CreateMap<CertificadoDigitalDTO, CertificadoDigital>();
                cfg.CreateMap<ConexaoBancoDTO, ConexaoBanco>();
                cfg.CreateMap<CidadeDTO, Cidade>();
                cfg.CreateMap<ClienteDTO, Cliente>();
                cfg.CreateMap<DBProviderDTO, DBProvider>();
                cfg.CreateMap<DeducaoRPSDTO, DeducaoRPS>();
                cfg.CreateMap<DemonstrativoDTO, Demonstrativo>();
                cfg.CreateMap<EmpresaDTO, Empresa>();

                cfg.CreateMap<EstadoDTO, Estado>();
                cfg.CreateMap<EtapaVendaDTO, EtapaVenda>();
                cfg.CreateMap<FaturaDTO, Fatura>();
                cfg.CreateMap<FaturamentoDTO, Faturamento>();
                cfg.CreateMap<FilialDTO, Filial>();
                cfg.CreateMap<IncidenciaDTO, Incidencia>();
                cfg.CreateMap<ItemRPSDTO, ItemRPS>();
                cfg.CreateMap<ItensServicoDTO, ItensServico>();
                cfg.CreateMap<LoteRPSDTO, LoteRPS>();
                cfg.CreateMap<NegocioDTO, Negocio>();
                cfg.CreateMap<NotaFiscalDTO, NotaFiscal>();
                cfg.CreateMap<NotaNegocioDTO, NotaNegocio>();
                cfg.CreateMap<OperacaoDTO, Operacao>();
                cfg.CreateMap<PermissaoDTO, Permissao>();
                cfg.CreateMap<RegimeTributarioDTO, RegimeTributario>();
                cfg.CreateMap<RPSDTO, RPS>();
                cfg.CreateMap<ServicoDTO, Servico>();
                cfg.CreateMap<StatusLoteRPSDTO, StatusLoteRPS>();
                cfg.CreateMap<TipoBairroDTO, TipoBairro>();
                cfg.CreateMap<TipoLogradouroDTO, TipoLogradouro>();
                cfg.CreateMap<TipoRecolhimentoDTO, TipoRecolhimento>();
                cfg.CreateMap<TributacaoDTO, Tributacao>();
                cfg.CreateMap<UnidadeDTO, Unidade>();
                cfg.CreateMap<UsuarioDTO, Usuario>();
                cfg.CreateMap<UtilizacaoDTO, Utilizacao>();
            });

            IsInitialized = true;
        }
    }
}