using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Italy;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Italy
{
    public class ItBetSelectionMapper
        : BaseBetSelectionMapper<ItBetSelectionMainInfo, ItUnifiedBetSelection>,
        IItBetSelectionMapper
    {
        public override ItUnifiedBetSelection Map(ItBetSelectionMainInfo betSelectionMainInfo)
        {
            var itUnifiedBetSelection = base.Map(betSelectionMainInfo);
            AppendItSpecific(itUnifiedBetSelection, betSelectionMainInfo);
            return itUnifiedBetSelection;
        }

        private static void AppendItSpecific(ItUnifiedBetSelection itUnifiedBetSelection, ItBetSelectionMainInfo betSelectionMainInfo)
        {
            itUnifiedBetSelection.ItSpecificProperty = betSelectionMainInfo.ItSpecificInfo;
        }
    }
}