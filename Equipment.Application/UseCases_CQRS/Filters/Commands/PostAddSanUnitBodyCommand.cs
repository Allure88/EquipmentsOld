
using AutoMapper;
using Equipment.Application.Adapters;
using Equipment.Application.Contracts.Persistence;
using Equipment.Application.Validators.Filters;
using Equipment.Application.Validators.Service;
using Equipment.Domain.Entities.Units;
using MediatR;
using SharedCommon.TechSchemaDomain;
using SharedCommon.TechSchemaDomain.PostDTO.Units;

namespace Equipment.Application.UseCases_CQRS.Filters.Commands
{
    public class PostAddFilterUnitBodyCommand(FilterUnitPostBody filterUnit) : IRequest<PostAddFilterUnitEntityResponse>
    {
        public FilterUnitPostBody FilterUnit { get; } = filterUnit;
    }

    public class PostAddFilterUnitEntityResponse(FilterUnitBody filterUnit)
    {
        public FilterUnitBody FilterUnit { get; } = filterUnit;
    }

    public class PostAddFilterUnitBodyCommandHandler(IFilterRepository filterRepository,
        IMapper mapper,
        ValidationService validationService) : IRequestHandler<PostAddFilterUnitBodyCommand, PostAddFilterUnitEntityResponse>
    {
        public async Task<PostAddFilterUnitEntityResponse> Handle(PostAddFilterUnitBodyCommand request, CancellationToken cancellationToken)
        {
            var validation = new FilterUnitPostBodyValidator(validationService);
            validation.Validate(request.FilterUnit);

            var mappedObject = mapper.Map<FilterUnitEntity>(request.FilterUnit);
            var addedEntity = await filterRepository.Add(mappedObject);
            var mappedEntity = addedEntity.ToFilterBody();
            return new PostAddFilterUnitEntityResponse(mappedEntity);
        }
    }
}
