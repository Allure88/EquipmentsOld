using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.EquipmentType
{
    public class PostAddEquipmentTypeRequest(EquipmentTypeBody body) : IRequest<PostAddEquipmentTypeResponse>
    {
        public EquipmentTypeBody Body { get; set; } = body;
    }

    public class PostAddEquipmentTypeResponse(EquipmentTypeEntity body)
    {
        public EquipmentTypeEntity Body { get; set; } = body;
    }

    public class PostAddEquipmentTypeRequestHandler(IGenericRepository<EquipmentTypeEntity> repository, IMapper mapper) : IRequestHandler<PostAddEquipmentTypeRequest, PostAddEquipmentTypeResponse>
    {
        public async Task<PostAddEquipmentTypeResponse> Handle(PostAddEquipmentTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EquipmentTypeEntity>(request.Body);
            var addedEntity = await repository.Add(entity);
            return new PostAddEquipmentTypeResponse(addedEntity);
        }
    }
}
