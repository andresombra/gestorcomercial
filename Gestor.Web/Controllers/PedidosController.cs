using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestor.Dominio.Entidades;
using Gestor.Dominio.Enums;
using Gestor.Infra;
using Gestor.Infra.Interface;
using Gestor.Infra.Services.Interface;
using Gestor.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;

namespace Gestor.Web.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly IPessoaService _pessoaService;
        private readonly IPedidoItemService _pedidoItemService;
        private readonly IProdutoService _produtoService;
        
        private readonly ISession _session;
        private List<PedidoItem> listaPedidoItem = new List<PedidoItem>();
        public PedidosController(IPedidoService pedido, IPessoaService pessoaService, IPedidoItemService pedidoItemService,
            IProdutoService produtoService, IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _pedidoService = pedido;
            _pessoaService = pessoaService;
            _pedidoItemService = pedidoItemService;
            _produtoService = produtoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo()
        {
            _session.SetObjectAsJson("ListaItem", new List<PedidoItem>());

            ViewBag.Clientes = _pessoaService.SelectListItemPessoas((int)ETipoPessoa.TipoPessoa_Cliente);
            ViewBag.Vendedores = _pessoaService.SelectListItemPessoas((int)ETipoPessoa.TipoPessoa_Vendedor);
            var model = new Pedido();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo(Pedido ped)
        {
            if (ModelState.IsValid)
            {
                ped.DataInclusao = DateTime.UtcNow;
                ped.UsuarioId = _session.GetUsuarioIdLogin();
                var ret = _pedidoService.Incluir(ped);
                
                //Apos gravar Pedido gravar a lista de items
                if (ret.Codigo == 1)
                {
                    var sessionListaPedidoItem = GetSessionListaPedidoItem();
                    sessionListaPedidoItem.ForEach(p => p.PedidoId = ped.Id); //Atualizar PedidoId para os PedidoItem
                    var retItems = _pedidoItemService.IncluirRanger(sessionListaPedidoItem);
                }

                _session.MensagemSessao("Retorno", ret);
                return RedirectToAction(nameof(Novo));
            }
            return View(nameof(Novo));
        }

        private List<PedidoItem> GetSessionListaPedidoItem()
        {
            return _session.GetObjectFromJson<List<PedidoItem>>("ListaItem");
        }

        public IActionResult AdicionarItem(string pedidoId)
        {
            ViewBag.Produtos = _produtoService.SelectListItemProdutos();
            var model = new PedidoItem() { PedidoId = Guid.Parse(pedidoId) };
            return View("~/Views/Pedidos/_AdicionarItem.cshtml",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AdicionarItem(PedidoItem pedItem)
        {
            pedItem.DataInclusao = DateTime.UtcNow;
            pedItem.UsuarioId = _session.GetUsuarioIdLogin();
            pedItem.Produto = _produtoService.Buscar(pedItem.ProdutoId);

            //Carregando items em sessao
            List<PedidoItem> listaPedidoItem = GetSessionListaPedidoItem();
            listaPedidoItem.Add(pedItem);

            _session.SetObjectAsJson("ListaItem", listaPedidoItem);

            //Retornando somente o item incluido para ser adicionado ao table da lista de items
            return Json(JsonConvert.SerializeObject(pedItem));
        }

        public IActionResult PedidoRapido()
        {
            var ped = new Pedido();
            ped.Situacao = EPedidoSituacao.PEDIDO_EM_ABERTO;
            ped.TipoPedido = ETipoPedido.PEDIDO_VENDA_ONLINE;

            ped.ListaProduto = _produtoService.Listar().Where(x => x.FornecedorId == 2).ToList();

            return View(ped);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PedidoRapido(Pedido ped)
        {
            ped.DataInclusao = DateTime.UtcNow;
            ped.UsuarioId = _session.GetUsuarioIdLogin();
            //var ret = _service._PedidoItemRepository.Incluir(ped);
            //return RedirectToAction(nameof(AdicionarItem), new { pedidoId = ped.PedidoId });
            return View(nameof(PedidoConfirmado));
        }

        public IActionResult PedidoConfirmado()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AdicionarItem(PedidoItem ped)
        //{
        //    ped.DataInclusao = DateTime.UtcNow;
        //    ped.UsuarioId = _session.GetUsuarioIdLogin();
        //    var ret = _service._PedidoItemRepository.Incluir(ped);
        //    return RedirectToAction(nameof(AdicionarItem), new { pedidoId = ped.PedidoId });
        //}


    }
}