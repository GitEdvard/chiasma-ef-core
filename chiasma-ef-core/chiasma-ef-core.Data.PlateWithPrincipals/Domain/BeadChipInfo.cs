using System;
using System.Collections.Generic;

namespace chiasma_ef_core.Data.PlateWithPrincipals
{
    public partial class BeadChipInfo
    {
        public BeadChipInfo()
        {
            PlateNavigation = new HashSet<Plate>();
        }

        public int BeadChipInfoId { get; set; }
        public int PlateId { get; set; }
        public int? NCompletedBatches { get; set; }
        public bool? MultipleBatches { get; set; }
        public int? BatchSize { get; set; }
        public int? DefaultBeadChipTypeId { get; set; }

        public BeadChipType DefaultBeadChipType { get; set; }
        public Plate Plate { get; set; }
        public ICollection<Plate> PlateNavigation { get; set; }
    }
}
