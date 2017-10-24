using System;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Common.Enums;
using Sport.Data.Models.Base;
using Sport.Data.Repositories.BetRepository.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList
{
    public class BaseSimpleBetsListBuilder<TContext,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>
        : BaseBetListBuilder<BaseSimpleBetsListBuilderParams, TContext,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>

        where TContext : BaseSimpleBetsListBuilderContext<TUnifiedBet, TBetMainInfo>, new()
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IBaseBetRepository<TBetMainInfo> _betRepository;

        public BaseSimpleBetsListBuilder(
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
            if (Params.BetType == BetType.Live)
            {
                LoadLiveBets();
            }
            else if (Params.BetType == BetType.Prelive)
            {
                LoadPreliveBets();
            }
            else
            {
                throw new ArgumentException("BetType parameter must be set.");
            }
        }

        private void LoadLiveBets()
        {
            Context.BetsMainInfo =
                _betRepository.GetLiveBets(Params.UserId);
        }

        public void LoadPreliveBets()
        {
            Context.BetsMainInfo =
                _betRepository.GetPreliveBets(Params.UserId);
        }
    }




    public class BaseSimpleBetsListBuilderContext<TUnifiedBet, TBetMainInfo>
        : BaseBetListBuilderContext<TUnifiedBet, TBetMainInfo>
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
    }


    public class BaseSimpleBetsListBuilderParams : BaseBetListBuilderParams
    {
        public BetType BetType { get; set; }

        public BaseSimpleBetsListBuilderParams(int userId, BetType betType) : base(userId)
        {
            BetType = betType;
        }
    }
}
