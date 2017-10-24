using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.Entities.Bet.Italy.Subentities;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base;
using ConsoleApplication2.Services.TaxService;
using Sport.Data.Models.Italy;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Italy
{
    public class ItUniversalTaxInfoProvider
        : BaseUniversalTaxInfoProvider<ItUnifiedBet, ItBetMainInfo, ItTaxInfo>, IItUniversalTaxInfoProvider
    {
        public ItUniversalTaxInfoProvider(ITaxService taxService) : base(taxService)
        {
        }
    }
}
