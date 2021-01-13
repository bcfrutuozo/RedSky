using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using RedSky.Application.Interfaces;
using RedSky.Domain.Entities;
using RedSky.Services.Interfaces;

namespace RedSky.Services
{
    public class ServiceHub : IServiceHub
    {
        private readonly IFinanceiroApplicationService FinanceiroApplicationService;
        private readonly IProjetoApplicationService ProjetoApplicationService;
        private readonly IRelatorioApplicationService RelatorioApplicationService;
        private readonly ISistemaApplicationService SistemaApplicationService;

        public ServiceHub(
            IFinanceiroApplicationService financeiroApplicationService,
            IProjetoApplicationService projetoApplicationService,
            IRelatorioApplicationService relatorioApplicationService,
            ISistemaApplicationService sistemaApplicationService)
        {
            FinanceiroApplicationService = financeiroApplicationService;
            ProjetoApplicationService = projetoApplicationService;
            RelatorioApplicationService = relatorioApplicationService;
            SistemaApplicationService = sistemaApplicationService;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
        }

        #region Atividade

        public Atividade AddAtividade(Atividade atividade)
        {
            return SistemaApplicationService.AddAtividade(atividade);
        }

        public Atividade GetAtividadeById(int idAtividade)
        {
            return SistemaApplicationService.GetAtividadeById(idAtividade);
        }

        public IEnumerable<Atividade> GetAllAtividade()
        {
            return SistemaApplicationService.GetAllAtividade();
        }

        public IEnumerable<Atividade> GetListAtividadeByIdEmpresa(int idEmpresa)
        {
            return SistemaApplicationService.GetListAtividadeByIdEmpresa(idEmpresa);
        }

        public Atividade UpdateAtividade(Atividade atividade)
        {
            return SistemaApplicationService.UpdateAtividade(atividade);
        }

        public Atividade DeleteAtividade(Atividade atividade)
        {
            return SistemaApplicationService.DeleteAtividade(atividade);
        }

        #endregion

        #region CertificadoDigital

        public CertificadoDigital AddCertificadoDigital(CertificadoDigital certificado)
        {
            return SistemaApplicationService.AddCertificadoDigital(certificado);
        }

        public IEnumerable<CertificadoDigital> AddRangeCertificadoDigital(IEnumerable<CertificadoDigital> lstCertificado)
        {
            return SistemaApplicationService.AddRangeCertificadoDigital(lstCertificado);
        }

        public IEnumerable<CertificadoDigital> GetListCertificadoDigitalByIdFilial(int idFilial)
        {
            return SistemaApplicationService.GetListCertificadoDigitalByIdFilial(idFilial);
        }

        public CertificadoDigital DeleteCertificadoDigital(CertificadoDigital certificado)
        {
            return SistemaApplicationService.DeleteCertificadoDigital(certificado);
        }

        #endregion

        #region Cidade

        public IEnumerable<Cidade> GetAllCidade()
        {
            return SistemaApplicationService.GetAllCidade();
        }

        public IEnumerable<Cidade> GetListCidadeByIdEstado(int idEstado)
        {
            return SistemaApplicationService.GetListCidadeByIdEstado(idEstado);
        }

        public IEnumerable<Cidade> GetListCidadeSameEstadoByIdCidade(int idCidade)
        {
            return SistemaApplicationService.GetListCidadeSameEstadoByIdCidade(idCidade);
        }

        public Cidade GetCidadeById(int idCidade)
        {
            return SistemaApplicationService.GetCidadeById(idCidade);
        }

        #endregion

        #region Cliente

        public Cliente AddCliente(Cliente cliente)
        {
            return SistemaApplicationService.AddCliente(cliente);
        }

        public Cliente GetClienteById_CREATEUPDATE(int idCliente)
        {
            return SistemaApplicationService.GetClienteById_CREATEUPDATE(idCliente);
        }

        public IEnumerable<Cliente> GetListClienteByIdEmpresa_INDEX(int idEmpresa)
        {
            return SistemaApplicationService.GetListClienteByIdEmpresa_INDEX(idEmpresa);
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            return SistemaApplicationService.UpdateCliente(cliente);
        }

        public Cliente RemoveCliente(Cliente cliente)
        {
            return SistemaApplicationService.DeleteCliente(cliente);
        }

        public IEnumerable<Cliente> GetListClienteByIdEmpresa_COMBOBOX(int idEmpresa)
        {
            return SistemaApplicationService.GetListClienteByIdEmpresa_COMBOBOX(idEmpresa);
        }

        #endregion

        #region Color

        public IEnumerable<Color> GetAllColor()
        {
            return SistemaApplicationService.GetAllColor();
        }

        #endregion

        #region ConexaoBanco

        public ConexaoBanco AddConexaoEmpresa(ConexaoBanco conexao)
        {
            return SistemaApplicationService.AddConexaoEmpresa(conexao);
        }

        public IEnumerable<ConexaoBanco> GetListConexaoBancoByIdEmpresa(int idEmpresa)
        {
            return SistemaApplicationService.GetListConexaoBancoByIdEmpresa(idEmpresa);
        }

        public ConexaoBanco GetConexaoBancoById(int idConexaoBanco)
        {
            return SistemaApplicationService.GetConexaoBancoById(idConexaoBanco);
        }

        public ConexaoBanco UpdateConexaoBanco(ConexaoBanco conexao)
        {
            return SistemaApplicationService.UpdateConexaoBanco(conexao);
        }

        public ConexaoBanco DeleteConexaoBanco(ConexaoBanco conexao)
        {
            return SistemaApplicationService.DeleteConexaoBanco(conexao);
        }

        public ConexaoBanco GetConexaoBancoByIdEmpresa_Nome(int idEmpresa, string nome)
        {
            return SistemaApplicationService.GetConexaoBancoByIdEmpresa_Nome(idEmpresa, nome);
        }

        #endregion

        #region DataType

        public IEnumerable<DataType> GetAllDataTypes()
        {
            return SistemaApplicationService.GetAllDataTypes();
        }

        #endregion

        #region Demonstrativo

        public Demonstrativo AddDemonstrativo(Demonstrativo demonstrativo)
        {
            return RelatorioApplicationService.AddDemonstrativo(demonstrativo);
        }

        public Demonstrativo GetDemonstrativoById_CREATEEDIT(int idDemonstrativo)
        {
            return RelatorioApplicationService.GetDemonstrativoById_CREATEEDIT(idDemonstrativo);
        }

        public IEnumerable<Demonstrativo> GetListDemonstrativoWithServicoByIdEmpresa_INDEX(int idEmpresa)
        {
            return RelatorioApplicationService.GetListDemonstrativoWithServicoByIdEmpresa_INDEX(idEmpresa);
        }

        public IEnumerable<Demonstrativo> GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(int idEmpresa)
        {
            return RelatorioApplicationService.GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(idEmpresa);
        }

        public IEnumerable<Demonstrativo> GetDemonstrativosFaturaveisPorCliente(int idCliente)
        {
            return RelatorioApplicationService.GetListDemonstrativoWithIsFaturavelByIdCliente(idCliente);
        }

        public Demonstrativo UpdateDemonstrativo(Demonstrativo demonstrativo)
        {
            return RelatorioApplicationService.UpdateDemonstrativo(demonstrativo);
        }

        public Demonstrativo DeleteDemonstrativo(Demonstrativo demonstrativo)
        {
            return RelatorioApplicationService.DeleteDemonstrativo(demonstrativo);
        }

        public Demonstrativo CopyDemonstrativo(int idDemonstrativo)
        {
            return RelatorioApplicationService.CopyDemonstrativoById(idDemonstrativo);
        }

        #endregion

        #region DBProvider

        public IEnumerable<DBProvider> GetAllDBProvider()
        {
            return SistemaApplicationService.GetAllDBProvider();
        }

        public DBProvider GetDBProviderById(int idDBProvider)
        {
            return SistemaApplicationService.GetDBProviderById(idDBProvider);
        }

        #endregion

        #region Empresa

        public Empresa AddEmpresa(Empresa empresa)
        {
            return SistemaApplicationService.AddEmpresa(empresa);
        }

        public Empresa GetEmpresaById(int idEmpresa)
        {
            return SistemaApplicationService.GetEmpresaById(idEmpresa);
        }

        public IEnumerable<Empresa> GetAllEmpresa()
        {
            return SistemaApplicationService.GetAllEmpresa();
        }

        public Empresa GetEmpresaByIdentificacao(string identificacao)
        {
            return SistemaApplicationService.GetEmpresaByIdentificacao(identificacao);
        }

        public Empresa GetEmpresaByIdUsuario(int idUsuario)
        {
            return SistemaApplicationService.GetEmpresaByIdUsuario(idUsuario);
        }

        public IEnumerable<Empresa> GetListEmpresaForGenericData()
        {
            return SistemaApplicationService.GetListEmpresaForGenericData();
        }

        public Empresa GetEmpresaByLoginUsuario(string loginUsuario)
        {
            return SistemaApplicationService.GetEmpresaByLoginUsuario(loginUsuario);
        }

        public Empresa UpdateEmpresa(Empresa empresa)
        {
            return SistemaApplicationService.UpdateEmpresa(empresa);
        }

        public Empresa DeleteEmpresa(int idEmpresa)
        {
            return SistemaApplicationService.DeleteEmpresa(idEmpresa);
        }

        #endregion

        #region Estado

        public IEnumerable<Estado> GetAllEstado()
        {
            return SistemaApplicationService.GetAllEstado();
        }

        public Estado GetEstadoById(int idEstado)
        {
            return SistemaApplicationService.GetEstadoById(idEstado);
        }

        #endregion

        #region Fatura

        public void SendBillingEmail(int idFatura)
        {
            FinanceiroApplicationService.SendFaturaEmail(idFatura);
        }

        public void SendInvoiceEmail(int idFilial, long numeroNF)
        {
            FinanceiroApplicationService.SendNotaFiscalEmail(idFilial, numeroNF);
        }

        public Fatura AddFatura(Fatura fatura)
        {
            return FinanceiroApplicationService.AddFatura(fatura);
        }

        public Fatura GetFaturaById_Update(int idFatura)
        {
            return FinanceiroApplicationService.GetFaturaById_Update(idFatura);
        }

        public IEnumerable<Fatura> GetAllFaturaByEmpresa_Mes_Ano(int idEmpresa, int month, int year)
        {
            return FinanceiroApplicationService.GetAllFaturaByEmpresa_Mes_Ano(idEmpresa, month, year);
        }

        public Fatura UpdateFatura(Fatura fatura)
        {
            return FinanceiroApplicationService.UpdateFatura(fatura);
        }

        public Fatura DeleteFatura(int idFatura)
        {
            return FinanceiroApplicationService.DeleteFatura(idFatura, false);
        }

        public Fatura DeleteFaturaAndFaturamentos(int idFatura)
        {
            return FinanceiroApplicationService.DeleteFatura(idFatura, true);
        }

        public Fatura EmitirFatura(int id)
        {
            return FinanceiroApplicationService.EmitirFatura(id);
        }

        public IEnumerable<Fatura> DuplicarCompetencia(int idEmpresa, int monthSource, int yearSource,
            int monthTarget, int yearTarget)
        {
            return FinanceiroApplicationService.DuplicarCompetencia(idEmpresa, monthSource, yearSource, monthTarget, yearTarget);
        }

        public Fatura CancelarRPS(int idRPS)
        {
            return FinanceiroApplicationService.CancelarRPS(idRPS);
        }

        public string GetFaturaNomeArquivo(int idFatura)
        {
            return FinanceiroApplicationService.GetFaturaNomeArquivo(idFatura);
        }

        public byte[] DownloadFatura(int idFatura)
        {
            return FinanceiroApplicationService.DownloadFatura(idFatura);
        }

        public Fatura ZerarFatura(int idFatura)
        {
            return FinanceiroApplicationService.DeleteFaturamentosFromFatura(idFatura);
        }

        #endregion

        #region Faturamento

        public Faturamento AddFaturamento(Faturamento faturamento, bool isUserEdit)
        {
            return FinanceiroApplicationService.AddFaturamento(faturamento, isUserEdit);
        }

        public IEnumerable<Faturamento> AddFaturamentos(IEnumerable<Faturamento> lstFaturamentos, bool isUserEdit)
        {
            return FinanceiroApplicationService.AddFaturamento(lstFaturamentos, isUserEdit);
        }

        public IEnumerable<Faturamento> GetListFaturamentoByIdFatura(int idFatura)
        {
            return FinanceiroApplicationService.GetListFaturamentoByIdFatura(idFatura);
        }

        public Faturamento UpdateFaturamento(Faturamento faturamento, bool isUserEdit)
        {
            return FinanceiroApplicationService.UpdateFaturamento(faturamento, isUserEdit);
        }

        public Faturamento DeleteFaturamento(Faturamento faturamento, bool isUserEdit)
        {
            return FinanceiroApplicationService.DeleteFaturamento(faturamento, isUserEdit);
        }

        public IEnumerable<Faturamento> DeleteFaturamentos(IEnumerable<Faturamento> faturamentos, bool isUserEdit)
        {
            return FinanceiroApplicationService.DeleteFaturamento(faturamentos, isUserEdit);
        }

        #endregion

        #region EXTERNAL_SVC_NFSE

        public LoteRPS EnviarLoteRPS(int idLoteRPS, bool synchronous)
        {
            return FinanceiroApplicationService.EnviarLoteRPS(idLoteRPS, synchronous);
        }

        public long ConsultarUltimoRPS(int idFilial)
        {
            throw new NotImplementedException();
        }

        public void ConsultarNotas(int idFilial, DateTime inicio, DateTime fim, int notaInicial = 0)
        {
            throw new NotImplementedException();
        }

        public void ConsultarNFS(int idFilial, int numeroLote, int numeroNF, string codigoVerificacao)
        {
            throw new NotImplementedException();
        }

        public void ConsultarRPS(int idFilial, int numeroLote, int numeroRPS)
        {
            throw new NotImplementedException();
        }

        public void CancelarNF(int idFilial, int numeroNF, string codigoVerificacao, string motivo)
        {
            throw new NotImplementedException();
        }

        public void DownloadNFSe(int idFilial, long numeroNF)
        {
            FinanceiroApplicationService.DownloadNFSe(idFilial, numeroNF);
        }

        public string ObterLinkNotaFiscal(int idFilial, int numeroNF)
        {
            throw new NotImplementedException();
        }

        public RPS Faturar(int idFatura)
        {
            return FinanceiroApplicationService.Faturar(idFatura);
        }

        #endregion

        #region Filial

        public Filial AddFilial(Filial filial)
        {
            return SistemaApplicationService.AddFilial(filial);
        }

        public IEnumerable<Filial> GetAllFilial()
        {
            return SistemaApplicationService.GetAllFilial();
        }

        public Filial GetFilialById_CREATEEDIT(int idFilial)
        {
            return SistemaApplicationService.GetFilialById_CREATEEDIT(idFilial);
        }

        public IEnumerable<Filial> GetListFilialByIdEmpresa_INDEX(int idEmpresa)
        {
            return SistemaApplicationService.GetListFilialByIdEmpresa_INDEX(idEmpresa);
        }

        public Filial GetFilialByIdEmpresa_Nome(int idEmpresa, string nome)
        {
            return SistemaApplicationService.GetFilialByIdEmpresa_Nome(idEmpresa, nome);
        }

        public Filial UpdateFilial(Filial filial)
        {
            return SistemaApplicationService.UpdateFilial(filial);
        }

        public Filial DeleteFilial(int idFilial)
        {
            return SistemaApplicationService.DeleteFilial(idFilial);
        }

        public int GetQuantidadeRpsPorLoteByIdFilial(int idFilial)
        {
            return SistemaApplicationService.GetQuantidadeRpsPorLoteByIdFilial(idFilial);
        }

        #endregion

        #region Incidencia

        public IEnumerable<Incidencia> GetAllIncidencia()
        {
            return SistemaApplicationService.GetAllIncidencia();
        }

        #endregion

        #region ItensServico

        public IEnumerable<ItensServico> GetAllItensServico()
        {
            return SistemaApplicationService.GetAllItensServico();
        }

        #endregion

        #region Label

        public Label AddLabel(Label label)
        {
            return ProjetoApplicationService.AddLabel(label);
        }

        public IEnumerable<Label> GetListLabelByIdEmpresa(int idEmpresa)
        {
            return ProjetoApplicationService.GetListLabelByIdEmpresa(idEmpresa);
        }

        #endregion

        #region LoteRPS

        public LoteRPS AddLoteRPS(int idFilial)
        {
            return FinanceiroApplicationService.AddLoteRPS(idFilial);
        }

        public void DownloadNFSeByIdLoteRPS(int idLoteRPS)
        {
            FinanceiroApplicationService.DownloadNFSeByIdLoteRPS(idLoteRPS);
        }

        public LoteRPS GetLoteRPSById(int idLoteRPS)
        {
            return FinanceiroApplicationService.GetLoteRPSById_DELETE(idLoteRPS);
        }

        public LoteRPS DeleteLoteRPS(LoteRPS loteRPS)
        {
            return FinanceiroApplicationService.DeleteLoteRPS(loteRPS);
        }

        public LoteRPS AddRangeRPSInLoteRPS(int idLoteRPS, IEnumerable<int> lstRPS)
        {
            return FinanceiroApplicationService.AddRangeRPSInLoteRPS(idLoteRPS, lstRPS);
        }

        public IEnumerable<LoteRPS> GetListLoteRPSByIdFilial(int idFilial, int idStatusLoteRPS = 0)
        {
            return FinanceiroApplicationService.GetListLoteRPSByIdFilial(idFilial, idStatusLoteRPS);
        }

        public LoteRPS DeleteRangeRPSFromLoteRPS(IEnumerable<int> lstRPS)
        {
            return FinanceiroApplicationService.DeleteRangeRPSFromLoteRPS(lstRPS);
        }

        #endregion
        
        #region Operacao

        public IEnumerable<Operacao> GetAllOperacao()
        {
            return SistemaApplicationService.GetAllOperacao();
        }

        #endregion

        #region Permissao

        public IEnumerable<Permissao> GetAllPermissao()
        {
            return SistemaApplicationService.GetAllPermissao();
        }

        public Permissao GetPermissaoById(int id)
        {
            return SistemaApplicationService.GetPermissaoById(id);
        }

        public Permissao AddPermissao(Permissao permissao)
        {
            return SistemaApplicationService.AddPermissao(permissao);
        }

        public Permissao UpdatePermissao(Permissao permissao)
        {
            return SistemaApplicationService.UpdatePermissao(permissao);
        }

        public Permissao DeletePermissao(int idPermissao)
        {
            return SistemaApplicationService.DeletePermissao(idPermissao);
        }

        public string[] GetAllPermissaoByUsuario(string username)
        {
            return SistemaApplicationService.GetAllPermissaoByUsuario(username);
        }

        #endregion

        #region Projeto

        public IEnumerable<Projeto> GetListProjetoByIdEmpresa_INDEX(Int32 idEmpresa)
        {
            return ProjetoApplicationService.GetListProjetoByIdEmpresa_INDEX(idEmpresa);
        }

        public Projeto GetProjetoById(Int32 id)
        {
            return ProjetoApplicationService.GetProjetoById(id);
        }

        #endregion

        #region RegimeTributario

        public IEnumerable<RegimeTributario> GetAllRegimeTributario()
        {
            return SistemaApplicationService.GetAllRegimeTributario();
        }

        #endregion

        #region RPS

        public IEnumerable<RPS> GetListRPSWithNoLoteRPSByIdFilial(int idFilial)
        {
            return FinanceiroApplicationService.GetListRPSWithNoLoteRPSByIdFilial(idFilial);
        }

        public RPS GetRPSPorIdFatura(int idFatura)
        {
            return FinanceiroApplicationService.GetRPSPorIdFatura(idFatura);
        }

        public IEnumerable<RPS> GetListRPSByIdLoteRPS(int idLoteRPS)
        {
            return FinanceiroApplicationService.GetListRPSByIdLoteRPS(idLoteRPS);
        }

        #endregion

        #region Servico

        public Servico AddServico(Servico servico)
        {
            return RelatorioApplicationService.AddServico(servico);
        }

        public Servico GetServicoById_CREATEEDIT(int idServico)
        {
            return RelatorioApplicationService.GetServicoById_CREATEEDIT(idServico);
        }

        public IEnumerable<Servico> GetListServicoByIdDemonstrativo_INDEX(int idDemonstrativo)
        {
            return RelatorioApplicationService.GetListServicoByIdDemonstrativo_INDEX(idDemonstrativo);
        }

        public IEnumerable<Servico> GetListServicoByIdFatura(int idFatura)
        {
            return RelatorioApplicationService.GetListServicoByIdFatura(idFatura);
        }

        public Servico UpdateServico(Servico servico)
        {
            return RelatorioApplicationService.UpdateServico(servico);
        }

        public Servico DeleteServico(Servico servico)
        {
            return RelatorioApplicationService.DeleteServico(servico);
        }

        public IEnumerable<Servico> DeleteServicos(IEnumerable<Servico> lstServicos)
        {
            return RelatorioApplicationService.DeleteServico(lstServicos).ToArray();
        }

        #endregion

        #region StatusProjeto

        public IEnumerable<StatusProjeto> GetAllStatusProjeto_COMBOBOX()
        {
            return ProjetoApplicationService.GetAllStatusProjeto_COMBOBOX();
        }

        #endregion

        #region Task

        public Task AddDefaultTask(int idTaskGroup)
        {
            return ProjetoApplicationService.AddTask(new Task
            {
                TaskTitle = "New Task",
                IdTaskGroup = idTaskGroup,
            });
        }

        public Task GetTaskById(int idTask)
        {
            return ProjetoApplicationService.GetTaskById(idTask);
        }

        public Task UpdateTaskName(Task task)
        {
            return ProjetoApplicationService.UpdateTaskName(task);
        }

        public Task DeleteTask(Task task)
        {
            return ProjetoApplicationService.DeleteTask(task);
        }

        #endregion

        #region TaskCell

        public TaskCell UpdateCellValue(TaskCell taskCell, CultureInfo culture)
        {
            return ProjetoApplicationService.UpdateCellValue(taskCell, culture);
        }

        #endregion

        #region TaskColumn

        public TaskColumn AddTaskColumn(TaskColumn taskColumn)
        {
            return ProjetoApplicationService.AddTaskColumn(taskColumn);
        }

        public TaskColumn GetTaskColumnById(int idTaskColumn)
        {
            return ProjetoApplicationService.GetTaskColumnById(idTaskColumn);
        }

        public TaskColumn UpdateTaskColumn(TaskColumn taskColumn)
        {
            return ProjetoApplicationService.UpdateTaskColumn(taskColumn);
        }

        public TaskColumn DeleteTaskColumn(TaskColumn taskColumn)
        {
            return ProjetoApplicationService.DeleteTaskColumn(taskColumn);
        }

        #endregion

        #region TaskGroup

        public TaskGroup AddTaskGroup(TaskGroup taskGroup)
        {
            return ProjetoApplicationService.AddTaskGroup(taskGroup);
        }
        
        public IEnumerable<TaskGroup> GetAllTaskGroup(int idEmpresa)
        {
            return ProjetoApplicationService.GetAllTaskGroup(idEmpresa);
        }

        public IEnumerable<TaskGroup> GetListTaskGroupByIdEmpresa(int idEmpresa)
        {
            return ProjetoApplicationService.GetListTaskGroupByIdEmpresa(idEmpresa);
        }

        #endregion
        
        #region TipoBairro

        public IEnumerable<TipoBairro> GetAllTipoBairro()
        {
            return SistemaApplicationService.GetAllTipoBairro();
        }

        public TipoBairro GetTipoBairroById(int id)
        {
            return SistemaApplicationService.GetTipoBairroById(id);
        }

        #endregion

        #region TipoLogradouro

        public IEnumerable<TipoLogradouro> GetAllTipoLogradouro()
        {
            return SistemaApplicationService.GetAllTipoLogradouro();
        }

        public TipoLogradouro GetTipoLogradouroById(int idTipoLogradouro)
        {
            return SistemaApplicationService.GetTipoLogradouroById(idTipoLogradouro);
        }

        #endregion

        #region TipoRecolhimento

        public TipoRecolhimento GetTipoRecolhimentoById(int idTipoRecolhimento)
        {
            return SistemaApplicationService.GetTipoRecolhimentoById(idTipoRecolhimento);
        }

        public IEnumerable<TipoRecolhimento> GetAllTipoRecolhimento()
        {
            return SistemaApplicationService.GetAllTipoRecolhimento();
        }

        #endregion

        #region Tributacao

        public IEnumerable<Tributacao> GetAllTributacao()
        {
            return SistemaApplicationService.GetAllTributacao();
        }

        #endregion

        #region Unidade

        public IEnumerable<Unidade> GetAllUnidade()
        {
            return SistemaApplicationService.GetAllUnidade();
        }

        public Unidade GetUnidadeById(int idUnidade)
        {
            return SistemaApplicationService.GetUnidadeById(idUnidade);
        }

        #endregion

        #region Utilizacao

        public IEnumerable<Utilizacao> GetAllUtilizacao()
        {
            return SistemaApplicationService.GetAllUtilizacao();
        }

        #endregion

        #region Usuario

        public Usuario Autenticar(string empresa, string login, string senha)
        {
            return SistemaApplicationService.Autenticar(empresa, login, senha);
        }

        public Usuario GetUsuarioById(int idUsuario)
        {
            return SistemaApplicationService.GetUsuarioById(idUsuario);
        }

        public Usuario GetUsuarioByLogin(string login)
        {
            return SistemaApplicationService.GetUsuarioByLogin(login);
        }

        public IEnumerable<Usuario> GetAllUsuario()
        {
            return SistemaApplicationService.GetAllUsuario();
        }

        public IEnumerable<Usuario> GetAllUsuarioByEmpresa(int idEmpresa)
        {
            return SistemaApplicationService.GetAllUsuarioByEmpresa(idEmpresa);
        }

        public Usuario AddUsuario(Usuario usuario)
        {
            return SistemaApplicationService.AddUsuario(usuario);
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            return SistemaApplicationService.UpdateUsuario(usuario);
        }

        public Usuario DeleteUsuario(Usuario usuario)
        {
            return SistemaApplicationService.DeleteUsuario(usuario);
        }

        public Usuario GetUsuarioById_UPDATE(int idUsuario)
        {
            return SistemaApplicationService.GetUsuarioById_UPDATE(idUsuario);
        }

        public Usuario GetAuthenticatedUserByLogin(string login)
        {
            return SistemaApplicationService.GetAuthenticatedUserByLogin(login);
        }

        #endregion
    }
}