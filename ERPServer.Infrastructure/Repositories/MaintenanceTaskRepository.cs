using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repositories;
internal sealed class MaintenanceTaskRepository : Repository<MaintenanceTask, ApplicationDbContext>, IMaintenanceTaskRepository
{
    public MaintenanceTaskRepository(ApplicationDbContext context) : base(context)
    {
    }
}
