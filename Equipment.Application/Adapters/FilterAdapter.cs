using Equipment.Domain.Entities.Commons;
using Equipment.Domain.Entities.Ports;
using Equipment.Domain.Entities.Units;
using SharedCommon.Common.Chemistry;
using SharedCommon.TechSchemaDomain;

namespace Equipment.Application.Adapters;

internal static class FilterAdapter
{
    public static FilterUnitBody ToFilterBody(this FilterUnitEntity entity)
    {
        List<FilterPortBody> outPorts = [.. entity.Ports.Where(p => p.Type == PortDirectionType.Output).Select(p => p.ToFilterPortBody())];

        List<PortBody> inPorts = [.. entity.Ports.Where(p => p.Type == PortDirectionType.Input).Select(p => p.ToPortBody())];

        var result = new FilterUnitBody()
        {
            OutPorts = outPorts,
            InPorts = inPorts,
            Stage = entity.StageType.Name,
        };
        return result;
    }


    public static FilterPortBody ToFilterPortBody(this FilterPortEntity entity)
    {
        List<DistributionBody> distributions = [.. entity.Distributions.Select(d => d.ToDistributionBody())];
        FilterPortBody portBody = new(entity.Guid, entity.Name, entity.UnaccountedComponent, entity.HumidityCoefficient, distributions);

        return portBody;
    }

    public static PortBody ToPortBody(this FilterPortEntity entity)
    {
        List<ConcentrationBody> concentration = [.. entity.PDK.Select(d => d.ToConcentrationBody())];

        PortBody body = new(entity.Guid, entity.Name)
        {
            PortNumber = entity.PortNumber,
            PDK = concentration
        };
        return body;
    }

    public static DistributionBody ToDistributionBody(this DistributionEntity entity)
    {
        var result = new DistributionBody(0, entity.Component.Name, entity.Percentage);
        return result;
    }

    public static ConcentrationBody ToConcentrationBody(this ConcentrationEntity entity)
    {
        var result = new ConcentrationBody(0, entity.Component.Name, entity.Value);
        return result;
    }
}
