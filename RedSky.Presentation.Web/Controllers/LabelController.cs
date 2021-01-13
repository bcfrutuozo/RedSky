using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using log4net;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.Controllers.Base;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    [Authorize(Roles = "Inteligencia")]
    public class LabelController : KopernikController
    {
        public LabelController(IServiceHub serviceHub, IMapper mapper, ILog logger) : base(serviceHub, mapper, logger)
        {

        }

        [HttpGet]
        public ActionResult Create(int idEmpresa)
        {
            ViewBag.Colors = Mapper.Map<IEnumerable<ColorDisplayViewModel>>(ServiceHub.GetAllColor());
            return PartialView("_Create", new CreateLabelViewModel {IdEmpresa = idEmpresa});
        }

        [HttpPost]
        public ActionResult Create(CreateLabelViewModel label)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //return Mapper.Map<LabelDisplayViewModel>(ServiceHub.AddLabel(Mapper.Map<Label>(label)));
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex;
                }
            }

            Response.StatusCode = 422;
            return PartialView("_Create", label);
        }
    }
}