using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic
{
    public interface IBaseSingleBetInfoProvider<in TBuilderContext, TUnifiedBet, TBetMainInfo>
        : IBaseInfoProvider<TBuilderContext>
        where TBuilderContext : BaseSingleBetBuilderContext<TUnifiedBet, TBetMainInfo>
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
    }
}