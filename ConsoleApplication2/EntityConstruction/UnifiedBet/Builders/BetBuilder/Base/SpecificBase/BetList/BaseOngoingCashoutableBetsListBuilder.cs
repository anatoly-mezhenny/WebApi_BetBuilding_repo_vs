using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Base;
using Sport.Data.Repositories.BetRepository.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList
{
    public class BaseOngoingCashoutableBetsListBuilder<TContext,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>
        : BaseBetListBuilder<BaseOngoingCashoutableBetsListBuilderParams, TContext,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>

        where TContext : BaseOngoingCashoutableBetsListBuilderContext<TUnifiedBet, TBetMainInfo>, new()
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IBaseBetRepository<TBetMainInfo> _betRepository;

        public BaseOngoingCashoutableBetsListBuilder(
            IBaseBetRepository<TBetMainInfo> betRepository,
            IMultiTenantCashOutService multiTenantCashOutService,
            IBaseBetMapper<TBetMainInfo, TUnifiedBet> betMapper,
            IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> betSelectionMapper,
            IBaseBetListInfoProvider<TContext, TUnifiedBet, TBetMainInfo> taxInfoProvider,
            IBaseBetListInfoProvider<TContext, TUnifiedBet, TBetMainInfo> regulatorInfoProvider)
            : base(multiTenantCashOutService, betMapper, betSelectionMapper, taxInfoProvider, regulatorInfoProvider)
        {
            _betRepository = betRepository;
        }

        public override void LoadBetsData()
        {
            Context.BetsMainInfo = _betRepository.GetOngoingBets(Params.UserId, onlyCashoutableBets: true);
        }
    }


    public class BaseOngoingCashoutableBetsListBuilderContext<TUnifiedBet, TBetMainInfo>
        : BaseBetListBuilderContext<TUnifiedBet, TBetMainInfo>
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
    }


    public class BaseOngoingCashoutableBetsListBuilderParams : BaseBetListBuilderParams
    {
        public BaseOngoingCashoutableBetsListBuilderParams(int userId) : base(userId)
        {
        }
    }
}
