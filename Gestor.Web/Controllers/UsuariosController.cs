using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestor.Web.Extensions;
using Gestor.Infra;

namespace Gestor.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private ISession _session;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository, IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _usuarioRepository = usuarioRepository;
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            var lst = _usuarioRepository.Listar();
            return View(lst);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usu.UsuarioId = _session.GetUsuarioIdLogin();
                    usu.DataAtualizacao = DateTime.UtcNow;
                    var ret = _usuarioRepository.Incluir(usu);
                    _session.MensagemSessao("Retorno", ret);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _session.MensagemSessao("Retorno",new Retorno(ex));
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            var usu = _usuarioRepository.Buscar(id);
            return View(usu);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usu.UsuarioId = _session.GetUsuarioIdLogin();
                    usu.DataAtualizacao = DateTime.UtcNow;
                    var ret = _usuarioRepository.Alterar(usu);
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
            var ret = _usuarioRepository.Excluir(id);
            _session.MensagemSessao("Retorno", ret);

            return RedirectToAction(nameof(Index));
        }
    }
}