using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic
{
    /// <summary>
    /// "Universal" info providers provides info for all type of contexts (list,single bet, ranging result contexts)
    /// </summary>
    /// <typeparam name="TUnifiedBet"></typeparam>
    /// <typeparam name="TBetMainInfo"></typeparam>
    public interface IBaseUniversalInfoProvider<TUnifiedBet, TBetMainInfo>
        : IBaseBetListInfoProvider<BaseBetListBuilderContext<TUnifiedBet, TBetMainInfo>, TUnifiedBet, TBetMainInfo>,
        IBaseSingleBetInfoProvider<BaseSingleBetBuilderContext<TUnifiedBet, TBetMainInfo>, TUnifiedBet, TBetMainInfo>,
        IBaseBetRangingResultInfoProvider<BaseBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo>, TUnifiedBet, TBetMainInfo>
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
    }
}
