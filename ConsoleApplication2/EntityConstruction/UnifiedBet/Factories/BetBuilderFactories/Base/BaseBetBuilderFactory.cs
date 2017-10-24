using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Base;
using Sport.Data.Repositories.BetRepository.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Base
{
    /// <summary>
    /// Creates family of bet builders
    /// </summary>
    public abstract class BaseBetBuilderFactory<
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>
        : IBaseBetBuilderFactory<TUnifiedBet>
        
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IBaseBetRepository<TBetMainInfo> _betRepository;
        private readonly IMultiTenantCashOutService _multiTenantCashOutService;
        private readonly IBaseBetMapper<TBetMainInfo, TUnifiedBet> _betMapper;
        private readonly IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> _betSelectionMapper;
        private readonly IBaseUniversalInfoProvider<TUnifiedBet, TBetMainInfo> _universalTaxInfoProvider;
        private readonly IBaseUniversalInfoProvider<TUnifiedBet, TBetMainInfo> _universalRegulatorInfoProvider;

        protected BaseBetBuilderFactory(IBaseBetRepository<TBetMainInfo> betRepository,
            IMultiTenantCashOutService multiTenantCashOutService, IBaseBetMapper<TBetMainInfo, TUnifiedBet> betMapper,
            IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> betSelectionMapper,
            IBaseUniversalInfoProvider<TUnifiedBet, TBetMainInfo> universalTaxInfoProvider,
            IBaseUniversalInfoProvider<TUnifiedBet, TBetMainInfo> universalRegulatorInfoProvider
            )
        {
            _betRepository = betRepository;
            _multiTenantCashOutService = multiTenantCashOutService;
            _betMapper = betMapper;
            _betSelectionMapper = betSelectionMapper;
            _universalTaxInfoProvider = universalTaxInfoProvider;
            _universalRegulatorInfoProvider = universalRegulatorInfoProvider;
        }

        public IBaseBetListBuilder<BaseOngoingBetsListBuilderParams, TUnifiedBet> CreateOngoingBetsListBuilder()
        {
            return new BaseOngoingBetsListBuilder
                <
                BaseOngoingBetsListBuilderContext<TUnifiedBet, TBetMainInfo>,
                TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo
                >(
                _betRepository, _multiTenantCashOutService, _betMapper, _betSelectionMapper, _universalTaxInfoProvider, _universalRegulatorInfoProvider
                );
        }

        public IBaseBetListBuilder<BaseOngoingCashoutableBetsListBuilderParams, TUnifiedBet> CreateOngoingCashoutableBetsListBuilder()
        {
            return new BaseOngoingCashoutableBetsListBuilder
                <
                BaseOngoingCashoutableBetsListBuilderContext<TUnifiedBet, TBetMainInfo>,
                TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo
                >(
                _betRepository, _multiTenantCashOutService, _betMapper, _betSelectionMapper, _universalTaxInfoProvider, _universalRegulatorInfoProvider
                );
        }

        public IBaseBetListBuilder<BaseSimpleBetsListBuilderParams, TUnifiedBet> CreateSimpleBetsListBuilder()
        {
            return new BaseSimpleBetsListBuilder
                <
                BaseSimpleBetsListBuilderContext<TUnifiedBet, TBetMainInfo>,
                TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo
                >(
                 _betRepository, _multiTenantCashOutService, _betMapper, _betSelectionMapper, _universalTaxInfoProvider, _universalRegulatorInfoProvider
                );
        }

        public IBaseSingleBetBuilder<BaseSimpleBetBuilderParams, TUnifiedBet> CreateSimpleBetBuilder()
        {
            return new BaseSimpleBetBuilder
                <
                BaseSimpleBetBuilderContext<TUnifiedBet, TBetMainInfo>,
                TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo
                >(
                 _betRepository, _multiTenantCashOutService, _betMapper, _betSelectionMapper, _universalTaxInfoProvider, _universalRegulatorInfoProvider
                );
        }

        public IBaseBetRangingResultBuilder<BaseEndedBetRangingResultBuilderParams, TUnifiedBet> CreateEndedBetRangingResultBuilder()
        {
            return new BaseEndedBetRangingResultBuilder
                <
                BaseEndedBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo>,
                TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo
                >(
                _betRepository, _multiTenantCashOutService, _betMapper, _betSelectionMapper, _universalTaxInfoProvider, _universalRegulatorInfoProvider
                );
        }
    }
}

