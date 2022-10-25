using Customer.Domain.Cadastro.Enums;


namespace Customer.Domain.Cadastro
{
    public class ClienteFilter
    {
        public string Nome { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Cpf { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public TipoSexoEnum? Sexo { get; set; }
    }
}
