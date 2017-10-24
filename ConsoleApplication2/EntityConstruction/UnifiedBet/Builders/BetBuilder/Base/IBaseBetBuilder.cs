namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base
{
    public interface IBaseBetBuilder
    {
        void InitBuilder();
        void LoadBetsData();
        void BuildBetsMainInfo();
        
        /*** EnrichBetsInfo block ***/
        void BuildRegulatorInfo();
        void BuildCashOutPlacementInfo();
        void BuildTaxInfo();
        /***/

        void BuildSelectionsMainInfo();

        /*** EnrichSelectionsInfo block ***/
        void BuildTranslationsInfo();
        void BuildSelectionScoreboards();
        /***/
    }
}