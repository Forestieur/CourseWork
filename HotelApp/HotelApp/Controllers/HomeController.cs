namespace HotelApp.PL.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using HotelApp.BLL.DTO;
    using System.Collections.Generic;
    using HotelApp.BLL.Interfaces;

    public class HomeController : Controller
    {
        IBookingService db;
        public static int currentUserId;
        public static string currentUserLogin;

        public HomeController(IBookingService service)
        {
            db = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Login 
        [HttpPost]
        public ActionResult Indeх(UserDTO user)
        {   
            string login = user.Login; 
            string password = user.Password;
            List<UserDTO> users = db.GetAllUsers().ToList();
            for (int i = 0; i < 4; i++)
            {
                if (login == users[i].Login && password == users[i].Password && users[i].Role.Equals("admin"))
                {
                    // Enter as Admin
                    currentUserId = users[i].id;
                    currentUserLogin = users[i].Login;
                    return RedirectToAction("../Suite/ListSuite");
                }
                else if (login == users[i].Login && password == users[i].Password &&  users[i].Role.Equals("user"))
                {
                    // Enter as User
                    currentUserId = users[i].id;
                    currentUserLogin = users[i].Login;
                    return RedirectToAction("../Suite/ListSuite");
                }
                else
                {
                  

                    
                    ViewBag.errorMsg = "Sorry, your password or login is wrong. Try again.";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDTO reg)
        {
            reg.Role = "user";
            reg.DateRegister =  "123";
            if (reg.Password != reg.RePassword)
            {
                ViewBag.err = "Password and RePassword are NOT equals!";
                return View();
            }
            else
            {
                db.AddUser(reg);
                db.Save();
                return RedirectToAction("../Home/Index"); // login
            }
        }
        #region }
        [HttpPost]
        public ActionResult Index(UserDTO user)
        {
            string login = user.Login;
            string password = user.Password;
            List<UserDTO> users = db.GetAllUsers().ToList();
            for (int i = 0; i < 4; i++)
            {
                if (login == users[i].Login && password == users[i].Password && users[i].Role.Equals("admin"))
                {
                    // Enter as Admin
                    currentUserId = users[i].id;
                    currentUserLogin = users[i].Login;
                    return RedirectToAction("../Suite/ListSuite");
                }
                else if (login == "Forest" && password == "123")
                {
                    // Enter as User
                    currentUserId = users[i].id;
                    currentUserLogin = users[i].Login;
                    return RedirectToAction("../Suite/ListSuite");
                }
                else
                {



                    ViewBag.errorMsg = "Sorry, your password or login is wrong. Try again.";
                }
            }
            return View();
        }
        #endregion 
    }
}