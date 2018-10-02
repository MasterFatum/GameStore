using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameStore.Domain.Entities;
using PagedList;

namespace WebUI.Models
{
    public class GamesListViewModel
    {
        public IEnumerable<Game> Games { get; set; }

        public string CurrentCategory { get; set; }

        public IPagedList<Game> GamesPadding { get; set; }

    }
}