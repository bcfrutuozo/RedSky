using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using RedSky.Domain.Entities;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    [Authorize(Roles = "Cadastro")]
    public class FiliaisController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public FiliaisController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        // GET: Filiais
        [Route("Cadastro/Filiais")]
        [Route("Cadastro/Filiais/Index")]
        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<FilialViewModel>>(_serviceHub.GetListFilialByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"]))));
        }

        public ActionResult Create()
        {
            var f = new FilialViewModel()
            {
                IdEmpresa = Convert.ToInt32(Session["IdEmpresa"])
            };

            ViewBag.Estados = new SelectList(_mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado()), "Id", "Sigla");
            ViewBag.Cidades = new SelectList(" ");
            ViewBag.TiposLogradouros = new SelectList(_mapper.Map<IEnumerable<TipoLogradouroViewModel>>(_serviceHub.GetAllTipoLogradouro()), "Id", "Descricao");
            ViewBag.TiposBairros = new SelectList(_mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoBairro()), "Id", "Descricao");

            return View(f);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilialViewModel filial)
        {
            if (ModelState.IsValid)
            {
                _serviceHub.AddFilial(_mapper.Map<Filial>(filial));
                return RedirectToAction("Index");
            }

            ViewBag.Estados = new SelectList(_mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado()), "Id", "Sigla", filial.IdEstado);
            ViewBag.Cidades = new SelectList(_mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetAllCidade()), "Id", "Nome", filial.IdCidade);
            ViewBag.TiposLogradouros =
                new SelectList(_mapper.Map<IEnumerable<TipoLogradouroViewModel>>(_serviceHub.GetAllTipoLogradouro()), "Id", "Descricao", filial.IdTipoLogradouro);
            ViewBag.TiposBairros = new SelectList(_mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoBairro()), "Id", "Descricao", filial.IdTipoBairro);

            return View(filial);
        }

        public ActionResult Edit(int id)
        {
            var f = _mapper.Map<FilialViewModel>(_serviceHub.GetFilialById_CREATEEDIT(id));

            if (f == null)
                return HttpNotFound();

            ViewBag.Estados = new SelectList(_mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado()), "Id", "Sigla", f.IdEstado);
            ViewBag.Cidades = new SelectList(_mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetListCidadeByIdEstado(f.IdEstado)), "Id", "Nome", f.IdCidade);
            ViewBag.TiposLogradouros =
                new SelectList(_mapper.Map<IEnumerable<TipoLogradouroViewModel>>(_serviceHub.GetAllTipoLogradouro()), "Id", "Descricao", f.IdTipoLogradouro);
            ViewBag.TiposBairros = new SelectList(_mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoBairro()), "Id", "Descricao", f.IdTipoBairro);

            return View(f);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilialViewModel filial)
        {
            if (ModelState.IsValid)
            {
                _serviceHub.UpdateFilial(_mapper.Map<Filial>(filial));
                return RedirectToAction("Index");
            }

            ViewBag.Estados = new SelectList(_mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado()), "Id", "Sigla", filial.IdEstado);
            ViewBag.Cidades = new SelectList(_mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetListCidadeByIdEstado(filial.IdEstado)), "Id", "Nome",
                filial.IdCidade);
            ViewBag.TiposLogradouros =
                new SelectList(_mapper.Map<IEnumerable<TipoLogradouroViewModel>>(_serviceHub.GetAllTipoLogradouro()), "Id", "Descricao", filial.IdTipoLogradouro);
            ViewBag.TiposBairros = new SelectList(_mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoBairro()), "Id", "Descricao", filial.IdTipoBairro);

            return View(filial);
        }

        public ActionResult Delete(int id)
        {
            var f = _mapper.Map<FilialViewModel>(_serviceHub.GetFilialById_CREATEEDIT(id));

            return View(f);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _serviceHub.DeleteFilial(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetCidadesPorEstado(int idEstado)
        {
            return Json(_mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetListCidadeByIdEstado(idEstado)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CertificadosIndex(int id)
        {
            ViewBag.IdFilial = id;
            return View(_mapper.Map<IEnumerable<CertificadoDigitalViewModel>>(_serviceHub.GetListCertificadoDigitalByIdFilial(id)));
        }

        public ActionResult CertificadosCreate(int idFilial)
        {
            return View(new CertificadoDigitalViewModel());
        }

        [HttpPost]
        public JsonResult UploadCertificate()
        {
            for (var i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i]; //Uploaded file
                //Use the following properties to get file's name, size and MIMEType
                var fileSize = file.ContentLength;
                var fileName = file.FileName;
                var mimeType = file.ContentType;
                var fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/") + fileName); //File will be saved in application root
            }

            return Json("Uploaded " + Request.Files.Count + " files");
        }
    }
}