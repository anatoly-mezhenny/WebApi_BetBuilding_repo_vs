using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic
{
    public abstract class BaseBetListBuilder<TParams, TContext, TUnifiedBet, TUnifiedBetSelection,TBetMainInfo, TBetSelectionMainInfo> 
        : BaseBetBuilder<TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo>,
        IBaseBetListBuilder<TParams, TUnifiedBet>

        where TParams : BaseBetListBuilderParams
        where TContext : BaseBetListBuilderContext<TUnifiedBet, TBetMainInfo>, new()
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IBaseBetListInfoProvider<TContext, TUnifiedBet, TBetMainInfo> _taxInfoProvider;
        private readonly IBaseBetListInfoProvider<TContext, TUnifiedBet, TBetMainInfo> _regulatorInfoProvider;

        protected BaseBetListBuilder(
            IMultiTenantCashOutService multiTenantCashOutService,
            IBaseBetMapper<TBetMainInfo, TUnifiedBet> betMapper,
            IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> betSelectionMapper,
            IBaseBetListInfoProvider<TContext, TUnifiedBet, TBetMainInfo> taxInfoProvider,
            IBaseBetListInfoProvider<TContext, TUnifiedBet, TBetMainInfo> regulatorInfoProvider
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
        public IEnumerable<TUnifiedBet> GetResult()
        {
            return Context.Bets;
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
            Context.Bets = MapBaseToUnifiedBetList(Context.BetsMainInfo);
        }

        public override void BuildSelectionsMainInfo()
        {
            var betMainInfoDict = Context.BetsMainInfo.ToDictionary(dm => dm.Id, dm => dm);

            foreach (var bet in Context.Bets)
            {
                var betMi = betMainInfoDict[bet.Id];
                bet.UnifiedBetSelections =
                    betMi.BetSelectionMainInfo.Select(MapBaseToUnifiedBetSelection).ToList();
            }
        }

        public override void BuildTaxInfo()
        {
            _taxInfoProvider?.ProvideInfo(Context);
        }

        public override void BuildRegulatorInfo()
        {
            _regulatorInfoProvider?.ProvideInfo(Context);
        }

        public override void BuildCashOutPlacementInfo()
        {
            var cashOutDict = GetBetsCashOutDict(Params.UserId, Context.Bets.Select(b => b.Id).ToList());
            foreach (var bet in Context.Bets)
            {
                if (cashOutDict.ContainsKey(bet.Id))
                {
                    bet.CashOutPlacementInfo = cashOutDict[bet.Id];
                }
            }
        }

        public override void BuildSelectionScoreboards()
        {
            //TODO:AMI:
        }

        public override void BuildTranslationsInfo()
        {
            //TODO:AMI:
        }

    }

    public class BaseBetListBuilderParams : BaseBetBuilderParams
    {
        public BaseBetListBuilderParams()
        {
        }

        public BaseBetListBuilderParams(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }

    public class BaseBetListBuilderContext<TUnifiedBet, TBetMainInfo> : BaseBetBuilderContext
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
        public int UserId { get; set; }
        public IEnumerable<TUnifiedBet> Bets { get; set; }
        public IEnumerable<TBetMainInfo> BetsMainInfo { get; set; }
    }
    
     
}
