using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TargetApp.API.Data;
using TargetApp.Entities.Concreate;
using TargetApp.Entities.General;

namespace TargetApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        [AllowAnonymous]
        [HttpPost("UserInsert")]
        public IActionResult InsertUser([FromBody] User Record)
        {
            Messages<User> m =new clsUserTransactions().Insert(Record, 1);

            return Json(m);


        }

        [AllowAnonymous]
        [HttpPost("CheckUser")]
        public IActionResult CheckUser(string userName,string password)
        {
            Messages<User> m = new clsUserTransactions().CheckUser(userName, password);

            return Json(m);


        }

        [AllowAnonymous]
        [HttpPost("UserUpdate")]
        public IActionResult UserUpdate([FromBody] User Record)
        {
            Messages<User> m = new clsUserTransactions().Update(Record, 1);
            return Json(m);


        }
        [AllowAnonymous]
        [HttpPost("UserDelete")]
        public IActionResult UserDelete(int UserId)
        {
            Messages<User> m = new Messages<User>();

            clsUserTransactions c = new clsUserTransactions();
            m = c.GetById(null,x => x.Id == UserId);
            if (m.Status && m.Record !=null)
            {
                m = new clsUserTransactions().Delete(m.Record, 1);
            }
            return Json(m);


        }
    }
}
