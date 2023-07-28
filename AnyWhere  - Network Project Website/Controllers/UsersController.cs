using AnyWhere____Network_Project_Website.Models;
using AnyWhere____Network_Project_Website.ViewModel;
using AnyWhere___Network_Project_WebSite.Dal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace AnyWhere____Network_Project_Website.Controllers
{
    public class UsersController : Controller
    {
        public static string UserEmail = "";
        public static int UserID = 0;
        public static string UserName = "";
        // GET: Users
        public ActionResult Login()
        {

            return View();
        }

        public ActionResult MyProfile()
        {

            using(DB db = new DB())
            {
                VM vm = new VM()
                {
                    books = db.books.Where(d => d.User_id == UserID).ToList(),
                };

                return View(vm);
            }
        }

        [HttpPost]
        public ActionResult LoginSubmit(VM us)
        {
            using (DB db = new DB())
            {
                VM usr = new VM();
                usr.user = db.users.Single(u => u.Email == us.user.Email && u.Password == us.user.Password);
                if (usr != null)
                {
                    UserEmail = usr.user.Email;
                    UserID = usr.user.Id;
                    UserName = usr.user.FirstName;
                    return RedirectToAction("LoggedIn", usr);

                }
                else
                {
                    ModelState.AddModelError("", "Email Or Password Are Wrong ");
                }
                return View("LoggedIn");
            }
        }

        public ActionResult LoggedIn(VM usr)
        {
            if (UserID != 0)
            {
                return RedirectToAction("Index", "Home", usr);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Register(VM usr)
        {
            if (ModelState.IsValid)
            {
                using (DB db = new DB())
                {
                    usr.user.FirstName = char.ToUpper(usr.user.FirstName[0]) + usr.user.FirstName.Substring(1);
                    usr.user.LastName = char.ToUpper(usr.user.LastName[0]) + usr.user.LastName.Substring(1);
                    // Get the current maximum user id
                    int maxId = db.users.Max(u => u.Id);

                    // Create a new user object with the incremented id
                    usr.user.Id = maxId + 1;

                    db.users.Add(usr.user);
                    db.SaveChanges();
                }
                ModelState.Clear();

            }
            return RedirectToAction("index", "Home", usr);
        }

        public ActionResult LogOut()
        {
            UserID = 0;
            UserEmail = "";
            UserName = "";
            return RedirectToAction("index", "Home");
        }
    }
}