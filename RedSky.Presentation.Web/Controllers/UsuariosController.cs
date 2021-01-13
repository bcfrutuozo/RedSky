using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AutoMapper;
using RedSky.Domain.Entities;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    public class UsuariosController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public UsuariosController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        [Authorize(Roles = "Administrador, Cadastro")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Cadastro")]
        public PartialViewResult GetUsers()
        {
            if (Session["IdEmpresa"] != null && Convert.ToInt32(Session["IdEmpresa"]) > 0)
            {
                ViewBag.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
                return PartialView("_GetUsers",
                    _mapper.Map<IEnumerable<UsuarioViewModel>>(
                        _serviceHub.GetAllUsuarioByEmpresa(Convert.ToInt32(Session["IdEmpresa"]))));
            }
            else
            {
                return PartialView("_GetUsers", _mapper.Map<IEnumerable<UsuarioViewModel>>(_serviceHub.GetAllUsuario()));
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador, Cadastro")]
        public PartialViewResult Create(int? idEmpresa)
        {
            UsuarioViewModel usr = new UsuarioViewModel
            {
                IdEmpresa = idEmpresa,
                Parametrizador = !idEmpresa.HasValue,
                Permissoes = _mapper.Map<IList<PermissaoViewModel>>(_serviceHub.GetAllPermissao()),
            };

            if (idEmpresa == null || idEmpresa == 0)
            {
                ViewBag.Empresas =_mapper.Map<IEnumerable<DropdownViewModel>>(_serviceHub.GetAllEmpresa());
            }
            
            return PartialView("_Create", usr);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Cadastro")]
        public PartialViewResult Create(UsuarioViewModel usr, HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    usr.Picture = memoryStream.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                _serviceHub.AddUsuario(_mapper.Map<Usuario>(usr));
                return this.GetUsers();
            }

            if (Convert.ToInt32(Session["IdEmpresa"]) == 0)
            {
                ViewBag.Empresas = _mapper.Map<IEnumerable<DropdownViewModel>>(_serviceHub.GetAllEmpresa());
                ViewBag.Permissoes = _mapper.Map<IEnumerable<PermissaoViewModel>>(_serviceHub.GetAllPermissao());
            }
            else
            {
                ViewBag.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            }

            Response.StatusCode = 422;
            return PartialView("_Create", usr);
        }

        [HttpGet]
        [Authorize]
        public PartialViewResult SimpleEdit(int idUsuario)
        {
            return PartialView("_SimpleEdit", _mapper.Map<_SimpleEditUserViewModel>(_serviceHub.GetUsuarioById_UPDATE(idUsuario)));
        }
        
        [HttpPost()]
        [ValidateAntiForgeryToken]
        [Authorize]
        public PartialViewResult SimpleEdit(_SimpleEditUserViewModel usr, HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    usr.Picture = memoryStream.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _serviceHub.UpdateUsuario(_mapper.Map<Usuario>(usr));
                    Session["NomeUsuario"] = usr.Nome;
                    return default(PartialViewResult); // Returns an empty partial view
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex;
                }
            }

            Response.StatusCode = 422;
            return PartialView("_SimpleEdit", usr);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador, Cadastro")]
        public PartialViewResult Edit(int idUsuario)
        {
            UsuarioViewModel usr = _mapper.Map<UsuarioViewModel>(_serviceHub.GetUsuarioById_UPDATE(idUsuario));

            if (Convert.ToInt32(Session["IdEmpresa"]) == 0)
            {
                ViewBag.Empresas =_mapper.Map<IEnumerable<DropdownViewModel>>(_serviceHub.GetAllEmpresa());
            }
            
            return PartialView("_Create", usr);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Cadastro")]
        public PartialViewResult Edit(UsuarioViewModel usr, HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    usr.Picture = memoryStream.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                _serviceHub.UpdateUsuario(_mapper.Map<Usuario>(usr));
                return this.GetUsers();
            }

            if (Convert.ToInt32(Session["IdEmpresa"]) == 0)
            {
                ViewBag.Empresas = _mapper.Map<IEnumerable<DropdownViewModel>>(_serviceHub.GetAllEmpresa());
                ViewBag.Permissoes = _mapper.Map<IEnumerable<PermissaoViewModel>>(_serviceHub.GetAllPermissao());
            }
            else
            {
                ViewBag.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            }

            Response.StatusCode = 422;
            return PartialView("_Create", usr);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador, Cadastro")]
        public PartialViewResult Delete(int idUsuario)
        {
            return PartialView("_Delete", _mapper.Map<UsuarioViewModel>(_serviceHub.GetUsuarioById(idUsuario)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Cadastro")]
        public PartialViewResult Delete(UsuarioViewModel usuario)
        {
            _serviceHub.DeleteUsuario(_mapper.Map<Usuario>(usuario));

            return this.GetUsers();
        }
    }
}