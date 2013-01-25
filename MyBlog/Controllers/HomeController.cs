using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Data;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var c = new MyBlogEntities())
            {
                
            }
            return Redirect("/Login");
        }
    }
}
