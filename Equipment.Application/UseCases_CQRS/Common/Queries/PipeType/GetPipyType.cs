using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.PipeType
{
    public class GetPipyTypeRequest(long id) : IRequest<GetPipeTypeResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetPipeTypeResponse(PipeTypeBody body)
    {
        public PipeTypeBody Body { get; set; } = body;
    }

    public class GetPipyTypeRequestHandler(IGenericRepository<PipeTypeEntity> repository, IMapper mapper) : IRequestHandler<GetPipyTypeRequest, GetPipeTypeResponse>
    {
        public async Task<GetPipeTypeResponse> Handle(GetPipyTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            var mappedEntity = mapper.Map<PipeTypeBody>(entity);
            return new GetPipeTypeResponse(mappedEntity);
        }
    }
}
