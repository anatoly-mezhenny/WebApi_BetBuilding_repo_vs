using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Italy;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Italy
{
    public class ItBetMapper
        : BaseBetMapper<ItBetMainInfo, ItUnifiedBet>,
        IItBetMapper
    {
        public override ItUnifiedBet Map(ItBetMainInfo betMainInfo)
        {
            var itUnifiedBet = base.Map(betMainInfo);
            AppendItSpecific(itUnifiedBet, betMainInfo);
            return itUnifiedBet;
        }

        private static void AppendItSpecific(ItUnifiedBet itUnifiedBet, ItBetMainInfo betMainInfo)
        {
            itUnifiedBet.ItSpecificProperty = betMainInfo.ItSpecificProperty;
        }
    }
}