using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TargetApp.API.Data;
using TargetApp.Entities.Concreate;
using TargetApp.Entities.General;

namespace TargetApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyAppHealthController : Controller
    {
        [AllowAnonymous]
        [HttpPost("InsertMyAppHealth")]
        public IActionResult InsertMyAppHealth([FromBody] MyAppHealth Record)
        {
            Messages<MyAppHealth> m = new clsMyAppHealthTransactions().Insert(Record, 1);
            return Json(m);
        }

        [AllowAnonymous]
        [HttpPost("UpdateMyAppHealth")]
        public IActionResult UpdateMyAppHealth([FromBody] MyAppHealth Record)
        {
            Messages<MyAppHealth> m = new clsMyAppHealthTransactions().Update(Record, 1);
            return Json(m);
        }
        [AllowAnonymous]
        [HttpPost("DeleteMyAppHealth")]
        public IActionResult DeleteMyAppHealth(int objectId)
        {
            Messages<MyAppHealth> m = new Messages<MyAppHealth>();

            clsMyAppHealthTransactions c = new clsMyAppHealthTransactions();
            m = c.GetById(null, x => x.Id == objectId);
            if (m.Status && m.Record != null)
            {
                m = new clsMyAppHealthTransactions().Delete(m.Record, 1);
            }
            return Json(m);


        }
    }
}
