using log4net;
using Ninject.Modules;
using RedSky.Application;
using RedSky.Application.Interfaces;
using RedSky.Application.Processing;
using RedSky.Application.Processing.Interfaces;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.NFSe;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;
using RedSky.Domain.Services;
using RedSky.Infrastructure.Data.Implementations;
using RedSky.Infrastructure.Data.Implementations.Factories;
using RedSky.Infrastructure.Data.Repositories;
using RedSky.Infrastructure.NFSe;
using RedSky.Infrastructure.NFSe.Factories;
using RedSky.Infrastructure.NFSe.Interfaces;
using RedSky.Services;
using RedSky.Services.Interfaces;

namespace RedSky.IoC
{
    public class DefaultInjectionModule : NinjectModule
    {
        public override void Load()
        {
            // 1 - Service Layer Bindings
            Bind<IServiceHub>().To<ServiceHub>();
            
            // 2 - Application Layer Bindings
            Bind<IFinanceiroApplicationService>().To<FinanceiroApplicationService>();
            Bind<IProjetoApplicationService>().To<ProjetoApplicationService>();
            Bind<IRelatorioApplicationService>().To<RelatorioApplicationService>();
            Bind<IReportGenerator>().To<ReportGenerator>();
            Bind<ISistemaApplicationService>().To<SistemaApplicationService>();

            // 3 - Domain Layer Bindings
            Bind<IAtividadeService>().To<AtividadeService>();
            Bind<ICertificadoDigitalService>().To<CertificadoDigitalService>();
            Bind<IClienteService>().To<ClienteService>();
            Bind<ICidadeService>().To<CidadeService>();
            Bind<IColorService>().To<ColorService>();
            Bind<IConexaoBancoService>().To<ConexaoBancoService>();
            Bind<IDataTypeService>().To<DataTypeService>();
            Bind<IDBProviderService>().To<DBProviderService>();
            Bind<IDeducaoRPSService>().To<DeducaoRPSService>();
            Bind<IDemonstrativoService>().To<DemonstrativoService>();
            Bind<IEmpresaService>().To<EmpresaService>();
            Bind<IEstadoService>().To<EstadoService>();
            Bind<IFaturaService>().To<FaturaService>();
            Bind<IFaturamentoService>().To<FaturamentoService>();
            Bind<IFilialService>().To<FilialService>();
            Bind<IIncidenciaService>().To<IncidenciaService>();
            Bind<IItemRPSService>().To<ItemRPSService>();
            Bind<IItensServicoService>().To<ItensServicoService>();
            Bind<ILoteRPSService>().To<LoteRPSService>();
            Bind<INegocioService>().To<NegocioService>();
            Bind<INotaFiscalService>().To<NotaFiscalService>();
            Bind<IOperacaoService>().To<OperacaoService>();
            Bind<IPermissaoService>().To<PermissaoService>();
            Bind<IProjetoService>().To<ProjetoService>();
            Bind<IRegimeTributarioService>().To<RegimeTributarioService>();
            Bind<IRPSService>().To<RPSService>();
            Bind<IServicoService>().To<ServicoService>();
            Bind<IStatusLoteRPSService>().To<StatusLoteRPSService>();
            Bind<IStatusProjetoService>().To<StatusProjetoService>();
            Bind<ILabelService>().To<LabelService>();
            Bind<ITaskService>().To<TaskService>();
            Bind<ITaskCellService>().To<TaskCellService>();
            Bind<ITaskColumnService>().To<TaskColumnService>();
            Bind<ITaskGroupService>().To<TaskGroupService>();
            Bind<ITaskUserService>().To<TaskUserService>();
            Bind<ITipoBairroService>().To<TipoBairroService>();
            Bind<ITipoLogradouroService>().To<TipoLogradouroService>();
            Bind<ITipoRecolhimentoService>().To<TipoRecolhimentoService>();
            Bind<ITributacaoService>().To<TributacaoService>();
            Bind<IUnidadeService>().To<UnidadeService>();
            Bind<IUsuarioService>().To<UsuarioService>();
            Bind<IUsuarioPermissaoService>().To<UsuarioPermissaoService>();
            Bind<IUtilizacaoService>().To<UtilizacaoService>();

            // 4.1 - Infrastructure Layer Bindings
            Bind<IRepositoryBase<Atividade>>().To<RepositoryBase<Atividade>>();
            Bind<IRepositoryBase<CertificadoDigital>>().To<RepositoryBase<CertificadoDigital>>();
            Bind<IRepositoryBase<Cliente>>().To<RepositoryBase<Cliente>>();
            Bind<IRepositoryBase<Cidade>>().To<RepositoryBase<Cidade>>();
            Bind<IRepositoryBase<Color>>().To<RepositoryBase<Color>>();
            Bind<IRepositoryBase<ConexaoBanco>>().To<RepositoryBase<ConexaoBanco>>();
            Bind<IRepositoryBase<DataType>>().To<RepositoryBase<DataType>>();
            Bind<IRepositoryBase<DBProvider>>().To<RepositoryBase<DBProvider>>();
            Bind<IRepositoryBase<DeducaoRPS>>().To<RepositoryBase<DeducaoRPS>>();
            Bind<IRepositoryBase<Demonstrativo>>().To<RepositoryBase<Demonstrativo>>();
            Bind<IRepositoryBase<Empresa>>().To<RepositoryBase<Empresa>>();
            Bind<IRepositoryBase<Estado>>().To<RepositoryBase<Estado>>();
            Bind<IRepositoryBase<Fatura>>().To<RepositoryBase<Fatura>>();
            Bind<IRepositoryBase<Faturamento>>().To<RepositoryBase<Faturamento>>();
            Bind<IRepositoryBase<Filial>>().To<RepositoryBase<Filial>>();
            Bind<IRepositoryBase<Incidencia>>().To<RepositoryBase<Incidencia>>();
            Bind<IRepositoryBase<ItemRPS>>().To<RepositoryBase<ItemRPS>>();
            Bind<IRepositoryBase<ItensServico>>().To<RepositoryBase<ItensServico>>();
            Bind<IRepositoryBase<LoteRPS>>().To<RepositoryBase<LoteRPS>>();
            Bind<IRepositoryBase<Negocio>>().To<RepositoryBase<Negocio>>();
            Bind<IRepositoryBase<NotaFiscal>>().To<RepositoryBase<NotaFiscal>>();
            Bind<IRepositoryBase<Operacao>>().To<RepositoryBase<Operacao>>();
            Bind<IRepositoryBase<Permissao>>().To<RepositoryBase<Permissao>>();
            Bind<IRepositoryBase<Projeto>>().To<RepositoryBase<Projeto>>();
            Bind<IRepositoryBase<RegimeTributario>>().To<RepositoryBase<RegimeTributario>>();
            Bind<IRepositoryBase<RPS>>().To<RepositoryBase<RPS>>();
            Bind<IRepositoryBase<Servico>>().To<RepositoryBase<Servico>>();
            Bind<IRepositoryBase<StatusLoteRPS>>().To<RepositoryBase<StatusLoteRPS>>();
            Bind<IRepositoryBase<StatusProjeto>>().To<RepositoryBase<StatusProjeto>>();
            Bind<IRepositoryBase<Label>>().To<RepositoryBase<Label>>();
            Bind<IRepositoryBase<Task>>().To<RepositoryBase<Task>>();
            Bind<IRepositoryBase<TaskCell>>().To<RepositoryBase<TaskCell>>();
            Bind<IRepositoryBase<TaskColumn>>().To<RepositoryBase<TaskColumn>>();
            Bind<IRepositoryBase<TaskGroup>>().To<RepositoryBase<TaskGroup>>();
            Bind<IRepositoryBase<TaskUser>>().To<RepositoryBase<TaskUser>>();
            Bind<IRepositoryBase<TipoBairro>>().To<RepositoryBase<TipoBairro>>();
            Bind<IRepositoryBase<TipoLogradouro>>().To<RepositoryBase<TipoLogradouro>>();
            Bind<IRepositoryBase<TipoRecolhimento>>().To<RepositoryBase<TipoRecolhimento>>();
            Bind<IRepositoryBase<Tributacao>>().To<RepositoryBase<Tributacao>>();
            Bind<IRepositoryBase<Unidade>>().To<RepositoryBase<Unidade>>();
            Bind<IRepositoryBase<Usuario>>().To<RepositoryBase<Usuario>>();
            Bind<IRepositoryBase<UsuarioPermissao>>().To<RepositoryBase<UsuarioPermissao>>();
            Bind<IRepositoryBase<Utilizacao>>().To<RepositoryBase<Utilizacao>>();

            // 4.2 - External Services
            // NFSe
            Bind<INFSeWSFactory>().To<NFSeWSFactory>();
            Bind<INFSeService>().To<NFSeService>();

            // 4.3 - Contexts
            Bind<IAmbientDbContextLocator>().To<AmbientDbContextLocator>();
            Bind<IDbContextCollection>().To<DbContextCollection>();
            Bind<IDbContextFactory>().To<DefaultDbContextFactory>();
            Bind<IDbContextReadOnlyScope>().To<DbContextReadOnlyScope>();
            Bind<IDbContextScope>().To<DbContextScope>();
            Bind<IDbContextScopeFactory>().To<DbContextScopeFactory>();
        }
    }
}