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

namespace WebUI.Controllers
{
    public class GameController : Controller
    {
        EFGameRepository repository = new EFGameRepository();

        private int pages = 3;

        
        public ActionResult List(int page = 1)
        {
            IEnumerable<Game> games = repository.Games.ToList();

            return View(games.ToPagedList(page, pages));
        }
    }
}