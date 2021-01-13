using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedSky.Common;
using RedSky.Domain.Entities;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.Controllers.Base;
using RedSky.Presentation.Web.Filters;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    [Authorize(Roles = "Inteligencia")]
    public class TrackingController : KopernikController
    {
        public TrackingController(IServiceHub serviceHub, IMapper mapper, ILog logger) : base(serviceHub, mapper, logger)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetTrackings()
        {
            ViewBag.LabelList = Mapper.Map<IEnumerable<LabelDisplayViewModel>>(ServiceHub.GetListLabelByIdEmpresa(Convert.ToInt32(Session["IdEmpresa"])));
            return PartialView("_GetTrackings", Mapper.Map<IEnumerable<GetTrackingsViewModel>>(ServiceHub.GetListTaskGroupByIdEmpresa(Convert.ToInt32(Session["IdEmpresa"]))));
        }

        [HttpGet]
        public PartialViewResult CreateTaskGroup()
        {
            return PartialView("_CreateTaskGroup",
                new CreateTaskGroupViewModel() { IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult CreateTaskGroup(CreateTaskGroupViewModel taskGroup)
        {
            if (ModelState.IsValid)
            {
                ServiceHub.AddTaskGroup(Mapper.Map<TaskGroup>(taskGroup));
                return this.GetTrackings();
            }

            Response.StatusCode = 422;
            return PartialView("_CreateTaskGroup", taskGroup);
        }

        [HttpGet]
        public PartialViewResult CreateColumn(int idTaskGroup)
        {
            ViewBag.DataTypes = Mapper.Map<IEnumerable<DropdownViewModel>>(ServiceHub.GetAllDataTypes());
            return PartialView("_CreateColumn", new CreateColumnViewModel { IdTaskGroup = idTaskGroup });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult CreateColumn(CreateColumnViewModel column)
        {
            if (ModelState.IsValid)
            {
                ServiceHub.AddTaskColumn(Mapper.Map<TaskColumn>(column));
                return this.GetTrackings();
            }

            Response.StatusCode = 422;
            ViewBag.DataTypes = Mapper.Map<IEnumerable<DropdownViewModel>>(ServiceHub.GetAllDataTypes());
            return PartialView("_CreateColumn", column);
        }

        [HttpGet]
        public PartialViewResult NewTask(int idTaskGroup)
        {
            ServiceHub.AddDefaultTask(idTaskGroup);
            return this.GetTrackings();
        }

        [HttpGet]
        public PartialViewResult DeleteTask(int idTask)
        {
            return PartialView("_DeleteTask", Mapper.Map<DeleteTaskViewModel>(ServiceHub.GetTaskById(idTask)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult DeleteTask(DeleteTaskViewModel task)
        {
            ServiceHub.DeleteTask(Mapper.Map<Task>(task));
            return this.GetTrackings();
        }

        [HttpGet]
        public PartialViewResult DeleteColumn(int idTaskColumn)
        {
            return PartialView("_DeleteColumn", Mapper.Map<DeleteColumnViewModel>(ServiceHub.GetTaskColumnById(idTaskColumn)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult DeleteColumn(DeleteColumnViewModel column)
        {
            ServiceHub.DeleteTaskColumn(Mapper.Map<TaskColumn>(column));
            return this.GetTrackings();
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult UpdateColumn(string taskColumnJson)
        {
            JObject obj = JObject.Parse(taskColumnJson);
            var oldValue = obj.Property("oldValue").Value.ToString();
            
            try
            {
                var taskColumn = JsonConvert.DeserializeObject<TaskColumnDisplayViewModel>(taskColumnJson);

                var context = new ValidationContext(taskColumn, null, null);
                var results = new List<ValidationResult>();

                if (!Validator.TryValidateObject(taskColumn, context, results, true))
                {
                    Response.StatusCode = 422;
                    return Json(new JObject
                    {
                        {"Error", JToken.FromObject(results.ToArray())},
                        {"oldValue", oldValue}
                    }.ToString(), JsonRequestBehavior.DenyGet);
                }

                return Json(Mapper.Map<TaskColumnDisplayViewModel>(ServiceHub.UpdateTaskColumn(Mapper.Map<TaskColumn>(taskColumn))), JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new JObject
                {
                    {"ex", ex.ToString()},
                    {"oldValue", oldValue}
                }.ToString(), JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult UpdateTaskName(string taskJson)
        {
            JObject obj = JObject.Parse(taskJson);
            var oldValue = obj.Property("oldValue").Value.ToString();
            TaskDisplayViewModel tp = JsonConvert.DeserializeObject<TaskDisplayViewModel>(taskJson);

            try
            {
                return Json(Mapper.Map<TaskDisplayViewModel>(ServiceHub.UpdateTaskName(Mapper.Map<Task>(tp))),
                    JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new JObject
                {
                    {"ex", ex.ToString()},
                    {"oldValue", oldValue}
                }.ToString(), JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult UpdateIntegerValue(string taskCellJson)
        {
            JObject obj = JObject.Parse(taskCellJson);
            var oldValue = obj.Property("oldValue").Value.ToString();
            var culture = obj.Property("culture").Value.ToString();
            TaskCellDisplayViewModel tc = JsonConvert.DeserializeObject<TaskCellDisplayViewModel>(taskCellJson);

            try
            {
                return Json(Mapper.Map<TaskCellDisplayViewModel>(ServiceHub.UpdateCellValue(Mapper.Map<TaskCell>(tc), new CultureInfo(culture))),
                    JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new JObject
                {
                    {"ex", ex.ToString()},
                    {"oldValue", oldValue}
                }.ToString(), JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult UpdateDecimalValue(string taskCellJson)
        {
            JObject obj = JObject.Parse(taskCellJson);
            var oldValue = obj.Property("oldValue").Value.ToString();
            var culture = obj.Property("culture").Value.ToString();
            TaskCellDisplayViewModel tc = JsonConvert.DeserializeObject<TaskCellDisplayViewModel>(taskCellJson);

            try
            {
                return Json(Mapper.Map<TaskCellDisplayViewModel>(ServiceHub.UpdateCellValue(Mapper.Map<TaskCell>(tc), new CultureInfo(culture))),
                    JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new JObject
                {
                    {"ex", ex.ToString()},
                    {"oldValue", oldValue}
                }.ToString(), JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult UpdateCellValue(string taskCellJson)
        {
            JObject obj = JObject.Parse(taskCellJson);
            var oldValue = obj.Property("oldValue").Value.ToString();
            var culture = obj.Property("culture").Value.ToString();
            TaskCellDisplayViewModel tc = JsonConvert.DeserializeObject<TaskCellDisplayViewModel>(taskCellJson);

            try
            {
                return Json(Mapper.Map<TaskCellDisplayViewModel>(ServiceHub.UpdateCellValue(Mapper.Map<TaskCell>(tc), new CultureInfo(culture))),
                    JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new JObject
                {
                    {"ex", ex.ToString()},
                    {"oldValue", oldValue}
                }.ToString(), JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult UpdateDateTimeValue(string taskCellJson)
        {
            JObject obj = JObject.Parse(taskCellJson);
            var oldValue = obj.Property("oldValue").Value.ToString();
            var culture = obj.Property("culture").Value.ToString();
            TaskCellDisplayViewModel tc = JsonConvert.DeserializeObject<TaskCellDisplayViewModel>(taskCellJson);

            try
            {
                var ret = Mapper.Map<TaskCellDisplayViewModel>(ServiceHub.UpdateCellValue(Mapper.Map<TaskCell>(tc),
                    new CultureInfo(culture)));

                ret.Value = DateTime.Parse(ret.Value, new CultureInfo("en-US")).ToShortDateString();
                
                return Json(ret,
                    JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new JObject
                {
                    {"ex", ex.ToString()},
                    {"oldValue", oldValue}
                }.ToString(), JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult UpdateStatusValue(string taskCellJson)
        {
            JObject obj = JObject.Parse(taskCellJson);
            var culture = obj.Property("culture").Value.ToString();
            TaskCellDisplayViewModel tc = JsonConvert.DeserializeObject<TaskCellDisplayViewModel>(taskCellJson);

            try
            {
                return Json(Mapper.Map<TaskCellDisplayViewModel>(ServiceHub.UpdateCellValue(Mapper.Map<TaskCell>(tc),
                        new CultureInfo(culture))),
                    JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new JObject
                {
                    {"ex", ex.ToString()}
                }.ToString(), JsonRequestBehavior.DenyGet);
            }
        }
    }
}