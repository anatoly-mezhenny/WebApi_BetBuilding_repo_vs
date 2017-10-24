using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using Sport.Data.Models.Default;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Default
{
    public interface IUniversalTaxInfoProvider : IBaseUniversalInfoProvider<Entities.Bet.Default.UnifiedBet, BetMainInfo>
    {
    }
}