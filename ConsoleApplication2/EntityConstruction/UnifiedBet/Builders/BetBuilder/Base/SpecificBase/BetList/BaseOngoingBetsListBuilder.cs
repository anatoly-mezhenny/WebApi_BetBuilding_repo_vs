using System;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Base;
using Sport.Data.Repositories.BetRepository.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList
{
    public class BaseOngoingBetsListBuilder<TContext, 
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>
        : BaseBetListBuilder<BaseOngoingBetsListBuilderParams, TContext,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>
        
        where TContext : BaseOngoingBetsListBuilderContext<TUnifiedBet, TBetMainInfo>, new()
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IBaseBetRepository<TBetMainInfo> _betRepository;

        public BaseOngoingBetsListBuilder(
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

        public override void SetBuildParams(BaseOngoingBetsListBuilderParams @params)
        {
            if (!@params.GetPrelive && !@params.GetLive)
            {
                throw new ArgumentException(
                    "getLive and getPrelive both cannot be false. Please review the caller logic.");
            }

            base.SetBuildParams(@params);
        }

        public override void LoadBetsData()
        {
            Context.BetsMainInfo = _betRepository.GetOngoingBets(Params.UserId, getPrelive: Params.GetPrelive, getLive: Params.GetLive);
        }
    }


    public class BaseOngoingBetsListBuilderContext<TUnifiedBet, TBetMainInfo>
        : BaseBetListBuilderContext<TUnifiedBet, TBetMainInfo>
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
    }


    public class BaseOngoingBetsListBuilderParams : BaseBetListBuilderParams
    {
        public BaseOngoingBetsListBuilderParams(int userId) : base(userId)
        {
        }

        public bool GetPrelive { get; set; } = true;
        public bool GetLive { get; set; } = true;
    }
}
