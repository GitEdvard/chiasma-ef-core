using System;
using System.Collections.Generic;

namespace chiasma_ef_core.Data.PlateWithPrincipals
{
    public partial class PlateType
    {
        public PlateType()
        {
            Plate = new HashSet<Plate>();
        }

        public int PlateTypeId { get; set; }
        public string Identifier { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public string Description { get; set; }
        public string Usage { get; set; }

        public ICollection<Plate> Plate { get; set; }
    }
}
