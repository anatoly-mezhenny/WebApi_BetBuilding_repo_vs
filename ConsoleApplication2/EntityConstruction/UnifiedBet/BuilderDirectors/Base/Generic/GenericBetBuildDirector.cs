using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BuilderDirectors.Base.Generic
{
    public class GenericBetBuildDirector<TConstructionParametersType>
        where TConstructionParametersType : BaseConstructionParametersType, new()
    {
        private readonly IBaseBetBuilder _baseBetBuilder;

        public GenericBetBuildDirector(IBaseBetBuilder baseBetBuilder)
        {
            _baseBetBuilder = baseBetBuilder;

            //create default construction parameters setup
            ConstructionParameters = new TConstructionParametersType()
            {
                BuildSelections = true,
                BuildTaxInfo = true,
                BuildSelectionScoreboards = false,
                BuildCashOutPlacementInfo = false,
            };
        }

        public TConstructionParametersType ConstructionParameters { get; set; }
        
        protected virtual void SetupConstructionParameters()
        {
            //if nothing - default setup is used
        }

        public virtual void Construct()
        {
            SetupConstructionParameters();

            _baseBetBuilder.InitBuilder();

            _baseBetBuilder.LoadBetsData();

            // *** Fills in: ***
            //  selections: selections' info, endedBetSelectionInfo (Result, WinningSelection)
            //   "ended bet info"
            //   "regulator specific info" (like ticket for Italy)
            //   "system bet info"
            //   "multiple boost applied info"
            //   "performed cash outs"
            _baseBetBuilder.BuildBetsMainInfo();
            //   -"current cash out info"
            //   -"tax info"
            EnrichBetsInfo();
            // ***

            if (ConstructionParameters.BuildSelections)
            {
                _baseBetBuilder.BuildSelectionsMainInfo();
                //   -selections scoreboards
                EnrichSelectionsInfo();
            }
        }

        private void EnrichBetsInfo()
        {
            _baseBetBuilder.BuildRegulatorInfo();

            if (ConstructionParameters.BuildCashOutPlacementInfo)
            {
                _baseBetBuilder.BuildCashOutPlacementInfo();
            }

            if (ConstructionParameters.BuildTaxInfo)
            {
                _baseBetBuilder.BuildTaxInfo();
            }
        }

        private void EnrichSelectionsInfo()
        {
            _baseBetBuilder.BuildTranslationsInfo();
            //NOTE:AMI: we handle scoreboards asynchronously from stake/selections retrieving
            // we can build scoreboard for live and for prelive selections, 
            // we can build for prelive if there is corresponding live is playing
            if (ConstructionParameters.BuildSelectionScoreboards)
            {
                _baseBetBuilder.BuildSelectionScoreboards();
            }
        }
    }
}