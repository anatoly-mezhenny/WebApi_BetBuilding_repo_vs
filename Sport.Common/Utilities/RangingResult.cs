using System.Collections.Generic;
using System.Linq;

namespace Sport.Common.Utilities
{
    //COPIED from real Sport.Core
    //the object was refined
    public class RangingResult<T>
    {

        public RangingResult(int @from, int to, int total, IEnumerable<T> items, int itemsInRangeCount)
        {
            From = @from;
            To = to;
            Total = total;
            Items = items;
            ItemsInRangeCount = itemsInRangeCount;
        }

        /// <summary>Gets the lower bound  of the ranging.</summary>
        public int From { get; private set; }

        /// <summary>Gets the upper bound  of the ranging.</summary>
        public int To { get; private set; }

        /// <summary>
        /// Gets the total number of elements in the initial sequence (i.e. elements count before the ranging).
        /// </summary>
        public int Total { get; private set; }

        /// <summary>Gets the items in the range.</summary>
        public IEnumerable<T> Items { get; private set; }

        /// <summary>
        /// Gets number of elements in <see cref="P:Sport.Common.Range.RangingResult`1.Items" />.
        /// </summary>
        public int ItemsInRangeCount { get; private set; }

    }

    public static class RangingResultHelper
    {
        public static RangingResult<T1> CreateFrom<T1, T2>(RangingResult<T2> rr)
            where T2 : T1
        {
            var lst = rr.Items.Cast<T1>().ToArray();
            return new RangingResult<T1>(rr.From, rr.To, rr.Total, lst, rr.ItemsInRangeCount);
        }
    }

}
