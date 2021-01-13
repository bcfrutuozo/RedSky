using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using RedSky.Domain.Entities;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    
    [Internationalization]
    [Authorize(Roles = "Financeiro")]
    public class LotesRPSController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public LotesRPSController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        // GET: LotesRPS
        public PartialViewResult Index()
        {
            ViewBag.Filiais = new SelectList(_mapper.Map<IEnumerable<FilialViewModel>>(_serviceHub.GetListFilialByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"]))),
                "Id", "Identificacao");
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult GetLotesRPSPorFilial(int idFilial)
        {
            ViewBag.IdFilial = idFilial;
            return PartialView("_GetLotesRPSPorFilial", _mapper.Map<IEnumerable<LoteRPSViewModel>>(_serviceHub.GetListLoteRPSByIdFilial(idFilial, 0)).OrderByDescending(l => l.IdStatusLoteRPS == 3) // LOTES EM ABERTO
                    .ThenByDescending(l => l.NumeroLote));
        }

        [HttpGet]
        public PartialViewResult Create(int idFilial)
        {
            _serviceHub.AddLoteRPS(idFilial);
            ViewBag.IdFilial = idFilial;
            return PartialView("_GetLotesRPSPorFilial", _mapper.Map<IEnumerable<LoteRPSViewModel>>(_serviceHub.GetListLoteRPSByIdFilial(idFilial, 0)).OrderByDescending(l => l.IdStatusLoteRPS == 3) // LOTES EM ABERTO
                .ThenByDescending(l => l.NumeroLote));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult ProcessBatch(int idFilial, int idLoteRPS)
        {
            _serviceHub.EnviarLoteRPS(idLoteRPS, true);
            ViewBag.IdFilial = idFilial;
            return PartialView("_GetLotesRPSPorFilial", _mapper.Map<IEnumerable<LoteRPSViewModel>>(_serviceHub.GetListLoteRPSByIdFilial(idFilial, 0)).OrderByDescending(l => l.IdStatusLoteRPS == 3) // LOTES EM ABERTO
                .ThenByDescending(l => l.NumeroLote));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult DownloadBatch(int idFilial, int idLoteRPS)
        {
            _serviceHub.DownloadNFSeByIdLoteRPS(idLoteRPS);
            ViewBag.IdFilial = idFilial;
            return PartialView("_GetLotesRPSPorFilial", _mapper.Map<IEnumerable<LoteRPSViewModel>>(_serviceHub.GetListLoteRPSByIdFilial(idFilial, 0)).OrderByDescending(l => l.IdStatusLoteRPS == 3) // LOTES EM ABERTO
                .ThenByDescending(l => l.NumeroLote));
        }

        [HttpGet]
        public PartialViewResult GetRPSSemLote(int idFilial, int idLoteRPS)
        {
            ViewBag.IdFilial = idFilial;
            ViewBag.IdLoteRPS = idLoteRPS;
            ViewBag.QuantidadeRpsPorLote = _serviceHub.GetQuantidadeRpsPorLoteByIdFilial(idFilial);
            return PartialView("_GetRPSSemLote", _mapper.Map<IEnumerable<RPSViewModel>>(_serviceHub.GetListRPSWithNoLoteRPSByIdFilial(idFilial)).OrderBy(rps => rps.NumeroRPS));
        }

        [HttpGet]
        public PartialViewResult GetListRPSByIdLoteRPS(int idFilial, int idLoteRPS)
        {
            ViewBag.IdFilial = idFilial;
            ViewBag.IdLoteRPS = idLoteRPS;
            return PartialView("_GetRPSLote", _mapper.Map<IEnumerable<RPSViewModel>>(_serviceHub.GetListRPSByIdLoteRPS(idLoteRPS)).OrderBy(rps => rps.NumeroRPS));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult AddRPSToLote(int idFilial, int idLoteRPS, int[] lstRps)
        {
            ViewBag.IdFilial = idFilial;
            ViewBag.IdLoteRPS = idLoteRPS;
            _serviceHub.AddRangeRPSInLoteRPS(idLoteRPS, lstRps);
            return PartialView("_GetLotesRPSPorFilial", _mapper.Map<IEnumerable<LoteRPSViewModel>>(_serviceHub.GetListLoteRPSByIdFilial(idFilial, 0)).OrderByDescending(l => l.IdStatusLoteRPS == 3) // LOTES EM ABERTO
                .ThenByDescending(l => l.NumeroLote));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult RemoveRPSFromLote(int idFilial, int[] lstRps)
        {
            ViewBag.IdFilial = idFilial;
            _serviceHub.DeleteRangeRPSFromLoteRPS(lstRps);
            return PartialView("_GetLotesRPSPorFilial", _mapper.Map<IEnumerable<LoteRPSViewModel>>(_serviceHub.GetListLoteRPSByIdFilial(idFilial, 0)).OrderByDescending(l => l.IdStatusLoteRPS == 3) // LOTES EM ABERTO
                .ThenByDescending(l => l.NumeroLote));
        }

        [HttpGet]
        public PartialViewResult Delete(int idLoteRPS)
        {
            return PartialView("_DeleteLoteRPS", _mapper.Map<LoteRPSViewModel>(_serviceHub.GetLoteRPSById(idLoteRPS)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Delete(LoteRPS loteRPS)
        {
            ViewBag.IdFilial = loteRPS.IdFilial;
            _serviceHub.DeleteLoteRPS(loteRPS);
            return PartialView("_GetLotesRPSPorFilial", _mapper.Map<IEnumerable<LoteRPSViewModel>>(_serviceHub.GetListLoteRPSByIdFilial(loteRPS.IdFilial, 0)).OrderByDescending(l => l.IdStatusLoteRPS == 3) // LOTES EM ABERTO
                .ThenByDescending(l => l.NumeroLote));
        }
    }
}