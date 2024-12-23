using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityChecks.GetAllQualityCheck;

public sealed record GetAllQualityCheckQuery() : IRequest<Result<List<QualityCheck>>>;
