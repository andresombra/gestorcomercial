using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Dominio.Entidades;
using System.Globalization;
using Gestor.Infra.Interface;
using Microsoft.AspNetCore.Http;
using Gestor.Web.Extensions;

namespace Gestor.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly GestorContext _context;
        private readonly IProdutoRepository _produto;
        private readonly ISession _session;
        public ProdutosController(GestorContext context, IProdutoRepository produto, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _produto = produto;
            _session = httpContextAccessor.HttpContext.Session;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var gestorContext = _context.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor).Include(p => p.Unidade);
            return View(await gestorContext.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .Include(p => p.Unidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        void CarregarSelectList()
        {
            ViewData["CategoriaId"]  = new SelectList(_context.Categorias, "Id", "NomeCategoria");
            ViewData["FornecedorId"] = new SelectList(_context.Pessoas, "Id", "Nome");
            ViewData["UnidadeId"]    = new SelectList(_context.Unidades, "Id", "NomeUnidade");
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            CarregarSelectList();    
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.DataInclusao = DateTime.UtcNow;
                produto.UsuarioId = _session.GetUsuarioIdLogin();
                var ret = await _produto.IncluirAsync(produto);
                _session.MensagemSessao("Retorno", ret);
                return RedirectToAction(nameof(Index));
            }
            CarregarSelectList();
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            CarregarSelectList();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    produto.UsuarioId = _session.GetUsuarioIdLogin();
                    var ret = _produto.Alterar(produto);
                    _session.MensagemSessao("Retorno", ret);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            CarregarSelectList();
            return View(produto);
        }

        public IActionResult Excluir(int id)
        {
            var ret = _produto.Excluir(id);
            _session.MensagemSessao("Retorno", ret);

            return RedirectToAction(nameof(Index));
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ret = _produto.Excluir(id);
            _session.MensagemSessao("Retorno", ret);

            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
