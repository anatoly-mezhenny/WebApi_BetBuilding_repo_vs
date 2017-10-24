using ConsoleApplication2.Entities.Bet.Base.Subentities;
using WebApi.Dto;

namespace WebApi.UserBetDtoBuilder.Base
{
    public static class BaseEntitiesMappingHelper
    {
        public static TaxInfoDto MapBaseTaxInfoToDto(BaseTaxInfo ti)
        {
            if (ti == null)
            {
                return null;
            }

            return new TaxInfoDto
            {
                IsTaxFree = ti.IsTaxFree,
                IsActive = ti.IsActive,
                OnlineDate = ti.OnlineDate,
                Tooltip = ti.Tooltip
            };
        }
    }
}
