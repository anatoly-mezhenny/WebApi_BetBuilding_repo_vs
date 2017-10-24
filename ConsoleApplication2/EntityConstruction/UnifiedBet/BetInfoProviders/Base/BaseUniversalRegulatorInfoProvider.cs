using System;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.Entities.Bet.Base.Subentities;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base
{
    public class BaseUniversalRegulatorInfoProvider<TUnifiedBet, TBetMainInfo, TRegulatorInfo>
        : IBaseUniversalInfoProvider<TUnifiedBet, TBetMainInfo>

        where TUnifiedBet : BaseUnifiedBet, IHaveRegulatorInfo<TRegulatorInfo>
        where TBetMainInfo : BaseBetMainInfo
        where TRegulatorInfo : BaseRegulatorInfo, new()
    {
        public void ProvideInfo(BaseBetListBuilderContext<TUnifiedBet, TBetMainInfo> buildContext)
        {
            throw new NotImplementedException();
        }

        public void ProvideInfo(BaseSingleBetBuilderContext<TUnifiedBet, TBetMainInfo> buildContext)
        {
            throw new NotImplementedException();
        }

        public void ProvideInfo(BaseBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo> buildContext)
        {
            throw new NotImplementedException();
        }
    }
}
