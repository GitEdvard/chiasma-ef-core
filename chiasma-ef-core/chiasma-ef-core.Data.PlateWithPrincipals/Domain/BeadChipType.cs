using System;
using System.Collections.Generic;

namespace chiasma_ef_core.Data.PlateWithPrincipals
{
    public partial class BeadChipType
    {
        public BeadChipType()
        {
            BeadChipInfo = new HashSet<BeadChipInfo>();
        }

        public int BeadChipTypeId { get; set; }
        public string Identifier { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public string Chiptype { get; set; }
        public int? DefaultBatchSize { get; set; }
        public string Status { get; set; }

        public ICollection<BeadChipInfo> BeadChipInfo { get; set; }
    }
}
