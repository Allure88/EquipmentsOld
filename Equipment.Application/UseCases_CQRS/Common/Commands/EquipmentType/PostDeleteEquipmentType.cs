using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.EquipmentType
{
    public class PostDeleteEquipmentTypeRequest(long id) : IRequest<PostDeleteEquipmentTypeResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteEquipmentTypeResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteMaterialRequestHandler(IGenericRepository<EquipmentTypeEntity> repository) : IRequestHandler<PostDeleteEquipmentTypeRequest, PostDeleteEquipmentTypeResponse>
    {
        public async Task<PostDeleteEquipmentTypeResponse> Handle(PostDeleteEquipmentTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeleteEquipmentTypeResponse(request.Id);
            }

            return new PostDeleteEquipmentTypeResponse(-1);
        }
    }
}
