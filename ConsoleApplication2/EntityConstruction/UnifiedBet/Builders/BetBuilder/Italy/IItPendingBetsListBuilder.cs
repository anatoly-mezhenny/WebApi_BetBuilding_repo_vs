using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Italy
{
    //This is custom Italy-brand builder (pending bets)
    public interface IItPendingBetsListBuilder : IBaseBetListBuilder<ItPendingBetsListBuilderParams, ItUnifiedBet>
    {
    }
}