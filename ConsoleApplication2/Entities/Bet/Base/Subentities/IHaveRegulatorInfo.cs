namespace ConsoleApplication2.Entities.Bet.Base.Subentities
{
    public interface IHaveRegulatorInfo<TRegulatorInfo>
        where TRegulatorInfo : BaseRegulatorInfo, new()
    {
        TRegulatorInfo RegulatorInfo { get; set; }
    }
}