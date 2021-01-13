using System;
using System.Collections.Generic;
using RedSky.Domain.Entities;

namespace RedSky.Application.Interfaces
{
    public interface ISistemaApplicationService
    {
        #region Atividade

        Atividade AddAtividade(Atividade atividade);
        Atividade GetAtividadeById(Int32 id);
        IEnumerable<Atividade> GetAllAtividade();
        IEnumerable<Atividade> GetListAtividadeByIdEmpresa(Int32 idEmpresa);
        Atividade UpdateAtividade(Atividade atividade);
        Atividade DeleteAtividade(Atividade atividade);

        #endregion

        #region CertificadoDigital

        CertificadoDigital AddCertificadoDigital(CertificadoDigital cert);
        IEnumerable<CertificadoDigital> AddRangeCertificadoDigital(IEnumerable<CertificadoDigital> cert);
        IEnumerable<CertificadoDigital> GetListCertificadoDigitalByIdFilial(Int32 idFilial);
        CertificadoDigital DeleteCertificadoDigital(CertificadoDigital cert);

        #endregion

        #region ConexaoBanco

        ConexaoBanco AddConexaoEmpresa(ConexaoBanco conexaoBanco);
        IEnumerable<ConexaoBanco> GetListConexaoBancoByIdEmpresa(Int32 idEmpresa);
        ConexaoBanco GetConexaoBancoById(Int32 id);
        ConexaoBanco UpdateConexaoBanco(ConexaoBanco conexaoBanco);
        ConexaoBanco DeleteConexaoBanco(ConexaoBanco conexaoBanco);
        ConexaoBanco GetConexaoBancoByIdEmpresa_Nome(Int32 idEmpresa, String nome);

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

        Cliente DeleteCliente(Cliente cliente);

        IEnumerable<Cliente> GetListClienteByIdEmpresa_COMBOBOX(int idEmpresa);

        #endregion

        #region Color

        IEnumerable<Color> GetAllColor();

        #endregion

        #region DataType

        IEnumerable<DataType> GetAllDataTypes();

        #endregion

        #region DBProvider

        IEnumerable<DBProvider> GetAllDBProvider();
        DBProvider GetDBProviderById(int id);

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

        #region Estado

        IEnumerable<Estado> GetAllEstado();
        Estado GetEstadoById(int id);

        #endregion

        #region Filial

        Filial AddFilial(Filial filial);

        IEnumerable<Filial> GetAllFilial();

        Filial GetFilialById_CREATEEDIT(Int32 idFilial);

        IEnumerable<Filial> GetListFilialByIdEmpresa_INDEX(Int32 idEmpresa);

        Filial GetFilialByIdEmpresa_Nome(Int32 idEmpresa, String nome);

        Filial UpdateFilial(Filial filial);

        Filial DeleteFilial(int idFilial);

        int GetQuantidadeRpsPorLoteByIdFilial(int idFilial);

        #endregion
        
        #region Incidencia

        IEnumerable<Incidencia> GetAllIncidencia();

        #endregion

        #region ItensServico

        IEnumerable<ItensServico> GetAllItensServico();

        #endregion

        #region Operacao

        IEnumerable<Operacao> GetAllOperacao();

        #endregion

        #region Permissao

        Permissao AddPermissao(Permissao permissao);

        Permissao UpdatePermissao(Permissao permissao);

        Permissao DeletePermissao(int idPermissao);

        IEnumerable<Permissao> GetAllPermissao();

        Permissao GetPermissaoById(Int32 id);

        string[] GetAllPermissaoByUsuario(string username);

        #endregion

        #region RegimeTributario

        IEnumerable<RegimeTributario> GetAllRegimeTributario();

        #endregion

        #region TipoBairro

        IEnumerable<TipoBairro> GetAllTipoBairro();
        TipoBairro GetTipoBairroById(Int32 id);

        #endregion

        #region TipoLogradouro

        IEnumerable<TipoLogradouro> GetAllTipoLogradouro();

        TipoLogradouro GetTipoLogradouroById(int id);

        #endregion

        #region TipoRecolhimento

        TipoRecolhimento  GetTipoRecolhimentoById(int idTipoRecolhimento);

        IEnumerable<TipoRecolhimento> GetAllTipoRecolhimento();

        #endregion

        #region Tributacao

        IEnumerable<Tributacao> GetAllTributacao();

        #endregion

        #region Unidade

        IEnumerable<Unidade> GetAllUnidade();

        Unidade GetUnidadeById(int id);

        #endregion

        #region Usuario

        IEnumerable<Usuario> GetAllUsuario();

        Usuario Autenticar(string empresa, string login, string senha);

        Usuario GetUsuarioById(int idUsuario);

        Usuario GetUsuarioByLogin(string login);

        IEnumerable<Usuario> GetAllUsuarioByEmpresa(int idEmpresa);

        Usuario AddUsuario(Usuario usuario);

        Usuario UpdateUsuario(Usuario usuario);

        Usuario DeleteUsuario(Usuario usuario);

        Usuario GetUsuarioById_UPDATE(int idUsuario);

        Usuario GetAuthenticatedUserByLogin(string login);

        #endregion

        #region Utilizacao

        IEnumerable<Utilizacao> GetAllUtilizacao();

        #endregion
    }
}
