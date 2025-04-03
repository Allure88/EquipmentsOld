using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using Equipment.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Application.Validators.Service
{
    public class ValidationService
    {
        public IGenericRepository<EquipmentTypeEntity> EquipmentRepository { get;}
        public IGenericRepository<StageTypeEntity> StageRepository { get;}
        public IGenericRepository<ComponentEntity> ComponentRepository { get;}
        public IGenericRepository<PipeTypeEntity> PipeRepository { get;}
        public IGenericRepository<DiametrEntity> DiametrRepository { get;}
        public IFilterRepository FilterRepository { get;}
        public ICompanyRepository CompanyRepository { get;}
        public IExternalProgrammRepository ExternalProgrammRepository { get;}
        public IGenericRepository<MaterialEntity> MaterialEntity { get; }

        public ValidationService(
            IGenericRepository<EquipmentTypeEntity> equipmentRepository,
            IGenericRepository<StageTypeEntity> stageRepository,
            IGenericRepository<ComponentEntity> componentRepository,
            IGenericRepository<PipeTypeEntity> pipeRepository,
            IGenericRepository<DiametrEntity> diametrRepository,
            IFilterRepository filterRepository,
            ICompanyRepository companyRepository,
            IExternalProgrammRepository externalProgramm,
            IGenericRepository<MaterialEntity> materialEntity)
        {
            EquipmentRepository = equipmentRepository;
            StageRepository = stageRepository;
            ComponentRepository = componentRepository;
            PipeRepository = pipeRepository;
            DiametrRepository = diametrRepository;
            FilterRepository = filterRepository;
            CompanyRepository = companyRepository;
            ExternalProgrammRepository = externalProgramm;
            MaterialEntity = materialEntity;
        }
    }
}
