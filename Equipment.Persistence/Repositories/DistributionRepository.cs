using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Persistence.Repositories;

internal class DistributionRepository(EquipmentDBContext dBContext) : GenericRepository<DistributionEntity>(dBContext), IDistributionRepository
{
    public override async Task<List<DistributionEntity>> GetAll()
    {
        return await _dbContext.Distributions
            .Include(d => d.Component)
            .ToListAsync();
    }

    public override async Task<DistributionEntity?> Get(long id)
    {
        return await _dbContext.Distributions
             .Include(d => d.Component)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}

