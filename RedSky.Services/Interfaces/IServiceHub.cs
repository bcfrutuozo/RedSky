using System;
using System.Collections.Generic;
using System.Globalization;
using RedSky.Domain.Entities;

namespace RedSky.Services.Interfaces
{
    public interface IServiceHub
    {
        #region Incidencia

        
        IEnumerable<Incidencia> GetAllIncidencia();

        #endregion

        #region ItensServico

        
        IEnumerable<ItensServico> GetAllItensServico();

        #endregion

        #region Operacao

        
        IEnumerable<Operacao> GetAllOperacao();

        #endregion

        #region RegimeTributario

        
        IEnumerable<RegimeTributario> GetAllRegimeTributario();

        #endregion

        #region TipoRecolhimento

        
        TipoRecolhimento GetTipoRecolhimentoById(int idTipoRecolhimento);

        
        IEnumerable<TipoRecolhimento> GetAllTipoRecolhimento();

        #endregion

        #region Tributacao

        
        IEnumerable<Tributacao> GetAllTributacao();

        #endregion

        #region Utilizacao

        
        IEnumerable<Utilizacao> GetAllUtilizacao();

        #endregion

        #region Atividade

        
        Atividade AddAtividade(Atividade atividade);

        
        Atividade GetAtividadeById(int idAtividade);

        
        IEnumerable<Atividade> GetAllAtividade();

        
        IEnumerable<Atividade> GetListAtividadeByIdEmpresa(int idEmpresa);

        
        Atividade UpdateAtividade(Atividade atividade);

        
        Atividade DeleteAtividade(Atividade atividade);

        #endregion

        #region CertificadoDigital

        
        CertificadoDigital AddCertificadoDigital(CertificadoDigital certificado);

        
        IEnumerable<CertificadoDigital> AddRangeCertificadoDigital(
            IEnumerable<CertificadoDigital> listaCertificado);

        
        IEnumerable<CertificadoDigital> GetListCertificadoDigitalByIdFilial(int idFilial);

        
        CertificadoDigital DeleteCertificadoDigital(CertificadoDigital certificado);

        #endregion

        #region Cidade

        
        IEnumerable<Cidade> GetAllCidade();

        
        IEnumerable<Cidade> GetListCidadeByIdEstado(int idEstado);

        
        IEnumerable<Cidade> GetListCidadeSameEstadoByIdCidade(int idCidade);

        
        Cidade GetCidadeById(int idCidade);

        #endregion

        #region Cliente

        
        Cliente AddCliente(Cliente cliente);

        
        Cliente GetClienteById_CREATEUPDATE(int idCliente);

        
        IEnumerable<Cliente> GetListClienteByIdEmpresa_INDEX(int idEmpresa);

        
        Cliente UpdateCliente(Cliente cliente);

        
        Cliente RemoveCliente(Cliente cliente);

        
        IEnumerable<Cliente> GetListClienteByIdEmpresa_COMBOBOX(int idEmpresa);

        #endregion

        #region Color

        IEnumerable<Color> GetAllColor();

        #endregion

        #region ConexaoBanco

        
        ConexaoBanco AddConexaoEmpresa(ConexaoBanco conexao);

        
        IEnumerable<ConexaoBanco> GetListConexaoBancoByIdEmpresa(int idEmpresa);

        
        ConexaoBanco GetConexaoBancoById(int idConexaoBanco);

        
        ConexaoBanco UpdateConexaoBanco(ConexaoBanco conexao);

        
        ConexaoBanco DeleteConexaoBanco(ConexaoBanco conexao);

        
        ConexaoBanco GetConexaoBancoByIdEmpresa_Nome(int idEmpresa, string nome);

        #endregion

        #region DataType

        IEnumerable<DataType> GetAllDataTypes();

        #endregion

        #region DBProvider

        
        IEnumerable<DBProvider> GetAllDBProvider();

        
        DBProvider GetDBProviderById(int idDBProvider);

        #endregion

        #region Demonstrativo

        
        Demonstrativo AddDemonstrativo(Demonstrativo demonstrativo);

        
        Demonstrativo GetDemonstrativoById_CREATEEDIT(int idDemonstrativo);

        
        IEnumerable<Demonstrativo> GetListDemonstrativoWithServicoByIdEmpresa_INDEX(int idEmpresa);

        
        IEnumerable<Demonstrativo> GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(int idEmpresa);

        
        IEnumerable<Demonstrativo> GetDemonstrativosFaturaveisPorCliente(int idCliente);

        
        Demonstrativo UpdateDemonstrativo(Demonstrativo demonstrativo);

        
        Demonstrativo DeleteDemonstrativo(Demonstrativo demonstrativo);

        
        Demonstrativo CopyDemonstrativo(int idDemonstrativo);

        #endregion

        #region Empresa

        
        Empresa AddEmpresa(Empresa empresa);

        
        Empresa GetEmpresaById(int idEmpresa);

        
        IEnumerable<Empresa> GetAllEmpresa();

        
        Empresa GetEmpresaByIdentificacao(string identificacao);

        
        Empresa GetEmpresaByIdUsuario(int idUsuario);

        
        Empresa GetEmpresaByLoginUsuario(string loginUsuario);

        
        IEnumerable<Empresa> GetListEmpresaForGenericData();

        
        Empresa UpdateEmpresa(Empresa empresa);

        
        Empresa DeleteEmpresa(int idEmpresa);

        #endregion

        #region EMail

        
        void SendBillingEmail(int idFatura);

        
        void SendInvoiceEmail(int idFilial, long numeroNF);

        #endregion

        #region Fatura

        
        Fatura AddFatura(Fatura fatura);

        
        Fatura GetFaturaById_Update(int idFatura);

        
        IEnumerable<Fatura> GetAllFaturaByEmpresa_Mes_Ano(int idEmpresa, int month, int year);

        
        Fatura UpdateFatura(Fatura fatura);

        
        Fatura DeleteFatura(int idFatura);

        
        Fatura DeleteFaturaAndFaturamentos(int idFatura);

        
        Fatura EmitirFatura(int idFatura);

        
        IEnumerable<Fatura> DuplicarCompetencia(int idEmpresa, int monthSource, int yearSource, int monthTarget,
            int yearTarget);

        
        Fatura CancelarRPS(int idRPS);

        
        Fatura ZerarFatura(int idFatura);

        
        string GetFaturaNomeArquivo(int idFatura);

        
        byte[] DownloadFatura(int idFatura);

        #endregion

        #region Faturamento

        
        Faturamento AddFaturamento(Faturamento fatura, bool isUserEdit);

        
        IEnumerable<Faturamento> AddFaturamentos(IEnumerable<Faturamento> faturamentos, bool isUserEdit);

        
        IEnumerable<Faturamento> GetListFaturamentoByIdFatura(int idFatura);

        
        Faturamento UpdateFaturamento(Faturamento fatura, bool isUserEdit);

        
        Faturamento DeleteFaturamento(Faturamento fatura, bool isUserEdit);

        
        IEnumerable<Faturamento> DeleteFaturamentos(IEnumerable<Faturamento> faturamentos, bool isUserEdit);

        #endregion

        #region Filial

        
        Filial AddFilial(Filial filial);

        
        IEnumerable<Filial> GetAllFilial();

        
        Filial GetFilialById_CREATEEDIT(int idFilial);

        
        IEnumerable<Filial> GetListFilialByIdEmpresa_INDEX(int idEmpresa);

        
        Filial GetFilialByIdEmpresa_Nome(int idEmpresa, string nome);

        
        Filial UpdateFilial(Filial filial);

        
        Filial DeleteFilial(int idFilial);

        
        int GetQuantidadeRpsPorLoteByIdFilial(int idFilial);

        #endregion

        #region Estado

        
        IEnumerable<Estado> GetAllEstado();

        
        Estado GetEstadoById(int idEstado);

        #endregion

        #region EXTERNAL_SVC_NFSE

        
        void ConsultarNotas(int idFilial, DateTime inicio, DateTime fim, int notaInicial = 0);

        
        void ConsultarNFS(int idFilial, int numeroLote, int numeroNF, string codigoVerificacao);

        
        void ConsultarRPS(int idFilial, int numeroLote, int numeroRPS);

        
        void CancelarNF(int idFilial, int numeroNF, string codigoVerificacao, string motivo);

        
        void DownloadNFSe(int idFilial, long numeroNF);

        
        string ObterLinkNotaFiscal(int idFilial, int numeroNF);

        #endregion

        #region Label

        Label AddLabel(Label label);

        IEnumerable<Label> GetListLabelByIdEmpresa(int idEmpresa);

        #endregion

        #region LoteRPS

        
        LoteRPS AddLoteRPS(int idFilial);

        
        LoteRPS AddRangeRPSInLoteRPS(int idLoteRPS, IEnumerable<int> lstRPS);

        
        IEnumerable<LoteRPS> GetListLoteRPSByIdFilial(int idFilial, int idStatusLoteRPS);

        
        LoteRPS DeleteRangeRPSFromLoteRPS(IEnumerable<int> lstRPS);

        
        LoteRPS EnviarLoteRPS(int idLoteRPS, bool synchronous);

        
        void DownloadNFSeByIdLoteRPS(int idLoteRPS);

        
        LoteRPS GetLoteRPSById(int idLoteRPS);

        
        LoteRPS DeleteLoteRPS(LoteRPS loteRPS);

        #endregion

        #region Permissao

        
        IEnumerable<Permissao> GetAllPermissao();

        
        Permissao GetPermissaoById(int idPermissao);

        
        Permissao AddPermissao(Permissao permissao);

        
        Permissao UpdatePermissao(Permissao permissao);

        
        Permissao DeletePermissao(int idPermissao);

        
        string[] GetAllPermissaoByUsuario(string username);

        #endregion

        #region Projeto

        
        IEnumerable<Projeto> GetListProjetoByIdEmpresa_INDEX(int idEmpresa);

        
        Projeto GetProjetoById(int id);

        #endregion

        #region RPS

        
        IEnumerable<RPS> GetListRPSWithNoLoteRPSByIdFilial(int idFilial);

        
        RPS Faturar(int idFatura);

        
        RPS GetRPSPorIdFatura(int idFatura);

        
        IEnumerable<RPS> GetListRPSByIdLoteRPS(int idLoteRPS);

        
        long ConsultarUltimoRPS(int idFilial);

        #endregion

        #region Servico

        
        Servico AddServico(Servico servico);

        
        Servico GetServicoById_CREATEEDIT(int idServico);

        
        IEnumerable<Servico> GetListServicoByIdDemonstrativo_INDEX(int idDemonstrativo);

        
        IEnumerable<Servico> GetListServicoByIdFatura(int idFatura);

        
        Servico UpdateServico(Servico servico);

        
        Servico DeleteServico(Servico servico);

        
        IEnumerable<Servico> DeleteServicos(IEnumerable<Servico> lstServicos);

        #endregion

        #region StatusProjeto

        
        IEnumerable<StatusProjeto> GetAllStatusProjeto_COMBOBOX();

        #endregion


        #region Task

        Task AddDefaultTask(int idTaskGroup);

        Task GetTaskById(int idTask);

        Task UpdateTaskName(Task task);

        Task DeleteTask(Task task);



        #endregion

        #region TaskCell

        TaskCell UpdateCellValue(TaskCell taskCell, CultureInfo culture);

        #endregion

        #region TaskColumn

        TaskColumn AddTaskColumn(TaskColumn taskColumn);

        TaskColumn GetTaskColumnById(int idTaskColumn);

        TaskColumn UpdateTaskColumn(TaskColumn taskColumn);

        TaskColumn DeleteTaskColumn(TaskColumn taskColumn);

        #endregion

        #region TaskGroup

        TaskGroup AddTaskGroup(TaskGroup taskGroup);

        IEnumerable<TaskGroup> GetAllTaskGroup(int idEmpresa);

        IEnumerable<TaskGroup> GetListTaskGroupByIdEmpresa(int idEmpresa);

        #endregion 

        #region TipoBairro

        
        IEnumerable<TipoBairro> GetAllTipoBairro();

        
        TipoBairro GetTipoBairroById(int idTipoBairro);

        #endregion

        #region TipoLogradouro

        
        IEnumerable<TipoLogradouro> GetAllTipoLogradouro();

        
        TipoLogradouro GetTipoLogradouroById(int idTipoLogradouro);

        #endregion

        #region Unidade

        
        IEnumerable<Unidade> GetAllUnidade();

        
        Unidade GetUnidadeById(int idUnidade);

        #endregion

        #region Usuario

        
        Usuario Autenticar(string empresa, string login, string senha);

        
        Usuario GetUsuarioById(int idUsuario);

        
        Usuario GetUsuarioByLogin(string login);

        
        IEnumerable<Usuario> GetAllUsuario();

        
        IEnumerable<Usuario> GetAllUsuarioByEmpresa(int idEmpresa);

        
        Usuario AddUsuario(Usuario usuario);

        
        Usuario UpdateUsuario(Usuario usuario);

        
        Usuario DeleteUsuario(Usuario usuario);

        Usuario GetUsuarioById_UPDATE(int idUsuario);

        Usuario GetAuthenticatedUserByLogin(string login);

        #endregion
    }
}