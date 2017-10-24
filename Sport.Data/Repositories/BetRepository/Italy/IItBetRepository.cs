using System.Collections.Generic;
using Sport.Data.Models.Italy;
using Sport.Data.Repositories.BetRepository.Base;

namespace Sport.Data.Repositories.BetRepository.Italy
{
    public interface IItBetRepository : IBaseBetRepository<ItBetMainInfo>
    {
        IEnumerable<ItBetMainInfo> GetPendingBets(int userId, bool onlyCashoutableStakes = false, bool getPrelive = true, bool getLive = true);
    }
}