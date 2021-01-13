using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using AutoMapper;
using RedSky.Presentation.Client.Mapping;
using RedSky.Presentation.Client.ServiceHub;
using RedSky.Presentation.Client.ViewModels;

namespace RedSky.Presentation.Client
{
    public class ClientHub
    {
        static ClientHub()
        {
            if (!AutoMapperBootstrap.IsInitialized)
                AutoMapperBootstrap.InitializeMap();

            const string UserName = @"bcfrutuozo@hotmail.com";
            const string Password = @"azxgEQEam$Z9Gp@6";

            string certificate = Environment.MachineName.Equals("NTBBcfrutuozo", StringComparison.CurrentCultureIgnoreCase)
                ? "AwAAAAEAAAAUAAAAlF7SFOHym1t4OppU+PilhOdzi2EgAAAAAQAAAPACAAAwggLsMIIB1KADAgECAhBvqh/Ppor1uUML2Ls+96LVMA0GCSqGSIb3DQEBCwUAMBQxEjAQBgNVBAMTCWxvY2FsaG9zdDAeFw0xOTA2MDkxMzAwNDNaFw0yNDA2MDkwMDAwMDBaMBQxEjAQBgNVBAMTCWxvY2FsaG9zdDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALAlkWs57+nLwbObvImvKZSNhStmD8ACbMnnq5gi4/MohuXrvv2b7l9DDLS6Q9YJCnLBA7MacRakiwjjG6bK6KBz2Ksb2yqa/mi0+yolJAEOZNEQ5oYEcEbKcv1Nq/ATm6pqN2a6sRGxxM0ryHA1xjiNYATZ5gSJlHbfKoKfDeRzO1as/Qpt+kmH/QihWkusfVkXl/0GXSNZfTpzLkuvjjiGVoBqUn4dol3mmBxmFTau/hcirWhVNq4moHNAzYJS2Uu3UdSWDGe/da1sO+DyevzSORJ+1OajSFVrOISNdXQBhQXfWE27k7VpjszgGB0u2E4qX2T7HAtp+Jd88HaKqdUCAwEAAaM6MDgwCwYDVR0PBAQDAgSwMBMGA1UdJQQMMAoGCCsGAQUFBwMBMBQGA1UdEQQNMAuCCWxvY2FsaG9zdDANBgkqhkiG9w0BAQsFAAOCAQEATzBuRSUPYUc0m+haMfXxv3K71AVM/vyd8sRHp3lPMPw/3oUvqcLSQClU/jlAm+X65YehGXa615xWuyf0hlmGalp5GcgQA7C2hx/i9V2633brdFpp3TjvkFRArU7DNSDWrzMd19UtupD8w4X/mBqz5qQ9sYuIn9bbPlsqoKfaV3WCnFlcBXKLvqENObFRdV/L00cpxXFku1sihkgOuYzeeFJ8r9iGnhLM46TAxZf9BoJKC3drSP5ZzSUaNXTL+RbEOOAspjUMtph24CJ5/BqsP4m/Qa0DVieTMTSYXCTo2WpSKap1uZT24nIdLjeSJCAC6lVaoYK1t+xXHuMea9GqRQ=="
                : "AwAAAAEAAAAUAAAAOgWXPi08zTsP8+wtlrZWF3TXcEsgAAAAAQAAAPACAAAwggLsMIIB1KADAgECAhBXvTwFGRf/vEDrpNVx5TkmMA0GCSqGSIb3DQEBCwUAMBQxEjAQBgNVBAMTCWxvY2FsaG9zdDAeFw0xOTA2MTAxNjM2MjlaFw0yNDA2MTAwMDAwMDBaMBQxEjAQBgNVBAMTCWxvY2FsaG9zdDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAJvl3EE5FO5c8RzlhOazKgCVcotXzU1iQK1guTu1F3I0vHjq6saWeV6hW/yQSm8h3LyaNZ5q60Dc4eoSkXeK8V/F5KHxhf1s03d72mFuXGODydpHDCaPzbc/a3dCAWFPiVGSctLfyaEC8N1MKkF7z5wv9rnZXMBVjJWzYF4THfCGeorFYe35vbRCAC1QukzsUdS05RUowyP8iK2/wEZsEUO/ZtfnRS/t499nO3PB7Cq2g7mVu0NfRq0rqOm7VCnpJs6nX3g+XXWVCMRqTe2tq3tg3fJ+uGOEeegr17VkR5h6xW1nLlDgNsI7T2062yQez7fQTv+CfHvhlQq0KFQNWVUCAwEAAaM6MDgwCwYDVR0PBAQDAgSwMBMGA1UdJQQMMAoGCCsGAQUFBwMBMBQGA1UdEQQNMAuCCWxvY2FsaG9zdDANBgkqhkiG9w0BAQsFAAOCAQEAIbOIJ5l7S8z9FB3iHGi3NsKe6CRBQcjk4/nflGiofrmvkoCOSWuqK2Ite+tmupOUeI+2ykvKnjTnJt1jb+QKLpM/vn+XjHXRZ0+VRc91gS9QjXSihqr9PQCb1RJwxPb76SD1auc6BMLsT8CXLJXplrGxuYv9GlvqsgH2kVWucswMkr3H4uTRFb1He+//pc6DwRI44bnSzbi1D7j/aMQG+MXSmly49Pby0xPHHzWtJ/426eZ03iZAU0b7RMkIYu7Cs2+i8msocDUr5trNnUPJyeaUVWm6sMPSVADj3fPMO1bTfCHxyvnia4+PpXrgWGEWmDjcxI8dMoItng6+6hzgag==";

            var certData = new X509Certificate(Encoding.ASCII.GetBytes(certificate));

            ServiceHub = new ServiceHubClient("WSDualHttpBinding_IServiceHub",
                new EndpointAddress(new Uri("http://localhost:8733/Design_Time_Addresses/"),
                    EndpointIdentity.CreateX509CertificateIdentity(new X509Certificate2(certData))));

            ServiceHub.ClientCredentials.UserName.UserName = UserName;
            ServiceHub.ClientCredentials.UserName.Password = Password;

#if DEBUG
            ServiceHub.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                X509CertificateValidationMode.None;
#endif
        }

        private static ServiceHubClient ServiceHub { get; }

        public static Usuario Autenticar(string empresa, string login, string senha)
        {
            return Mapper.Map<Usuario>(ServiceHub.Autenticar(empresa, login, senha));
        }

        public static Usuario GetUsuarioById(int idUsuario)
        {
            return Mapper.Map<Usuario>(ServiceHub.GetUsuarioById(idUsuario));
        }

        public static Empresa GetEmpresaByIdUsuario(int idUsuario)
        {
            return Mapper.Map<Empresa>(ServiceHub.GetEmpresaByIdUsuario(idUsuario));
        }

        public static IEnumerable<Permissao> GetAllPermissao()
        {
            return Mapper.Map<IEnumerable<Permissao>>(ServiceHub.GetAllPermissao());
        }

        public static Empresa GetEmpresaByLoginUsuario(string login)
        {
            return Mapper.Map<Empresa>(ServiceHub.GetEmpresaByLoginUsuario(login));
        }

        public static IEnumerable<TipoBairro> GetAllTipoBairro()
        {
            return Mapper.Map<IEnumerable<TipoBairro>>(ServiceHub.GetAllTipoBairro());
        }

        public static IEnumerable<TipoLogradouro> GetAllTipoLogradouro()
        {
            return Mapper.Map<IEnumerable<TipoLogradouro>>(ServiceHub.GetAllTipoLogradouro());
        }

        public static IEnumerable<Cidade> GetAllCidade()
        {
            return Mapper.Map<IEnumerable<Cidade>>(ServiceHub.GetAllCidade());
        }

        public static IEnumerable<Estado> GetAllEstado()
        {
            return Mapper.Map<IEnumerable<Estado>>(ServiceHub.GetAllEstado());
        }

        public static IEnumerable<RegimeTributario> GetAllRegimeTributario()
        {
            return Mapper.Map<IEnumerable<RegimeTributario>>(ServiceHub.GetAllRegimeTributario());
        }

        public static IEnumerable<DBProvider> GetDBProviders()
        {
            return Mapper.Map<IEnumerable<DBProvider>>(ServiceHub.GetAllDBProvider());
        }

        public static IEnumerable<Unidade> GetAllUnidade()
        {
            return Mapper.Map<IEnumerable<Unidade>>(ServiceHub.GetAllUnidade());
        }

        public static IEnumerable<Incidencia> GetAllIncidencia()
        {
            return Mapper.Map<IEnumerable<Incidencia>>(ServiceHub.GetAllIncidencia());
        }

        public static IEnumerable<Operacao> GetAllOperacao()
        {
            return Mapper.Map<IEnumerable<Operacao>>(ServiceHub.GetAllOperacao());
        }

        public static IEnumerable<Tributacao> GetAllTributacao()
        {
            return Mapper.Map<IEnumerable<Tributacao>>(ServiceHub.GetAllTributacao());
        }

        public static IEnumerable<ItensServico> GetAllItensServico()
        {
            return Mapper.Map<IEnumerable<ItensServico>>(ServiceHub.GetAllItensServico());
        }

        public static IEnumerable<Utilizacao> GetAllUtilizacao()
        {
            return Mapper.Map<IEnumerable<Utilizacao>>(ServiceHub.GetAllUtilizacao());
        }

        public static IEnumerable<Atividade> GetAllAtividade()
        {
            return Mapper.Map<IEnumerable<Atividade>>(ServiceHub.GetAllAtividade());
        }

        public static IEnumerable<Atividade> GetListAtividadeByIdEmpresa(int idEmpresa)
        {
            return Mapper.Map<IEnumerable<Atividade>>(ServiceHub.GetListAtividadeByIdEmpresa(idEmpresa));
        }

        public static IEnumerable<ConexaoBanco> GetListConexaoBancoByIdEmpresa(int idEmpresa)
        {
            return Mapper.Map<IEnumerable<ConexaoBanco>>(ServiceHub.GetListConexaoBancoByIdEmpresa(idEmpresa));
        }

        public static IEnumerable<Demonstrativo> GetListDemonstrativoWithServicoByIdEmpresa_INDEX(int idEmpresa)
        {
            return Mapper.Map<IEnumerable<Demonstrativo>>(ServiceHub.GetListDemonstrativoWithServicoByIdEmpresa_INDEX(idEmpresa));
        }

        public static IEnumerable<Demonstrativo> GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(int idEmpresa)
        {
            return Mapper.Map<IEnumerable<Demonstrativo>>(ServiceHub.GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(idEmpresa));
        }

        public static Demonstrativo CopyDemonstrativo(int idDemonstrativo)
        {
            return Mapper.Map<Demonstrativo>(ServiceHub.CopyDemonstrativo(idDemonstrativo));
        }

        public static Demonstrativo DeleteDemonstrativo(Demonstrativo demonstrativo)
        {
            return Mapper.Map<Demonstrativo>(ServiceHub.DeleteDemonstrativo(Mapper.Map<DemonstrativoDTO>(demonstrativo)));
        }

        public static Cliente GetClienteById_CREATEUPDATE(int idCliente)
        {
            return Mapper.Map<Cliente>(ServiceHub.GetClienteById_CREATEUPDATE(idCliente));
        }

        public static Cidade GetCidadeById(int idCidade)
        {
            return Mapper.Map<Cidade>(ServiceHub.GetCidadeById(idCidade));
        }

        public static Unidade GetUnidadeById(int idUnidade)
        {
            return Mapper.Map<Unidade>(ServiceHub.GetUnidadeById(idUnidade));
        }

        public static Estado GetEstadoById(int idEstado)
        {
            return Mapper.Map<Estado>(ServiceHub.GetEstadoById(idEstado));
        }

        public static TipoLogradouro GetTipoLogradouroById(int idTipoLogradouro)
        {
            return Mapper.Map<TipoLogradouro>(ServiceHub.GetTipoLogradouroById(idTipoLogradouro));
        }

        public static TipoBairro GetTipoBairroById(int idTipoBairro)
        {
            return Mapper.Map<TipoBairro>(ServiceHub.GetTipoBairroById(idTipoBairro));
        }

        public static DBProvider GetDBProviderById(int idDBProvider)
        {
            return Mapper.Map<DBProvider>(ServiceHub.GetDBProviderById(idDBProvider));
        }

        public static ConexaoBanco GetConexaoBancoById(int idConexaoBanco)
        {
            return Mapper.Map<ConexaoBanco>(ServiceHub.GetConexaoBancoById(idConexaoBanco));
        }

        public static ConexaoBanco AddConexaoEmpresa(ConexaoBanco conexao)
        {
            return Mapper.Map<ConexaoBanco>(ServiceHub.AddConexaoEmpresa(Mapper.Map<ConexaoBancoDTO>(conexao)));
        }

        public static ConexaoBanco UpdateConexaoBanco(ConexaoBanco conexao)
        {
            return Mapper.Map<ConexaoBanco>(ServiceHub.UpdateConexaoBanco(Mapper.Map<ConexaoBancoDTO>(conexao)));
        }

        public static ConexaoBanco DeleteConexaoBanco(ConexaoBanco conexao)
        {
            return Mapper.Map<ConexaoBanco>(ServiceHub.DeleteConexaoBanco(Mapper.Map<ConexaoBancoDTO>(conexao)));
        }

        public static IEnumerable<Cliente> GetListClienteByIdEmpresa_INDEX(int idEmpresa)
        {
            return Mapper.Map<IEnumerable<Cliente>>(ServiceHub.GetListClienteByIdEmpresa_INDEX(idEmpresa));
        }

        public static Cliente RemoveCliente(Cliente cliente)
        {
            return Mapper.Map<Cliente>(ServiceHub.RemoveCliente(Mapper.Map<ClienteDTO>(cliente)));
        }

        public static Cliente AddCliente(Cliente cliente)
        {
            return Mapper.Map<Cliente>(ServiceHub.AddCliente(Mapper.Map<ClienteDTO>(cliente)));
        }

        public static Cliente UpdateCliente(Cliente cliente)
        {
            return Mapper.Map<Cliente>(ServiceHub.UpdateCliente(Mapper.Map<ClienteDTO>(cliente)));
        }

        public static IEnumerable<Cidade> GetListCidadeByIdEstado(int idEstado)
        {
            return Mapper.Map<IEnumerable<Cidade>>(ServiceHub.GetListCidadeByIdEstado(idEstado));
        }

        public static IEnumerable<FaturaDisplayViewModel> GetFaturasPeriodo(int idEmpresa, int competenciaMonth,
            int competenciaYear)
        {
            return Mapper.Map<IEnumerable<FaturaDisplayViewModel>>(ServiceHub.GetAllFaturaByEmpresa_Mes_Ano(idEmpresa, competenciaMonth, competenciaYear)).Where(f => !f.IsCancelada);
        }

        public static Demonstrativo GetDemonstrativoById_CREATEEDIT(int idDemonstrativo)
        {
            return Mapper.Map<Demonstrativo>(ServiceHub.GetDemonstrativoById_CREATEEDIT(idDemonstrativo));
        }

        public static long ConsultarUltimoRPS(int idFilial)
        {
            return ServiceHub.ConsultarUltimoRPS(idFilial);
        }

        public static RPS GetRPSPorIdFatura(int idFatura)
        {
            return Mapper.Map<RPS>(ServiceHub.GetRPSPorIdFatura(idFatura));
        }

        public static IEnumerable<Faturamento> RemoveFaturamentos(IEnumerable<Faturamento> faturamentos, bool isUserEdit)
        {
            return Mapper.Map<IEnumerable<Faturamento>>(ServiceHub.DeleteFaturamentos(Mapper.Map<FaturamentoDTO[]>(faturamentos), isUserEdit));
        }

        public static FaturaViewModel RemoveFatura(FaturaViewModel fatura)
        {
            return Mapper.Map<FaturaViewModel>(ServiceHub.DeleteFatura(Mapper.Map<FaturaDTO>(fatura)));
        }

        public static FaturaViewModel UpdateFatura(FaturaViewModel fatura)
        {
            return Mapper.Map<FaturaViewModel>(ServiceHub.UpdateFatura(Mapper.Map<FaturaDTO>(fatura)));
        }

        public static IEnumerable<FaturaViewModel> DuplicarCompetencia(int idEmpresa, int competenciaAnteirorMonth,
            int competenciaAnteirorYear, int competenciaMonth, int competenciaYear)
        {
            return Mapper.Map<IEnumerable<FaturaViewModel>>(ServiceHub.DuplicarCompetencia(idEmpresa,
                competenciaAnteirorMonth, competenciaAnteirorYear, competenciaMonth, competenciaYear));
        }

        public static FaturaViewModel EmitirFatura(int idFatura)
        {
            return Mapper.Map<FaturaViewModel>(ServiceHub.EmitirFatura(idFatura));
        }

        public static IEnumerable<Filial> GetListFilialByIdEmpresa_INDEX(int idEmpresa)
        {
            return Mapper.Map<IEnumerable<Filial>>(ServiceHub.GetListFilialByIdEmpresa_INDEX(idEmpresa));
        }

        public static LoteRPS AddLoteRPS(int idFilial)
        {
            return Mapper.Map<LoteRPS>(ServiceHub.AddLoteRPS(idFilial));
        }

        public static LoteRPS EnviarLoteRPSSincrono(int idLoteRPS)
        {
            return Mapper.Map<LoteRPS>(ServiceHub.EnviarLoteRPS(idLoteRPS, true));
        }

        public static LoteRPS EnviarLoteRPSAssincrono(int idLoteRPS)
        {
            return Mapper.Map<LoteRPS>(ServiceHub.EnviarLoteRPS(idLoteRPS, false));
        }

        public static IEnumerable<LoteRPS> GetListLoteRPSByIdFilial(int idFilial)
        {
            return Mapper.Map<IEnumerable<LoteRPS>>(ServiceHub.GetListLoteRPSByIdFilial(idFilial, 0));
        }

        public static IEnumerable<LoteRPS> GetAllLotesRPSPorStatus(int idFilial, int idStatusLoteRPS)
        {
            return Mapper.Map<IEnumerable<LoteRPS>>(ServiceHub.GetListLoteRPSByIdFilial(idFilial, idStatusLoteRPS));
        }

        public static void SendInvoiceEmail(int idFilial, long notaFiscalNumero)
        {
            ServiceHub.SendInvoiceEmail(idFilial, notaFiscalNumero);
        }

        public static void SendBillingEmail(int idFatura)
        {
            ServiceHub.SendBillingEmail(idFatura);
        }

        public static IEnumerable<Servico> GetListServicoByIdDemonstrativo_INDEX(int idDemonstrativo)
        {
            return Mapper.Map<IEnumerable<Servico>>(ServiceHub.GetListServicoByIdDemonstrativo_INDEX(idDemonstrativo));
        }

        public static Demonstrativo AddDemonstrativo(Demonstrativo demonstrativo)
        {
            return Mapper.Map<Demonstrativo>(ServiceHub.AddDemonstrativo(Mapper.Map<DemonstrativoDTO>(demonstrativo)));
        }

        public static IEnumerable<Servico> DeleteServico(Servico[] servicos)
        {
            return Mapper.Map<IEnumerable<Servico>>(ServiceHub.DeleteServicos(Mapper.Map<ServicoDTO[]>(servicos)));
        }

        public static Demonstrativo UpdateDemonstrativo(Demonstrativo demonstrativo)
        {
            return Mapper.Map<Demonstrativo>(
                ServiceHub.UpdateDemonstrativo(Mapper.Map<DemonstrativoDTO>(demonstrativo)));
        }

        public static IEnumerable<Demonstrativo> GetDemonstrativosFaturaveisPorCliente(int idCliente)
        {
            return Mapper.Map<IEnumerable<Demonstrativo>>(ServiceHub.GetDemonstrativosFaturaveisPorCliente(idCliente));
        }

        public static FaturaViewModel AddFatura(FaturaViewModel fatura)
        {
            return Mapper.Map<FaturaViewModel>(ServiceHub.AddFatura(Mapper.Map<FaturaDTO>(fatura)));
        }

        public static RPS Faturar(int idFatura)
        {
            return Mapper.Map<RPS>(ServiceHub.Faturar(idFatura));
        }

        public static IEnumerable<RPS> GetListRPSWithNoLoteRPSByIdFilial(int idFilial)
        {
            return Mapper.Map<IEnumerable<RPS>>(ServiceHub.GetListRPSWithNoLoteRPSByIdFilial(idFilial));
        }

        public static LoteRPS AddListaRPSInLoteRPS(int idLoteRPS, IEnumerable<int> lstRps)
        {
            return Mapper.Map<LoteRPS>(ServiceHub.AddRangeRPSInLoteRPS(idLoteRPS, lstRps.ToArray()));
        }

        public static void DownloadNFSe(int idFilial, int numeroNF)
        {
            ServiceHub.DownloadNFSe(idFilial, numeroNF);
        }

        public static Servico DeleteServico(Servico servico)
        {
            return Mapper.Map<Servico>(ServiceHub.DeleteServico(Mapper.Map<ServicoDTO>(servico)));
        }

        public static Servico GetServicoById_CREATEEDIT(int idServico)
        {
            return Mapper.Map<Servico>(ServiceHub.GetServicoById_CREATEEDIT(idServico));
        }

        public static Servico AddServico(Servico servico)
        {
            return Mapper.Map<Servico>(ServiceHub.AddServico(Mapper.Map<ServicoDTO>(servico)));
        }

        public static Servico UpdateServico(Servico servico)
        {
            return Mapper.Map<Servico>(ServiceHub.UpdateServico(Mapper.Map<ServicoDTO>(servico)));
        }

        public static byte[] DownloadFatura(int idFatura)
        {
            return ServiceHub.DownloadFatura(idFatura);
        }

        public static FaturaViewModel GetFaturaById(int idFatura)
        {
            return Mapper.Map<FaturaViewModel>(ServiceHub.GetFaturaById_Update(idFatura));
        }

        public static Filial GetFilialById_CREATEEDIT(int id)
        {
            return Mapper.Map<Filial>(ServiceHub.GetFilialById_CREATEEDIT(id));
        }

        public static Filial AddFilial(Filial filial)
        {
            return Mapper.Map<Filial>(ServiceHub.AddFilial(Mapper.Map<FilialDTO>(filial)));
        }

        public static Filial UpdateFilial(Filial filial)
        {
            return Mapper.Map<Filial>(ServiceHub.UpdateFilial(Mapper.Map<FilialDTO>(filial)));
        }

        public static Filial DeleteFilial(Filial filial)
        {
            return Mapper.Map<Filial>(ServiceHub.DeleteFilial(Mapper.Map<FilialDTO>(filial)));
        }

        public static IEnumerable<TipoRecolhimento> GetAllTipoRecolhimento()
        {
            return Mapper.Map<IEnumerable<TipoRecolhimento>>(ServiceHub.GetAllTipoRecolhimento());
        }

        public static Usuario GetUsuarioByLogin(string username)
        {
            return Mapper.Map<Usuario>(ServiceHub.GetUsuarioByLogin(username));
        }

        public static IEnumerable<Usuario> GetAllUsuario()
        {
            return Mapper.Map<IEnumerable<Usuario>>(ServiceHub.GetAllUsuario());
        }

        public static IEnumerable<Usuario> GetAllUsuarioByEmpresa(int idEmpresa)
        {
            return Mapper.Map<IEnumerable<Usuario>>(ServiceHub.GetAllUsuarioByEmpresa(idEmpresa));
        }

        public static Usuario AddUsuario(Usuario usuario)
        {
            return Mapper.Map<Usuario>(ServiceHub.AddUsuario(Mapper.Map<UsuarioDTO>(usuario)));
        }

        public static Usuario UpdateUsuario(Usuario usuario)
        {
            return Mapper.Map<Usuario>(ServiceHub.UpdateUsuario(Mapper.Map<UsuarioDTO>(usuario)));
        }

        public static Usuario DeleteUsuario(Usuario usuario)
        {
            return Mapper.Map<Usuario>(ServiceHub.DeleteUsuario(Mapper.Map<UsuarioDTO>(usuario)));
        }

        public static Usuario DeleteUsuario(int id)
        {
            return DeleteUsuario(GetUsuarioById(id));
        }

        public static IEnumerable<Empresa> GetListEmpresaForGenericData()
        {
            return Mapper.Map<IEnumerable<Empresa>>(ServiceHub.GetListEmpresaForGenericData());
        }

        public static Permissao AddPermissao(Permissao permissao)
        {
            return Mapper.Map<Permissao>(ServiceHub.AddPermissao(Mapper.Map<PermissaoDTO>(permissao)));
        }

        public static Permissao GetPermissaoById(int id)
        {
            return Mapper.Map<Permissao>(ServiceHub.GetPermissaoById(id));
        }

        public static Permissao UpdatePermissao(Permissao permissao)
        {
            return Mapper.Map<Permissao>(ServiceHub.UpdatePermissao(Mapper.Map<PermissaoDTO>(permissao)));
        }

        public static Permissao DeletePermissao(Permissao permissao)
        {
            return Mapper.Map<Permissao>(ServiceHub.DeletePermissao(Mapper.Map<PermissaoDTO>(permissao)));
        }

        public static IEnumerable<Empresa> GetEmpresas()
        {
            return Mapper.Map<IEnumerable<Empresa>>(ServiceHub.GetAllEmpresa());
        }

        public static Empresa AddEmpresa(Empresa empresa)
        {
            return Mapper.Map<Empresa>(ServiceHub.AddEmpresa(Mapper.Map<EmpresaDTO>(empresa)));
        }

        public static Empresa GetEmpresaPorId(int id)
        {
            return Mapper.Map<Empresa>(ServiceHub.GetEmpresaById(id));
        }

        public static Empresa UpdateEmpresa(Empresa empresa)
        {
            return Mapper.Map<Empresa>(ServiceHub.UpdateEmpresa(Mapper.Map<EmpresaDTO>(empresa)));
        }

        public static Empresa DeleteEmpresa(int id)
        {
            return DeleteEmpresa(GetEmpresaPorId(id));
        }

        public static Empresa DeleteEmpresa(Empresa empresa)
        {
            return Mapper.Map<Empresa>(ServiceHub.DeleteEmpresa(Mapper.Map<EmpresaDTO>(empresa)));
        }

        public static IEnumerable<Faturamento> GetFaturamentosPorFatura(int idFatura)
        {
            return Mapper.Map<IEnumerable<Faturamento>>(ServiceHub.GetListFaturamentoByIdFatura(idFatura));
        }

        public static Faturamento UpdateFaturamento(Faturamento faturamento, bool isUserEdit)
        {
            return Mapper.Map<Faturamento>(ServiceHub.UpdateFaturamento(Mapper.Map<FaturamentoDTO>(faturamento), isUserEdit));
        }

        public static Faturamento RemoveFaturamento(Faturamento faturamento, bool isUserEdit)
        {
            return Mapper.Map<Faturamento>(ServiceHub.DeleteFaturamento(Mapper.Map<FaturamentoDTO>(faturamento), isUserEdit));
        }

        public static Faturamento AddFaturamento(Faturamento faturamento, bool isUserEdit)
        {
            return Mapper.Map<Faturamento>(ServiceHub.AddFaturamento(Mapper.Map<FaturamentoDTO>(faturamento), isUserEdit));
        }

        public static Atividade AddAtividade(Atividade atividade)
        {
            return Mapper.Map<Atividade>(ServiceHub.AddAtividade(Mapper.Map<AtividadeDTO>(atividade)));
        }

        public static Atividade GetAtividadeById(int idAtividade)
        {
            return Mapper.Map<Atividade>(ServiceHub.GetAtividadeById(idAtividade));
        }

        public static Atividade UpdateAtividade(Atividade atividade)
        {
            return Mapper.Map<Atividade>(ServiceHub.UpdateAtividade(Mapper.Map<AtividadeDTO>(atividade)));
        }

        public static Atividade DeleteAtividade(Atividade atividade)
        {
            return Mapper.Map<Atividade>(ServiceHub.DeleteAtividade(Mapper.Map<AtividadeDTO>(atividade)));
        }

        public static IEnumerable<CertificadoDigital> GetCertificadosPorFilial(int id)
        {
            return Mapper.Map<IEnumerable<CertificadoDigital>>(ServiceHub.GetListCertificadoDigitalByIdFilial(id));
        }

        public static void DownloadNFSeByIdLoteRPS(int idLoteRPS)
        {
            ServiceHub.DownloadNFSeByIdLoteRPS(idLoteRPS);
        }

        public static string GetFaturaNomeArquivo(int idFatura)
        {
            return ServiceHub.GetFaturaNomeArquivo(idFatura);
        }

        public static IEnumerable<RPS> GetListRPSByIdLoteRPS(int idLoteRPS)
        {
            return Mapper.Map<IEnumerable<RPS>>(ServiceHub.GetListRPSByIdLoteRPS(idLoteRPS));
        }

        public static LoteRPS RemoveRPSFromLote(IEnumerable<int> lstRps)
        {
            return Mapper.Map<LoteRPS>(ServiceHub.DeleteRangeRPSFromLoteRPS(lstRps.ToArray()));
        }

        public static IEnumerable<Servico> GetListServicoByIdFatura(int idFatura)
        {
            return Mapper.Map<IEnumerable<Servico>>(ServiceHub.GetListServicoByIdFatura(idFatura));
        }

        public static FaturaViewModel ZerarFatura(int idFatura)
        {
            return Mapper.Map<FaturaViewModel>(ServiceHub.ZerarFatura(idFatura));
        }

        public static IEnumerable<Faturamento> AddFaturamentos(List<Faturamento> lstData, bool isUserEdit)
        {
            return Mapper.Map<IEnumerable<Faturamento>>(ServiceHub.AddFaturamentos(Mapper.Map<FaturamentoDTO[]>(lstData.ToArray()), isUserEdit));
        }

        public static FaturaViewModel CancelarRPS(int idRPS)
        {
            return Mapper.Map<FaturaViewModel>(ServiceHub.CancelarRPS(idRPS));
        }

        public static IEnumerable<Cidade> GetListCidadeSameEstadoByIdCidade(int idCidade)
        {
            return Mapper.Map<IEnumerable<Cidade>>(ServiceHub.GetListCidadeSameEstadoByIdCidade(idCidade));
        }

        public static LoteRPS GetLoteRPSById(int idLoteRPS)
        {
            return Mapper.Map<LoteRPS>(ServiceHub.GetLoteRPSById(idLoteRPS));
        }

        public static LoteRPS DeleteLoteRPS(LoteRPS loteRps)
        {
            return Mapper.Map<LoteRPS>(ServiceHub.DeleteLoteRPS(Mapper.Map<LoteRPSDTO>(loteRps)));
        }

        public static string[] GetAllPermissaoByUsuario(string username)
        {
            return ServiceHub.GetAllPermissaoByUsuario(username);
        }

        public static IEnumerable<Cliente> GetListClienteByIdEmpresa_COMBOBOX(Int32 idEmpresa)
        {
            return Mapper.Map<IEnumerable<Cliente>>(ServiceHub.GetListClienteByIdEmpresa_COMBOBOX(idEmpresa));
        }

        public static IEnumerable<ProjetoDisplayViewModel> GetListProjetoByIdEmpresa_INDEX(Int32 idEmpresa)
        {
            return Mapper.Map<IEnumerable<ProjetoDisplayViewModel>>(ServiceHub.GetListProjetoByIdEmpresa_INDEX(idEmpresa));
        }

        public static IEnumerable<GenericData> a()
        {
            return Mapper.Map<IEnumerable<GenericData>>(ServiceHub.GetAllStatusProjeto_COMBOBOX());
        }

        public static TipoRecolhimento GetTipoRecohimentoById(int idTipoRecolhimento)
        {
            return Mapper.Map<TipoRecolhimento>(ServiceHub.GetTipoRecolhimentoById(idTipoRecolhimento));
        }

        public static int GetQuantidadeRpsPorLoteByIdFilial(int idFilial)
        {
            return ServiceHub.GetQuantidadeRpsPorLoteByIdFilial(idFilial);
        }
    }
}