using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await categoryRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (category is null)
        {
            return Result<string>.Failure("Kategori bulunamadı");
        }

        bool isNameExists = await categoryRepository.AnyAsync(p => p.Name == request.Name && p.Id != request.Id, cancellationToken);
        if (isNameExists)
        {
            return Result<string>.Failure("Aynı isimde başka bir kategori zaten mevcut");
        }

        mapper.Map(request, category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Kategori başarıyla güncellendi");
    }
}
