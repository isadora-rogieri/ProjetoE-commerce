using EcommercePet.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePet.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }



        public void SaveProdutos(List<Itens> itens)
        {

            foreach (var item in itens)
            {
                if (!dbSet.Where(
                    p => p.Codigo == item.Codigo).Any()) {
                    dbSet.Add(new Produto(item.Codigo, item.Nome, item.Descricao, item.Preco));
                }
          
            }
            contexto.SaveChanges();
        }
        
    }


    public class Itens
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
   
}
