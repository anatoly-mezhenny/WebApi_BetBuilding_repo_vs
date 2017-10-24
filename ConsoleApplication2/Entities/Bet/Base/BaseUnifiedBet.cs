using System.Collections.Generic;
using ConsoleApplication2.Entities.Bet.Base.Subentities;

namespace ConsoleApplication2.Entities.Bet.Base
{
    public abstract class BaseUnifiedBet<TUnifiedBetSelection> : BaseUnifiedBet
        where TUnifiedBetSelection : BaseUnifiedBetSelection
    {
        public override IEnumerable<BaseUnifiedBetSelection> BaseUnifiedBetSelections
        {
            get { return UnifiedBetSelections; }
        }

        public IEnumerable<TUnifiedBetSelection> UnifiedBetSelections { get; set; }

    }

    public abstract class BaseUnifiedBet
    {
        public int Id { get; set; } //TODO: UnifiedId
        public string CommonPropertyForAllBrands { get; set; }
        public decimal Amount { get; set; }
        public virtual IEnumerable<BaseUnifiedBetSelection> BaseUnifiedBetSelections { get; }

        
        //customizable objects per brand; better to user "info providers" to fetch this info
        public virtual BaseTaxInfo BaseTaxInfo { get; }
        public virtual BaseRegulatorInfo BaseRegulatorInfo { get; }


        //common objects for all brands
        //the implementation of the objects' fetching can be done using special "info provider" or just in BetBuilder hierarchy (common stuff in BaseBetBuilder; list-, rangeResult-, single-betbuilders contain the coding difference)
        public virtual CashOutPlacementInfo CashOutPlacementInfo { get; set; }
        public virtual AppliedMultipleBetBoostInfo AppliedMultipleBetBoostInfo { get; set; }
        public virtual EndedBetInfo EndedBetInfo { get; set; }
        public virtual SystemInfo SystemInfo { get; set; }

    }

    //TODO: move to separate files
    public class CashOutPlacementInfo
    {
        public int Id { get; set; }
        public decimal CashOutAmount { get; set; }
    }

    public class AppliedMultipleBetBoostInfo
    {
    }

    public class EndedBetInfo
    {
    }
    public class SystemInfo
    {
    }
}
