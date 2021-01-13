using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    [Authorize(Roles = "Projetos")]
    public class ProjetosController : Controller
    {
        private readonly IServiceHub _serviceHub;
        private readonly IMapper _mapper;

        public ProjetosController(IServiceHub serviceHub, IMapper mapper)
        {
            _serviceHub = serviceHub;
            _mapper = mapper;
        }

        [HttpGet]
        public PartialViewResult Index(int idEmpresa)
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult GetListProjeto()
        {
            return PartialView("_GetListProjeto",  _mapper.Map<IEnumerable<ProjetoDisplayViewModel>>(_serviceHub.GetListProjetoByIdEmpresa_INDEX(Convert.ToInt32(Session["IdEmpresa"]))));
        }
    }
}