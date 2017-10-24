using System.Collections.Generic;
using WebApi.Dto;

namespace WebApi.UserBetDtoBuilder.Base.FeatureSpecific
{
    public interface IBasePendingUserBetDtoBuilder
    {
        IEnumerable<BaseUserBetDto> GetPendingUserBetDtos(int userId);
    }

    public interface IBasePendingUserBetDtoBuilder<TUserBetDto> : IBasePendingUserBetDtoBuilder
        where TUserBetDto : BaseUserBetDto
    {
        new IEnumerable<TUserBetDto> GetPendingUserBetDtos(int userId);
    }
}