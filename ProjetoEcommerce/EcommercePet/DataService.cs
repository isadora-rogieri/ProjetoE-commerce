using EcommercePet.Models;
using EcommercePet.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EcommercePet
{
    
        class DataService : IDataService
        {
            private readonly ApplicationContext contexto;
            private readonly IProdutoRepository produtoRepository;

            public DataService(ApplicationContext contexto,
                        IProdutoRepository produtoRepository)
            {
                this.contexto = contexto;
                this.produtoRepository = produtoRepository;
            }

            public void InicializaDB()
            {
                contexto.Database.Migrate();

                List<Itens> produtos = GetItens();

                produtoRepository.SaveProdutos(produtos);
            }

        private static List<Itens> GetItens()
        {
            var json = File.ReadAllText("itens.json");
            var itens = JsonConvert.DeserializeObject<List<Itens>>(json);
            return itens;
        }         

       
    }
    }