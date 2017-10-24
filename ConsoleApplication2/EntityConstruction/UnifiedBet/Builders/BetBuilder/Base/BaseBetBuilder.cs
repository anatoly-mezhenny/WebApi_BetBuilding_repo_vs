using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2.Entities;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Utilities.Mappers.Bet.Base;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base
{
    public abstract class BaseBetBuilder
        <
        //specify bet and bet selection types to get common mapping/remapping methods:
        TUnifiedBet, TUnifiedBetSelection,
        TBetMainInfo, TBetSelectionMainInfo
        > 
        : IBaseBetBuilder

        where TUnifiedBet : BaseUnifiedBet
        where TUnifiedBetSelection : BaseUnifiedBetSelection
        where TBetMainInfo : BaseBetMainInfo<TBetSelectionMainInfo>
        where TBetSelectionMainInfo : BaseBetSelectionMainInfo
    {
        private readonly IMultiTenantCashOutService _multiTenantCashOutService;
        private readonly IBaseBetMapper<TBetMainInfo, TUnifiedBet> _baseBetMapper;
        private readonly IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> _baseBetSelectionMapper;

        /// <summary>
        /// Building parameters (aka user id, application id, etc)
        /// </summary>
        protected abstract BaseBetBuilderParams BaseParams { get; }

        /// <summary>
        /// Building context (aka .Bets)
        /// </summary>
        protected abstract BaseBetBuilderContext BaseContext { get; }
        
        protected BaseBetBuilder(IMultiTenantCashOutService multiTenantCashOutService,
            IBaseBetMapper<TBetMainInfo, TUnifiedBet> baseBetMapper,
            IBaseBetSelectionMapper<TBetSelectionMainInfo, TUnifiedBetSelection> baseBetSelectionMapper
            )
        {
            _multiTenantCashOutService = multiTenantCashOutService;
            _baseBetMapper = baseBetMapper;
            _baseBetSelectionMapper = baseBetSelectionMapper;
        }

        public abstract void InitBuilder();

        public abstract void LoadBetsData();

        /// <summary>
        /// Parse from bets data.
        /// Set simple bet info (that cannot be optional/doesn't take significant resources).
        /// </summary>
        public abstract void BuildBetsMainInfo();

        /*** EnrichBetsInfo block ***/

        public abstract void BuildRegulatorInfo();

        public abstract void BuildCashOutPlacementInfo();

        public abstract void BuildTaxInfo();
        /***/

        /// <summary>
        /// Parse from bets selection data.
        /// Set simple bet info (that cannot be optional/doesn't take significant resources). Like is streaming for bet available.
        /// </summary>
        public abstract void BuildSelectionsMainInfo();

        /*** EnrichSelectionsInfo block ***/
        public abstract void BuildTranslationsInfo();

        //TODO: TBD regarding fetching this logic together with other bet info (separate endpoing for fetching?.. fetching of "light" info here?..)
        public abstract void BuildSelectionScoreboards();
        /***/




        /// <summary>
        /// Common stuff for all brands (like placement info) can be fetched without special providers,
        /// right in bet bulder hierarchy
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="betIds"></param>
        /// <returns></returns>
        protected IDictionary<int, CashOutPlacementInfo> GetBetsCashOutDict(int userId, IEnumerable<int> betIds)
        {
            var betsCashOutPlacementInfoList = _multiTenantCashOutService.GetCashoutableStakesLightInfoAsync(userId);
            var cashOutPlacementInfoList = MapLightCashoutableStakeInfoListToCashOutPlacementInfo(betsCashOutPlacementInfoList);
            var betsCashOutDict = cashOutPlacementInfoList.ToDictionary(cashOutPlacementInfo => cashOutPlacementInfo.Id, cpi => cpi);
            return betsCashOutDict;
        }

        private static List<CashOutPlacementInfo> MapLightCashoutableStakeInfoListToCashOutPlacementInfo(IEnumerable<CashoutableBetLightInfo> betsCashOutPlacementInfoList)
        {
            return betsCashOutPlacementInfoList.Select(MapToCashOutPlacementInfo).ToList();
        }

        private static CashOutPlacementInfo MapToCashOutPlacementInfo(CashoutableBetLightInfo li)
        {
            return new CashOutPlacementInfo
            {
                Id = li.Id,
                CashOutAmount = li.MaxCashOutAmount
                //map other properties...
            };

        }

        protected virtual IEnumerable<TUnifiedBet> MapBaseToUnifiedBetList(IEnumerable<TBetMainInfo> betMainInfoList)
        {
            return betMainInfoList.Select(MapBaseToUnifiedBet).ToList();
        }

        protected virtual TUnifiedBet MapBaseToUnifiedBet(TBetMainInfo betMainInfo)
        {
            return _baseBetMapper.Map(betMainInfo);
        }

        protected virtual TUnifiedBetSelection MapBaseToUnifiedBetSelection(TBetSelectionMainInfo betSelectionMainInfo)
        {
            return _baseBetSelectionMapper.Map(betSelectionMainInfo);
        }
    }



    public class BaseBetBuilderParams
    {
    }

    public class BaseBetBuilderContext
    {
    }


}
