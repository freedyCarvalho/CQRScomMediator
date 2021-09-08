using MediatR;
using Shop.Domain.Commands.Requests;
using Shop.Domain.Commands.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Domain.Commands.Handlers
{
    // IRequestHandler recebe um CreateCustomerRequest e retorna um CreateCustomerResponse
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        // Verifica se o cliente já está cadastrado
        // Valida os dados
        // Insere o cliente
        // Enviar o e-mail de boas-vindas

        // CancellationToken serve para cancelarmos a requisição
        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            var result = new CreateCustomerResponse
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Date = DateTime.Now
            };

            return await Task.FromResult(result);
        }
    }
}
