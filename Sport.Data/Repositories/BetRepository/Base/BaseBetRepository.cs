using System.Collections.Generic;
using Sport.Common.Utilities;
using Sport.Data.Models.Base;

namespace Sport.Data.Repositories.BetRepository.Base
{
    public abstract class BaseBetRepository<TBetMainInfo>
        : IBaseBetRepository<TBetMainInfo>
        where TBetMainInfo : BaseBetMainInfo
    {
        IEnumerable<BaseBetMainInfo> IBaseBetRepository.GetOngoingBets(int userId, bool onlyCashoutableBets, bool getPrelive = true, bool getLive = true)
        {
            return GetOngoingBets(userId, onlyCashoutableBets, getPrelive, getLive);
        }

        BaseBetMainInfo IBaseBetRepository.GetPreliveBet(int userId, int betId)
        {
            return GetPreliveBet(userId, betId);
        }

        BaseBetMainInfo IBaseBetRepository.GetLiveBet(int userId, int betId)
        {
            return GetLiveBet(userId, betId);
        }

        public abstract TBetMainInfo GetPreliveBet(int userId, int betId);

        public abstract TBetMainInfo GetLiveBet(int userId, int betId);

        RangingResult<BaseBetMainInfo> IBaseBetRepository.GetEndedBets(int userId, EndedStakesFilters endedStakesFilters)
        {
            var rr = GetEndedBets(userId, endedStakesFilters);
            return RangingResultHelper.CreateFrom<BaseBetMainInfo, TBetMainInfo>(rr);
        }

        public abstract RangingResult<TBetMainInfo> GetEndedBets(int userId, EndedStakesFilters endedStakesFilters);

        public abstract IEnumerable<TBetMainInfo> GetOngoingBets(int userId, bool onlyCashoutableBets = false,
            bool getPrelive = true, bool getLive = true);

        IEnumerable<BaseBetMainInfo> IBaseBetRepository.GetPreliveBets(int userId)
        {
            return GetPreliveBets(userId);
        }

        public abstract IEnumerable<TBetMainInfo> GetPreliveBets(int userId);

        IEnumerable<BaseBetMainInfo> IBaseBetRepository.GetLiveBets(int userId)
        {
            return GetLiveBets(userId);
        }

        public abstract IEnumerable<TBetMainInfo> GetLiveBets(int userId);
    }
}