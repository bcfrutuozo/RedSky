using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using RedSky.Common;
using RedSky.Domain.Entities;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    [Authorize(Roles = "Relatorios")]
    public class DemonstrativosController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public DemonstrativosController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        // GET: Clientes
        [Route("Cadastro/Demonstrativos")]
        [Route("Cadastro/Demonstrativos/Index")]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult GetDemonstrativos()
        {
            return PartialView("_GetDemonstrativos", _mapper.Map<IEnumerable<DemonstrativoViewModel>>(_serviceHub.GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"]))));
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_serviceHub.GetListClienteByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));

            return PartialView("_Create", new DemonstrativoViewModel() {IdEmpresa = Convert.ToInt32(Session["IdEmpresa"])});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Create(DemonstrativoViewModel demonstrativo)
        {
            if (ModelState.IsValid)
            {
                _serviceHub.AddDemonstrativo(_mapper.Map<Demonstrativo>(demonstrativo));
                return PartialView("_GetDemonstrativos",  _mapper.Map<IEnumerable<DemonstrativoViewModel>>(_serviceHub.GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"]))));
            }

            ViewBag.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_serviceHub.GetListClienteByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));
            Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            return PartialView("_Create", demonstrativo);
        }

        [HttpGet]
        public PartialViewResult Edit(int idDemonstrativo)
        {
            ViewBag.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_serviceHub.GetListClienteByIdEmpresa_COMBOBOX(Convert.ToInt32(Session["IdEmpresa"])));

            return PartialView("_Edit", _mapper.Map<DemonstrativoViewModel>(_serviceHub.GetDemonstrativoById_CREATEEDIT(idDemonstrativo)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Edit(DemonstrativoViewModel demonstrativo)
        {
            if (ModelState.IsValid)
            {
                _serviceHub.UpdateDemonstrativo(_mapper.Map<Demonstrativo>(demonstrativo));
                return PartialView("_GetDemonstrativos",
                    _mapper.Map<IEnumerable<DemonstrativoViewModel>>(_serviceHub.GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"]))));
            }

            ViewBag.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_serviceHub.GetListClienteByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])));

            return PartialView("_Edit", demonstrativo);
        }

        [HttpGet]
        public PartialViewResult Delete(int idDemonstrativo)
        {
            return PartialView("_Delete", _mapper.Map<DemonstrativoViewModel>(_serviceHub.GetDemonstrativoById_CREATEEDIT(idDemonstrativo)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Delete(Demonstrativo demonstrativo)
        {
            _serviceHub.DeleteDemonstrativo(demonstrativo);
            return PartialView("_GetDemonstrativos",
                _mapper.Map<IEnumerable<DemonstrativoViewModel>>(_serviceHub.GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"]))));
        }

        public JsonResult GetClientesPorEmpresa(int idEmpresa)
        {
            return Json(_mapper.Map<IEnumerable<ClienteViewModel>>(_serviceHub.GetListClienteByIdEmpresa_INDEX(idEmpresa)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string GetValue(string x)
        {
            decimal retX;

            if (!decimal.TryParse(
                x == string.Empty
                    ? decimal.Zero.ToString(CultureInfo.CurrentCulture)
                    : x.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator),
                NumberStyles.Any, CultureInfo.CurrentCulture, out retX))
                return "Erro";

            return Json(new {value = retX}).ToJson();
        }

        [HttpGet]
        public PartialViewResult CopyDemonstrativoById(int idDemonstrativo)
        {
            _serviceHub.CopyDemonstrativo(idDemonstrativo);
            return PartialView("_GetDemonstrativos", _mapper.Map<IEnumerable<DemonstrativoViewModel>>(_serviceHub.GetListDemonstrativoWithoutServicoByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"]))));
        }
    }
}