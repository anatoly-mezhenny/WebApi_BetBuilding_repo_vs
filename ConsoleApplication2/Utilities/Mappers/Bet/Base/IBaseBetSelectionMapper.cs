using ConsoleApplication2.Entities.Bet.Base;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Base
{
    public interface IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection>
    where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    where TUnifiedBetSelection : BaseUnifiedBetSelection
    {
        TUnifiedBetSelection Map(TBetSelectionMainInfo betSelectionMainInfo);
    }
}
