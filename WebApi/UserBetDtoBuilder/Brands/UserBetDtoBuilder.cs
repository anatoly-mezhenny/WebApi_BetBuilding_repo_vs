using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2.Entities.Bet.Default;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult;
using ConsoleApplication2.Services.MultitenantUnifiedBetService.Default;
using Sport.Common.Utilities;
using WebApi.Dto;
using WebApi.UserBetDtoBuilder.Base;

namespace WebApi.UserBetDtoBuilder.Brands
{
    public class UserBetDtoBuilder : BaseUserBetDtoBuilder<UserBetDto, UnifiedBet>
    {
        public UserBetDtoBuilder(IMultitenantUnifiedBetService multitenantUnifiedBetService)
            :base(multitenantUnifiedBetService)
        {
        }

        protected override UserBetDto MapToDto(UnifiedBet unifiedBet)
        {
            var userBetDto = new UserBetDto
            {
                CommonPropertyForAllBrands = unifiedBet.CommonPropertyForAllBrands,
                DefaultSpecificBetProperty = unifiedBet.DefaultSpecificBetProperty,
                TaxInfo = BaseEntitiesMappingHelper.MapBaseTaxInfoToDto(unifiedBet.TaxInfo),
                UnifiedBetSelections = unifiedBet.UnifiedBetSelections?.Select(MapSelectionToDto).ToList()
            };
            return userBetDto;
        }

        private static UserBetSelectionDto MapSelectionToDto(UnifiedBetSelection ubD)
        {
            return new UserBetSelectionDto
            {
                CommonBaseUnifiedBetSelectionProperty = ubD.CommonBaseUnifiedBetSelectionProperty,
                DefaultSpecificProperty = ubD.DefaultSpecificProperty
            };
        }
    }
}
