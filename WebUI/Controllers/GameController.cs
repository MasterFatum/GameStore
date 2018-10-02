using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using GameStore.Domain.Abstract;
using GameStore.Domain;
using GameStore.Domain.Entities;
using PagedList;
using PagedList.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class GameController : Controller
    {
        EFGameRepository repository = new EFGameRepository();

        private int pages = 3;

        
        public ActionResult List(string category, int page = 1)
        {
            IEnumerable<Game> games = repository.Games
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(game => game.GameId);

            ViewBag.IPaggingModel = games;

            return View(games.ToPagedList(page, pages));
        }
    }
}