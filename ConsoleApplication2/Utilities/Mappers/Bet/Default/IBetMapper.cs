using ConsoleApplication2.Entities.Bet.Default;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Default;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Default
{
    public interface IBetMapper : IBaseBetMapper<BetMainInfo, UnifiedBet>
    {
    }
}