using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TargetApp.API.Data;
using TargetApp.Entities.Concreate;
using TargetApp.Entities.General;

namespace TargetApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyAppInfoController : Controller
    {

        [AllowAnonymous]
        [HttpPost("InsertMyApp")]
        public IActionResult InsertMyApp([FromBody] MyAppInfo Record)
        {
            Messages<MyAppInfo> m = new clsMyAppInfoTransaction().Insert(Record, 1);

            return Json(m);


        }

        [AllowAnonymous]
        [HttpPost("UpdateMyApp")]
        public IActionResult UpdateMyApp([FromBody] MyAppInfo Record)
        {
            Messages<MyAppInfo> m = new clsMyAppInfoTransaction().Update(Record, 1);
            return Json(m);


        }
        [AllowAnonymous]
        [HttpPost("DeleteMyApp")]
        public IActionResult DeleteMyApp(int objectId)
        {
            Messages<MyAppInfo> m = new Messages<MyAppInfo>();

            clsMyAppInfoTransaction c = new clsMyAppInfoTransaction();
            m = c.GetById(null, x => x.Id == objectId);
            if (m.Status && m.Record != null)
            {
                m = new clsMyAppInfoTransaction().Delete(m.Record, 1);
            }
            return Json(m);


        }



    }
}
