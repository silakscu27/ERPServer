using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityChecks.DeleteQualityCheckById;

public sealed record DeleteQualityCheckByIdCommand(
    Guid Id) : IRequest<Result<string>>;