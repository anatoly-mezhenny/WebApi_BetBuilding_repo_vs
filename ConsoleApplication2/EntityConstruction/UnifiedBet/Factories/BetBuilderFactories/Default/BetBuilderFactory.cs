using ConsoleApplication2.Entities.Bet.Default;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Default;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Base;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Default;
using Sport.Data.Models.Default;
using Sport.Data.Repositories.BetRepository.Default;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Default
{
    public class BetBuilderFactory
        : BaseBetBuilderFactory<Entities.Bet.Default.UnifiedBet, UnifiedBetSelection,
            BetMainInfo, BetSelectionMainInfo>,
        IBetBuilderFactory
    {
        public BetBuilderFactory(IBetRepository betRepository,
            IMultiTenantCashOutService multiTenantCashOutService,
            IBetMapper betMapper,
            IBetSelectionMapper betSelectionMapper,
            IUniversalTaxInfoProvider universalTaxInfoProvider
            )
            : base(betRepository, multiTenantCashOutService, betMapper, betSelectionMapper, universalTaxInfoProvider, null /*no regulator info provider for default*/)
        {
        }

        //There is no any specific inside of "default" bet builder factory
    }
}
