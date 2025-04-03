using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Ports;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Persistence.Repositories;

internal partial class PumpInlinePortRepository(EquipmentDBContext dBContext) : GenericRepository<PumpInlinePort>(dBContext), IPumpInlinePortRepository
{
    public override async Task<List<PumpInlinePort>> GetAll()
    {
        return await _dbContext.PumpInlinePorts
            .Include(u => u.PumpUnit)
            .OrderBy(p=>p.PortNumber)
            .ToListAsync();
    }

    public override async Task<PumpInlinePort?> Get(long id)
    {
        return await _dbContext.PumpInlinePorts
            .Include(c => c.PumpUnit)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}