using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Base;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Italy;
using Sport.Data.Models.Italy;
using Sport.Data.Repositories.BetRepository.Italy;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Italy
{
    public class ItBetBuilderFactory : BaseBetBuilderFactory<ItUnifiedBet, ItUnifiedBetSelection, ItBetMainInfo,
        ItBetSelectionMainInfo>,
        IItBetBuilderFactory
    {
        private readonly IItBetRepository _betRepository;
        private readonly IMultiTenantCashOutService _multiTenantCashOutService;
        private readonly IItBetMapper _betMapper;
        private readonly IItBetSelectionMapper _betSelectionMapper;
        private readonly IItUniversalTaxInfoProvider _taxInfoProvider;
        private readonly IItUniversalRegulatorInfoProvider _regulatorInfoProvider;

        public ItBetBuilderFactory(IItBetRepository betRepository,
            IMultiTenantCashOutService multiTenantCashOutService, 
            IItBetMapper betMapper,
            IItBetSelectionMapper betSelectionMapper,
            IItUniversalTaxInfoProvider taxInfoProvider,
            IItUniversalRegulatorInfoProvider regulatorInfoProvider)
            : base(betRepository, multiTenantCashOutService, betMapper, betSelectionMapper, taxInfoProvider, regulatorInfoProvider)
        {
            _betRepository = betRepository;
            _multiTenantCashOutService = multiTenantCashOutService;
            _betMapper = betMapper;
            _betSelectionMapper = betSelectionMapper;
            _taxInfoProvider = taxInfoProvider;
            _regulatorInfoProvider = regulatorInfoProvider;
        }

        //This is custom Italy-brand builder (pending bets)
        public IItPendingBetsListBuilder CreatePendingBetsListBuilder()
        {
            return new ItPendingBetsListBuilder(
                _betRepository, _multiTenantCashOutService, _betMapper, _betSelectionMapper, _taxInfoProvider, _regulatorInfoProvider);
        }

    }
}