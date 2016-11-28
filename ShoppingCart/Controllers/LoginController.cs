using ShoppingCart.Enums;
using ShoppingCart.Interfaces;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        private ShoppingCartDb shoppingCartDb = new ShoppingCartDb();
        private IUserRepository UserRepository;

        public LoginController()
        {
            this.UserRepository = new UserRepository(shoppingCartDb);
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        private bool IsValid(string username, string password)
        {
            var dbUser = shoppingCartDb.users.Where(i=>i.username == username && i.password == password).FirstOrDefault();
            return dbUser != null;
        }
        
        
        [HttpPost]
        public ActionResult checkLogin()
        {
            string name = Request.Form["name"];
            string pass = Request.Form["pass"];
            
            if (IsValid(name, pass))
            {
                Session["username"] = name;
                Session["password"] = pass;
                HttpCookie cookie = new HttpCookie("UserLogin");
                cookie["username"] = name;
                cookie["password"] = pass;
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Response.Cookies.Add(cookie);
                //Response.Redirect(Request.RawUrl);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index","Erro");
        }

        public ActionResult LogOut()
        {
            if (Request.Cookies["UserLogin"] != null)
            {
                var user = new HttpCookie("UserLogin")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Value = null
                };
                Session.Abandon();
                Response.Cookies.Add(user);

            }
            return RedirectToAction("Index","Login");
        }

        private bool isValidUserName(string username)
        {

            var dbUser = shoppingCartDb.users.Where(i => i.username == username ).FirstOrDefault();
            return dbUser == null;
        }

        public bool insert( user user )
        {
            try
            {
                UserRepository.InsertUser(user);
                UserRepository.Save();
                
            }
            catch (Exception)
            {

                return false;
            }
            return true;   
        }

        public ActionResult doRegister()
        {
            
            string username = Request.Form["username"];
            string name = Request.Form["name"];
            string age = Request.Form["age"];
            string password = Request.Form["password"];
            string userAddress = Request.Form["userAddress"];
            string phoneNumber = Request.Form["phoneNumber"];

            if (isValidUserName(username)){
                user user = new user();
                user.username = username;
                user.NAME = name;
                user.age = Int32.Parse(age);
                user.user_address = userAddress;
                user.password = password;
                user.phonenumber = Int32.Parse(phoneNumber);
                user.roleid = (int)Role.USER;
                insert(user);
                return RedirectToAction("Index", "RegisterSuccess");
            }
            return RedirectToAction("Index", "RegisterFail");

        }








    }
}