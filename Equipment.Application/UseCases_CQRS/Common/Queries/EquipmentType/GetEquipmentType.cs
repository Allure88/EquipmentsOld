using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.EquipmentType
{
    public class GetEquipmentTypeRequest(long id) : IRequest<GetEquipmentTypeResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetEquipmentTypeResponse(EquipmentTypeBody body)
    {
        public EquipmentTypeBody Body { get; set; } = body;
    }

    public class GetEquipmentTypeRequestHandler(IGenericRepository<EquipmentTypeEntity> repository, IMapper mapper) : IRequestHandler<GetEquipmentTypeRequest, GetEquipmentTypeResponse>
    {
        public async Task<GetEquipmentTypeResponse> Handle(GetEquipmentTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            var mappedEntity = mapper.Map<EquipmentTypeBody>(entity);
            return new GetEquipmentTypeResponse(mappedEntity);
        }
    }
}
