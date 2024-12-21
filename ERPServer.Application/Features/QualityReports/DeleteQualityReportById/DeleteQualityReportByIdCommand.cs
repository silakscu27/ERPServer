using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityReports.DeleteQualityReportsById;

public sealed record DeleteQualityReportsByIdCommand(
    Guid Id) : IRequest<Result<string>>;
