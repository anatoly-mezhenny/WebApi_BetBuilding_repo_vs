using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Base
{
    public interface IBaseBetBuilderFactory<TUnifiedBet>
        where TUnifiedBet : BaseUnifiedBet
    {
        IBaseBetListBuilder<BaseOngoingBetsListBuilderParams, TUnifiedBet> CreateOngoingBetsListBuilder();
        IBaseBetListBuilder<BaseOngoingCashoutableBetsListBuilderParams, TUnifiedBet> CreateOngoingCashoutableBetsListBuilder();
        IBaseBetListBuilder<BaseSimpleBetsListBuilderParams, TUnifiedBet> CreateSimpleBetsListBuilder();
        IBaseSingleBetBuilder<BaseSimpleBetBuilderParams, TUnifiedBet> CreateSimpleBetBuilder();
        IBaseBetRangingResultBuilder<BaseEndedBetRangingResultBuilderParams, TUnifiedBet> CreateEndedBetRangingResultBuilder();
        
    }
}