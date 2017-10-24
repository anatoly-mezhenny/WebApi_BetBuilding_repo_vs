using ConsoleApplication2.Entities.Bet.Default.Subentities;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base;
using ConsoleApplication2.Services.TaxService;
using Sport.Data.Models.Default;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Default
{
    public class UniversalTaxInfoProvider
        : BaseUniversalTaxInfoProvider<Entities.Bet.Default.UnifiedBet, BetMainInfo, TaxInfo>, IUniversalTaxInfoProvider
    {
        public UniversalTaxInfoProvider(ITaxService taxService) : base(taxService)
        {
        }
    }
}