using System;
using System.Collections.Generic;

namespace chiasma_ef_core.Data
{
    public partial class Plate
    {
        public int PlateId { get; set; }
        public string PlateUsage { get; set; }
        public int PlateTypeId { get; set; }
        public string Identifier { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public int? BeadChipInfoId { get; set; }
        public int? SampleSeriesId { get; set; }
        public int? PlateNumber { get; set; }
        public string Method { get; set; }
        public int? TestColumn { get; set; }
    }
}
