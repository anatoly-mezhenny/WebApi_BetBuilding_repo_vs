using ConsoleApplication2.Entities.Bet.Default;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Default;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Default
{
    public class BetSelectionMapper : BaseBetSelectionMapper<BetSelectionMainInfo, UnifiedBetSelection>, IBetSelectionMapper
    {
        public override UnifiedBetSelection Map(BetSelectionMainInfo betSelectionMainInfo)
        {
            var unifiedBetSelection = base.Map(betSelectionMainInfo);
            AppendDefaultSpecific(unifiedBetSelection, betSelectionMainInfo);
            return unifiedBetSelection;
        }

        private static void AppendDefaultSpecific(UnifiedBetSelection unifiedBetSelection, BetSelectionMainInfo betSelectionMainInfo)
        {
            unifiedBetSelection.DefaultSpecificProperty = betSelectionMainInfo.DefaultSpecificProperty;
        }
    }
}
