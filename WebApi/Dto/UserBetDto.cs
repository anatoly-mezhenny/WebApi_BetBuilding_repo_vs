using System.Collections.Generic;

namespace WebApi.Dto
{
    public class UserBetDto : BaseUserBetDto
    {
        public string CommonPropertyForAllBrands { get; set; }
        public string DefaultSpecificBetProperty { get; set; }
        public TaxInfoDto TaxInfo { get; set; }
        public IEnumerable<UserBetSelectionDto> UnifiedBetSelections { get; set; }
    }


    public class UserBetSelectionDto
    {
        public string CommonBaseUnifiedBetSelectionProperty { get; set; }
        public string DefaultSpecificProperty { get; set; }
    }
}
