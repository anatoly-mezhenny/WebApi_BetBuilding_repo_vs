using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.Entities.Bet.Base.Subentities;
using ConsoleApplication2.Entities.Bet.Default.Subentities;

namespace ConsoleApplication2.Entities.Bet.Default
{
    public class UnifiedBet : BaseUnifiedBet<UnifiedBetSelection>,
        IHaveTaxInfo<TaxInfo>
    {
        public override BaseTaxInfo BaseTaxInfo
        {
            get { return TaxInfo; }
        }
        public TaxInfo TaxInfo { get; set; }

        //Note, that UnifiedBet doesn't need and don't have any regulator info (ItUnifiedBet has)

        public string DefaultSpecificBetProperty { get; set; }
        
    }
}
