using EcommercePet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePet.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> Update(int clienteId, Cliente novoCadastro);
    }

    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IPedidoRepository pedidoRepository;
        public ClienteRepository(ApplicationContext contexto) : base(contexto)
        {
        }
        private void SetClienteId(int clienteId)
        {
            contextAccessor.HttpContext.Session.SetInt32("clienteId", clienteId);
        }

        public async Task<Cliente> Update(int clienteId, Cliente novoCadastro)
        {
            var clienteDB =
                await dbSet.Where(u => u.Id == clienteId)
                .SingleOrDefaultAsync();

            if (clienteDB == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            clienteDB.Update(novoCadastro);
            await contexto.SaveChangesAsync();
            return clienteDB;


        }
    }
}
