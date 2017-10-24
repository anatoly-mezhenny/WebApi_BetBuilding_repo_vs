using System.Collections.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult;
using Sport.Common.Utilities;
using WebApi.Dto;

namespace WebApi.UserBetDtoBuilder.Base
{
    public interface IBaseUserBetDtoBuilder
    {
        IEnumerable<BaseUserBetDto> GetOngoingUserBetDtos(int userId, bool getLive = true, bool getPrelive = true, bool getScoreboards = false);
        IEnumerable<BaseUserBetDto> GetAllOngoingCashoutableUserBetDtos(int userId);
        BaseUserBetDto GetPreliveBetDto(int userId, int betId, bool getScoreboards = false);
        BaseUserBetDto GetLiveBetDto(int userId, int betId, bool getScoreboards = false);
        RangingResult<BaseUserBetDto> GetEndedUserBetDtos(int userId, EndedStakesFilters endedStakesFilters);
    }

    public interface IBaseUserBetDtoBuilder<TUserBetDto> : IBaseUserBetDtoBuilder
        where TUserBetDto : BaseUserBetDto
    {
        new IEnumerable<TUserBetDto> GetOngoingUserBetDtos(int userId, bool getLive = true, bool getPrelive = true, bool getScoreboards = false);
        new IEnumerable<TUserBetDto> GetAllOngoingCashoutableUserBetDtos(int userId);
        new TUserBetDto GetPreliveBetDto(int userId, int betId, bool getScoreboards = false);
        new TUserBetDto GetLiveBetDto(int userId, int betId, bool getScoreboards = false);
        new RangingResult<TUserBetDto> GetEndedUserBetDtos(int userId, EndedStakesFilters endedStakesFilters);
    }
}