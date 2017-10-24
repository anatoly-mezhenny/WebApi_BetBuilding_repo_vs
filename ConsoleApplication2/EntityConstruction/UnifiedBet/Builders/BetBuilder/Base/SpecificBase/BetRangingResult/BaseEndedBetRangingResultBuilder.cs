using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Base;
using Sport.Data.Repositories.BetRepository.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult
{
    public class BaseEndedBetRangingResultBuilder<TContext,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>
        : BaseBetRangingResultBuilder<BaseEndedBetRangingResultBuilderParams, TContext,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>

        where TContext : BaseEndedBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo>, new()
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
    {
        private readonly IBaseBetRepository<TBetMainInfo> _betRepository;

        public BaseEndedBetRangingResultBuilder(
            IBaseBetRepository<TBetMainInfo> betRepository,
            IMultiTenantCashOutService multiTenantCashOutService,
            IBaseBetMapper<TBetMainInfo, TUnifiedBet> betMapper,
            IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> betSelectionMapper,
            IBaseBetRangingResultInfoProvider<TContext, TUnifiedBet, TBetMainInfo> taxInfoProvider,
            IBaseBetRangingResultInfoProvider<TContext, TUnifiedBet, TBetMainInfo> regulatorInfoProvider
            )
            : base(multiTenantCashOutService, betMapper, betSelectionMapper, taxInfoProvider, regulatorInfoProvider)
        {
            _betRepository = betRepository;
        }

        public override void LoadBetsData()
        {
            Context.BetsMainInfoRangingResult =
                _betRepository.GetEndedBets(Params.UserId, EndedStakesFiltersMapHelper.MapToEndedStakesFilters(Params.EndedStakesFilters));
        }
    }

    
    public class BaseEndedBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo>
        : BaseBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo>
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
    }


    public class BaseEndedBetRangingResultBuilderParams : BaseBetRangingResultBuilderParams
    {
        public EndedStakesFilters EndedStakesFilters { get; set; }

        public BaseEndedBetRangingResultBuilderParams(int userId, EndedStakesFilters endedStakesFilters) : base(userId)
        {
            EndedStakesFilters = endedStakesFilters;
        }
    }
}
