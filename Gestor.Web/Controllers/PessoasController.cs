using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Gestor.Infra.Interface;
using Gestor.Web.Extensions;
using MySql.Data.MySqlClient;
using Gestor.Infra;
using Gestor.Infra.Repository;
using Gestor.Infra.Services.Interface;

namespace Gestor.Web.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaService _pessoa;
        private readonly ITipoPessoaRepository _tipopessoa;
        private readonly ISession _session;

        public PessoasController(IPessoaService pessoa, ITipoPessoaRepository tipopessoa, IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _pessoa = pessoa;
            _tipopessoa = tipopessoa;
        }

        // GET: Pessoas
        public IActionResult Index()
        {
            var lst = _pessoa.ListaPessoasTipoPessoa();
            return View(lst);
        }

        void ListarTipoPessoa()
        {
            var lst_tipopessoa = _tipopessoa.Listar();
            ViewBag.TipoPessoa = lst_tipopessoa
                .Select(s => new SelectListItem() { Text = s.NomeTipoPessoa, Value = s.Id.ToString() }).ToList();
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            ListarTipoPessoa();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pessoa pes)
        {
            if (ModelState.IsValid)
            {
                pes.DataInclusao = DateTime.UtcNow;
                pes.UsuarioId = _session.GetUsuarioIdLogin();
                var ret = _pessoa.Incluir(pes);
                _session.MensagemSessao("Retorno", ret);
                return RedirectToAction(nameof(Index));
            }
            return View("Create");
        }

        public IActionResult Edit(int id)
        {
            var pes = _pessoa.Buscar(id);
            ListarTipoPessoa();
            return View("Edit", pes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pessoa pes)
        {
            if (ModelState.IsValid)
            {
                pes.DataAtualizacao = DateTime.UtcNow;
                pes.UsuarioId = _session.GetUsuarioIdLogin();
                var ret = _pessoa.Alterar(pes);
                _session.MensagemSessao("Retorno", ret);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", pes);
        }

        public IActionResult Excluir(int id)
        {
            var ret = _pessoa.Excluir(id);
            _session.MensagemSessao("Retorno", ret);

            return RedirectToAction(nameof(Index));
        }
    }
}
