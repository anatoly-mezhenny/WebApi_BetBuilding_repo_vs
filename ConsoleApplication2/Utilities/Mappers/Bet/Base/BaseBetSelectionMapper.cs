using ConsoleApplication2.Entities.Bet.Base;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Base
{
    public class BaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> 
        : IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> 
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo 
        where TUnifiedBetSelection : BaseUnifiedBetSelection, new()
    {
        public virtual TUnifiedBetSelection Map(TBetSelectionMainInfo betSelectionMainInfo)
        {
            return new TUnifiedBetSelection
            {
                //NOTE: Map all commont fields between TUnifiedBetSelection and TBetSelectionMainInfo
                Id = betSelectionMainInfo.Id,
                CommonBaseUnifiedBetSelectionProperty = betSelectionMainInfo.CommonBetSelectionProperty,
                Odds = betSelectionMainInfo.Odds,
                Result = betSelectionMainInfo.Result
            };
        }
    }
}