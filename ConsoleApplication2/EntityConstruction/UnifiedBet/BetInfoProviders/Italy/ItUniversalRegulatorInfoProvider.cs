using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2.Entities.Bet.Italy;
using ConsoleApplication2.Entities.Bet.Italy.Subentities;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic;
using Sport.Data.Models.Default;
using Sport.Data.Models.Italy;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Italy
{
    public class ItUniversalRegulatorInfoProvider
        : BaseUniversalRegulatorInfoProvider<ItUnifiedBet, BetMainInfo, ItRegulatorInfo>, IItUniversalRegulatorInfoProvider
    {
        public void ProvideInfo(BaseBetListBuilderContext<ItUnifiedBet, ItBetMainInfo> buildContext)
        {
            var miInfoList = buildContext.BetsMainInfo;
            var bets = buildContext.Bets;
            MapRegulationInfoList(bets, miInfoList);
        }

        public void ProvideInfo(BaseSingleBetBuilderContext<ItUnifiedBet, ItBetMainInfo> buildContext)
        {
            MapRegulatorInfo(buildContext.Bet, buildContext.BetMainInfo);
        }

        public void ProvideInfo(BaseBetRangingResultBuilderContext<ItUnifiedBet, ItBetMainInfo> buildContext)
        {
            MapRegulationInfoList(buildContext.RangingResult.Items, buildContext.BetsMainInfoRangingResult.Items);
        }



        private static void MapRegulationInfoList(IEnumerable<ItUnifiedBet> bets, IEnumerable<ItBetMainInfo> miInfoList)
        {
            var miDict = miInfoList.ToDictionary(mi => mi.Id, mi => mi);
            foreach (var itUnifiedBet in bets)
            {
                if (miDict.ContainsKey(itUnifiedBet.Id))
                {
                    MapRegulatorInfo(itUnifiedBet, miDict[itUnifiedBet.Id]);
                }
            }
        }

        private static void MapRegulatorInfo(ItUnifiedBet bet, ItBetMainInfo betMainInfo)
        {
            bet.RegulatorInfo = new ItRegulatorInfo
            {
                TicketDate = betMainInfo.TicketDate,
                SogeiTicket = betMainInfo.SogeiTicket,
                ReturnCode = betMainInfo.ReturnCode,
            };
        }
    }
}
