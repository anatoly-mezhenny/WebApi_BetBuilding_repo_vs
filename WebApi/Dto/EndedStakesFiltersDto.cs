using System;
using System.Collections.Generic;

namespace WebApi.Dto
{
    public class EndedStakesFiltersDto
    {
        /// <summary>
        /// Represents the type of stake that have to be returned.
        /// </summary>
        public enum StakeTypeFilter
        {
            None = 0,
            All,
            Winning,
            Losing
        }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public StakeTypeFilter Type { get; set; }

        public int StartIndex { get; set; }

        public int LastIndex { get; set; }

        public bool IsLive { get; set; }

        public IEnumerable<int> StakeIds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether stakes placed since user's last visit have to be returned (<c>true</c>) or all user's stakes (<c>false</c>).
        /// </summary>
        public bool SinceLastVisit { get; set; }
    }
}