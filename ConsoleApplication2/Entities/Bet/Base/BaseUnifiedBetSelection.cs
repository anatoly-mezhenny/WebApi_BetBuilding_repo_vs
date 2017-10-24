namespace ConsoleApplication2.Entities.Bet.Base
{
    public abstract class BaseUnifiedBetSelection
    {
        public int Id { get; set; }
        public string CommonBaseUnifiedBetSelectionProperty { get; set; }
        public decimal Odds { get; set; }
        public char? Result { get; set; } //TODO: enum
    }
}