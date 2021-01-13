using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using RedSky.Common;
using RedSky.Domain.Entities;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    [Authorize(Roles = "Financeiro")]
    public class FaturasController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public FaturasController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        public PartialViewResult Index(int? month, int? year)
        {
            ViewBag.Month = month;
            ViewBag.Year = year;
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult Create(int month, int year)
        {
            ViewBag.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_serviceHub.GetListClienteByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Filiais = _mapper.Map<IEnumerable<FilialViewModel>>(_serviceHub.GetListFilialByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Demonstrativos = new List<DemonstrativoViewModel> {new DemonstrativoViewModel {Id = 0}};
            ViewBag.EstadosPrestacao = _mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado());
            ViewBag.CidadesPrestacao = new List<CidadeViewModel> {new CidadeViewModel {Id = 0}};
            ViewBag.TiposRecolhimentos = _mapper.Map<IEnumerable<TipoRecolhimentoViewModel>>(_serviceHub.GetAllTipoRecolhimento());
            ViewBag.Empresa = _mapper.Map<EmpresaViewModel>(_serviceHub.GetEmpresaById(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Atividades = _mapper.Map<IEnumerable<AtividadeViewModel>>(_serviceHub.GetListAtividadeByIdEmpresa(Convert.ToInt32(Session["IdEmpresa"])));

            return PartialView("_Create", new FaturaViewModel
            {
                Mes = month,
                Ano = year
            });
        }

        [HttpGet]
        public PartialViewResult Edit(int idFatura)
        {
            var f = _mapper.Map<FaturaViewModel>(_serviceHub.GetFaturaById_Update(idFatura));

            ViewBag.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_serviceHub.GetListClienteByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Filiais = _mapper.Map<IEnumerable<FilialViewModel>>(_serviceHub.GetListFilialByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));

            if (f.IdDemonstrativo.HasValue)
                ViewBag.Demonstrativos = _mapper.Map<IEnumerable<DemonstrativoViewModel>>(_serviceHub.GetDemonstrativosFaturaveisPorCliente(f.IdCliente));
            else
                ViewBag.Demonstrativos = new List<Demonstrativo> {new Demonstrativo {Id = 0}};

            ViewBag.EstadosPrestacao = _mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado());
            ViewBag.CidadesPrestacao = _mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetListCidadeSameEstadoByIdCidade(f.IdCidadePrestacao));
            ViewBag.TiposRecolhimentos = _mapper.Map<IEnumerable<TipoRecolhimentoViewModel>>(_serviceHub.GetAllTipoRecolhimento());
            ViewBag.Empresa = _mapper.Map<EmpresaViewModel>(_serviceHub.GetEmpresaById(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Atividades = _mapper.Map<IEnumerable<AtividadeViewModel>>(_serviceHub.GetListAtividadeByIdEmpresa(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Incidencias = new[]
            {
                new {Id = 1, Descricao = "ISS a recolher em outro município"},
                new {Id = 2, Descricao = "ISS a Recolher pelo prestador"}
            };

            return PartialView("_Edit", f);
        }

        [HttpGet]
        public PartialViewResult Detail(int idFatura)
        {
            var f = _mapper.Map<FaturaViewModel>(_serviceHub.GetFaturaById_Update(idFatura));

            ViewBag.Cliente = _mapper.Map<ClienteViewModel>(_serviceHub.GetClienteById_CREATEUPDATE(f.IdCliente));
            ViewBag.Filial = _mapper.Map<FilialViewModel>(_serviceHub.GetFilialById_CREATEEDIT(f.IdFilial));

            if (f.IdDemonstrativo.HasValue)
                ViewBag.Demonstrativo = _mapper.Map<DemonstrativoViewModel>(_serviceHub.GetDemonstrativoById_CREATEEDIT(f.IdDemonstrativo.Value));

            ViewBag.EstadoPrestacao = _mapper.Map<EstadoViewModel>(_serviceHub.GetEstadoById(f.IdEstadoPrestacao));
            ViewBag.CidadePrestacao = _mapper.Map<CidadeViewModel>(_serviceHub.GetCidadeById(f.IdCidadePrestacao));
            ViewBag.TipoRecolhimento = _mapper.Map<TipoRecolhimento>(_serviceHub.GetTipoRecolhimentoById(f.IdTipoRecolhimento));
            ViewBag.Empresa = _mapper.Map<EmpresaViewModel>(_serviceHub.GetEmpresaById(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Atividade = _mapper.Map<AtividadeViewModel>(_serviceHub.GetAtividadeById(f.IdAtividade));

            return PartialView("_Detail", f);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Create(FaturaViewModel fatura)
        {
            ViewBag.Month = fatura.Mes;
            ViewBag.Year = fatura.Ano;

            // Remove the slash.
            if (!string.IsNullOrEmpty(fatura.Competencia))
                fatura.Competencia = fatura.Competencia.Replace("/", string.Empty);


            if (ModelState.IsValid)
            {
                _serviceHub.AddFatura(_mapper.Map<Fatura>(fatura));
                return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), fatura.Mes, fatura.Ano)).OrderBy(fat => fat.NumeroNF));
            }

            ViewBag.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_serviceHub.GetListClienteByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Filiais = _mapper.Map<IEnumerable<FilialViewModel>>(_serviceHub.GetListFilialByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));

            if (fatura.IdDemonstrativo.HasValue)
                ViewBag.Demonstrativos = _mapper.Map<IEnumerable<DemonstrativoViewModel>>(_serviceHub.GetDemonstrativosFaturaveisPorCliente(fatura.IdCliente));
            else
                ViewBag.Demonstrativos = new List<DemonstrativoViewModel> { new DemonstrativoViewModel { Id = 0 } };

            ViewBag.EstadosPrestacao = _mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado());

            if (fatura.IdCidadePrestacao == 0)
                ViewBag.CidadesPrestacao = new List<CidadeViewModel> { new CidadeViewModel { Id = 0 } };
            else
                ViewBag.CidadesPrestacao = _mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetListCidadeSameEstadoByIdCidade(fatura.IdCidadePrestacao));

            ViewBag.TiposRecolhimentos = _mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoRecolhimento());
            ViewBag.Empresa = _mapper.Map<EmpresaViewModel>(_serviceHub.GetEmpresaById(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Atividades = _mapper.Map<IEnumerable<AtividadeViewModel>>(_serviceHub.GetListAtividadeByIdEmpresa(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Incidencias = new[]
            {
                new {Id = 1, Descricao = "ISS a recolher em outro município"},
                new {Id = 2, Descricao = "ISS a Recolher pelo prestador"}
            };

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return PartialView("_Edit", fatura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Edit(FaturaViewModel fatura)
        {
            ViewBag.Month = fatura.Mes;
            ViewBag.Year = fatura.Ano;

            // Remove the slash.
            if (!string.IsNullOrEmpty(fatura.Competencia))
                fatura.Competencia = fatura.Competencia.Replace("/", string.Empty);


            if (ModelState.IsValid)
            {
                _serviceHub.UpdateFatura(_mapper.Map<Fatura>(fatura));
                return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), fatura.Mes, fatura.Ano)).OrderBy(fat => fat.NumeroNF));
            }

            ViewBag.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_serviceHub.GetListClienteByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Filiais = _mapper.Map<IEnumerable<FilialViewModel>>(_serviceHub.GetListFilialByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));

            if (fatura.IdDemonstrativo.HasValue)
                ViewBag.Demonstrativos = _mapper.Map<IEnumerable<DemonstrativoViewModel>>(_serviceHub.GetDemonstrativosFaturaveisPorCliente(fatura.IdCliente));
            else
                ViewBag.Demonstrativos = new List<DemonstrativoViewModel> {new DemonstrativoViewModel {Id = 0}};

            ViewBag.EstadosPrestacao = _mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado());

            if (fatura.IdCidadePrestacao == 0)
                ViewBag.CidadesPrestacao = new List<CidadeViewModel> {new CidadeViewModel {Id = 0}};
            else
                ViewBag.CidadesPrestacao = _mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetListCidadeSameEstadoByIdCidade(fatura.IdCidadePrestacao));

            ViewBag.TiposRecolhimentos = _mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoRecolhimento());
            ViewBag.Empresa = _mapper.Map<EmpresaViewModel>(_serviceHub.GetEmpresaById(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Atividades = _mapper.Map<IEnumerable<AtividadeViewModel>>(_serviceHub.GetListAtividadeByIdEmpresa(Convert.ToInt32(Session["IdEmpresa"])));
            ViewBag.Incidencias = new[]
            {
                new {Id = 1, Descricao = "ISS a recolher em outro município"},
                new {Id = 2, Descricao = "ISS a Recolher pelo prestador"}
            };

            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return PartialView("_Edit", fatura);
        }

        [HttpGet]
        public PartialViewResult Delete(int idFatura)
        {
            return PartialView("_Delete", _mapper.Map<FaturaViewModel>(_serviceHub.GetFaturaById_Update(idFatura)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Delete(FaturaViewModel fatura)
        {
            ViewBag.Month = fatura.Mes;
            ViewBag.Year = fatura.Ano;

            _serviceHub.DeleteFatura(fatura.Id);     
            
            return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), fatura.Mes, fatura.Ano)).OrderBy(fat => fat.NumeroNF));
        }

        [HttpGet]
        public PartialViewResult GetFaturas(int month, int year)
        {
            ViewBag.Month = month;
            ViewBag.Year = year;
            return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), month, year)).OrderBy(fat => fat.NumeroNF));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult DeleteRPS(int idRPS, int month, int year)
        {
            _serviceHub.CancelarRPS(idRPS);

            ViewBag.Month = month;
            ViewBag.Year = year;

            return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), month, year)).OrderBy(fat => fat.NumeroNF));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult CopiarCompetenciaAnterior(int month, int year)
        {
            // Obtem a competencia atual.
            var date = new DateTime(year, month, 1);

            // Obtem a competencia anterior.
            var last = new DateTime(year, month, 1).AddDays(-1);
            _serviceHub.DuplicarCompetencia(Convert.ToInt32(Session["IdEmpresa"]), last.Month, last.Year, date.Month,
                date.Year);


            ViewBag.Month = month;
            ViewBag.Year = year;
            return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), month, year)).OrderBy(fat => fat.NumeroNF));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Process(int idFatura)
        {
            var f = _serviceHub.EmitirFatura(idFatura);
            ViewBag.Month = f.Mes;
            ViewBag.Year = f.Ano;
            return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), f.Mes, f.Ano)).OrderBy(fat => fat.NumeroNF));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Bill(int idFatura)
        {
            _serviceHub.Faturar(idFatura);
            var f = _serviceHub.GetFaturaById_Update(idFatura);
            ViewBag.Month = f.Mes;
            ViewBag.Year = f.Ano;
            return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), f.Mes, f.Ano)).OrderBy(fat => fat.NumeroNF));
        }

        public FileContentResult DownloadFatura(int idFatura)
        {
            var outputName = _serviceHub.GetFaturaNomeArquivo(idFatura);
            var fileContent = _serviceHub.DownloadFatura(idFatura);

            return File(fileContent, MediaTypeNames.Application.Octet, outputName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void SendBillEmail(int idFatura)
        {
            _serviceHub.SendBillingEmail(idFatura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void SendInvoiceEmail(int idFatura, int idFilial, long numeroNF)
        {
            _serviceHub.SendInvoiceEmail(idFilial, numeroNF);
        }

        [HttpGet]
        public ActionResult GetFaturamentos(int idFatura, string nomeFatura, int month, int year, bool isProcessavel,
            bool isFaturado)
        {
            ViewBag.IdFatura = idFatura;
            ViewBag.NomeFatura = nomeFatura;
            ViewBag.IsProcessavel = isProcessavel;
            ViewBag.IsFaturado = isFaturado;

            var faturamentos = _mapper.Map<IEnumerable<FaturamentoViewModel>>(_serviceHub.GetListFaturamentoByIdFatura(idFatura));

            if (isProcessavel)
            {
                var minValue = _serviceHub.GetDemonstrativoById_CREATEEDIT(_serviceHub.GetFaturaById_Update(idFatura).IdDemonstrativo.Value)
                    .ValorMinimo;
                
                var ret = new List<ServicoViewModel> {new ServicoViewModel() {Id = 0, Descricao = @"Serviços Prestados", Valor = minValue}};
                ret.AddRange(_mapper.Map<IEnumerable<ServicoViewModel>>(_serviceHub.GetListServicoByIdFatura(idFatura)));
                ViewBag.MaxSize = ret.Count();
                ViewBag.Servicos = ret;
            }
            else
            {
                ViewBag.MaxSize = 0;
            }

            return PartialView("_GetFaturamentos", faturamentos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult UpdateFaturamentos(int idFatura, string lstFaturamentos)
        {
            var lstData = JsonConvert.DeserializeObject<FaturamentoViewModel[]>(lstFaturamentos);
            _serviceHub.ZerarFatura(idFatura);
            _serviceHub.AddFaturamentos(_mapper.Map<IEnumerable<Faturamento>>(lstData.ToList()), true);

            var f = _serviceHub.GetFaturaById_Update(idFatura);

            ViewBag.Month = f.Mes;
            ViewBag.Year = f.Ano;
            return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), f.Mes, f.Ano)).OrderBy(fat => fat.NumeroNF));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult RemoveFaturamentos(int idFatura)
        {
            _serviceHub.ZerarFatura(idFatura);

            var f = _serviceHub.GetFaturaById_Update(idFatura);

            ViewBag.Month = f.Mes;
            ViewBag.Year = f.Ano;
            return PartialView("_GetFaturas", _mapper.Map<IEnumerable<FaturaDisplayViewModel>>(_serviceHub.GetAllFaturaByEmpresa_Mes_Ano(Convert.ToInt32(Session["IdEmpresa"]), f.Mes, f.Ano)).OrderBy(fat => fat.NumeroNF));
        }

        [HttpGet]
        public JsonResult GetDemonstrativosPorCliente(int idCliente)
        {
            return Json(_mapper.Map<IEnumerable<DemonstrativoViewModel>>(_serviceHub.GetDemonstrativosFaturaveisPorCliente(idCliente)), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCidadesPorEstado(int idEstado)
        {
            return Json(_mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetListCidadeByIdEstado(idEstado)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDadosAtividade(int idAtividade)
        {
            return Json(_mapper.Map<AtividadeViewModel>(_serviceHub.GetAtividadeById(idAtividade)), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAtividadesPorEmpresa()
        {
            return Json(_mapper.Map<IEnumerable<AtividadeViewModel>>(_serviceHub.GetListAtividadeByIdEmpresa(Convert.ToInt32(Session["IdEmpresa"]))),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string GetCalculateValue(string x, string y)
        {
            decimal retX;
            decimal retY;

            if (!decimal.TryParse(
                    x == string.Empty
                        ? decimal.Zero.ToString(CultureInfo.CurrentCulture)
                        : x.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator),
                    NumberStyles.Any, CultureInfo.CurrentCulture, out retX)
                ||
                !decimal.TryParse(
                    y == string.Empty
                        ? decimal.Zero.ToString(CultureInfo.CurrentCulture)
                        : y.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator),
                    NumberStyles.Any, CultureInfo.CurrentCulture, out retY))
                return "Erro";

            var res = (retX * retY).DecimalTowardZero(2);

            return Json(new {x = retX, y = retY, ret = res}).ToJson();
        }
    }
}