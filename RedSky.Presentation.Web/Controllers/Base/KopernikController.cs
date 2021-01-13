using System.Web.Mvc;
using AutoMapper;
using log4net;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers.Base
{
    public abstract class KopernikController : Controller
    {
        protected readonly IServiceHub ServiceHub;
        protected readonly IMapper Mapper;
        protected readonly ILog Logger;

        protected KopernikController(IServiceHub serviceHub, IMapper mapper, ILog logger)
        {
            this.ServiceHub = serviceHub;
            this.Mapper = mapper;
            this.Logger = logger;
        }
    }
}