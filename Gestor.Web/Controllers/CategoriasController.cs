using System;
using System.Collections.Generic;
using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestor.Web.Extensions;
using Gestor.Infra;

namespace Gestor.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private ISession _session;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository, IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _categoriaRepository = categoriaRepository;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            var lst = _categoriaRepository.Listar();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cat.DataInclusao = DateTime.UtcNow;
                    cat.UsuarioId = _session.GetUsuarioIdLogin();
                    var ret = _categoriaRepository.Incluir(cat);
                    _session.MensagemSessao("Retorno", ret);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _session.MensagemSessao("Retorno", new Retorno(ex));
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var usu = _categoriaRepository.Buscar(id);
            return View(usu);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cat.DataAtualizacao = DateTime.UtcNow;
                    cat.UsuarioId = _session.GetUsuarioIdLogin();
                    var ret = _categoriaRepository.Alterar(cat);
                    _session.MensagemSessao("Retorno", ret);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _session.MensagemSessao("Retorno", new Retorno(ex));
                return View();
            }
        }

        public IActionResult Excluir(int id)
        {
            var ret = _categoriaRepository.Excluir(id);
            _session.MensagemSessao("Retorno", ret);

            return RedirectToAction(nameof(Index));
        }
    }
}
