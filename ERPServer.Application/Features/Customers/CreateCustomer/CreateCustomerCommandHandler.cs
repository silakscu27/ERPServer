using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Customers.CreateCustomer;

internal sealed class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateCustomerCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        bool isTaxNumberExists = await customerRepository.AnyAsync(p => p.TaxNumber == request.TaxNumber, cancellationToken);
        if (isTaxNumberExists)
        {
            return Result<string>.Failure("Vergi numarası daha önce kaydedilmiş");
        }

        bool isContactExists = await customerRepository.AnyAsync(p => p.PhoneNumber == request.PhoneNumber || p.Email == request.Email, cancellationToken);
        if (isContactExists)
        {
            return Result<string>.Failure("Telefon numarası veya e-posta zaten kayıtlı");
        }

        Customer customer = mapper.Map<Customer>(request);

        await customerRepository.AddAsync(customer, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Müşteri kaydı başarıyla tamamlandı";
    }
}
