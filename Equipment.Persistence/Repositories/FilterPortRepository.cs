using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Ports;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Persistence.Repositories;

internal partial class PumpInlinePortRepository
{
    internal class FilterPortRepository(EquipmentDBContext dBContext) : GenericRepository<FilterPort>(dBContext), IFilterPortRepository
    {
        public override async Task<List<FilterPort>> GetAll()
        {
            return await _dbContext.FilterPorts
                .Include(u => u.FilterUnit)
                .Include(u => u.InlineUnits)
                .Include(u => u.Distributions)
                .ToListAsync();
        }

        public override async Task<FilterPort?> Get(long id)
        {
            return await _dbContext.FilterPorts
                .Include(c => c.FilterUnit)
                .Include(u => u.InlineUnits)
                .Include(u => u.Distributions)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}