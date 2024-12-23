using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityReports.DeleteQualityReportsById;

public sealed record DeleteQualityReportByIdCommand(
    Guid Id) : IRequest<Result<string>>;
