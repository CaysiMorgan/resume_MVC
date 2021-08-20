using resume_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace resume_MVC.Controllers
{ 
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: UserDetail
        //Login Authentication
        //Only able access this Actionmethod when User Log in
        [Authorize]
        public ActionResult UserDetail()
        {
            return View();
        }
        // GET:Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Post:Login 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel LoginViewModel)
        {
            if (IsAuthenitcatedUser(LoginViewModel.Email, LoginViewModel.Password))
            {
                //MVC and Login Authentication
                FormsAuthentication.SetAuthCookie(LoginViewModel.Email, false);
                return RedirectToAction("UserDetail", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Your credentail is incorrect");
            }
            return View(LoginViewModel);
        }
        // GET:Register return view
        [HttpGet]
        public ActionResult UserRegistration()
        {
            return View();
        }
        // Post:Register 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserRegistration(RegistrationViewModel registrationView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!IsEmailExist(registrationView.Email))
                    {
                        using (DemoDataBaseEntities db = new DemoDataBaseEntities())
                        {  
                            Company_Users userobj = new Company_Users
                            {
                                Email = registrationView.Email,
                                Name = registrationView.Name,
                                //for encryption you should use a strong and secure Algorithm
                                // I'm simply using Base64 for explanation purpose
                                Encryptedpassword = Base64Encode(registrationView.Password),
                                Address = registrationView.Address
                            };
                            db.Company_Users.Add(userobj);
                            if (db.SaveChanges() > 0)
                            {
                                //Set MVC and Login Authentication
                                FormsAuthentication.SetAuthCookie(registrationView.Email, false);
                                return RedirectToAction("UserDetail", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Something went wrong please try again later!");
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "email already exist please try with diffrent one!");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Model is Invalid");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View();
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsEmailExist(string email)
        {
            bool IsEmailExist = false;
            using (DemoDataBaseEntities db = new DemoDataBaseEntities())
            {
                int count = db.Company_Users.Where(a => a.Email == email).Count();
                if (count > 0)
                {
                    IsEmailExist = true;
                }
            }
            return IsEmailExist;
        }
        private bool IsAuthenitcatedUser(string email, string password)
        {
            var encryptpassowrd = Base64Encode(password);
            bool IsValid = false;
            using (DemoDataBaseEntities db = new DemoDataBaseEntities())
            {
                int count = db.Company_Users.Where(a => a.Email == email && a.Encryptedpassword == encryptpassowrd).Count();
                if (count > 0)
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }
        private static string Base64Encode(string PlainPassword)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(PlainPassword);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}