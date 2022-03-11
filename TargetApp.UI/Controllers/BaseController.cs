using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TargetApp.Entities.Concreate;
using TargetApp.UI.ExtensionMethods;

namespace TargetApp.UI.Controllers
{
    public class BaseController : Controller
    {

        IHttpContextAccessor cnt;
        IConfiguration cfg;
        public string _WebApiUrl { get; }


        public User _baseUser { get; }
        public string _basePassword { get; }
           public string _WebApiUrl { get; }
        public BaseController(IHttpContextAccessor _cnt, IConfiguration _cfg)
        {
            cnt = _cnt;
            cfg = _cfg;

            _baseUser = _cnt.HttpContext.Session.GetObject<User>("user");
            _basePassword = _cnt.HttpContext.Session.GetString("pass");

            //_basePerms = _cnt.HttpContext.Session.GetObject<List<KULLANICI_ROL_YETKI>>("perm");
            //_baseSistemParametreler = _cnt.HttpContext.Session.GetObject<SISTEM_PARAMETRE>("sysParams");

            _WebApiUrl = _cfg.GetValue<string>("WebApiUrl");
        }

    }
}
