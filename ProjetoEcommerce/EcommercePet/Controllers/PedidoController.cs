using EcommercePet.Models;
using EcommercePet.Models.ViewModels;
using EcommercePet.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePet.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository,
            IItemPedidoRepository itemPedidoRepository
            )
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                pedidoRepository.AddItem(codigo);
            }


            List<ItemPedido> itens = pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }

        public IActionResult Cadastro()
        {
            var pedido = pedidoRepository.GetPedido();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            return View(pedido.Cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //protegendo os dados
        public IActionResult Resumo(Cliente cadastro)
        {

            if (ModelState.IsValid)
            {
                return View(pedidoRepository.UpdateCadastro(cadastro));
            }
            else
            {
                TempData["ERRO"] = "Campos com dados Invalidos";
                this.ModelState.AddModelError("ERRO", "Campos com dados Invalidos");
                return RedirectToAction("Cadastro");
            }
        }

        //envia dados no corpo da requisição
        [HttpPost]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody] ItemPedido itemPedido)
        {
            return pedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}