using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic
{
    public interface IBaseInfoProvider<in TBuilderContext>
        where TBuilderContext : BaseBetBuilderContext
    {
        void ProvideInfo(TBuilderContext buildContext);
    }
}
