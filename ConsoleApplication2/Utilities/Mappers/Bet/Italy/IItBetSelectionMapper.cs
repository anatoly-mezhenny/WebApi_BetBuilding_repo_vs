using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Italy;

namespace ConsoleApplication2.Utilities.Mappers.Bet.Italy
{
    public interface IItBetSelectionMapper : IBaseBetSelectionMapper<ItBetSelectionMainInfo, ItUnifiedBetSelection>
    {
    }
}