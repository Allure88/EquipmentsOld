using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Units;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Persistence.Repositories;

internal class FilterRepository(EquipmentDBContext dBContext) : GenericRepository<FilterUnitEntity>(dBContext), IFilterRepository
{
    public override async Task<List<FilterUnitEntity>> GetAll()
    {
        return await _dbContext.Filters
            .Include(u => u.Ports)
                .ThenInclude(p => p.Distributions)
                    .ThenInclude(d => d.Component)
            .Include(u => u.Ports)
                .ThenInclude(p => p.PDK)
                    .ThenInclude(d => d.Component)
            .ToListAsync();
    }

    public override async Task<FilterUnitEntity?> Get(long id)
    {
        return await _dbContext.Filters
             .Include(u => u.Ports)
                .ThenInclude(p => p.Distributions)
                    .ThenInclude(d => d.Component)
                    .Include(u => u.Ports)
                .ThenInclude(p => p.PDK)
                    .ThenInclude(d => d.Component)
            .FirstOrDefaultAsync(uf => uf.Id == id);
    }

    public override async Task<FilterUnitEntity> Add(FilterUnitEntity entity)
    {
        _dbContext.ChangeTracker.DetectChanges();
        _dbContext.Entry(entity).State = EntityState.Added;
        foreach (var port in entity.Ports)
        {
            _dbContext.Entry(port).State = EntityState.Added;
        }
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}
