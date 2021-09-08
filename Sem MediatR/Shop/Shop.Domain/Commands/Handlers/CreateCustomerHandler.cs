using Shop.Domain.Commands.Requests;
using Shop.Domain.Commands.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Commands.Handlers
{
    public class CreateCustomerHandler : ICreateCustomerHandler
    {
        public CreateCustomerResponse Handle(CreateCustomerRequest request)
        {
            // Verifica se o cliente já está cadastrado
            // Valida os dados
            // Insere o cliente
            // Enviar o e-mail de boas-vindas

            return new CreateCustomerResponse
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Date = DateTime.Now
            };
        }
    }
}
