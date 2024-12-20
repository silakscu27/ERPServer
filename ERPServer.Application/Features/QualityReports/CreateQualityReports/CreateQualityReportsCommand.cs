using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityReports.CreateQualityReports;

public sealed record CreateQualityReportsCommand(
    string Name,
    DateTime CreatedDate,
    string? Description) : IRequest<Result<string>>;
