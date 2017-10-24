namespace ConsoleApplication2.Entities.Bet.Base.Subentities
{
    public interface IHaveTaxInfo<TTaxInfo>
        where TTaxInfo : BaseTaxInfo, new()
    {
        TTaxInfo TaxInfo { get; set; }
    }
}