using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AtividadesController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public AtividadesController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            try
            {
                return View(_mapper.Map<IEnumerable<AtividadeViewModel>>(_serviceHub.GetAllAtividade().OrderBy(item => item.CodigoAtividade)));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        public ActionResult Create()
        {
            try
            {
                ViewBag.Tributacoes = new SelectList(_serviceHub.GetAllTributacao(), "Id", "Descricao");
                ViewBag.Operacoes = new SelectList(_serviceHub.GetAllOperacao(), "Id", "Descricao");
                ViewBag.Incidencias = new SelectList(_serviceHub.GetAllIncidencia(), "Id", "Descricao");
                ViewBag.ItensServicos = new SelectList(_serviceHub.GetAllItensServico(), "Id", "Descricao");
                ViewBag.Utilizacoes = new SelectList(_serviceHub.GetAllUtilizacao(), "Id", "Descricao");

                return View(new AtividadeViewModel());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(AtividadeViewModel atividade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceHub.AddAtividade(_mapper.Map<Atividade>(atividade));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            ViewBag.Tributacoes = new SelectList(_serviceHub.GetAllTributacao(), "Id", "Descricao", atividade.IdTributacao);
            ViewBag.Operacoes = new SelectList(_serviceHub.GetAllOperacao(), "Id", "Descricao", atividade.IdOperacao);
            ViewBag.Incidencias = new SelectList(_serviceHub.GetAllIncidencia(), "Id", "Descricao", atividade.IdIncidencia);
            ViewBag.ItensServicos =
                new SelectList(_serviceHub.GetAllItensServico(), "Id", "Descricao", atividade.IdItensServico);
            ViewBag.Utilizacoes = new SelectList(_serviceHub.GetAllUtilizacao(), "Id", "Descricao", atividade.IdUtilizacao);

            return View(atividade);
        }

        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Tributacoes = new SelectList(_serviceHub.GetAllTributacao(), "Id", "Descricao");
                ViewBag.Operacoes = new SelectList(_serviceHub.GetAllOperacao(), "Id", "Descricao");
                ViewBag.Incidencias = new SelectList(_serviceHub.GetAllIncidencia(), "Id", "Descricao");
                ViewBag.ItensServicos = new SelectList(_serviceHub.GetAllItensServico(), "Id", "Descricao");
                ViewBag.Utilizacoes = new SelectList(_serviceHub.GetAllUtilizacao(), "Id", "Descricao");

                return View(_mapper.Map<AtividadeViewModel>(_serviceHub.GetAtividadeById(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return HttpNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(AtividadeViewModel atividade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceHub.UpdateAtividade(_mapper.Map<Atividade>(atividade));
                    return RedirectToAction("Index");
                }

                ViewBag.Tributacoes =
                    new SelectList(_serviceHub.GetAllTributacao(), "Id", "Descricao", atividade.IdTributacao);
                ViewBag.Operacoes = new SelectList(_serviceHub.GetAllOperacao(), "Id", "Descricao", atividade.IdOperacao);
                ViewBag.Incidencias =
                    new SelectList(_serviceHub.GetAllIncidencia(), "Id", "Descricao", atividade.IdIncidencia);
                ViewBag.ItensServicos = new SelectList(_serviceHub.GetAllItensServico(), "Id", "Descricao",
                    atividade.IdItensServico);
                ViewBag.Utilizacoes =
                    new SelectList(_serviceHub.GetAllUtilizacao(), "Id", "Descricao", atividade.IdUtilizacao);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(atividade);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                return View(_mapper.Map<AtividadeViewModel>(_serviceHub.GetAtividadeById(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return HttpNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _serviceHub.DeleteAtividade(_serviceHub.GetAtividadeById(id));
            }
            catch (EntityRelationshipException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
            catch (EntityNotFoundException ex)
            {
                return HttpNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}