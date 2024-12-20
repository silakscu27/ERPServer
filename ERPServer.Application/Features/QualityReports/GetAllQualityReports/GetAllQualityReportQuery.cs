using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityReports.GetAllQualityReports;

public sealed record GetAllQualityReportQuery() : IRequest<Result<List<QualityReport>>>;