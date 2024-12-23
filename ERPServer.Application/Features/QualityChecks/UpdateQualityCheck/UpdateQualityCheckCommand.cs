using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityChecks.UpdateQualityCheck;

public sealed record UpdateQualityCheckCommand(
    Guid Id,
    DateTime CheckDate,
    Guid ReportId,
    string Checkpoint,
    string Result) : IRequest<Result<string>>;
