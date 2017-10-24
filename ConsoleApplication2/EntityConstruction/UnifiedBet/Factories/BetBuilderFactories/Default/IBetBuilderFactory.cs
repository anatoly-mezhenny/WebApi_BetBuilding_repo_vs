using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Default
{
    public interface IBetBuilderFactory : IBaseBetBuilderFactory<Entities.Bet.Default.UnifiedBet>
    {
    }
}