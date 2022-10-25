using Customer.CrossCutting.Entity;
using Customer.Domain.Account;
using Customer.Domain.Cadastro.Enums;
using Customer.Domain.Cadastro.ValueObject;
using Customer.Domain.Helpers.Extension;

namespace Customer.Domain.Cadastro
{

    public class Cliente : Entity<Guid>
    {
        
        public string Nome { get; private set; }
        public Cpf Cpf { get; private set; }
        public Endereco Endereco { get; private set; }
        public DateTime Nascimento { get; private set; }
        public TipoSexoEnum Sexo { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        //Para o EF
        protected Cliente() { }

        public int Idade => Nascimento.CalculaAge();

        public  Cliente(string nome, Endereco endereco, Cpf cpf, TipoSexoEnum sexo, DateTime nascimento, Guid usuarioId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Sexo = sexo;
            Endereco = endereco;
            Cpf = cpf;
            Nascimento = nascimento;
            UsuarioId = usuarioId;
        }

        public void SetUsuarioId(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }

    }
}
