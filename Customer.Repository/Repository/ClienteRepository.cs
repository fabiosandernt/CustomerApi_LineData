using Customer.Domain.Cadastro;
using Customer.Domain.Cadastro.Repository;
using Customer.Repository.Context;
using Customer.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repository.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CustomerContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> ObterTodosClientes()
        {
            return await this.Query.Include(x => x.Cpf.Numero).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ObterTodosClientesPorCpf(string cpf)
        {
            return await this.Query.Where(x => x.Cpf.Numero == cpf).ToListAsync();  
        }
    }
}
