using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        EFGameRepository context = new EFGameRepository();

        // GET: Admin
        public ActionResult Index()
        {
            return View(context.Games);
        }
    }
}