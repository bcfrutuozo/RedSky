using System;
using System.Collections.Generic;
using System.Linq;
using RedSky.Application.Interfaces;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.Services;
using RedSky.Domain.Services;
using RedSky.Security;

namespace RedSky.Application
{
    public class SistemaApplicationService : ISistemaApplicationService
    {
        private readonly IAtividadeService _atividadeService;
        private readonly ICertificadoDigitalService _certificadoDigitalService;
        private readonly ICidadeService _cidadeService;
        private readonly IClienteService _clienteService;
        private readonly IColorService _colorService;
        private readonly IConexaoBancoService _conexaoBancoService;
        private readonly IDataTypeService _dataTypeService;
        private readonly IDBProviderService _dbProviderService;
        private readonly IEmpresaService _empresaService;
        private readonly IEstadoService _estadoService;
        private readonly IFilialService _filialService;
        private readonly IIncidenciaService _incidenciaService;
        private readonly IItensServicoService _itensServicoService;
        private readonly IOperacaoService _operacaoService;
        private readonly IPermissaoService _permissaoService;
        private readonly IRegimeTributarioService _regimeTributarioService;
        private readonly ITipoBairroService _tipoBairroService;
        private readonly ITipoLogradouroService _tipoLogradouroService;
        private readonly ITipoRecolhimentoService _tipoRecolhimentoService;
        private readonly ITributacaoService _tributacaoService;
        private readonly IUnidadeService _unidadeService;
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioPermissaoService _usuarioPermissaoService;
        private readonly IUtilizacaoService _utilizacaoService;

        public SistemaApplicationService(
            IAtividadeService atividadeService,
            ICertificadoDigitalService certificadoDigitalService,
            ICidadeService cidadeService,
            IClienteService clienteService,
            IColorService colorService,
            IConexaoBancoService conexaoBancoService,
            IDataTypeService dataTypeService,
            IDBProviderService dbProviderService,
            IEmpresaService empresaService,
            IEstadoService estadoService,
            IFilialService filialService,
            IIncidenciaService incidenciaService,
            IItensServicoService itensServicoService,
            IOperacaoService operacaoService,
            IPermissaoService permissaoService,
            IRegimeTributarioService regimeTributarioService,
            ITipoBairroService tipoBairroService,
            ITipoLogradouroService tipoLogradouroService,
            ITipoRecolhimentoService tipoRecolhimentoService,
            ITributacaoService tributacaoService,
            IUnidadeService unidadeService,
            IUsuarioService usuarioService,
            IUsuarioPermissaoService usuarioPermissaoService,
            IUtilizacaoService utilizacaoService)
        {
            this._atividadeService = atividadeService;
            this._certificadoDigitalService = certificadoDigitalService;
            this._cidadeService = cidadeService;
            this._clienteService = clienteService;
            this._colorService = colorService;
            this._conexaoBancoService = conexaoBancoService;
            this._dataTypeService = dataTypeService;
            this._dbProviderService = dbProviderService;
            this._empresaService = empresaService;
            this._estadoService = estadoService;
            this._filialService = filialService;
            this._incidenciaService = incidenciaService;
            this._itensServicoService = itensServicoService;
            this._operacaoService = operacaoService;
            this._permissaoService = permissaoService;
            this._regimeTributarioService = regimeTributarioService;
            this._tipoBairroService = tipoBairroService;
            this._tipoLogradouroService = tipoLogradouroService;
            this._tipoRecolhimentoService = tipoRecolhimentoService;
            this._tributacaoService = tributacaoService;
            this._unidadeService = unidadeService;
            this._usuarioService = usuarioService;
            this._usuarioPermissaoService = usuarioPermissaoService;
            this._utilizacaoService = utilizacaoService;
        }

        #region Atividade

        public Atividade AddAtividade(Atividade atividade)
        {
            return _atividadeService.Add(atividade).First();
        }

        public Atividade GetAtividadeById(Int32 id)
        {
            return _atividadeService.GetById(id);
        }

        public IEnumerable<Atividade> GetAllAtividade()
        {
            return _atividadeService.GetAll();
        }

        public IEnumerable<Atividade> GetListAtividadeByIdEmpresa(Int32 idEmpresa)
        {
            return _atividadeService.GetListAtividadeByIdEmpresa(idEmpresa);
        }

        public Atividade UpdateAtividade(Atividade atividade)
        {
            return _atividadeService.Update(atividade).First();
        }

        public Atividade DeleteAtividade(Atividade atividade)
        {
            return _atividadeService.Delete(atividade).First();
        }

        #endregion

        #region CertificadoDigital

        public CertificadoDigital AddCertificadoDigital(CertificadoDigital cert)
        {
            return _certificadoDigitalService.Add(cert).First();
        }

        public IEnumerable<CertificadoDigital> AddRangeCertificadoDigital(IEnumerable<CertificadoDigital> cert)
        {
            return _certificadoDigitalService.Add(cert.ToArray());
        }

        public IEnumerable<CertificadoDigital> GetListCertificadoDigitalByIdFilial(Int32 idFilial)
        {
            return _certificadoDigitalService.GetListCertificadoDigitalByIdFilial(idFilial);
        }

        public CertificadoDigital DeleteCertificadoDigital(CertificadoDigital cert)
        {
            return _certificadoDigitalService.Delete(cert).First();
        }

        #endregion

        #region ConexaoBanco

        public ConexaoBanco AddConexaoEmpresa(ConexaoBanco conexaoBanco)
        {
            return _conexaoBancoService.Add(conexaoBanco).First();
        }

        public IEnumerable<ConexaoBanco> GetListConexaoBancoByIdEmpresa(Int32 idEmpresa)
        {
            return _conexaoBancoService.GetListConexaoBancoByIdEmpresa(idEmpresa);
        }

        public ConexaoBanco GetConexaoBancoById(Int32 id)
        {
            return _conexaoBancoService.GetById(id);
        }

        public ConexaoBanco UpdateConexaoBanco(ConexaoBanco conexaoBanco)
        {
            return _conexaoBancoService.Update(conexaoBanco).First();
        }

        public ConexaoBanco DeleteConexaoBanco(ConexaoBanco conexaoBanco)
        {
            return _conexaoBancoService.Delete(conexaoBanco).First();
        }

        public ConexaoBanco GetConexaoBancoByIdEmpresa_Nome(Int32 idEmpresa, String nome)
        {
            return _conexaoBancoService.GetConexaoBancoByIdEmpresa_Nome(idEmpresa, nome);
        }

        #endregion

        #region Cidade

        public IEnumerable<Cidade> GetAllCidade()
        {
            return _cidadeService.GetAll();
        }

        public IEnumerable<Cidade> GetListCidadeByIdEstado(int idEstado)
        {
            return _cidadeService.GetList(cd => cd.IdEstado == idEstado);
        }

        public IEnumerable<Cidade> GetListCidadeSameEstadoByIdCidade(int idCidade)
        {
            return _cidadeService.GetList(c => c.Estado.Cidades.Any(cd => cd.Id == idCidade));
        }

        public Cidade GetCidadeById(int id)
        {
            return _cidadeService.GetById(id);
        }

        #endregion

        #region Cliente

        public Cliente AddCliente(Cliente cliente)
        {
            return _clienteService.Add(cliente).FirstOrDefault();
        }

        public Cliente GetClienteById_CREATEUPDATE(int idCliente)
        {
            return _clienteService.GetClienteById_CREATEUPDATE(idCliente);
        }

        public IEnumerable<Cliente> GetListClienteByIdEmpresa_INDEX(int idEmpresa)
        {
            return _clienteService.GetListClienteByIdEmpresa_INDEX(idEmpresa);
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            return _clienteService.Update(cliente).First();
        }

        public Cliente DeleteCliente(Cliente cliente)
        {
            return _clienteService.Delete(cliente).First();
        }

        public IEnumerable<Cliente> GetListClienteByIdEmpresa_COMBOBOX(int idEmpresa)
        {
            return _clienteService.GetListClienteByIdEmpresa_COMBOBOX(idEmpresa);
        }

        #endregion

        #region Color

        public IEnumerable<Color> GetAllColor()
        {
            return _colorService.GetAll();
        }

        #endregion

        #region DataType

        public IEnumerable<DataType> GetAllDataTypes()
        {
            return _dataTypeService.GetAll();
        }

        #endregion

        #region DBProvider

        public IEnumerable<DBProvider> GetAllDBProvider()
        {
            return _dbProviderService.GetAll();
        }

        public DBProvider GetDBProviderById(int id)
        {
            return _dbProviderService.GetById(id);
        }

        #endregion

        #region Empresa

        public Empresa AddEmpresa(Empresa empresa)
        {
            empresa.HashEmail = Guid.NewGuid().ToString();
            empresa.SenhaEmail = Cryptography.EncryptWithSalt(empresa.SenhaEmail, empresa.HashEmail);
            return _empresaService.Add(empresa).First();
        }

        public Empresa GetEmpresaById(int idEmpresa)
        {
            return _empresaService.GetById(idEmpresa);
        }

        public IEnumerable<Empresa> GetAllEmpresa()
        {
            return _empresaService.GetAll();
        }

        public Empresa GetEmpresaByIdentificacao(string identificacao)
        {
            return _empresaService.GetEmpresaByIdentificacao(identificacao);
        }

        public Empresa GetEmpresaByIdUsuario(int idUsuario)
        {
            return _empresaService.GetEmpresaByIdUsuario(idUsuario);
        }

        public Empresa GetEmpresaByLoginUsuario(string loginUsuario)
        {
            return _empresaService.GetEmpresaByLoginUsuario(loginUsuario);
        }

        public IEnumerable<Empresa> GetListEmpresaForGenericData()
        {
            return _empresaService.GetListEmpresaForGenericData();
        }

        public Empresa UpdateEmpresa(Empresa empresa)
        {
            // Verificar se houve alteração na senha de e-mail.

            var objEmpresa = _empresaService.GetById(empresa.Id);
            if (string.IsNullOrEmpty(empresa.SenhaEmail))
            {
                empresa.SenhaEmail = objEmpresa.SenhaEmail;
                empresa.HashEmail = objEmpresa.HashEmail;
            }
            else
            {
                empresa.HashEmail = Guid.NewGuid().ToString();
                empresa.SenhaEmail = Cryptography.EncryptWithSalt(empresa.SenhaEmail, empresa.HashEmail);
            }

            return _empresaService.Update(empresa).First();
        }

        public Empresa DeleteEmpresa(int idEmpresa)
        {
            return _empresaService.Delete(_empresaService.GetById(idEmpresa)).First();
        }

        #endregion

        #region Estado

        public IEnumerable<Estado> GetAllEstado()
        {
            return _estadoService.GetAll();
        }

        public Estado GetEstadoById(int id)
        {
            return _estadoService.GetById(id);
        }

        #endregion

        #region Filial

        public Filial AddFilial(Filial filial)
        {
            return _filialService.Add(filial).First();
        }
         
        public IEnumerable<Filial> GetAllFilial()
        {
            return _filialService.GetAll();
        }

        public Filial GetFilialById_CREATEEDIT(Int32 idFilial)
        {
            return _filialService.GetById(idFilial);
        }

        public IEnumerable<Filial> GetListFilialByIdEmpresa_INDEX(Int32 idEmpresa)
        {
            return _filialService.GetListFilialByIdEmpresa_INDEX(idEmpresa);
        }

        public Filial GetFilialByIdEmpresa_Nome(Int32 idEmpresa, String nome)
        {
            return _filialService.GetFilialByIdEmpresa_Nome(idEmpresa, nome);
        }

        public Filial UpdateFilial(Filial filial)
        {
            return _filialService.Update(filial).First();
        }

        public Filial DeleteFilial(int idFilial)
        {
            return _filialService.Delete(_filialService.GetById(idFilial)).First();
        }

        public int GetQuantidadeRpsPorLoteByIdFilial(int idFilial)
        {
            return _filialService.GetQuantidadeRpsPorLoteByIdFilial(idFilial);
        }

        #endregion

        #region Incidencia

        public IEnumerable<Incidencia> GetAllIncidencia()
        {
            return _incidenciaService.GetAll();
        }

        #endregion

        #region ItensServicos

        public IEnumerable<ItensServico> GetAllItensServico()
        {
            return this._itensServicoService.GetAll();
        }

        #endregion

        #region Operacao

        public IEnumerable<Operacao> GetAllOperacao()
        {
            return _operacaoService.GetAll();
        }

        #endregion

        #region Permissao

        public Permissao AddPermissao(Permissao permissao)
        {
            return _permissaoService.Add(permissao).FirstOrDefault();
        }

        public Permissao UpdatePermissao(Permissao permissao)
        {
            return _permissaoService.Update(permissao).FirstOrDefault();
        }

        public Permissao DeletePermissao(int idPermissao)
        {
            return _permissaoService.Delete(_permissaoService.GetById(idPermissao)).FirstOrDefault();
        }

        public IEnumerable<Permissao> GetAllPermissao()
        {
            return _permissaoService.GetAll();
        }

        public Permissao GetPermissaoById(Int32 id)
        {
            return _permissaoService.GetById(id);
        }

        public string[] GetAllPermissaoByUsuario(string username)
        {
            return _permissaoService.GetAllPermissaoByUsuario(username).Select(p => p.Nome).ToArray();
        }

        #endregion

        #region RegimeTributario

        public IEnumerable<RegimeTributario> GetAllRegimeTributario()
        {
            return _regimeTributarioService.GetAll();
        }

        #endregion
        
        #region TipoBairro

        public IEnumerable<TipoBairro> GetAllTipoBairro()
        {
            return _tipoBairroService.GetAll();
        }

        public TipoBairro GetTipoBairroById(Int32 id)
        {
            return _tipoBairroService.GetById(id);
        }

        #endregion

        #region TipoLogradouro

        public IEnumerable<TipoLogradouro> GetAllTipoLogradouro()
        {
            return _tipoLogradouroService.GetAll();
        }

        public TipoLogradouro GetTipoLogradouroById(int id)
        {
            return _tipoLogradouroService.GetById(id);
        }

        #endregion

        #region TipoRecolhimento

        public TipoRecolhimento GetTipoRecolhimentoById(int id)
        {
            return _tipoRecolhimentoService.GetById(id);
        }

        public IEnumerable<TipoRecolhimento> GetAllTipoRecolhimento()
        {
            return _tipoRecolhimentoService.GetAll();
        }

        #endregion

        #region Tributacao

        public IEnumerable<Tributacao> GetAllTributacao()
        {
            return _tributacaoService.GetAll();
        }

        #endregion

        #region Unidade

        public IEnumerable<Unidade> GetAllUnidade()
        {
            return _unidadeService.GetAll();
        }

        public Unidade GetUnidadeById(int id)
        {
            return _unidadeService.GetById(id);
        }

        #endregion
        
        #region Usuario

        public IEnumerable<Usuario> GetAllUsuario()
        {
            return _usuarioService.GetAllUsuario_INDEX();
        }

        public Usuario Autenticar(string empresa, string login, string senha)
        {
            // Only password is case sensitive
            var u = _usuarioService.GetAuthentication(string.IsNullOrEmpty(empresa) ? null : empresa.ToLower(), login.ToLower(), senha);

            if (u != null && senha.Equals(Cryptography.DecryptWithSalt(u.Senha, u.Hash)))
                return u;

            return null;
        }

        public Usuario GetUsuarioById(int idUsuario)
        {
            return _usuarioService.GetById(idUsuario);
        }

        public Usuario GetUsuarioByLogin(string login)
        {
            return _usuarioService.GetUsuarioByLogin(login);
        }

        public IEnumerable<Usuario> GetAllUsuarioByEmpresa(int idEmpresa)
        {
            return _usuarioService.GetAllUsuarioByEmpresa(idEmpresa);
        }

        public Usuario AddUsuario(Usuario usuario)
        {
            usuario.Hash = Guid.NewGuid().ToString();
            usuario.Senha = Cryptography.EncryptWithSalt(usuario.Senha, usuario.Hash);
            return this._usuarioService.Add(usuario).First();
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            // Simple Edit
            if (usuario.UsuarioPermissao != null)
            {
                _usuarioPermissaoService.Delete(_usuarioPermissaoService.GetList(up => up.IdUsuario == usuario.Id).ToArray());
            }

            // Atualiza senha
            if (!string.IsNullOrEmpty(usuario.Senha))
            {
                usuario.Hash = Guid.NewGuid().ToString();
                usuario.Senha = Cryptography.EncryptWithSalt(usuario.Senha, usuario.Hash);
            }
            else
            {
                Usuario temp = _usuarioService.GetById(usuario.Id);
                usuario.Hash = temp.Hash;
                usuario.Senha = temp.Senha;
            }

            // Disable eager loagind
            usuario.Empresa = null;

            return this._usuarioService.Update(usuario).First();
        }

        public Usuario DeleteUsuario(Usuario usuario)
        {
            // Apaga todas as permissões do usuário.
            _usuarioPermissaoService.Delete(_usuarioPermissaoService.GetList(up => up.IdUsuario == usuario.Id).ToArray());
            return _usuarioService.Delete(usuario).First();
        }

        public Usuario GetUsuarioById_UPDATE(int idUsuario)
        {
            return _usuarioService.GetUsuarioById_UPDATE(idUsuario);
        }

        public Usuario GetAuthenticatedUserByLogin(string login)
        {
            return _usuarioService.GetAuthenticatedUserByLogin(login);
        }

        #endregion

        #region Utilizacao

        public IEnumerable<Utilizacao> GetAllUtilizacao()
        {
            return _utilizacaoService.GetAll();
        }

        #endregion
    }
}