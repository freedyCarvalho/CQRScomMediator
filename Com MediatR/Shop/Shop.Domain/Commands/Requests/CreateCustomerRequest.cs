using MediatR;
using Shop.Domain.Commands.Response;

namespace Shop.Domain.Commands.Requests
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse> // Usamos o IRequest e informamos que o retorno dele será um CreateCustomerResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
