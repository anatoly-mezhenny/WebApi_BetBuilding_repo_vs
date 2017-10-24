using System;
using ConsoleApplication2.Entities.Bet.Base.Subentities;

namespace ConsoleApplication2.Entities.Bet.Italy.Subentities
{

    public class ItRegulatorInfo : BaseRegulatorInfo
    {
        public string ItSpecificProperty { get; set; }
        public DateTime TicketDate { get; set; }
        public string SogeiTicket { get; set; }
        public int ReturnCode { get; set; }
    }
}
