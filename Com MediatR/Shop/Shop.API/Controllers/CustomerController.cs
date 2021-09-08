using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Commands.Requests;
using Shop.Domain.Commands.Response;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    // Para usar CQRS não precisa usar MediatR, é comum mas não é obrigatório e sem o EventSource.
    // Mediator é um padrão para a abstração de comunicação (Mediador, faz a mediação)

    // Podemos criar um BaseController para:
    // validar os comandos que entram para o mediator
    // que chama o MediatR de qualquer controle que recebe

    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        [HttpPost]   
        [Route("")]
        // O Controller fica bem mais enxuto porque a regra de negócio sai do Controller e vai para o Handler

        // Abaixo o ICreateCustomerHandler é quem está gerenciando a variável command
        public async Task<CreateCustomerResponse> Create(
            [FromServices]IMediator mediator,// para fazer a injeção de dependência
            [FromBody] CreateCustomerRequest command
            ){
            
            return await mediator.Send(command);
        }
    }
}
