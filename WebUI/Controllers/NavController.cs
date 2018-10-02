using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using GameStore.Domain.Entities;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        EFGameRepository repository = new EFGameRepository();

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.Category = category;

            IEnumerable<string> categories = repository.Games.Select(game => game.Category).Distinct().OrderBy(game => game);

            return PartialView(categories);
        }
    }
}