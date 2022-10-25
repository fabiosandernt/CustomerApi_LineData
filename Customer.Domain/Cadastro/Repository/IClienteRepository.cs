using Customer.CrossCutting.Repository;


namespace Customer.Domain.Cadastro.Repository
{
    public interface IClienteRepository: IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> ObterTodosClientes();
        Task<IEnumerable<Cliente>> ObterTodosClientesPorCpf(string cpf);
    }
}
