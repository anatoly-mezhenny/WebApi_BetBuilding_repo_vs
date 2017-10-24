using System;
using System.Linq;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Common.Utilities;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic
{
    public abstract class BaseBetRangingResultBuilder<TParams, TContext, TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo>
        : BaseBetBuilder<TUnifiedBet, TUnifiedBetSelection, TBetMainInfo, TBetSelectionMainInfo>,
        IBaseBetRangingResultBuilder<TParams, TUnifiedBet>

        where TParams : BaseBetRangingResultBuilderParams
        where TContext : BaseBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo>, new()
        where TUnifiedBet : BaseUnifiedBet<TUnifiedBetSelection>
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IBaseBetRangingResultInfoProvider<TContext, TUnifiedBet, TBetMainInfo> _taxInfoProvider;
        private readonly IBaseBetRangingResultInfoProvider<TContext, TUnifiedBet, TBetMainInfo> _regulatorInfoProvider;

        protected BaseBetRangingResultBuilder(
            IMultiTenantCashOutService multiTenantCashOutService, IBaseBetMapper<TBetMainInfo, TUnifiedBet> betMapper,
            IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> betSelectionMapper,
            IBaseBetRangingResultInfoProvider<TContext, TUnifiedBet, TBetMainInfo> taxInfoProvider,
            IBaseBetRangingResultInfoProvider<TContext, TUnifiedBet, TBetMainInfo> regulatorInfoProvider
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
        public RangingResult<TUnifiedBet> GetResult()
        {
            return Context.RangingResult;
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
            var rr = Context.BetsMainInfoRangingResult;
            Context.RangingResult = new RangingResult<TUnifiedBet>(rr.From, rr.To, rr.Total,
                rr.Items.Select(MapBaseToUnifiedBet).ToList(), rr.ItemsInRangeCount);
        }

        public override void BuildSelectionsMainInfo()
        {
            var betMainInfoDict = Context.BetsMainInfoRangingResult.Items.ToDictionary(dm => dm.Id, dm => dm);

            foreach (var bet in Context.RangingResult.Items)
            {
                var betMi = betMainInfoDict[bet.Id];
                bet.UnifiedBetSelections =
                    betMi.BetSelectionMainInfo.Select(MapBaseToUnifiedBetSelection).ToList();
            }
        }

        public override void BuildRegulatorInfo()
        {
            _regulatorInfoProvider?.ProvideInfo(Context);
        }

        public override void BuildCashOutPlacementInfo()
        {
            var cashOutDict = GetBetsCashOutDict(Params.UserId, Context.RangingResult.Items.Select(b => b.Id).ToList());
            foreach (var bet in Context.RangingResult.Items)
            {
                if (cashOutDict.ContainsKey(bet.Id))
                {
                    bet.CashOutPlacementInfo = cashOutDict[bet.Id];
                }
            }
        }

        public override void BuildSelectionScoreboards()
        {
            throw new NotImplementedException();
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

    public class BaseBetRangingResultBuilderParams : BaseBetBuilderParams
    {
        public BaseBetRangingResultBuilderParams()
        {
        }

        public BaseBetRangingResultBuilderParams(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }

    public class BaseBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo> : BaseBetBuilderContext
        where TUnifiedBet : BaseUnifiedBet
        where TBetMainInfo : BaseBetMainInfo
    {
        public int UserId { get; set; }
        public RangingResult<TUnifiedBet> RangingResult { get; set; }
        public RangingResult<TBetMainInfo> BetsMainInfoRangingResult { get; set; }
    }
}
