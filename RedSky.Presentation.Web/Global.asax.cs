using System;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using AutoMapper;
using log4net;
using log4net.Config;
using RedSky.Presentation.Web.Membership;
using RedSky.Services.Interfaces;

namespace RedSky.Presentation.Web
{
    public class MvcApplication : HttpApplication
    {
        private static readonly IServiceHub _serviceHub;
        private static readonly IMapper _mapper;
        private static readonly ILog _logger;

        static MvcApplication()
        {
            _serviceHub = DependencyResolver.Current.GetService<IServiceHub>();
            _mapper = DependencyResolver.Current.GetService<IMapper>();
            _logger = LogManager.GetLogger(typeof(MvcApplication));
        }

        protected void Application_Start()
        {
            XmlConfigurator.Configure();
            _logger.Info("Logger started successfully");
            _logger.Info("Initiating the application");
            _logger.Info("Registering areas in MVC application");
            AreaRegistration.RegisterAllAreas();
            _logger.Info("Registering global filters");
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            _logger.Info("Registering routes");
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            _logger.Info("Registering bundles");
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            _logger.Error("An unhandled exception was caught");
            _logger.Error(Server.GetLastError());
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported && Request.IsAuthenticated)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now         
                        _logger.Info("Obtaining the username for roles");
                        var username = FormsAuthentication
                            .Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        var roles = string.Empty;

                        roles = string.Join(";", _serviceHub.GetAllPermissaoByUsuario(username));

                        //let us extract the roles from our own custom cookie
                        //Let us set the Pricipal with our user specific details
                        _logger.Info("Extraing the user roles for custom cookie");
                        HttpContext.Current.User =
                            new GenericPrincipal(new GenericIdentity(username, "Forms"), roles.Split(';'));
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error when executing PostAuthenticateRequest");
                        _logger.Error(ex);
                    }
                }
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    _logger.Info("Getting user variables for session");

                    var usr = _mapper.Map<AuthenticationUser>(_serviceHub.GetUsuarioByLogin(User.Identity.Name));

                    Session["IdUsuario"] = usr.Id;
                    Session["IdEmpresa"] = usr.IdEmpresa;
                    Session["Usuario"] = usr.Login;
                    Session["NomeUsuario"] = usr.Nome;
                    Session["IsAdministrator"] = usr.Parametrizador;

                    //_logger.Info("Enabling the notification component for remote update on menu bar");
                    //Notification
                    //NotificationComponent nc = new NotificationComponent();
                    //var currentTime = DateTime.Now;
                    //HttpContext.Current.Session["LastUpdated"] = currentTime;
                    //nc.RegisterNotification(currentTime);
                }
                catch (Exception ex)
                {
                    _logger.Error("Error obtaining user variables for session");
                    _logger.Error(ex);

                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                }
            }
        }
    }
}