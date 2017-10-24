using ConsoleApplication2.Entities.Bet.Default;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Default;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Default
{
    public class BetMapper : BaseBetMapper<BetMainInfo, UnifiedBet>, IBetMapper
    {
        public override UnifiedBet Map(BetMainInfo betMainInfo)
        {
            var unifiedBet = base.Map(betMainInfo);
            AppendDefaultSpecific(unifiedBet, betMainInfo);
            return unifiedBet;
        }

        private static void AppendDefaultSpecific(UnifiedBet unifiedBet, BetMainInfo betMainInfo)
        {
            unifiedBet.DefaultSpecificBetProperty = betMainInfo.DefaultSpecificProperty;
        }
    }
}
