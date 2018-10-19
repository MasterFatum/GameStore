using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GameStore.Domain.Entities
{
    public class Game
    {
        [HiddenInput(DisplayValue = false)]
        public int GameId { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Display(Name = "Цена (руб)")]
        public decimal Price { get; set; }
    }
}
