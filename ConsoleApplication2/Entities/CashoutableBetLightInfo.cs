using System;
using System.Collections.Generic;

namespace ConsoleApplication2.Entities
{
    public class CashoutableBetLightInfo
    {
        public int Id { get; set; }

        public bool IsLive { get; set; }

        public decimal Amount { get; set; }

        public decimal InitialOdds { get; set; }

        public string ReferenceNumber { get; set; }

        public DateTime PlacementDate { get; set; }

        public bool CashOutHasBeenDone { get; set; }

        public bool IsCashBackBonusAssigned { get; set; }
        public decimal MaxCashOutAmount { get; set; }

        public decimal MaxCashOutCurrentOdds { get; set; }

        public bool SuspendedForCashOut { get; set; }

        public decimal MinCashOutAmount { get; set; }

        public bool IsPartialCashoutAllowed { get; set; }

        public bool IsPreliveStakePlayingLive { get; set; }

        public bool IsCashOutAvailable { get; set; }

        public byte Status { get; set; }

        public bool IsFixedMarginRuleApplied { get; set; }

        public bool IsCashOutAmountLimitedByStakeAmount { get; set; }

        public bool IsCashOutAmountLimitedByPotentialWinning { get; set; }

        public bool CashOutRestrictedByMinimalStakePercentageRule { get; set; }

        public byte CashOutSuspendingReasonCode { get; set; }

        public SimpleCashOutSuspendingReasonEnum SimpleCashOutSuspendingReason { get; set; }

        public List<KeyValuePair<string, string>> CalculationInfoDict { get; set; }

        public enum SimpleCashOutSuspendingReasonEnum
        {
            Undefined = 0,
            GameStartedForPreliveNotHavingCorrespondingLiveOffer = 1,
            OnlySelectionsWhereGameStartedForPreliveNotHavingCorrespondingLiveOffer = 2,
            OfferSuspended = 3,
            OtherReason = 4,
        }
    }
}