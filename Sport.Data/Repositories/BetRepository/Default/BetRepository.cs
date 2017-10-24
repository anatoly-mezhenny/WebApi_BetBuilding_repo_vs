using System;
using System.Collections.Generic;
using Sport.Common.Utilities;
using Sport.Data.Models.Default;
using Sport.Data.Repositories.BetRepository.Base;

namespace Sport.Data.Repositories.BetRepository.Default
{
    public class BetRepository : BaseBetRepository<BetMainInfo>, IBetRepository
    {

        public override IEnumerable<BetMainInfo> GetOngoingBets(int userId, bool onlyCashoutableStakes = false, bool getPrelive = true, bool getLive = true)
        {
            //get UnifiedBet by default-specific way or use base
            var lst = new List<BetMainInfo>
            {
                new BetMainInfo
                {
                    Id = 1,
                    CommonPropertyForAllBrands = "CommonPropVal1 for ongoing",
                    
                    DefaultSpecificProperty = "DefPropVal1 for ongoing",
                    BetSelectionMainInfo = new List<BetSelectionMainInfo>
                    {
                        new BetSelectionMainInfo
                        {
                            Id = 2,
                            CommonBetSelectionProperty = "CommonPropVal1 for ongoing",
                            DefaultSpecificProperty = "DefPropVal1 for ongoing"
                        }
                    }
                },
                new BetMainInfo
                {
                    Id = 3,
                    CommonPropertyForAllBrands = "CommonPropVal2 for ongoing",
                    DefaultSpecificProperty = "DefPropVal2 for ongoing",
                    BetSelectionMainInfo = new List<BetSelectionMainInfo>
                    {
                        new BetSelectionMainInfo
                        {
                            Id = 4,
                            CommonBetSelectionProperty = "CommonPropVal2 for ongoing",
                            DefaultSpecificProperty = "DefPropVal2 for ongoing"
                        }
                    }
                },
            };
            return lst;
        }

        public override RangingResult<BetMainInfo> GetEndedBets(int userId, EndedStakesFilters endedStakesFilters)
        {
            //get UnifiedBet by default-specific way or use base
            var lst = new List<BetMainInfo>
            {
                new BetMainInfo
                {
                    Id = 5,
                    CommonPropertyForAllBrands = "CommonPropVal1 for ended",
                    DefaultSpecificProperty = "DefPropVal1 for ended",
                    BetSelectionMainInfo = new List<BetSelectionMainInfo>
                    {
                        new BetSelectionMainInfo
                        {
                            Id = 6,
                            CommonBetSelectionProperty = "CommonPropVal1 for ended",
                            DefaultSpecificProperty = "DefPropVal1 for ended"
                        }
                    }
                },
                new BetMainInfo
                {
                    Id = 7,
                    CommonPropertyForAllBrands = "CommonPropVal2 for ended",
                    DefaultSpecificProperty = "DefPropVal2 for ended",
                    BetSelectionMainInfo = new List<BetSelectionMainInfo>
                    {
                        new BetSelectionMainInfo
                        {
                            Id = 8,
                            CommonBetSelectionProperty =  "CommonPropVal2 for ended",
                            DefaultSpecificProperty = "DefPropVal2 for ended"
                        }
                    }
                },
            };
            var total = endedStakesFilters.LastIndex - endedStakesFilters.StartIndex + 1;
            return new RangingResult<BetMainInfo>(endedStakesFilters.StartIndex, endedStakesFilters.LastIndex, total, lst, lst.Count);
        }

        public override BetMainInfo GetLiveBet(int userId, int betId)
        {
            return new BetMainInfo
            {
                Id = 7,
                CommonPropertyForAllBrands = "CommonPropVal1 for live bet",
                DefaultSpecificProperty = "DefPropVal1 for live  bet",
                BetSelectionMainInfo = new List<BetSelectionMainInfo>
                {
                    new BetSelectionMainInfo
                    {
                        Id = 8,
                        CommonBetSelectionProperty = "CommonPropVal1 for live bet",
                        DefaultSpecificProperty = "DefPropVal1 for live  bet"
                    }
                }
            };
        }

        public override BetMainInfo GetPreliveBet(int userId, int betId)
        {
            return new BetMainInfo
            {
                Id = 9,
                CommonPropertyForAllBrands = "CommonPropVal1 for prelive bet",
                DefaultSpecificProperty = "DefPropVal1 for prelive bet",
                BetSelectionMainInfo = new List<BetSelectionMainInfo>
                {
                    new BetSelectionMainInfo
                    {
                        Id = 10,
                        CommonBetSelectionProperty = "CommonPropVal1 for prelive bet",
                        DefaultSpecificProperty = "DefPropVal1 for prelive bet"
                    }
                }
            };
        }

        public override IEnumerable<BetMainInfo> GetPreliveBets(int userId)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<BetMainInfo> GetLiveBets(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
