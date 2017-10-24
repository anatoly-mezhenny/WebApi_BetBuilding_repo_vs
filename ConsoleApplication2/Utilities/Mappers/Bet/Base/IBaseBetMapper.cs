using ConsoleApplication2.Entities.Bet.Base;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Base
{
    public interface IBaseBetMapper<TBetMainInfo, TUnifiedBet>
        where TBetMainInfo : BaseBetMainInfo
        where TUnifiedBet : BaseUnifiedBet
    {
        TUnifiedBet Map(TBetMainInfo betMainInfo);
    }
}
