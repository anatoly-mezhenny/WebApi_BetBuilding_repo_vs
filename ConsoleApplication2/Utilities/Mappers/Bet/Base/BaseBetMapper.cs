using ConsoleApplication2.Entities.Bet.Base;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Base
{
    public class BaseBetMapper<TBetMainInfo, TUnifiedBet> 
        : IBaseBetMapper<TBetMainInfo, TUnifiedBet> 
        where TBetMainInfo : BaseBetMainInfo 
        where TUnifiedBet : BaseUnifiedBet, new()
    {
        public virtual TUnifiedBet Map(TBetMainInfo betMainInfo)
        {
            return new TUnifiedBet
            {
                //NOTE: Map all commont fields between TUnifiedBet and TBetMainInfo
                Id = betMainInfo.Id,
                CommonPropertyForAllBrands = betMainInfo.CommonPropertyForAllBrands,
                Amount = betMainInfo.Amount
            };
        }
    }
}