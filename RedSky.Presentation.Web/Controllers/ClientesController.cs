using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class ClientesController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public ClientesController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        // GET: Clientes
        [Route("Cadastro/Clientes")]
        [Route("Cadastro/Clientes/Index")]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult GetClientes()
        {
            return PartialView("_GetClientes", _mapper.Map<IEnumerable<GetClientesViewModel>>(_serviceHub.GetListClienteByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"])).OrderBy(c => c.Apelido)));
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            var c = new ClienteViewModel()
            {
                IdEmpresa = Convert.ToInt32(Session["IdEmpresa"])
            };

            ViewBag.Estados = new SelectList(_mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado()), "Id", "Sigla");
            ViewBag.Cidades = new SelectList(" ");
            ViewBag.TiposLogradouros = new SelectList(_mapper.Map<IEnumerable<TipoLogradouroViewModel>>(_serviceHub.GetAllTipoLogradouro()), "Id", "Descricao");
            ViewBag.TiposBairros = new SelectList(_mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoBairro()), "Id", "Descricao");

            return PartialView("_Create", c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                _serviceHub.AddCliente(_mapper.Map<Cliente>(cliente));
                return GetClientes();
            }

            ViewBag.Estados = new SelectList(_mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado()), "Id", "Sigla", cliente.IdEstado);
            ViewBag.Cidades = new SelectList(_mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetAllCidade()), "Id", "Nome", cliente.IdCidade);
            ViewBag.TiposLogradouros = new SelectList(_mapper.Map<IEnumerable<TipoLogradouroViewModel>>(_serviceHub.GetAllTipoLogradouro()), "Id", "Descricao",
                cliente.IdTipoLogradouro);
            ViewBag.TiposBairros =
                new SelectList(_mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoBairro()), "Id", "Descricao", cliente.IdTipoBairro);

            Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            return PartialView("_Create", cliente);
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            var c = _mapper.Map<ClienteViewModel>(_serviceHub.GetClienteById_CREATEUPDATE(id));
            ViewBag.Estados = new SelectList(_mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado()), "Id", "Sigla", c.IdEstado);
            ViewBag.Cidades = new SelectList(_mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetAllCidade()), "Id", "Nome", c.IdCidade);
            ViewBag.TiposLogradouros = new SelectList(_mapper.Map<IEnumerable<TipoLogradouroViewModel>>(_serviceHub.GetAllTipoLogradouro()), "Id", "Descricao",
                c.IdTipoLogradouro);
            ViewBag.TiposBairros =
                new SelectList(_mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoBairro()), "Id", "Descricao", c.IdTipoBairro);

            return PartialView("_Edit", c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                _serviceHub.UpdateCliente(_mapper.Map<Cliente>(cliente));
                return GetClientes();
            }

            ViewBag.Estados = new SelectList(_mapper.Map<IEnumerable<EstadoViewModel>>(_serviceHub.GetAllEstado()), "Id", "Sigla", cliente.IdEstado);
            ViewBag.Cidades = new SelectList(_mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetAllCidade()), "Id", "Nome", cliente.IdCidade);
            ViewBag.TiposLogradouros = new SelectList(_mapper.Map<IEnumerable<TipoLogradouroViewModel>>(_serviceHub.GetAllTipoLogradouro()), "Id", "Descricao",
                cliente.IdTipoLogradouro);
            ViewBag.TiposBairros =
                new SelectList(_mapper.Map<IEnumerable<TipoBairroViewModel>>(_serviceHub.GetAllTipoBairro()), "Id", "Descricao", cliente.IdTipoBairro);

            Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            return PartialView("_Edit", cliente);
        }

        [HttpGet]
        public PartialViewResult Delete(int id)
        {
            return PartialView("_Delete", _mapper.Map<ClienteViewModel>(_serviceHub.GetClienteById_CREATEUPDATE(id)));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Delete(ClienteViewModel cliente)
        {
            _serviceHub.RemoveCliente(_mapper.Map<Cliente>(cliente));
            return GetClientes();
        }

        [HttpGet]
        public JsonResult GetListCidadeByIdEstado(int idEstado)
        {
            return Json(_mapper.Map<IEnumerable<CidadeViewModel>>(_serviceHub.GetListCidadeByIdEstado(idEstado)), JsonRequestBehavior.AllowGet);
        }
    }
}