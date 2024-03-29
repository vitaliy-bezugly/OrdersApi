using OrdersApi.Mappers;
using FluentResults;
using MediatR;
using OrdersApi.Contracts.Responses;
using OrdersApi.Entities;
using OrdersApi.Repositories.Abstract;

namespace OrdersApi.Commands.CreateCustomerCommand;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Result<CustomerModel>>
{
    private readonly IRepository<CustomerEntity> _customerRepository;
    public CreateCustomerHandler(IRepository<CustomerEntity> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<CustomerModel>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerEntity = new CustomerEntity
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Orders = new List<OrderEntity>()
        };

        var operationResult = await _customerRepository.AddAsync(customerEntity, cancellationToken);
        
        if (operationResult == false)
            return Result.Fail(new Error("Can not add customer", new Error("Internal server error")));
        return Result.Ok(customerEntity.ToModel());
    }
}