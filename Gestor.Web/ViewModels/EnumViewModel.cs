using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor.Web.ViewModels
{
    public class EnumViewModel
    {
        public string NomeLabel { get; set; }
        public string Campo { get; set; }
        public List<SelectListItem> ListaEnum { get; set; }
    }
}
