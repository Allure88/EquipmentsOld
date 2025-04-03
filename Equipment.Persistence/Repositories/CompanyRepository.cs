using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using Equipment.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Persistence.Repositories
{
    public class CompanyRepository(EquipmentDBContext dBContext) : GenericRepository<CompanyEntity>(dBContext), ICompanyRepository
    {
        public override async Task<CompanyEntity?> Get(long id)
        {
            return await _dbContext.Companies
                .Include(c => c.Stage)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<CompanyEntity>> GetAll()
        {
            return await _dbContext.Companies
                .Include(c => c.Stage)
                .ToListAsync();
        }

        public override async Task<CompanyEntity> Add(CompanyEntity entity)
        {
            _dbContext.ChangeTracker.DetectChanges();
            _dbContext.Entry(entity).State = EntityState.Added;
            if (entity.Stage != null)
            {
                foreach (var item in entity.Stage)
                {
                    _dbContext.Entry(item).State = EntityState.Added;
                }
            }

            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public override Task Delete(CompanyEntity entity)
        {
            if (entity.Stage != null)
            {
                var relEntities = _dbContext.StageTypes
                .Where(stage => entity.Stage.Contains(stage));

                _dbContext.Set<StageTypeEntity>().RemoveRange(relEntities);
            }
            
            return base.Delete(entity);
        }
    }
}
