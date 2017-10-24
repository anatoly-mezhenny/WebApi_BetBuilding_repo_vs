using System;
using Sport.Data.Models.Base;

namespace Sport.Data.Models.Italy
{
    public class ItBetMainInfo : BaseBetMainInfo<ItBetSelectionMainInfo>
    {
        public string ItSpecificProperty { get; set; }
        public DateTime TicketDate { get; set; }
        public string SogeiTicket { get; set; }
        public int ReturnCode { get; set; }
    }
}