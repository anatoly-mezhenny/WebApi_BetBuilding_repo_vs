using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.Entities.Bet.Base.Subentities;
using ConsoleApplication2.Entities.Bet.Italy.Subentities;

namespace ConsoleApplication2.Entities.Bet.Italy
{
    public class ItUnifiedBet : BaseUnifiedBet<ItUnifiedBetSelection>,
        IHaveTaxInfo<ItTaxInfo>,
        IHaveRegulatorInfo<ItRegulatorInfo>
    {

        public override BaseTaxInfo BaseTaxInfo
        {
            get { return TaxInfo; }
        }
        public ItTaxInfo TaxInfo { get; set; }


        public override BaseRegulatorInfo BaseRegulatorInfo
        {
            get { return RegulatorInfo; }
        }
        public ItRegulatorInfo RegulatorInfo { get; set; }


        public string ItSpecificProperty { get; set; }
    }
}
