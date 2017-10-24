using System.Collections.Generic;
using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.Services.MultitenantUnifiedBetService.Base;

namespace ConsoleApplication2.Services.MultitenantUnifiedBetService.Italy
{
    public interface IItMultitenantUnifiedBetService : IBaseMultitenantUnifiedBetService<ItUnifiedBet>
    {
        IEnumerable<ItUnifiedBet> GetAllPendingBets(int userId);
    }
}