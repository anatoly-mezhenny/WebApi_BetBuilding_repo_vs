using System.Collections.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult;

namespace ConsoleApplication2.Utilities.Mappers
{
    public class EndedStakesFiltersMapHelper
    {
        public static Sport.Data.Repositories.BetRepository.Base.EndedStakesFilters MapToEndedStakesFilters(
            EndedStakesFilters endedStakesFilters)
        {
            return new Sport.Data.Repositories.BetRepository.Base.EndedStakesFilters
            {
                StartDate = endedStakesFilters.StartDate,
                EndDate = endedStakesFilters.EndDate,
                Type = MapStakeTypeFilter(endedStakesFilters.Type),
                StartIndex = endedStakesFilters.StartIndex,
                LastIndex = endedStakesFilters.LastIndex,
                IsLive = endedStakesFilters.IsLive,
                StakeIds = new List<int>(endedStakesFilters.StakeIds),
                SinceLastVisit = endedStakesFilters.SinceLastVisit,
            };
        }


        private static Sport.Data.Repositories.BetRepository.Base.EndedStakesFilters.StakeTypeFilter MapStakeTypeFilter(EndedStakesFilters.StakeTypeFilter stakeTypeFilter)
        {
            return (Sport.Data.Repositories.BetRepository.Base.EndedStakesFilters.StakeTypeFilter)stakeTypeFilter;
        }
    }
}
