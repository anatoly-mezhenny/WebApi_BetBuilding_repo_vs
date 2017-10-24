using System.Collections.Generic;
using ConsoleApplication2.Entities.Bet.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic
{
    public interface IBaseBetListBuilder<TParams, TUnifiedBet> : IBaseBetBuilder
        where TParams : BaseBetListBuilderParams
        where TUnifiedBet : BaseUnifiedBet
    {
        void SetBuildParams(TParams @params);
        IEnumerable<TUnifiedBet> GetResult();
    }
}