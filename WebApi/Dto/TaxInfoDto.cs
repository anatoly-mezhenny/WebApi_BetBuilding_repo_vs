using System;

namespace WebApi.Dto
{
    public class TaxInfoDto
    {
        public DateTime OnlineDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsTaxFree { get; set; }

        public string Tooltip { get; set; }
    }
}