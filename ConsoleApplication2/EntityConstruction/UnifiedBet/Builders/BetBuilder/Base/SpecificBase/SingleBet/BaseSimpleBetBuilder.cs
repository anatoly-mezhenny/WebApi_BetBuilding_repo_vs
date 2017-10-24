using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Common.Enums;
using Sport.Data.Models.Base;
using Sport.Data.Repositories.BetRepository.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet
{
    public class BaseSimpleBetBuilder<TContext,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>
        : BaseSingleBetBuilder<BaseSimpleBetBuilderParams, TContext,
            TUnifiedBet, TUnifiedBetSelection,
            TBetMainInfo, TBetSelectionMainInfo>

        where TContext : BaseSimpleBetBuilderContext<TUnifiedBet, TBetMainInfo>, new()
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IBaseBetRepository<TBetMainInfo> _betRepository;

        public BaseSimpleBetBuilder(
            IBaseBetRepository<TBetMainInfo> betRepository,
            IMultiTenantCashOutService multiTenantCashOutService,
            IBaseBetMapper<TBetMainInfo, TUnifiedBet> betMapper,
            IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> betSelectionMapper,
            IBaseSingleBetInfoProvider<TContext, TUnifiedBet, TBetMainInfo> taxInfoProvider,
            IBaseSingleBetInfoProvider<TContext, TUnifiedBet, TBetMainInfo> regulatorInfoProvider
            )
            : base(multiTenantCashOutService, betMapper, betSelectionMapper, taxInfoProvider, regulatorInfoProvider)
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
            Context.BetMainInfo = _betRepository.GetPreliveBet(Params.UserId, Params.BetId);
        }

        private void LoadLiveBet()
        {
            Context.BetMainInfo = _betRepository.GetLiveBet(Params.UserId, Params.BetId);
        }
    }


    public class BaseSimpleBetBuilderContext<TUnifiedBet, TBetMainInfo>
        : BaseSingleBetBuilderContext<TUnifiedBet, TBetMainInfo>
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
    }


    public class BaseSimpleBetBuilderParams : BaseSingleBetBuilderParams
    {
        public BetType BetType { get; set; }

        public BaseSimpleBetBuilderParams(int userId, int betId, BetType betType): base(userId, betId)
        {
            BetType = betType;
        }
    }
}
