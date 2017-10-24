using System.Linq;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic
{
    public abstract class BaseSingleBetBuilder
        <TParams, TContext, TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo>
        : BaseBetBuilder<TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo>,
        IBaseSingleBetBuilder<TParams, TUnifiedBet> 

        where TParams : BaseSingleBetBuilderParams
        where TContext : BaseSingleBetBuilderContext<TUnifiedBet, TBetMainInfo>, new()
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IBaseSingleBetInfoProvider<TContext, TUnifiedBet, TBetMainInfo> _taxInfoProvider;
        private readonly IBaseSingleBetInfoProvider<TContext, TUnifiedBet, TBetMainInfo> _regulatorInfoProvider;

        protected BaseSingleBetBuilder(
            IMultiTenantCashOutService multiTenantCashOutService, IBaseBetMapper<TBetMainInfo, TUnifiedBet> betMapper,
            IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> betSelectionMapper,
            IBaseSingleBetInfoProvider<TContext, TUnifiedBet, TBetMainInfo> taxInfoProvider,
            IBaseSingleBetInfoProvider<TContext, TUnifiedBet, TBetMainInfo> regulatorInfoProvider
            )
            : base(multiTenantCashOutService, betMapper, betSelectionMapper)
        {
            _taxInfoProvider = taxInfoProvider;
            _regulatorInfoProvider = regulatorInfoProvider;
        }

        protected TParams Params { get; set; }

        protected override BaseBetBuilderParams BaseParams
        {
            get { return Params; }
        }

        public virtual void SetBuildParams(TParams @params)
        {
            Params = @params;
        }
        public TUnifiedBet GetResult()
        {
            return Context.Bet;
        }

        protected TContext Context { get; set; }

        protected override BaseBetBuilderContext BaseContext
        {
            get { return Context; }
        }
        
        public override void InitBuilder()
        {
            Context = new TContext
            {
                //copy necessary data from params to context
                UserId = Params.UserId
            };
        }

        public override void BuildBetsMainInfo()
        {
            Context.Bet = MapBaseToUnifiedBet(Context.BetMainInfo);
        }

        public override void BuildSelectionsMainInfo()
        {
            Context.Bet.UnifiedBetSelections =
                Context.BetMainInfo.BetSelectionMainInfo.Select(MapBaseToUnifiedBetSelection).ToList();
            
        }

        public override void BuildRegulatorInfo()
        {
            _regulatorInfoProvider?.ProvideInfo(Context);
        }

        public override void BuildCashOutPlacementInfo()
        {
            throw new System.NotImplementedException();
        }

        public override void BuildSelectionScoreboards()
        {
            //TODO:AMI:
        }

        public override void BuildTranslationsInfo()
        {
            //TODO:AMI:
        }

        public override void BuildTaxInfo()
        {
            _taxInfoProvider?.ProvideInfo(Context);
        }
    }


    public class BaseSingleBetBuilderParams : BaseBetBuilderParams
    {
        public BaseSingleBetBuilderParams()
        {
        }

        public BaseSingleBetBuilderParams(int userId, int betId)
        {
            UserId = userId;
            BetId = betId;
        }

        public int UserId { get; set; }
        public int BetId { get; set; }
    }

    public class BaseSingleBetBuilderContext<TUnifiedBet, TBetMainInfo> : BaseBetBuilderContext
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
        public int UserId { get; set; }
        public TUnifiedBet Bet { get; set; }
        public TBetMainInfo BetMainInfo { get; set; }
    }
}
