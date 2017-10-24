using System.Collections.Generic;

namespace Sport.Data.Models.Base
{
    public abstract class BaseBetMainInfo<TBetSelectionMainInfo> : BaseBetMainInfo
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        public IEnumerable<TBetSelectionMainInfo> BetSelectionMainInfo { get; set; }
        
        public override IEnumerable<BaseBetSelectionMainInfo> BaseBetSelectionMainInfo
        {
            get
            {
                return BetSelectionMainInfo;
            }
        }

    }

    public abstract class BaseBetMainInfo
    {
        public int Id { get; set; }
        public string CommonPropertyForAllBrands { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalOdds { get; set; }
        public int UserId { get; set; }
        public abstract IEnumerable<BaseBetSelectionMainInfo> BaseBetSelectionMainInfo { get; }
    }
}