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
    public class PermissoesController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public PermissoesController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        public ActionResult Index()
        {

            return View(_mapper.Map<IEnumerable<PermissaoViewModel>>(_serviceHub.GetAllPermissao()));
        }

        public ActionResult Create()
        {
            return View(new PermissaoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PermissaoViewModel permissao)
        {

            if (ModelState.IsValid)
            {
                _serviceHub.AddPermissao(_mapper.Map<Permissao>(permissao));
                return RedirectToAction("Index");
            }

            return View(permissao);
        }

        public ActionResult Edit(int id)
        {
            return View(_mapper.Map<PermissaoViewModel>(_serviceHub.GetPermissaoById(id)));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PermissaoViewModel permissao)
        {
            if (ModelState.IsValid)
            {
                _serviceHub.UpdatePermissao(_mapper.Map<Permissao>(permissao));
                return RedirectToAction("Index");
            }

            return View(permissao);
        }

        public ActionResult Delete(int id)
        {
            return View(_mapper.Map<PermissaoViewModel>(_serviceHub.GetPermissaoById(id)));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _serviceHub.DeletePermissao(id);
            return RedirectToAction("Index");
        }
    }
}