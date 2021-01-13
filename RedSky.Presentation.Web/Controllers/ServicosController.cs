using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using RedSky.Domain.Entities;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    [Authorize(Roles = "Relatorios")]
    public class ServicosController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public ServicosController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        [HttpGet]
        public PartialViewResult Index(int idDemonstrativo)
        {
            ViewBag.IdDemonstrativo = idDemonstrativo;
            return PartialView(_mapper.Map<IEnumerable<ServicoViewModel>>(_serviceHub.GetListServicoByIdDemonstrativo_INDEX(idDemonstrativo).OrderBy(svc => svc.Ordem)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Delete(string lstServicos, string servico)
        {
            var lstSvc = JsonConvert.DeserializeObject<List<ServicoViewModel>>(lstServicos);
            var svc = JsonConvert.DeserializeObject<ServicoViewModel>(servico);

            ViewBag.IdDemonstrativo = svc.IdDemonstrativo;

            if (lstSvc.Count > 1)
            {
                lstSvc.RemoveAt(svc.Ordem - 1);

                foreach (var otherSvc in lstSvc.Where(s => s.Ordem > svc.Ordem))
                    otherSvc.Ordem = otherSvc.Ordem - 1;
            }
            else
            {
                lstSvc.RemoveAt(0);
            }

            return PartialView("Index", lstSvc);
        }

        [HttpGet]
        public PartialViewResult Create(int idDemonstrativo, int order)
        {
            ViewBag.IdDemonstrativo = idDemonstrativo;
            ViewBag.Unidades = _mapper.Map<IEnumerable<UnidadeViewModel>>(_serviceHub.GetAllUnidade());
            ViewBag.ConexoesBanco = _mapper.Map<IEnumerable<ConexaoBancoViewModel>>(_serviceHub.GetListConexaoBancoByIdEmpresa(Convert.ToInt32(Session["IdEmpresa"])));
            return PartialView("_Create", new ServicoViewModel() {IdDemonstrativo = idDemonstrativo, Ordem = order});
        }

        [HttpPost]
        public PartialViewResult Edit(string servico)
        {
            var svc = JsonConvert.DeserializeObject<ServicoViewModel>(servico);

            ViewBag.IdDemonstrativo = svc.IdDemonstrativo;
            ViewBag.Unidades = _mapper.Map<IEnumerable<UnidadeViewModel>>(_serviceHub.GetAllUnidade());
            ViewBag.ConexoesBanco = _mapper.Map<IEnumerable<ConexaoBancoViewModel>>(_serviceHub.GetListConexaoBancoByIdEmpresa(Convert.ToInt32(Session["IdEmpresa"])));

            return PartialView("_Edit", svc);
        }
    }
}