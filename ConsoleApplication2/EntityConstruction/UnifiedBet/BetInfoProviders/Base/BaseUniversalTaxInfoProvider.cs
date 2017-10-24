using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.Entities.Bet.Base.Subentities;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetList.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.BetRangingResult.Generic;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Builders.BetBuilder.Base.SpecificBase.SingleBet.Generic;
using ConsoleApplication2.Services.TaxService;
using Sport.Data.Models.Base;

namespace ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Base
{
    public abstract class BaseUniversalTaxInfoProvider<TUnifiedBet, TBetMainInfo, TTaxInfo>
        : IBaseUniversalInfoProvider<TUnifiedBet, TBetMainInfo>
        
        where TUnifiedBet : BaseUnifiedBet, IHaveTaxInfo<TTaxInfo>
        where TBetMainInfo : BaseBetMainInfo
        where TTaxInfo : BaseTaxInfo, new()
    {
        private readonly ITaxService _taxService;

        protected BaseUniversalTaxInfoProvider(ITaxService taxService)
        {
            _taxService = taxService;
        }

        /// <summary>
        /// If remap from base is enough (no extra properties in derived class) - no need to override.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bets"></param>
        /// <returns></returns>
        protected virtual IDictionary<int, TTaxInfo> GetBetsTaxDict(int userId, IEnumerable<TUnifiedBet> bets)
        {
            var baseBetsTaxes = _taxService.GetBetsTaxes(userId, bets);
            var betsTaxes = MapBaseToTaxInfo(baseBetsTaxes);
            var betTaxesDict = betsTaxes.ToDictionary(bt => bt.BetId, bt => bt);
            return betTaxesDict;
        }



        private static IEnumerable<TTaxInfo> MapBaseToTaxInfo(IEnumerable<BaseTaxInfo> baseBetsTaxes)
        {
            return baseBetsTaxes.Select(MapBaseToTaxInfo).ToList();
        }

        private static TTaxInfo MapBaseToTaxInfo(BaseTaxInfo baseBetTax)
        {
            return new TTaxInfo
            {
                IsActive = baseBetTax.IsActive,
                BetId = baseBetTax.BetId,
                IsTaxFree = baseBetTax.IsTaxFree,
                MinimumOdds = baseBetTax.MinimumOdds,
                MinimumSelections = baseBetTax.MinimumSelections,
                OnlineDate = baseBetTax.OnlineDate,
                TaxInfos = baseBetTax.TaxInfos.ToDictionary(kv => kv.Key, kv => kv.Value),
                Tooltip = baseBetTax.Tooltip,
            };
        }
        

        public void ProvideInfo(BaseBetListBuilderContext<TUnifiedBet, TBetMainInfo> context)
        {
            var taxInfoDict = GetBetsTaxDict(context.UserId, context.Bets);
            foreach (var bet in context.Bets)
            {
                if (taxInfoDict.ContainsKey(bet.Id))
                {
                    bet.TaxInfo = taxInfoDict[bet.Id];
                }
            }
        }

        public void ProvideInfo(BaseSingleBetBuilderContext<TUnifiedBet, TBetMainInfo> context)
        {
            var taxInfoDict = GetBetsTaxDict(context.UserId, new List<TUnifiedBet> { context.Bet });
            if (taxInfoDict.ContainsKey(context.Bet.Id))
            {
                context.Bet.TaxInfo = taxInfoDict[context.Bet.Id];
            }
        }

        public void ProvideInfo(BaseBetRangingResultBuilderContext<TUnifiedBet, TBetMainInfo> context)
        {
            var taxInfoDict = GetBetsTaxDict(context.UserId, context.RangingResult.Items);
            foreach (var bet in context.RangingResult.Items)
            {
                if (taxInfoDict.ContainsKey(bet.Id))
                {
                    bet.TaxInfo = taxInfoDict[bet.Id];
                }
            }
        }

    }
}