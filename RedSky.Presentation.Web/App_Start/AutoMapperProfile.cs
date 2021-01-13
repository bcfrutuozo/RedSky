using System;
using System.Linq;
using AutoMapper;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Presentation.Web.Membership;
using RedSky.Presentation.Web.ViewModels;

namespace RedSky.Presentation.Web
{
    public class AutoMapperProfile : Profile
    {
        public static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.ValidateInlineMaps = false;
                
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

                cfg.CreateMap<IEntity, DropdownViewModel>();

                // DropdownViewModel
                cfg.CreateMap<Empresa, DropdownViewModel>()
                    .IncludeBase<IEntity, DropdownViewModel>()
                    .ForMember(tgt => tgt.Value, opt => opt.MapFrom(src => src.Identificacao));

                cfg.CreateMap<DataType, DropdownViewModel>()
                    .IncludeBase<IEntity, DropdownViewModel>()
                    .ForMember(tgt => tgt.Value, opt => opt.MapFrom(src => src.Name));

                // Membership
                cfg.CreateMap<Usuario, AuthenticationUser>()
                    .ForMember(tgt => tgt.IdEmpresa, opt => opt.MapFrom(src => src.IdEmpresa));
                cfg.CreateMap<Permissao, AuthenticationRole>();

                // Entities to ViewModels
                cfg.CreateMap<Atividade, AtividadeViewModel>()
                    .ForMember(tgt => tgt.Incidencia, opt => opt.MapFrom(src => src.Incidencia.Descricao))
                    .ForMember(tgt => tgt.Operacao, opt => opt.MapFrom(src => src.Operacao.Descricao))
                    .ForMember(tgt => tgt.ItensServico, opt => opt.MapFrom(src => src.ItensServico.Descricao))
                    .ForMember(tgt => tgt.Tributacao, opt => opt.MapFrom(src => src.Tributacao.Descricao))
                    .ForMember(tgt => tgt.Utilizacao, opt => opt.MapFrom(src => src.Utilizacao.Descricao));

                cfg.CreateMap<CertificadoDigital, CertificadoDigitalViewModel>()
                    .ForMember(tgt => tgt.SenhaCertificado, opt => opt.Ignore());
                cfg.CreateMap<ConexaoBanco, ConexaoBancoViewModel>()
                    .ForMember(tgt => tgt.Namespace, opt => opt.MapFrom(src => src.DBProvider.Namespace))
                    .ForMember(tgt => tgt.DescricaoProvider, opt => opt.MapFrom(src => src.DBProvider.Descricao));
                cfg.CreateMap<Cidade, CidadeViewModel>();
                
                #region Cliente

                cfg.CreateMap<Cliente, GetClientesViewModel>()
                    .ForMember(tgt => tgt.TipoLogradouro, opt => opt.MapFrom(src => src.TipoLogradouro.Descricao))
                    .ForMember(tgt => tgt.Cidade, opt => opt.MapFrom(src => src.Cidade.Nome))
                    .ForMember(tgt => tgt.Estado, opt => opt.MapFrom(src => src.Cidade.Estado.Sigla));
                cfg.CreateMap<Cliente, ClienteViewModel>()
                    .ForMember(tgt => tgt.IdCidade, opt => opt.MapFrom(src => src.Cidade.Id))
                    .ForMember(tgt => tgt.IdEstado, opt => opt.MapFrom(src => src.Cidade.IdEstado))
                    .ForMember(tgt => tgt.TipoBairro, opt => opt.MapFrom(src => src.TipoBairro.Descricao))
                    .ForMember(tgt => tgt.TipoLogradouro, opt => opt.MapFrom(src => src.TipoLogradouro.Descricao))
                    .ForMember(tgt => tgt.Cidade, opt => opt.MapFrom(src => src.Cidade.Nome))
                    .ForMember(tgt => tgt.Estado, opt => opt.MapFrom(src => src.Cidade.Estado.Sigla));

                #endregion

                cfg.CreateMap<DataType, DataTypeDisplayViewModel>();
                cfg.CreateMap<Color, ColorDisplayViewModel>();
                cfg.CreateMap<ColorDisplayViewModel, Color>();
                
                cfg.CreateMap<DBProvider, DBProviderViewModel>();
                cfg.CreateMap<Demonstrativo, DemonstrativoViewModel>()
                    .ForMember(tgt => tgt.Cliente, opt => opt.MapFrom(src => src.Cliente.Apelido));

                cfg.CreateMap<Empresa, EmpresaViewModel>()
                    .ForMember(tgt => tgt.SenhaEmail, opt => opt.Ignore())
                    .ForMember(tgt => tgt.RegimeTributario, opt => opt.MapFrom(src => src.RegimeTributario.Nome));

                cfg.CreateMap<Estado, EstadoViewModel>();

                cfg.CreateMap<Fatura, FaturaDisplayViewModel>()
                    .ForMember(tgt => tgt.NumeroNF,
                        opt => opt.MapFrom(src => src.RPS.OrderBy(r => r.Id).LastOrDefault(r => r.MotivoCancelamento == null).NotaFiscal.FirstOrDefault().NumeroNF))
                    .ForMember(tgt => tgt.Filial,
                        opt => opt.MapFrom(src => src.Prestador.Identificacao))
                    .ForMember(tgt => tgt.IsProcessavel, opt => opt.MapFrom(src => src.IdDemonstrativo.HasValue))
                    .ForMember(tgt => tgt.IdRPS,
                        opt => opt.MapFrom(src => src.RPS.OrderBy(r => r.Id).LastOrDefault(r => r.MotivoCancelamento == null).Id))
                    .ForMember(tgt => tgt.IdLoteRPS,
                        opt => opt.MapFrom(src => src.RPS.OrderBy(r => r.Id).LastOrDefault(r => r.MotivoCancelamento == null).IdLoteRPS))
                    .ForMember(tgt => tgt.IsCancelada, opt => opt.MapFrom(src => src.RPS.OrderBy(r => r.Id).LastOrDefault(r => r.MotivoCancelamento == null).NotaFiscal.FirstOrDefault().IsCancelada))
                    .ForMember(tgt => tgt.IdStatusLoteRPS, opt => opt.MapFrom(src => src.RPS.OrderBy(r => r.Id).LastOrDefault(r => r.MotivoCancelamento == null).LoteRPS.IdStatusLoteRPS));


                cfg.CreateMap<Fatura, FaturaViewModel>()
                    .ForMember(tgt => tgt.IsProcessavel, opt => opt.MapFrom(src => src.IdDemonstrativo.HasValue))
                    .ForMember(tgt => tgt.HasRetencao, opt => opt.MapFrom(
                        src => src.AliquotaIR > 0.00m || src.AliquotaCOFINS > 0.00m ||
                               src.AliquotaINSS > 0.00m || src.AliquotaPIS > 0.00m || src.AliquotaCSLL > 0.00m))
                    .ForMember(tgt => tgt.IdEstadoPrestacao, opt => opt.MapFrom(src => src.LocalPrestacao.IdEstado));


                cfg.CreateMap<Faturamento, FaturamentoViewModel>();
                cfg.CreateMap<Filial, FilialViewModel>()
                    .ForMember(tgt => tgt.IdCidade, opt => opt.MapFrom(src => src.Cidade.Id))
                    .ForMember(tgt => tgt.IdEstado, opt => opt.MapFrom(src => src.Cidade.IdEstado))
                    .ForMember(tgt => tgt.TipoBairro, opt => opt.MapFrom(src => src.TipoBairro.Descricao))
                    .ForMember(tgt => tgt.TipoLogradouro, opt => opt.MapFrom(src => src.TipoLogradouro.Descricao))
                    .ForMember(tgt => tgt.Cidade, opt => opt.MapFrom(src => src.Cidade.Nome))
                    .ForMember(tgt => tgt.Estado, opt => opt.MapFrom(src => src.Cidade.Estado.Sigla));

                cfg.CreateMap<Incidencia, IncidenciaViewModel>();
                cfg.CreateMap<ItensServico, ItensServicoViewModel>();
                cfg.CreateMap<LoteRPS, LoteRPSViewModel>()
                    .ForMember(tgt => tgt.StatusLoteRPS, opt => opt.MapFrom(src => src.StatusLoteRPS.Descricao));

                cfg.CreateMap<NotaFiscal, NotaFiscalViewModel>();
                cfg.CreateMap<Operacao, OperacaoViewModel>();
                cfg.CreateMap<Permissao, PermissaoViewModel>();

                cfg.CreateMap<Projeto, ProjetoDisplayViewModel>()
                    .ForMember(tgt => tgt.Status, opt => opt.MapFrom(src => src.StatusProjeto.Descricao));

                cfg.CreateMap<RegimeTributario, RegimeTributarioViewModel>();
                cfg.CreateMap<RPS, RPSViewModel>()
                    .ForMember(tgt => tgt.ValorTotal, opt => opt.MapFrom(src => src.ItensRPS.Sum(v => v.ValorTotal)))
                    .ForMember(tgt => tgt.DeducaoTotal,
                        opt => opt.MapFrom(src => src.DeducaoRPS.Sum(v => v.ValorDeduzir)));
                cfg.CreateMap<Servico, ServicoViewModel>()
                    .ForMember(tgt => tgt.Unidade, opt => opt.MapFrom(src => src.Unidade.Descricao))
                    .ForMember(tgt => tgt.NomeConexao, opt => opt.MapFrom(src => src.ConexaoBanco.Nome))
                    .ForMember(tgt => tgt.Servidor, opt => opt.MapFrom(src => src.ConexaoBanco.Servidor))
                    .ForMember(tgt => tgt.Database, opt => opt.MapFrom(src => src.ConexaoBanco.Database))
                    .ForMember(tgt => tgt.Namespace, opt => opt.MapFrom(src => src.ConexaoBanco.DBProvider.Namespace));

                cfg.CreateMap<Task, DeleteTaskViewModel>();
                cfg.CreateMap<DeleteTaskViewModel, Task>();
                cfg.CreateMap<Task, TaskDisplayViewModel>()
                    .ForMember(tgt => tgt.Cells, opt => opt.MapFrom(src => src.TaskCells));
                cfg.CreateMap<TaskColumn, TaskColumnDisplayViewModel>()
                    .ForMember(tgt => tgt.Cells, opt => opt.MapFrom(src => src.TaskCells));
                cfg.CreateMap<TaskColumn, DeleteColumnViewModel>();
                cfg.CreateMap<DeleteColumnViewModel, TaskColumn>();
                cfg.CreateMap<TaskCell, TaskCellDisplayViewModel>();
                cfg.CreateMap<Label, LabelDisplayViewModel>();
                cfg.CreateMap<TaskGroup, GetTrackingsViewModel>()
                    .ForMember(tgt => tgt.Columns, opt => opt.MapFrom(src => src.Columns));

                cfg.CreateMap<TipoBairro, TipoBairroViewModel>();
                cfg.CreateMap<TipoLogradouro, TipoLogradouroViewModel>();
                cfg.CreateMap<TipoRecolhimento, TipoRecolhimentoViewModel>();
                cfg.CreateMap<Tributacao, TributacaoViewModel>();
                cfg.CreateMap<Unidade, UnidadeViewModel>();
                cfg.CreateMap<Usuario, UsuarioViewModel>()
                    .ForMember(tgt => tgt.Senha, opt => opt.Ignore())
                    .ForMember(tgt => tgt.Empresa, opt => opt.MapFrom(src => src.Empresa.Identificacao))
                    .ForMember(tgt => tgt.Permissoes,
                        opt => opt.MapFrom(src => src.UsuarioPermissao.Select(per => new PermissaoViewModel
                            {Id = per.IdPermissao, Nome = per.Permissao.Nome, IsEnabled = true}).ToList()));
                cfg.CreateMap<Usuario, _SimpleEditUserViewModel>()
                    .ForMember(tgt => tgt.Senha, opt => opt.Ignore())
                    .ForMember(tgt => tgt.Empresa, opt => opt.MapFrom(src => src.Empresa.Identificacao));
                cfg.CreateMap<Usuario, AuthenticatedUserViewModel>()
                    .ForMember(tgt => tgt.Name, opt => opt.MapFrom(src => src.Nome));
                cfg.CreateMap<Utilizacao, UtilizacaoViewModel>();

                // ViewModels to Entities
                cfg.CreateMap<AtividadeViewModel, Atividade>();
                cfg.CreateMap<CertificadoDigitalViewModel, CertificadoDigital>();
                cfg.CreateMap<ConexaoBancoViewModel, ConexaoBanco>();
                cfg.CreateMap<CidadeViewModel, Cidade>();
                cfg.CreateMap<ClienteViewModel, Cliente>();
                cfg.CreateMap<DBProviderViewModel, DBProvider>();
                cfg.CreateMap<DemonstrativoViewModel, Demonstrativo>();
                cfg.CreateMap<EmpresaViewModel, Empresa>();
                cfg.CreateMap<EstadoViewModel, Estado>();
                cfg.CreateMap<FaturaViewModel, Fatura>();
                cfg.CreateMap<FaturamentoViewModel, Faturamento>();
                cfg.CreateMap<FilialViewModel, Filial>();
                cfg.CreateMap<IncidenciaViewModel, Incidencia>();
                cfg.CreateMap<ItensServicoViewModel, ItensServico>();
                cfg.CreateMap<LoteRPSViewModel, LoteRPS>();
                cfg.CreateMap<NotaFiscalViewModel, NotaFiscal>();
                cfg.CreateMap<OperacaoViewModel, Operacao>();
                cfg.CreateMap<PermissaoViewModel, Permissao>();
                cfg.CreateMap<RegimeTributarioViewModel, RegimeTributario>();
                cfg.CreateMap<RPSViewModel, RPS>();
                cfg.CreateMap<ServicoViewModel, Servico>();
                cfg.CreateMap<StatusLoteRPS, StatusLoteRPS>();
                cfg.CreateMap<TipoBairroViewModel, TipoBairro>();
                cfg.CreateMap<TipoLogradouroViewModel, TipoLogradouro>();
                cfg.CreateMap<TipoRecolhimentoViewModel, TipoRecolhimento>();
                cfg.CreateMap<TributacaoViewModel, Tributacao>();
                cfg.CreateMap<UnidadeViewModel, Unidade>();
                cfg.CreateMap<UsuarioViewModel, Usuario>()
                    .ForMember(tgt => tgt.UsuarioPermissao, opt => opt.MapFrom(src => src.Permissoes.Where(p => p.IsEnabled).Select(s => new UsuarioPermissao() {IdUsuario = src.Id, IdPermissao = s.Id,}).ToList()));
                cfg.CreateMap<_SimpleEditUserViewModel, Usuario>();
                cfg.CreateMap<UtilizacaoViewModel, Utilizacao>();
                cfg.CreateMap<CreateColumnViewModel, TaskColumn>();
                cfg.CreateMap<Label, CreateLabelViewModel>();
                cfg.CreateMap<CreateLabelViewModel, Label>();
                // Combobox mapping
                cfg.CreateMap<StatusLoteRPSViewModel, GenericData>();
            });
        }
    }
}