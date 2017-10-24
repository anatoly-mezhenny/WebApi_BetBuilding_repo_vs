using System.Collections.Generic;
using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BuilderDirectors.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Italy;
using ConsoleApplication2.Services.MultitenantUnifiedBetService.Base;

namespace ConsoleApplication2.Services.MultitenantUnifiedBetService.Italy
{
    public class ItMultitenantUnifiedBetService : 
        BaseMultitenantUnifiedBetService<ItUnifiedBet>, 
        IItMultitenantUnifiedBetService
    {
        private readonly IItBetBuilderFactory _betBuilderFactory;

        /// <summary>
        /// </summary>
        /// <param name="betBuilderFactory">Brand-specific factory may return brand-specific builders</param>
        public ItMultitenantUnifiedBetService(IItBetBuilderFactory betBuilderFactory) : base(betBuilderFactory)
        {
            _betBuilderFactory = betBuilderFactory;
        }

        //some italy-specific methods (available under IItMultitenantUnifiedBetService interface 
        //if needed by client - WebApi, for ex.)
        public IEnumerable<ItUnifiedBet> GetAllPendingBets(int userId)
        {
            //create builder, provide build params
            var builder = _betBuilderFactory.CreatePendingBetsListBuilder();
            builder.SetBuildParams(new ItPendingBetsListBuilderParams(userId));
            //create director, provide construction params
            var director = new BaseBetBuildDirector(builder);
            //construct
            director.Construct();
            //get result
            return builder.GetResult();
        }
        
    }
}