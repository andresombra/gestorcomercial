using Gestor.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor.Web.ViewComponents
{
    //[ViewComponent(Name = "ComboxEnum")]
    public class ComboxEnum : ViewComponent
    {
        public IViewComponentResult Invoke(string nomeLabel, string nomeCampo, List<SelectListItem> lista)
        {
            var model = new EnumViewModel() {NomeLabel = nomeLabel, Campo = nomeCampo, ListaEnum = lista };

            return View(model);
        }
    }
}
