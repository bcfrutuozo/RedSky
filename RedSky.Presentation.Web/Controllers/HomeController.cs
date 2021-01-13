using System;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using log4net;
using RedSky.Presentation.Web.Attributes;
using RedSky.Presentation.Web.Controllers.Base;
using RedSky.Presentation.Web.Membership;
using RedSky.Presentation.Web.ViewModels;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web.Controllers
{
    [Internationalization]
    public class HomeController : KopernikController
    {
        public HomeController(IServiceHub serviceHub, IMapper mapper, ILog logger) : base(serviceHub, mapper,
            logger)
        { }

        // GET: Home
        [Authorize]
        [Route("Home")]
        public ActionResult Index()
        {
            Logger.Info("Testing");
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
            {
#if DEBUG
            return View(new LoginViewModel
            {
                Empresa = "kopernik",
                Usuario = "bcfrutuozo",
                Senha = "@k9d2tyc4"
            });
#endif
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View();

            AuthenticationUser usr = Mapper.Map<AuthenticationUser>(ServiceHub.Autenticar(login.Empresa, login.Usuario, login.Senha));

            if (usr == null)
            {
                ViewBag.Message = "Invalid credentials";
                return View();
            }
            
            FormsAuthentication.SetAuthCookie(usr.Login, login.RememberMe);

            Session["IdEmpresa"] = usr.IdEmpresa;
            Session["IdUsuario"] = usr.Id;
            Session["Usuario"] = usr.Login;
            Session["NomeUsuario"] = usr.Nome;
            Session["IsAdministrator"] = usr.Parametrizador;

            if (string.IsNullOrEmpty(returnUrl))
                return Redirect("~/Home/Index");

            return Redirect(returnUrl);
        }

        [ChildActionOnly]
        public ActionResult AuthenticatedUser()
        {
            return PartialView("_AuthenticatedUser", 
                Mapper.Map<AuthenticatedUserViewModel>(ServiceHub.GetAuthenticatedUserByLogin(Convert.ToString(Session["Usuario"]))));
        }

        [Authorize]
        public ActionResult Logout()
        {
            Session["IdEmpresa"] = null;
            Session["IdUsuario"] = null;
            Session["Usuario"] = null;
            Session["NomeUsuario"] = null;
            Session["IsAdministrator"] = null;

            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            FormsAuthentication.SignOut();
            return Redirect("~/Home/Index");
        }

        public JsonResult GetNotifications()
        {
            //var notificationRegisterTime = Session["LastUpdated"] != null
            //    ? Convert.ToDateTime(Session["LastUpdated"])
            //    : DateTime.Now;

            ////NotificationComponent nc = new NotificationComponent();
            ////var list = nc.GetNotifications(notificationRegisterTime);

            //// Update Session here for get only new added notifications
            //Session["LastUpdated"] = DateTime.Now;
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}