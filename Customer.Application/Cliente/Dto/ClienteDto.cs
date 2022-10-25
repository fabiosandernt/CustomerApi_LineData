using Customer.Domain.Cadastro.Enums;
using Customer.Domain.Cadastro.ValueObject;


namespace Customer.Application.Cliente.Dto
{
    public class ClienteDto
    {
        public record ClienteInputDto(Guid? Id, string Nome, Cpf Cpf, Endereco Endereco, TipoSexoEnum Sexo, DateTime Nascimento);
        public record ClienteOutputDto(Guid Id, string Nome, Cpf Cpf, Endereco Endereco, TipoSexoEnum Sexo, DateTime Nascimento);
    }
}
