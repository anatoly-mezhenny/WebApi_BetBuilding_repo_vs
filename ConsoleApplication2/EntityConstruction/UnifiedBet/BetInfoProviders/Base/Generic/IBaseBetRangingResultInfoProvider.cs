using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic
{
    public interface IBaseBetRangingResultInfoProvider<in TBuilderContext, TUnifiedBet, TBetMainInfo>
        : IBaseInfoProvider<TBuilderContext>
        where TBuilderContext : BaseBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo>
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
    }
}