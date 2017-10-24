using System.Collections.Generic;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult;
using Sport.Common.Utilities;

namespace ConsoleApplication2.Services.MultitenantUnifiedBetService.Base
{
    public interface IBaseMultitenantUnifiedBetService
    {
        IEnumerable<BaseUnifiedBet> GetOngoingBets(int userId, bool getLive = true, bool getPrelive = true, bool buildScoreboards = false);
        IEnumerable<BaseUnifiedBet> GetAllOngoingCashoutableBets(int userId);
        BaseUnifiedBet GetPreliveBet(int userId, int betId, bool buildScoreboards = false);
        BaseUnifiedBet GetLiveBet(int userId, int betId, bool buildScoreboards = false);
        IEnumerable<BaseUnifiedBet> GetLiveBets(int userId, bool buildScoreboards = false);
        IEnumerable<BaseUnifiedBet> GetPreliveBets(int userId, bool buildScoreboards = false);
        RangingResult<BaseUnifiedBet> GetEndedBets(int userId, EndedStakesFilters endedStakesFilters);
    }

    public interface IBaseMultitenantUnifiedBetService<TUnifiedBet> : IBaseMultitenantUnifiedBetService
        where TUnifiedBet : BaseUnifiedBet
    {
        new IEnumerable<TUnifiedBet> GetOngoingBets(int userId, bool getLive = true, bool getPrelive = true, bool buildScoreboards = false);
        new IEnumerable<TUnifiedBet> GetAllOngoingCashoutableBets(int userId);
        new TUnifiedBet GetPreliveBet(int userId, int betId, bool buildScoreboards = false);
        new TUnifiedBet GetLiveBet(int userId, int betId, bool buildScoreboards = false);
        new IEnumerable<TUnifiedBet> GetLiveBets(int userId, bool buildScoreboards = false);
        new IEnumerable<TUnifiedBet> GetPreliveBets(int userId, bool buildScoreboards = false);
        new RangingResult<TUnifiedBet> GetEndedBets(int userId, EndedStakesFilters endedStakesFilters);
    }
}