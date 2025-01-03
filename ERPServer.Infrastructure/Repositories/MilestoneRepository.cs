using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repositories
{
    internal sealed class MilestoneRepository : Repository<Milestone, ApplicationDbContext>, IMilestoneRepository
    {
        public MilestoneRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
