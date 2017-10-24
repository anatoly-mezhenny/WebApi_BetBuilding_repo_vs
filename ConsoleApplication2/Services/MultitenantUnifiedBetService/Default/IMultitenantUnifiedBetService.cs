using ConsoleApplication2.Entities.Bet.Default;
using ConsoleApplication2.Services.MultitenantUnifiedBetService.Base;

namespace ConsoleApplication2.Services.MultitenantUnifiedBetService.Default
{
    public interface IMultitenantUnifiedBetService : IBaseMultitenantUnifiedBetService<UnifiedBet>
    {
    }
}