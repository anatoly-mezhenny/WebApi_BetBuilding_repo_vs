using System.Collections.Generic;
using Sport.Common.Utilities;
using Sport.Data.Models.Base;
using Sport.Data.Models.Italy;
using Sport.Data.Repositories.BetRepository.Base;

namespace Sport.Data.Repositories.BetRepository.Italy
{
    public class ItBetRepository : BaseBetRepository<ItBetMainInfo>, IItBetRepository
    {
        public override ItBetMainInfo GetPreliveBet(int userId, int betId)
        {
            return new ItBetMainInfo
            {
                Id = 1,
                CommonPropertyForAllBrands = "CommonPropVal1 for prelive bet",
                ItSpecificProperty = "ItPropVal1 for prelive bet",
                SogeiTicket = "SogeiTicket1 for prelive bet",
                BetSelectionMainInfo = new List<ItBetSelectionMainInfo>
                {
                    new ItBetSelectionMainInfo
                    {
                        Id = 1,
                        CommonBetSelectionProperty = "CommonPropVal1 for prelive bet",
                        ItSpecificInfo = "ItPropVal1 for prelive bet"
                    }
                }
            };
        }

        public override ItBetMainInfo GetLiveBet(int userId, int betId)
        {
            return new ItBetMainInfo
            {
                Id = 2,
                CommonPropertyForAllBrands = "CommonPropVal1 for live bet",
                ItSpecificProperty = "ItPropVal1 for live bet",
                SogeiTicket = "SogeiTicket1 for live bet",
                BetSelectionMainInfo = new List<ItBetSelectionMainInfo>
                {
                    new ItBetSelectionMainInfo
                    {
                        Id = 2,
                        CommonBetSelectionProperty = "CommonPropVal1 for live bet",
                        ItSpecificInfo = "ItPropVal1 for live bet"
                    }
                }
            };
        }

        IEnumerable<BaseBetMainInfo> IBaseBetRepository.GetOngoingBets(int userId, bool onlyCashoutableBets, bool getPrelive = true, bool getLive = true)
        {
            return GetOngoingBets(userId, onlyCashoutableBets);
        }

        RangingResult<BaseBetMainInfo> IBaseBetRepository.GetEndedBets(int userId, EndedStakesFilters endedStakesFilters)
        {
            var rr = GetEndedBets(userId, endedStakesFilters);
            return RangingResultHelper.CreateFrom<BaseBetMainInfo, ItBetMainInfo>(rr);
        }

        public override IEnumerable<ItBetMainInfo> GetOngoingBets(int userId, bool onlyCashoutableBets = false, bool getPrelive = true, bool getLive = true)
        {
            //get UnifiedBet by default-specific way or use base
            var lst = new List<ItBetMainInfo>
            {
                new ItBetMainInfo
                {
                    Id = 1,
                    CommonPropertyForAllBrands = "CommonPropVal1 for ongoing",
                    ItSpecificProperty = "ItPropVal1 for ongoing",
                    SogeiTicket = "SogeiTicket1 for ongoing",
                    BetSelectionMainInfo = new List<ItBetSelectionMainInfo>
                    {
                        new ItBetSelectionMainInfo
                        {
                            Id = 1,
                            CommonBetSelectionProperty = "CommonPropVal1 for ongoing",
                            ItSpecificInfo = "ItPropVal1 for ongoing"
                        }
                    }
                },
                new ItBetMainInfo
                {
                    Id = 2,
                    CommonPropertyForAllBrands = "CommonPropVal2 for ongoing",
                    ItSpecificProperty = "ItPropVal2 for ongoing",
                    SogeiTicket = "SogeiTicket2 for ongoing",
                    BetSelectionMainInfo = new List<ItBetSelectionMainInfo>
                    {
                        new ItBetSelectionMainInfo
                        {
                            Id = 2,
                            CommonBetSelectionProperty = "CommonPropVal2 for ongoing",
                            ItSpecificInfo = "ItPropVal2 for ongoing"
                        }
                    }
                },
            };
            return lst;
        }

        public override RangingResult<ItBetMainInfo> GetEndedBets(int userId, EndedStakesFilters endedStakesFilters)
        {
            //get UnifiedBet by default-specific way or use base
            var lst = new List<ItBetMainInfo>
            {
                new ItBetMainInfo
                {
                    Id = 3,
                    CommonPropertyForAllBrands = "CommonPropVal1 for ended",
                    ItSpecificProperty = "ItPropVal1 for ended",
                    SogeiTicket = "SogeiTicket1 for ongoing",
                    BetSelectionMainInfo = new List<ItBetSelectionMainInfo>
                    {
                        new ItBetSelectionMainInfo
                        {
                            Id = 3,
                            CommonBetSelectionProperty = "CommonPropVal1 for ended",
                            ItSpecificInfo = "ItPropVal1 for ended"
                        }
                    }
                },
                new ItBetMainInfo
                {
                    Id = 4,
                    CommonPropertyForAllBrands = "CommonPropVal2 for ended",
                    ItSpecificProperty = "ItPropVal2 for ended",
                    SogeiTicket = "SogeiTicket2 for ongoing",
                    BetSelectionMainInfo = new List<ItBetSelectionMainInfo>
                    {
                        new ItBetSelectionMainInfo
                        {
                            Id = 4,
                            CommonBetSelectionProperty = "CommonPropVal2 for ended",
                            ItSpecificInfo = "ItPropVal2 for ended"
                        }
                    }
                },
            };
            var rr = new RangingResult<ItBetMainInfo>(1, lst.Count, lst.Count, lst, lst.Count);
            return rr;
        }
        public IEnumerable<ItBetMainInfo> GetPendingBets(int userId, bool onlyCashoutableStakes = false, bool getPrelive = true, bool getLive = true)
        {
            //get UnifiedBet by default-specific way or use base
            var lst = new List<ItBetMainInfo>
            {
                new ItBetMainInfo
                {
                    Id = 3,
                    CommonPropertyForAllBrands = "CommonPropVal1 for pending",
                    ItSpecificProperty = "ItPropVal1 for ended",
                    SogeiTicket = "SogeiTicket1 for ongoing",
                    BetSelectionMainInfo = new List<ItBetSelectionMainInfo>
                    {
                        new ItBetSelectionMainInfo
                        {
                            Id = 3,
                            CommonBetSelectionProperty = "CommonPropVal1 for ended",
                            ItSpecificInfo = "ItPropVal1 for pending"
                        }
                    }
                },
                new ItBetMainInfo
                {
                    Id = 4,
                    CommonPropertyForAllBrands = "CommonPropVal2 for pending",
                    ItSpecificProperty = "ItPropVal2 for pending",
                    SogeiTicket = "SogeiTicket2 for ongoing",
                    BetSelectionMainInfo = new List<ItBetSelectionMainInfo>
                    {
                        new ItBetSelectionMainInfo
                        {
                            Id = 4,
                            CommonBetSelectionProperty = "CommonPropVal2 for pending",
                            ItSpecificInfo = "ItPropVal2 for pending"
                        }
                    }
                },
            };
            return lst;
        }

        public override IEnumerable<ItBetMainInfo> GetPreliveBets(int userId)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<ItBetMainInfo> GetLiveBets(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
