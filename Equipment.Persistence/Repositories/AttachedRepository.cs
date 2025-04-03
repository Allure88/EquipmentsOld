using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.ExternalProgrammsInfos;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Persistence.Repositories
{
    public class AttachedRepository(EquipmentDBContext dBContext) : GenericRepository<ExternalProgrammsInfo>(dBContext), IAttachedRepository
    {
        public override async Task<List<ExternalProgrammsInfo>> GetAll()
        {
            return await _dbContext.ExternalProgrammsInfos
                .Include(at => at.Eplain)
                    .ThenInclude(ep => ep.EplainPorts)
                        .ThenInclude(ep => ep.Designation)
                .ToListAsync();
        }

        public override async Task<ExternalProgrammsInfo?> Get(long id)
        {
            return await _dbContext.ExternalProgrammsInfos
                .Include(at => at.Eplain)
                    .ThenInclude(ep => ep.EplainPorts)
                        .ThenInclude(ep => ep.Designation)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
