using Shop.Domain.Commands.Requests;
using Shop.Domain.Commands.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Commands.Handlers
{
    public interface ICreateCustomerHandler
    {
        CreateCustomerResponse Handle(CreateCustomerRequest request);
    }
}
