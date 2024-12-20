using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityReports.UpdateQualityReports;

public sealed record UpdateQualityReportCommand(
    Guid Id,
    string Name,
    string? Description) : IRequest<Result<string>>;
