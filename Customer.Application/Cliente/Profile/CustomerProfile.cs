using Customer.Domain.Account;

using static Customer.Application.Cliente.Dto.UsuarioDto;
using static Customer.Application.Cliente.Dto.ClienteDto;
using Customer.Domain.Helpers.Extension;

namespace Customer.Application.Cliente.Profile
{
    public class CustomerProfile: AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<UsuarioInputDto, Usuario>();

            CreateMap<Usuario, UsuarioOutputDto>();

            CreateMap<ClienteInputDto, Customer.Domain.Cadastro.Cliente>().ForMember(x => x.Id, x => x.MapFrom(x => Guid.NewGuid()));

            CreateMap<Customer.Domain.Cadastro.Cliente, ClienteOutputDto>();
        }        
                    
    }
}
