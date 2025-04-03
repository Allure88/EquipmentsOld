using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Application.Validators.Service;
using Equipment.Application.Validators.SpecificFilter;
using Equipment.Domain.Entities.Units;
using MediatR;
using SharedCommon.Responces;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.PostBodies;

namespace Equipment.Application.UseCases_CQRS.SpecialFilter.Commands
{
    public class PostAddSpecialFilterBodyCommand(PhysUnitPostBody physUnit) : IRequest<PostAddSpecialFilterBodyResponse>
    {
        public PhysUnitPostBody PhysUnit { get; } = physUnit;
    }

    public class PostAddSpecialFilterBodyResponse(SpecificFilterEntity filterUnit)
    {
        public SpecificFilterEntity FilterUnit { get; } = filterUnit;

    }

    public class PostAddSpecialFilterBodyCommandHandler(ISpecificFilterRepository specificFilterRepository,
        IMapper mapper,
        ValidationService service) : IRequestHandler<PostAddSpecialFilterBodyCommand, PostAddSpecialFilterBodyResponse>
    {
        private readonly ISpecificFilterRepository _specificFilterRepository = specificFilterRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ValidationService validationService = service;

        public async Task<PostAddSpecialFilterBodyResponse> Handle(PostAddSpecialFilterBodyCommand request, CancellationToken cancellationToken)
        {
            var validation = new SpecificFilterPostBodyValidator(validationService);
            validation.Validate(request.PhysUnit);

            var mappedObject = _mapper.Map<SpecificFilterEntity>(request.PhysUnit);
            var addedEntity = await _specificFilterRepository.Add(mappedObject);
            return new PostAddSpecialFilterBodyResponse(addedEntity);
        }
    }
}
