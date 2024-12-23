using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityChecks.CreateQualityCheck;

public sealed record CreateQualityCheckCommand(
    DateTime CheckDate,
    Guid ReportId,
    string Checkpoint,
    string Result) : IRequest<Result<string>>;
