using System.Collections.Generic;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BuilderDirectors.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Base;
using Sport.Common.Enums;
using Sport.Common.Utilities;

namespace ConsoleApplication2.Services.MultitenantUnifiedBetService.Base
{
    /// <summary>
    /// Class contains common logic between all brands.
    /// </summary>
    public abstract class BaseMultitenantUnifiedBetService<TUnifiedBet> : IBaseMultitenantUnifiedBetService<TUnifiedBet>
        where TUnifiedBet : BaseUnifiedBet
    {
        private readonly IBaseBetBuilderFactory<TUnifiedBet> _betBuilderFactory;

        protected BaseMultitenantUnifiedBetService(IBaseBetBuilderFactory<TUnifiedBet> betBuilderFactory)
        {
            _betBuilderFactory = betBuilderFactory;
        }

        IEnumerable<BaseUnifiedBet> IBaseMultitenantUnifiedBetService.GetOngoingBets(int userId, bool getLive = true, bool getPrelive = true, bool buildScoreboards = false)
        {
            return GetOngoingBets(userId, getLive, getPrelive, buildScoreboards);
        }

        IEnumerable<BaseUnifiedBet> IBaseMultitenantUnifiedBetService.GetAllOngoingCashoutableBets(int userId)
        {
            return GetAllOngoingCashoutableBets(userId);
        }

        BaseUnifiedBet IBaseMultitenantUnifiedBetService.GetPreliveBet(int userId, int betId, bool buildScoreboards)
        {
            return GetPreliveBet(userId, betId, buildScoreboards);
        }

        BaseUnifiedBet IBaseMultitenantUnifiedBetService.GetLiveBet(int userId, int betId, bool buildScoreboards)
        {
            return GetLiveBet(userId, betId, buildScoreboards);
        }

        RangingResult<BaseUnifiedBet> IBaseMultitenantUnifiedBetService.GetEndedBets(int userId, EndedStakesFilters endedStakesFilters)
        {
            var rr = GetEndedBets(userId, endedStakesFilters);
            return RangingResultHelper.CreateFrom<BaseUnifiedBet, TUnifiedBet>(rr);
        }

        IEnumerable<BaseUnifiedBet> IBaseMultitenantUnifiedBetService.GetLiveBets(int userId, bool buildScoreboards)
        {
            return GetLiveBets(userId, buildScoreboards);
        }

        IEnumerable<BaseUnifiedBet> IBaseMultitenantUnifiedBetService.GetPreliveBets(int userId, bool buildScoreboards)
        {
            return GetPreliveBets(userId, buildScoreboards);
        }

        //may contain some "base" implementation or be abstract 
        public virtual IEnumerable<TUnifiedBet> GetOngoingBets(int userId, bool getLive = true, bool getPrelive = true, bool buildScoreboards = false)
        {
            //create builder, provide build params
            var builder = _betBuilderFactory.CreateOngoingBetsListBuilder();
            builder.SetBuildParams(new BaseOngoingBetsListBuilderParams(userId)
                    { GetLive = getLive, GetPrelive = getPrelive });
            //create director, provide construction params
            var director = new BaseBetBuildDirector(builder);
            director.ConstructionParameters.BuildCashOutPlacementInfo = true;
            director.ConstructionParameters.BuildSelectionScoreboards = buildScoreboards;
            //construct
            director.Construct();
            //get result
            return builder.GetResult();
        }

        //may contain some "base" implementation or be abstract 
        public virtual IEnumerable<TUnifiedBet> GetAllOngoingCashoutableBets(int userId)
        {
            //create builder, provide build params
            var builder = _betBuilderFactory.CreateOngoingCashoutableBetsListBuilder();
            builder.SetBuildParams(new BaseOngoingCashoutableBetsListBuilderParams(userId));
            //create director, provide construction params
            var director = new BaseBetBuildDirector(builder);
            director.ConstructionParameters.BuildSelectionScoreboards = true;
            director.ConstructionParameters.BuildCashOutPlacementInfo = true;
            //construct
            director.Construct();
            //get result
            return builder.GetResult();
        }

        public virtual RangingResult<TUnifiedBet> GetEndedBets(int userId, EndedStakesFilters endedStakesFilters)
        {
            //create builder, provide build params
            var builder = _betBuilderFactory.CreateEndedBetRangingResultBuilder();
            builder.SetBuildParams(new BaseEndedBetRangingResultBuilderParams(userId, endedStakesFilters));
            //create director, provide construction params
            var director = new BaseBetBuildDirector(builder);
            //construct
            director.Construct();
            //get result
            return builder.GetResult();
        }

        public virtual TUnifiedBet GetLiveBet(int userId, int betId, bool buildScoreboards = false)
        {
            //create builder, provide build params
            var builder = _betBuilderFactory.CreateSimpleBetBuilder();
            builder.SetBuildParams(new BaseSimpleBetBuilderParams(userId, betId, BetType.Live));
            //create director, provide construction params
            var director = new BaseBetBuildDirector(builder);
            director.ConstructionParameters.BuildSelectionScoreboards = buildScoreboards;
            //construct
            director.Construct();
            //get result
            return builder.GetResult();
        }

        public virtual TUnifiedBet GetPreliveBet(int userId, int betId, bool buildScoreboards = false)
        {
            //create builder, provide build params
            var builder = _betBuilderFactory.CreateSimpleBetBuilder();
            builder.SetBuildParams(new BaseSimpleBetBuilderParams(userId, betId, BetType.Prelive));
            //create director, provide construction params
            var director = new BaseBetBuildDirector(builder);
            director.ConstructionParameters.BuildSelectionScoreboards = buildScoreboards;
            //construct
            director.Construct();
            //get result
            return builder.GetResult();
        }

        public virtual IEnumerable<TUnifiedBet> GetLiveBets(int userId, bool buildScoreboards = false)
        {
            //create builder, provide build params
            var builder = _betBuilderFactory.CreateSimpleBetsListBuilder();
            builder.SetBuildParams(new BaseSimpleBetsListBuilderParams(userId, BetType.Live));
            //create director, provide construction params
            var director = new BaseBetBuildDirector(builder);
            director.ConstructionParameters.BuildSelectionScoreboards = buildScoreboards;
            //construct
            director.Construct();
            //get result
            return builder.GetResult();
        }

        public virtual IEnumerable<TUnifiedBet> GetPreliveBets(int userId, bool buildScoreboards = false)
        {
            //create builder, provide build params
            var builder = _betBuilderFactory.CreateSimpleBetsListBuilder();
            builder.SetBuildParams(new BaseSimpleBetsListBuilderParams(userId, BetType.Prelive));
            //create director, provide construction params
            var director = new BaseBetBuildDirector(builder);
            director.ConstructionParameters.BuildSelectionScoreboards = buildScoreboards;
            //construct
            director.Construct();
            //get result
            return builder.GetResult();
        }
    }
}