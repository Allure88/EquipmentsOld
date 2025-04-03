using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Units;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Persistence.Repositories
{
    internal class SpecificFilterRepository(EquipmentDBContext dBContext) : GenericRepository<SpecificFilterEntity>(dBContext), ISpecificFilterRepository
    {
        public override async Task<List<SpecificFilterEntity>> GetAll()
        {
            return await _dbContext.SpecificFilters
                    .Include(sf => sf.ExternalProgrammsInfo)
                    .Include(sf => sf.Material)
                    .Include(sf => sf.FilterUnit)
                        .ThenInclude(fu => fu.Ports)
                    .Include(sf => sf.FilterUnit)
                        .ThenInclude(fu => fu.Ports)
                            .ThenInclude(p => p.PipeType)
                    .Include(sf => sf.FilterUnit)
                        .ThenInclude(fu => fu.Ports)
                            .ThenInclude(p => p.Diametr)
                    .Include(sf => sf.FilterUnit)
                        .ThenInclude(p => p.EquipmentType)
                    .ToListAsync();

        }

        public async override Task<SpecificFilterEntity?> Get(long id)
        {
            return await _dbContext.SpecificFilters
                .Include(sf => sf.ExternalProgrammsInfo)
                    .Include(sf => sf.Material)
                    .Include(sf => sf.FilterUnit)
                        .ThenInclude(fu => fu.Ports)
                            .ThenInclude(p => p.PipeType)
                    .Include(sf => sf.FilterUnit)
                        .ThenInclude(fu => fu.Ports)
                            .ThenInclude(p => p.Diametr)
                    .Include(sf => sf.FilterUnit)
                        .ThenInclude(p => p.EquipmentType)
                .FirstOrDefaultAsync(uf => uf.Id == id);
        }

        public async override Task<SpecificFilterEntity> Add(SpecificFilterEntity entity)
        {
            _dbContext.ChangeTracker.DetectChanges();
            _dbContext.Entry(entity).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
