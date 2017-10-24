using System.Collections.Generic;
using ConsoleApplication2.Entities.Bet.Default;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Default;
using ConsoleApplication2.Services.MultitenantUnifiedBetService.Base;

namespace ConsoleApplication2.Services.MultitenantUnifiedBetService.Default
{
    /// <summary>
    /// There is no any specific inside of "default" multitenant unified bet service,
    /// so it's just implementation of BaseMultitenantUnifiedBetService
    /// </summary>
    public class MultitenantUnifiedBetService : BaseMultitenantUnifiedBetService<UnifiedBet>, 
        IMultitenantUnifiedBetService
    {
        public MultitenantUnifiedBetService(IBetBuilderFactory betBuilderFactory) : base(betBuilderFactory)
        {
        }

    }
}