using ConsoleApplication2.Entities.Bet.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic
{
    public interface IBaseSingleBetBuilder<in TParams, TUnifiedBet> : IBaseBetBuilder
        where TParams : BaseSingleBetBuilderParams
        where TUnifiedBet : BaseUnifiedBet
    {
        void SetBuildParams(TParams @params);
        TUnifiedBet GetResult();
    }
}