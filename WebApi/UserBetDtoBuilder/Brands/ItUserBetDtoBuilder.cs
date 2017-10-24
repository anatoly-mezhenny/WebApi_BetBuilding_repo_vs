using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.Entities.Bet.Italy.Subentities;
using ConsoleApplication2.Services.MultitenantUnifiedBetService.Italy;
using WebApi.Dto;
using WebApi.UserBetDtoBuilder.Base;
using WebApi.UserBetDtoBuilder.Base.FeatureSpecific;

namespace WebApi.UserBetDtoBuilder.Brands
{
    public class ItUserBetDtoBuilder : BaseUserBetDtoBuilder<ItUserBetDto, ItUnifiedBet>,
        IBasePendingUserBetDtoBuilder<ItUserBetDto>
    {
        private readonly IItMultitenantUnifiedBetService _itMultitenantUnifiedBetService;
        
        public ItUserBetDtoBuilder(IItMultitenantUnifiedBetService itMultitenantUnifiedBetService)
            : base(itMultitenantUnifiedBetService)
        {
            _itMultitenantUnifiedBetService = itMultitenantUnifiedBetService;
        }


        IEnumerable<BaseUserBetDto> IBasePendingUserBetDtoBuilder.GetPendingUserBetDtos(int userId)
        {
            return GetPendingUserBetDtos(userId);
        }
        public IEnumerable<ItUserBetDto> GetPendingUserBetDtos(int userId)
        {
            return _itMultitenantUnifiedBetService.GetAllPendingBets(userId).Select(MapToDto).ToList();
        }
        
        protected override ItUserBetDto MapToDto(ItUnifiedBet unifiedBet)
        {
            var userBetDto = new ItUserBetDto
            {
                CommonPropertyForAllBrands = unifiedBet.CommonPropertyForAllBrands,
                ItSpecificProperty = unifiedBet.ItSpecificProperty,
                TaxInfo = BaseEntitiesMappingHelper.MapBaseTaxInfoToDto(unifiedBet.TaxInfo),
                RegulatorInfo = MapRegulatorInfoToDto(unifiedBet.RegulatorInfo),
                UnifiedBetSelections = unifiedBet.UnifiedBetSelections?.Select(MapSelectionToDto).ToList()
            };
            return userBetDto;
        }

        private static ItUserBetSelectionDto MapSelectionToDto(ItUnifiedBetSelection ubD)
        {
            return new ItUserBetSelectionDto
            {
                CommonBaseUnifiedBetSelectionProperty = ubD.CommonBaseUnifiedBetSelectionProperty,
                ItSpecificProperty = ubD.ItSpecificProperty
            };
        }

        private static ItRegulatorInfoDto MapRegulatorInfoToDto(ItRegulatorInfo regulatorInfo)
        {
            return new ItRegulatorInfoDto
            {
                SogeiTicket = regulatorInfo.SogeiTicket,
                ReturnCode = regulatorInfo.ReturnCode,
                TicketDate = regulatorInfo.TicketDate,
            };
        }
    }
}
