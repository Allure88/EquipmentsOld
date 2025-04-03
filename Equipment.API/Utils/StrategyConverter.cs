using Equipment.Domain.Entities.OldEnums;
using SharedCommon.TechSchemaDomain.Enums;

namespace Equipment.API.Utils
{
    public class StrategyConverter
    {
        public List<string> ConvertAllStagesToString()
        {
            var list = Enum.GetValues<StageType>().Select(x => x.GetDescription()).ToList();
            return list;
        }
        public List<string> ConvertStagesToString(List<StageType> stages)
        {
            var strStages = stages.Select(x => x.GetDescription()).ToList();
            return strStages;
        }

        public List<StageType> ConvertStagesToInt(List<string> stages)
        {
            var enumStages = stages.Select(Enum.Parse<StageType>).ToList();
            return enumStages;
        }

        public StageType StringToStageType(string stageStr)
        {
            return Enum.GetValues<StageType>().FirstOrDefault(x => x.GetDescription().Equals(stageStr));
        }
    }
}
