using EcommercePet.Models;
using System.Collections.Generic;

namespace EcommercePet.Repositories
{
    public interface IProdutoRepository 
    {
        void SaveProdutos(List<Itens> itens);
        IList<Produto> GetProdutos();
    }
}