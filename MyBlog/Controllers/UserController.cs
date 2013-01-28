using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index(int? id)
        {
            using (var c = new MyBlog.Data.MyBlogEntities())
            {
                id = Int32.Parse(Request.Cookies["UserId"].Value);
                User user = c.Users.Where(u => u.Id == id).Single();
                UserInfo userInfo = new UserInfo
                {
                    Email = user.Email,
                    City = user.City,
                    Country = user.Country.Value.ToString(),
                    Icq = user.Icq,
                    Phone = user.Phone,
                    Sex = UserInfo.GetSex(user.Sex.Value),
                    Skype = user.Skype
                };
                return View("Index", userInfo);
            }
        }
    }
}
