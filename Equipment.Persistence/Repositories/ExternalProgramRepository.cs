using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.ExternalProgrammsInfos;
using Equipment.Domain.Entities.ExternalProgrammsInfos.Fields.Eplan;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Equipment.Persistence.Repositories
{
    internal class  ExternalProgramRepository(EquipmentDBContext dBContext) : GenericRepository<ExternalProgrammsInfo>(dBContext), IExternalProgrammRepository
    {
        public override async Task<List<ExternalProgrammsInfo>> GetAll()
        {
            return await _dbContext.ExternalProgrammsInfos
                                        .Include(epf => epf.Eplan)
                                            .ThenInclude(eb => eb.Ports)
                                        .Include(epf => epf.Eplan)
                                            .ThenInclude(eb => eb.Ports)
                                                .ThenInclude(port => port.PipeType)
                                        .ToListAsync();
        }

        public override async Task<ExternalProgrammsInfo?> Get(long id)
        {
            return await _dbContext.ExternalProgrammsInfos
                                        .Include(epf => epf.Eplan)
                                            .ThenInclude(eb => eb.Ports)
                                        .Include(epf => epf.Eplan)
                                            .ThenInclude(eb => eb.Ports)
                                                .ThenInclude(port => port.PipeType)
                                        .FirstOrDefaultAsync(epf => epf.Id == id);
        }

        public async override Task<ExternalProgrammsInfo> Add(ExternalProgrammsInfo entity)
        {
            _dbContext.ChangeTracker.DetectChanges();
            _dbContext.Entry(entity).State = EntityState.Added;
            if (entity.Eplan != null)
            {
                _dbContext.Entry(entity.Eplan).State = EntityState.Added;
                foreach (var port in entity.Eplan.Ports)
                {
                    _dbContext.Entry(port).State = EntityState.Added;
                }
            }

            if (entity.Revit != null)
            {
                _dbContext.Entry(entity.Revit).State = EntityState.Added;
            }

            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public override Task Delete(ExternalProgrammsInfo entity)
        {
            var relEntity = _dbContext.EplanBlocks
                                        .FirstOrDefault(eb => entity.EplanId == eb.Id);
            if (relEntity != null)
            {
                _dbContext.Set<EplanBlockEntity>().Remove(relEntity);
            }
            
            return base.Delete(entity);
        }
    }
}
