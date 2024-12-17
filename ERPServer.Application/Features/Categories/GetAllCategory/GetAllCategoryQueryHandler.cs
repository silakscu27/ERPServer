using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Categories.GetAllCategory;

internal sealed class GetAllCategoryQueryHandler(
    ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoryQuery, Result<List<Category>>>
{
    public async Task<Result<List<Category>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        List<Category> categories = await categoryRepository.GetAll()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        return categories.Any()
            ? Result<List<Category>>.Succeed(categories)
            : Result<List<Category>>.Failure("Kategori bulunamadı");
    }
}
