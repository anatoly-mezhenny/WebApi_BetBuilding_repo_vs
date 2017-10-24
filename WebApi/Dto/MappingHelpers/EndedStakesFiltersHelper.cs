using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult;

namespace WebApi.Dto.MappingHelpers
{
    public static class EndedStakesFiltersHelper
    {
        public static EndedStakesFilters MapToEndedStakesFilters(EndedStakesFiltersDto endedStakesFiltersDto)
        {
            return new EndedStakesFilters
            {
                LastIndex = endedStakesFiltersDto.LastIndex,
                StartIndex = endedStakesFiltersDto.StartIndex,
                IsLive = endedStakesFiltersDto.IsLive,
                //TODO: other fields....
            };
        }
    }
}
