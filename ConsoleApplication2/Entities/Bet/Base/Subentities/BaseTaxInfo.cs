using System;
using System.Collections.Generic;

namespace ConsoleApplication2.Entities.Bet.Base.Subentities
{
    public abstract class BaseTaxInfo
    {
        public int BetId { get; set; }

        public DateTime OnlineDate { get; set; }

        public Dictionary<double, double> TaxInfos { get; set; }

        public bool IsActive { get; set; }

        public bool IsTaxFree { get; set; }

        public double MinimumOdds { get; set; }

        public int MinimumSelections { get; set; }

        public string Tooltip { get; set; }
    }
}