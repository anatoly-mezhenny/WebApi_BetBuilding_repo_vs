using System;
using System.Collections.Generic;
using Sport.Common.Utilities;
using WebApi.Dto;
using WebApi.Dto.MappingHelpers;
using WebApi.UserBetDtoBuilder.Base;
using WebApi.UserBetDtoBuilder.Base.FeatureSpecific;

namespace WebApi.Controllers
{
    public class BetsController
    {
        private readonly Lazy<IBaseUserBetDtoBuilder> _userBetDtoBuilder;
        private readonly Lazy<IBasePendingUserBetDtoBuilder> _pendingUserBetDtoBuilder;

        public BetsController(
            Lazy<IBaseUserBetDtoBuilder> userBetDtoBuilder,
            Lazy<IBasePendingUserBetDtoBuilder> pendingUserBetDtoBuilder
            )
        {
            _userBetDtoBuilder = userBetDtoBuilder;
            _pendingUserBetDtoBuilder = pendingUserBetDtoBuilder;
        }

        public IEnumerable<BaseUserBetDto> GetOngoingBets(int userId, bool getLive = true, bool getPrelive = true, bool getScoreboards = false)
        {
            return _userBetDtoBuilder.Value.GetOngoingUserBetDtos(userId, getLive, getPrelive, getScoreboards);
        }

        public IEnumerable<BaseUserBetDto> GetAllOngoingCashoutableBets(int userId)
        {
            return _userBetDtoBuilder.Value.GetAllOngoingCashoutableUserBetDtos(userId);
        }

        public BaseUserBetDto GetPreliveBet(int userId, int betId, bool getScoreboard = false)
        {
            return _userBetDtoBuilder.Value.GetPreliveBetDto(userId, betId, getScoreboard);
        }

        public BaseUserBetDto GetLiveBet(int userId, int betId, bool getScoreboard = false)
        {
            return _userBetDtoBuilder.Value.GetLiveBetDto(userId, betId, getScoreboard);
        }

        public RangingResult<BaseUserBetDto> GetEndedBets(int userId, EndedStakesFiltersDto endedStakesFiltersDto)
        {
            var endedStakesFilters = EndedStakesFiltersHelper.MapToEndedStakesFilters(endedStakesFiltersDto);
            return _userBetDtoBuilder.Value.GetEndedUserBetDtos(userId, endedStakesFilters);
        }

        public IEnumerable<BaseUserBetDto> GetPendingBets(int userId)
        {
            return _pendingUserBetDtoBuilder.Value.GetPendingUserBetDtos(userId);
        }
    }
}



