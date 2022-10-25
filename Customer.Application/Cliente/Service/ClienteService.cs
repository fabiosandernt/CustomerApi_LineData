using AutoMapper;
using Customer.Application.Cliente.Dto;
using Customer.Domain.Account;
using Customer.Domain.Account.Repository;
using Customer.Domain.Cadastro.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using static Customer.Application.Cliente.Dto.ClienteDto;


namespace Customer.Application.Cliente.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
     
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            this._clienteRepository = clienteRepository;
         
            this._mapper = mapper;
        }

        public async Task<ClienteOutputDto> Criar(ClienteInputDto dto, Guid usuarioId)
        {
            if (await _clienteRepository.AnyAsync(x => x.Cpf.Numero == dto.Cpf.Numero))
                throw new Exception("Já existe um cliente cadastrado com o mesmo CPF");

            var cliente = this._mapper.Map<Customer.Domain.Cadastro.Cliente>(dto);
            cliente.SetUsuarioId(usuarioId);

            await this._clienteRepository.Save(cliente);
            return this._mapper.Map<ClienteOutputDto>(cliente);
        }
        public async Task<ClienteOutputDto> Deletar(Guid id)
        {
            var cliente = await _clienteRepository.Get(id);

            await this._clienteRepository.Delete(cliente);

            return this._mapper.Map<ClienteOutputDto>(cliente);                          
        }

        public async Task<ClienteOutputDto> Atualizar(ClienteInputDto dto)
        {
            if (await _clienteRepository.AnyAsync(x => x.Cpf.Numero == dto.Cpf.Numero))
            {
                var cliente = await _clienteRepository.Get(dto.Id);

                cliente.Update(dto.Nome, dto.Endereco, dto.Cpf, dto.Sexo, dto.Nascimento);

                await this._clienteRepository.Update(cliente);
                return this._mapper.Map<ClienteOutputDto>(cliente);
            }
            else
            {
                throw new Exception("Este cliente não existe.");
            }
        }
        public async Task<List<ClienteOutputDto>> ObterTodos()
        {
            var cliente = await this._clienteRepository.GetAll();
            return this._mapper.Map<List<ClienteOutputDto>>(cliente);
        }

        public async Task<ClienteOutputDto> ObterPorId(Guid id)
        {
            var cliente = await this._clienteRepository.Get(id);
            return this._mapper.Map<ClienteOutputDto>(cliente);
        }


    }


}
