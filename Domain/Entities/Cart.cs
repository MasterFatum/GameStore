using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace Domain.Entities
{
    public class CartLine
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Game game, int quantity)
        {
            CartLine line = lineCollection.FirstOrDefault(g => g.Game.GameId == game.GameId);

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Game = game,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public void RemoveLine(Game game)
        {
            lineCollection.RemoveAll(l => l.Game.GameId == game.GameId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Game.Price * e.Quantity);
        }

        public IEnumerable<CartLine> Lines => lineCollection;
    }
}
