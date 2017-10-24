using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult;
using ConsoleApplication2.Services.MultitenantUnifiedBetService.Base;
using Sport.Common.Utilities;
using WebApi.Dto;

namespace WebApi.UserBetDtoBuilder.Base
{
    public abstract class BaseUserBetDtoBuilder<TUserBetDto, TUnifiedBet> : IBaseUserBetDtoBuilder<TUserBetDto>
        where TUserBetDto : BaseUserBetDto
        where TUnifiedBet : BaseUnifiedBet
    {
        private readonly IBaseMultitenantUnifiedBetService<TUnifiedBet> _multitenantUnifiedBetService;

        protected BaseUserBetDtoBuilder(IBaseMultitenantUnifiedBetService<TUnifiedBet> multitenantUnifiedBetService)
        {
            _multitenantUnifiedBetService = multitenantUnifiedBetService;
        }


        IEnumerable<BaseUserBetDto> IBaseUserBetDtoBuilder.GetOngoingUserBetDtos(int userId, bool getLive = true, bool getPrelive = true, bool getScoreboards = false)
        {
            return GetOngoingUserBetDtos(userId, getLive, getPrelive, getScoreboards);
        }
        public virtual IEnumerable<TUserBetDto> GetOngoingUserBetDtos(int userId, bool getLive = true,
            bool getPrelive = true, bool getScoreboards = false)
        {
            return
                _multitenantUnifiedBetService.GetOngoingBets(userId, getLive, getPrelive, getScoreboards)
                .Select(MapToDto).ToList();
        }

        
        IEnumerable<BaseUserBetDto> IBaseUserBetDtoBuilder.GetAllOngoingCashoutableUserBetDtos(int userId)
        {
            return GetAllOngoingCashoutableUserBetDtos(userId);
        }
        public virtual IEnumerable<TUserBetDto> GetAllOngoingCashoutableUserBetDtos(int userId)
        {
            return
                _multitenantUnifiedBetService.GetAllOngoingCashoutableBets(userId)
                .Select(MapToDto).ToList();
        }


        BaseUserBetDto IBaseUserBetDtoBuilder.GetPreliveBetDto(int userId, int betId, bool getScoreboards)
        {
            return GetPreliveBetDto(userId, betId, getScoreboards);
        }
        public TUserBetDto GetPreliveBetDto(int userId, int betId, bool getScoreboards = false)
        {
            return MapToDto(_multitenantUnifiedBetService.GetPreliveBet(userId, betId, getScoreboards));
        }


        BaseUserBetDto IBaseUserBetDtoBuilder.GetLiveBetDto(int userId, int betId, bool getScoreboards)
        {
            return GetLiveBetDto(userId, betId, getScoreboards);
        }
        public TUserBetDto GetLiveBetDto(int userId, int betId, bool getScoreboards = false)
        {
            return MapToDto(_multitenantUnifiedBetService.GetPreliveBet(userId, betId, getScoreboards));
        }


        RangingResult<BaseUserBetDto> IBaseUserBetDtoBuilder.GetEndedUserBetDtos(int userId, EndedStakesFilters endedStakesFilters)
        {
            var rr = GetEndedUserBetDtos(userId, endedStakesFilters);
            return RangingResultHelper.CreateFrom<BaseUserBetDto, TUserBetDto>(rr);
        }
        public virtual RangingResult<TUserBetDto> GetEndedUserBetDtos(int userId, EndedStakesFilters endedStakesFilters)
        {
            var rr = _multitenantUnifiedBetService.GetEndedBets(userId, endedStakesFilters);
            var lst = rr.Items.Select(MapToDto).ToList();
            var ongonigBetDtos = new RangingResult<TUserBetDto>(rr.From, rr.To, rr.Total, lst, rr.ItemsInRangeCount);
            return ongonigBetDtos;
        }
        

        protected abstract TUserBetDto MapToDto(TUnifiedBet unifiedBet);
    }


}
