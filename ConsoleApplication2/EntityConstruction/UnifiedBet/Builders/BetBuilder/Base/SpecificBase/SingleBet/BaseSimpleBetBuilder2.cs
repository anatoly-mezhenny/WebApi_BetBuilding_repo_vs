using System.Linq;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Common.Enums;
using Sport.Data.Models.Base;
using Sport.Data.Repositories.BetRepository.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet
{
    class BaseSimpleBetBuilder2<
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>
        : BaseSimpleBetsListBuilder<BaseSimpleBetsListBuilderContextExt<TUnifiedBet, TBetMainInfo>,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>,
        IBaseSingleBetBuilder<BaseSimpleBetBuilderParams, TUnifiedBet>
        
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IBaseBetRepository<TBetMainInfo> _betRepository;

        public BaseSimpleBetBuilder2(
            IBaseBetRepository<TBetMainInfo> betRepository,
            IMultiTenantCashOutService multiTenantCashOutService, IBaseBetMapper<TBetMainInfo, TUnifiedBet> betMapper, IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> betSelectionMapper,
            IBaseBetListInfoProvider<BaseSimpleBetsListBuilderContextExt<TUnifiedBet, TBetMainInfo>, TUnifiedBet, TBetMainInfo> taxInfoProvider,
            IBaseBetListInfoProvider<BaseSimpleBetsListBuilderContextExt<TUnifiedBet, TBetMainInfo>, TUnifiedBet, TBetMainInfo> regulatorInfoProvider)
            : base(betRepository, multiTenantCashOutService, betMapper, betSelectionMapper, taxInfoProvider, regulatorInfoProvider)
        {
            _betRepository = betRepository;
        }


        public override void LoadBetsData()
        {
            if (Params.BetType == BetType.Prelive)
            {
                LoadPreliveBet();
            }
            else if (Params.BetType == BetType.Live)
            {
                LoadLiveBet();
            }
        }

        private void LoadPreliveBet()
        {
            Context.BetsMainInfo = new [] { _betRepository.GetPreliveBet(Params.UserId, Context.BetId) };
        }

        private void LoadLiveBet()
        {
            Context.BetsMainInfo = new[] { _betRepository.GetLiveBet(Params.UserId, Context.BetId) };
        }

        void IBaseSingleBetBuilder<BaseSimpleBetBuilderParams, TUnifiedBet>.SetBuildParams(BaseSimpleBetBuilderParams @params)
        {
            Params = new BaseSimpleBetsListBuilderParams(@params.UserId, @params.BetType);
            Context.BetId = @params.BetId;
        }

        TUnifiedBet IBaseSingleBetBuilder<BaseSimpleBetBuilderParams, TUnifiedBet>.GetResult()
        {
            return Context.Bets.FirstOrDefault();
        }
    }


    public class BaseSimpleBetsListBuilderContextExt<TUnifiedBet, TBetMainInfo>
        : BaseSimpleBetsListBuilderContext<TUnifiedBet, TBetMainInfo>
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
        public int BetId { get; set; }
    }
}
