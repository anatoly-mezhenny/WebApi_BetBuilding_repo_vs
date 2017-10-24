using ConsoleApplication2.EntityConstruction.UnifiedBet.BuilderDirectors.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BuilderDirectors.Base
{
    public class BaseBetBuildDirector : GenericBetBuildDirector<BaseConstructionParametersType>
    {
        public BaseBetBuildDirector(IBaseBetBuilder baseBetBuilder) : base(baseBetBuilder)
        {
        }
    }
}