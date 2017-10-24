using ConsoleApplication2.Entities.Bet.Base;
using Sport.Common.Utilities;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic
{
    public interface IBaseBetRangingResultBuilder<in TParams, TUnifiedBet> : IBaseBetBuilder
        where TParams : BaseBetRangingResultBuilderParams
        where TUnifiedBet : BaseUnifiedBet
    {
        void SetBuildParams(TParams @params);
        RangingResult<TUnifiedBet> GetResult();
    }
}
