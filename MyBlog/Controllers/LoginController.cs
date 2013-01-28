using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using MyBlog.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public static byte[] StringToBytes(string str)
        {
            char[] charArray = str.ToCharArray();
            byte[] byteArray = new byte[charArray.Length];
            for (int i = 0; i < charArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(charArray[i]);
            }
            return byteArray;
        }

        public static byte[] BytesToHash(byte[] byteArray)
        {
            byte[] result;
            SHA512 shaM = new SHA512Managed();
            result = shaM.ComputeHash(byteArray);
            return result;
        }

        public static bool IsValidEmail(string email)
        {
            var emailAttribute = new EmailAddressAttribute();
            return emailAttribute.IsValid(email);
        }

        public static bool IsValidString(string str)
        {
            string pattern = @"\w{4,64}";
            Match isMatch = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }

        public ActionResult AddNewUser(string name, string email, string password, string confirm)
        {
            if (IsValidString(name) && IsValidString(password) && IsValidEmail(email) && password == confirm)
            {
                using (var c = new MyBlogEntities())
                {
                    byte[] passToByte = StringToBytes(password);
                    User newUser = new User
                    {
                        Name = name,
                        Email = email,
                        Password = BytesToHash(passToByte),
                    };
                    User existingUser = c.Users.Where(u => u.Email == email).SingleOrDefault();
                    if (existingUser == null)
                    {
                        c.Users.Add(newUser);
                        c.SaveChanges();
                        ViewBag.LoginMessage = "User was created successfully.";
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.LoginMessage = "User already exist.";
                        return View("Index");
                    }
                }
            }
            else
            {
                ViewBag.LoginMessage = "Invalid data format.";
                return View("Index");
            }
        }

        public ActionResult Login(string email, string password)
        {
            using (var c = new MyBlogEntities())
            {
                User user = new User();
                user = c.Users.Where(u => u.Email == email).SingleOrDefault();
                if (user != null)
                {
                    byte[] passToByte = StringToBytes(password);
                    byte[] passToHash = BytesToHash(passToByte);
                    bool goodPass = true;
                    for (int i = 0; i < user.Password.Length; i++)
                    {
                        if (user.Password[i] != passToHash[i])
                        {
                            goodPass = false;
                            break;
                        }
                    }

                    if (goodPass)
                    {
                        ViewBag.UserName = user.Name;
                        Response.SetCookie(new HttpCookie("UserName", user.Name));
                        Response.SetCookie(new HttpCookie("UserId", user.Id.ToString()));
                        //Session["Layout"] = new Layout { Name = user.Name, LogOut = "Log out" };
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ViewBag.LoginMessage = "Incorrect password!";
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.LoginMessage = "Incorrect login, user doesn't exist!";
                    return View("Index");
                }
            }
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
