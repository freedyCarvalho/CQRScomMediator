using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Commands.Handlers;
using Shop.Domain.Commands.Requests;
using Shop.Domain.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    // Para usar CQRS não precisa usar MediatR, é comum mas não é obrigatório e sem o EventSource.
    // Mediator é um padrão para a abstração de comunicação (Mediador, faz a mediação)
    
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        [HttpPost]   
        [Route("")]
        // O Controller fica bem mais enxuto porque a regra de negócio sai do Controller e vai para o Handler

        // Abaixo o ICreateCustomerHandler é quem está gerenciando a variável command
        public CreateCustomerResponse Create(
            [FromServices]ICreateCustomerHandler handler,// para fazer a injeção de dependência
            [FromBody] CreateCustomerRequest command
            ){
            return handler.Handle(command);
        }
    }
}
