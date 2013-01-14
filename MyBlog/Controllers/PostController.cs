using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        public ActionResult Index(int id)
        {
            return View();
        }

    }
}
