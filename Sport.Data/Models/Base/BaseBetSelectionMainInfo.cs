namespace Sport.Data.Models.Base
{
    public class BaseBetSelectionMainInfo
    {
        public int Id { get; set; }
        public string CommonBetSelectionProperty { get; set; }
        public decimal Odds { get; set; }
        public char? Result { get; set; }
    }
}