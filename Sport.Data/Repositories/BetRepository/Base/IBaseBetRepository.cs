using System;
using System.Collections.Generic;
using Sport.Common.Utilities;
using Sport.Data.Models.Base;

namespace Sport.Data.Repositories.BetRepository.Base
{
    public interface IBaseBetRepository<TBetMainInfo> : IBaseBetRepository
        where TBetMainInfo : BaseBetMainInfo
    {
        new IEnumerable<TBetMainInfo> GetOngoingBets(int userId, bool onlyCashoutableBets = false, bool getPrelive = true, bool getLive = true);
        new RangingResult<TBetMainInfo> GetEndedBets(int userId, EndedStakesFilters endedStakesFilters);
        new TBetMainInfo GetPreliveBet(int userId, int betId);
        new TBetMainInfo GetLiveBet(int userId, int betId);
        new IEnumerable<TBetMainInfo> GetPreliveBets(int userId);
        new IEnumerable<TBetMainInfo> GetLiveBets(int userId);
    }

    public interface IBaseBetRepository
    {
        IEnumerable<BaseBetMainInfo> GetOngoingBets(int userId, bool onlyCashoutableStakes = false, bool getPrelive = true, bool getLive = true);
        RangingResult<BaseBetMainInfo> GetEndedBets(int userId, EndedStakesFilters endedStakesFilters);
        BaseBetMainInfo GetPreliveBet(int userId, int betId);
        BaseBetMainInfo GetLiveBet(int userId, int betId);
        IEnumerable<BaseBetMainInfo> GetPreliveBets(int userId);
        IEnumerable<BaseBetMainInfo> GetLiveBets(int userId);
    }

    public class EndedStakesFilters
    {
        /// <summary>
        /// Represents the type of stake that have to be returned.
        /// </summary>
        public enum StakeTypeFilter
        {
            None = 0,
            All,
            Winning,
            Losing
        }

        public int UserId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public StakeTypeFilter Type { get; set; }

        public int StartIndex { get; set; }

        public int LastIndex { get; set; }

        public bool IsLive { get; set; }

        public IEnumerable<int> StakeIds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether stakes placed since user's last visit have to be returned (<c>true</c>) or all user's stakes (<c>false</c>).
        /// </summary>
        public bool SinceLastVisit { get; set; }

        public EndedStakesFilters()
        {
            StakeIds = new List<int>();
        }
    }
}
