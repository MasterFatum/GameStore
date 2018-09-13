﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using GameStore.Domain.Abstract;
using GameStore.Domain;

namespace WebUI.Controllers
{
    public class GameController : Controller
    {
        EFGameRepository repository = new EFGameRepository();

        public int pageSize = 5;

        public ActionResult List(int page = 1)
        {
            return View(repository.Games.OrderBy(game => game.GameId).Skip((page - 1) * pageSize).Take(pageSize));
        }
    }
}