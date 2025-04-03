using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Units;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Persistence.Repositories;

internal class CommonInlineUnitRepository(EquipmentDBContext dBContext) : GenericRepository<CommonInlineUnitEntity>(dBContext), ICommonInlineUnitRepository
{
    public override async Task<List<CommonInlineUnitEntity>> GetAll()
    {
        return await _dbContext.CommonInlineUnits
            .Include(u => u.Company)
            .Include(u => u.Material)
            .Include(u => u.PorstsAttachedTo)
            .Include(u => u.Ports.OrderBy(p => p.PortNumber))
            .ToListAsync();
    }

    public override async Task<CommonInlineUnitEntity?> Get(long id)
    {
        return await _dbContext.CommonInlineUnits
             .Include(u => u.Company)
             .Include(u => u.Material)
            .Include(u => u.PorstsAttachedTo)
            .Include(u => u.Ports.OrderBy(p => p.PortNumber))
            .FirstOrDefaultAsync(uf => uf.Id == id);
    }
}

