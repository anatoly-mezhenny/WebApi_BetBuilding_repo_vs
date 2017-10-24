using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Italy;
using Sport.Data.Models.Italy;
using Sport.Data.Repositories.BetRepository.Italy;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Italy
{
    public class ItPendingBetsListBuilder
        : BaseBetListBuilder<ItPendingBetsListBuilderParams, ItPendingBetsListBuilderContext,
            ItUnifiedBet, ItUnifiedBetSelection,
            ItBetMainInfo, ItBetSelectionMainInfo>,
            IItPendingBetsListBuilder
    {
        private readonly IItBetRepository _betRepository;

        public ItPendingBetsListBuilder(IItBetRepository betRepository,
            IMultiTenantCashOutService multiTenantCashOutService,
            IItBetMapper betMapper, IItBetSelectionMapper betSelectionMapper,
            IItUniversalTaxInfoProvider taxInfoProvider,
            IItUniversalRegulatorInfoProvider regulatorInfoProvider)
            : base(multiTenantCashOutService, betMapper, betSelectionMapper, taxInfoProvider, regulatorInfoProvider)
        {
            _betRepository = betRepository;
        }

        public override void LoadBetsData()
        {
            Context.BetsMainInfo =
                _betRepository.GetPendingBets(Params.UserId, getPrelive: true, getLive: true);
        }
    }


    public class ItPendingBetsListBuilderParams : BaseBetListBuilderParams
    {
        public ItPendingBetsListBuilderParams(int userId) : base(userId)
        {
        }

        public ItPendingBetsListBuilderParams()
        {
        }
    }

    public class ItPendingBetsListBuilderContext
    : BaseBetListBuilderContext<ItUnifiedBet, ItBetMainInfo>
    {
    }
}