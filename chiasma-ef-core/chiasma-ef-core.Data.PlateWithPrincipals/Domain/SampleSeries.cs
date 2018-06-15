using System;
using System.Collections.Generic;

namespace chiasma_ef_core.Data.PlateWithPrincipals
{
    public partial class SampleSeries
    {
        public SampleSeries()
        {
            Plate = new HashSet<Plate>();
        }

        public int SampleSeriesId { get; set; }
        public string Identifier { get; set; }
        public int ContactId { get; set; }
        public string Comment { get; set; }

        public Contact Contact { get; set; }
        public ICollection<Plate> Plate { get; set; }
    }
}
