using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Italy
{
    public interface IItBetBuilderFactory : IBaseBetBuilderFactory<ItUnifiedBet>
    {
        //This is custom Italy-brand builder (pending bets)
        IItPendingBetsListBuilder CreatePendingBetsListBuilder();
    }
}