using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using GameStore.Domain.Entities;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        EFGameRepository context = new EFGameRepository();


        public ActionResult Index()
        {
            return View(context.Games);
        }

        public ViewResult Edit(int gameId)
        {
            Game game = context.Games.FirstOrDefault(g => g.GameId == gameId);

            return View(game);
        }

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                context.SaveGame(game);
                TempData["message"] = $"Изменения в игре \"{game.Name}\" были сохранены";
                return RedirectToAction("Index");
            }
            else
            {
                return View(game);
            }
        }
    }
}