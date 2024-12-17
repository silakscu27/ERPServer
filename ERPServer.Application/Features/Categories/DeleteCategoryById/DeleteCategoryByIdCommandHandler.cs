using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Categories.DeleteCategoryById;

internal sealed class DeleteCategoryByIdCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (category is null)
        {
            return Result<string>.Failure("Kategori bulunamadı");
        }

        bool hasAssociatedStocks = category.Stocks.Any();
        if (hasAssociatedStocks)
        {
            return Result<string>.Failure("Bu kategoriye bağlı stoklar bulunduğu için silinemiyor");
        }

        categoryRepository.Delete(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Kategori başarıyla silindi");
    }
}
