using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using GameStore.Domain.Abstract;
using GameStore.Domain;

namespace WebUI.Controllers
{
    public class GameController : Controller
    {
        private IGameRepository repository;
        
        public ActionResult List()
        {
            return View(repository.Games);
        }
    }
}