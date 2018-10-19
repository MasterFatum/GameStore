using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using GameStore.Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {

        EFGameRepository repository = new EFGameRepository();

        EmailOrderProcessor emailOrderProcessor = new EmailOrderProcessor(new EmailSettings());


        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }


        public RedirectToRouteResult RemoveFromCart(Cart cart, int gameId, string returnUrl)
        {
            Game game = repository.Games.FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                cart.RemoveLine(game);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult AddToCart(Cart cart, string gameIdString, string returnUrl)
        {
            int gameId = Convert.ToInt32(gameIdString);

            Game game = repository.Games.FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                cart.AddItem(game, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpGet]
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                emailOrderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}