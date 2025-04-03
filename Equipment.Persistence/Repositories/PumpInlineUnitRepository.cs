using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Units;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Persistence.Repositories;

internal class PumpInlineUnitRepository(EquipmentDBContext dBContext) : GenericRepository<PumpInlineUnitEntity>(dBContext), IPumpInlineUnitRepository
{
    public override async Task<List<PumpInlineUnitEntity>> GetAll()
    {
        return await _dbContext.PumpInlineUnits
            .Include(u => u.Company)
            .Include(u => u.Material)
            .Include(u => u.PorstsAttachedTo)
            .Include(u => u.PumpPorts.OrderBy(p => p.PortNumber))
            .ToListAsync();
    }

    public override async Task<PumpInlineUnitEntity?> Get(long id)
    {
        return await _dbContext.PumpInlineUnits
             .Include(u => u.Company)
             .Include(u => u.Material)
            .Include(u => u.PorstsAttachedTo)
            .Include(u => u.PumpPorts.OrderBy(p=>p.PortNumber))
            .FirstOrDefaultAsync(uf => uf.Id == id);
    }
}

