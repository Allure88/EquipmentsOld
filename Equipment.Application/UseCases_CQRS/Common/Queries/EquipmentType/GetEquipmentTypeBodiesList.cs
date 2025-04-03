using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.EquipmentType
{
    public class GetEquipmentTypeBodiesListRequest : IRequest<GetEquipmentTypeBodiesListResponse> { }

    public class GetEquipmentTypeBodiesListResponse(List<EquipmentTypeEntity> bodies)
    {
        public List<EquipmentTypeEntity> Bodies { get; set; } = bodies;
    }

    public class GetEquipmentTypeBodiesListRequestHandler(IGenericRepository<EquipmentTypeEntity> repository) : IRequestHandler<GetEquipmentTypeBodiesListRequest, GetEquipmentTypeBodiesListResponse>
    {
        public async Task<GetEquipmentTypeBodiesListResponse> Handle(GetEquipmentTypeBodiesListRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetAll();
            return new GetEquipmentTypeBodiesListResponse(entity);
        }
    }
}
