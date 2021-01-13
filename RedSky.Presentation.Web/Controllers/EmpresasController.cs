using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using RedSky.Common.Exceptions;
using RedSky.Domain.Entities;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    [Authorize(Roles = "Administrador")]
    public class EmpresasController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public EmpresasController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            try
            {
                return View(_mapper.Map<IEnumerable<EmpresaViewModel>>(_serviceHub.GetAllEmpresa()));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public ActionResult Create()
        {
            try
            {
                ViewBag.RegimesTributarios = new SelectList(_mapper.Map<IEnumerable<RegimeTributarioViewModel>>(_serviceHub.GetAllRegimeTributario()), "Id", "Nome");
                return View(new EmpresaViewModel());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(EmpresaViewModel empresa)
        {
            if (empresa.IdRegimeTributario == 1) // SIMPLES NACIONAL
            {
                empresa.AliquotaINSS = 0.00m;
                empresa.AliquotaPIS = 0.00m;
                empresa.AliquotaCOFINS = 0.00m;
                empresa.AliquotaCSLL = 0.00m;
                empresa.AliquotaIR = 0.00m;
            }

            if (ModelState.IsValid)
            {
                _serviceHub.AddEmpresa(_mapper.Map<Empresa>(empresa));
                return RedirectToAction("Index");
            }

            ViewBag.RegimesTributarios = new SelectList(_mapper.Map<IEnumerable<RegimeTributarioViewModel>>(_serviceHub.GetAllRegimeTributario()), "Id", "Nome",
                empresa.IdRegimeTributario);

            return View(empresa);
        }

        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.RegimesTributarios = new SelectList(_mapper.Map<IEnumerable<RegimeTributarioViewModel>>(_serviceHub.GetAllRegimeTributario()), "Id", "Nome");
                return View(_mapper.Map<EmpresaViewModel>(_serviceHub.GetEmpresaById(id)));
            }
            catch (EntityNotFoundException ex)
            {
                HttpNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(EmpresaViewModel empresa)
        {
            if (empresa.IdRegimeTributario == 1) // SIMPLES NACIONAL
            {
                empresa.AliquotaINSS = 0.00m;
                empresa.AliquotaPIS = 0.00m;
                empresa.AliquotaCOFINS = 0.00m;
                empresa.AliquotaCSLL = 0.00m;
                empresa.AliquotaIR = 0.00m;
            }

            if (ModelState.IsValid)
                try
                {
                    _serviceHub.UpdateEmpresa(_mapper.Map<Empresa>(empresa));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }

            ViewBag.RegimesTributarios = new SelectList(_mapper.Map<IEnumerable<RegimeTributarioViewModel>>(_serviceHub.GetAllRegimeTributario()), "Id", "Nome",
                empresa.IdRegimeTributario);

            return View(empresa);
        }

        public ActionResult Delete(int id)
        {
            return View(_mapper.Map<EmpresaViewModel>(_serviceHub.GetEmpresaById(id)));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _serviceHub.DeleteEmpresa(id);
            return RedirectToAction("Index");
        }
    }
}