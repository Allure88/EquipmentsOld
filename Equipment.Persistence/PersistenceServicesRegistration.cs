using Equipment.Application.Contracts.Persistence;
using Equipment.Application.Validators.Service;
using Equipment.Domain.Entities;
using Equipment.Domain.Entities.Commons;
using Equipment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equipment.Persistence;

public static class PersistenceServicesRegistration
{
    public static string ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        //string connString = configuration.GetConnectionString("PostgresEquipmentDbConnectionString")!;
        //string connString = configuration.GetConnectionString("LocalPostgresEquipmentFillingsDbConnectionString")!;
        string connString = configuration.GetConnectionString("DevelopPostgresEquipmentFillingsDbConnectionString")!;

        services.AddDbContext<EquipmentDBContext>(options =>
        {
            options.UseNpgsql(connString);
            //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<IFilterRepository, FilterRepository>();
        services.AddScoped<IPumpInlineUnitRepository, PumpInlineUnitRepository>();
        services.AddScoped<ICommonInlineUnitRepository, CommonInlineUnitRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ISpecificFilterRepository, SpecificFilterRepository>();
        services.AddScoped<IExternalProgrammRepository, ExternalProgramRepository>();

        services.AddScoped<IGenericRepository<EquipmentTypeEntity>, GenericRepository<EquipmentTypeEntity>>();
        services.AddScoped<IGenericRepository<StageTypeEntity>, GenericRepository<StageTypeEntity>>();
        services.AddScoped<IGenericRepository<ComponentEntity>, GenericRepository<ComponentEntity>>();
        services.AddScoped<IGenericRepository<PipeTypeEntity>, GenericRepository<PipeTypeEntity>>();
        services.AddScoped<IGenericRepository<DiametrEntity>, GenericRepository<DiametrEntity>>();
        services.AddScoped<IGenericRepository<MaterialEntity>, GenericRepository<MaterialEntity>>();

        services.AddTransient<ValidationService>();

        return connString;
    }
}
