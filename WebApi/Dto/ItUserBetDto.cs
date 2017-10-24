using System;
using System.Collections.Generic;

namespace WebApi.Dto
{
    public class ItUserBetDto : BaseUserBetDto
    {
        public string CommonPropertyForAllBrands { get; set; }
        public string ItSpecificProperty { get; set; }
        public TaxInfoDto TaxInfo { get; set; }
        public ItRegulatorInfoDto RegulatorInfo { get; set; }
        public IEnumerable<ItUserBetSelectionDto> UnifiedBetSelections { get; set; }
    }

    public class ItUserBetSelectionDto
    {
        public string CommonBaseUnifiedBetSelectionProperty { get; set; }
        public string ItSpecificProperty { get; set; }
    }

    public class ItRegulatorInfoDto
    {
        public DateTime TicketDate { get; set; }
        public string SogeiTicket { get; set; }
        public int ReturnCode { get; set; }
    }
}
