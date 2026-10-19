using System.Linq;
using System.Web.Mvc;
using ASPNETWebAppMVCStudentApp.Filters;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class AccountController : Controller
    {
        private SchoolModel db = new SchoolModel();

        [Filters.AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Filters.AllowAnonymous]
        public ActionResult Login(string username, string password)
        {
            var user = db.tblUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Session["Username"] = user.Username;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        [Filters.AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}