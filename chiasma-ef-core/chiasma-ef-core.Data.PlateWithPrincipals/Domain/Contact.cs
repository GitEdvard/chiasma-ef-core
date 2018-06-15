using System;
using System.Collections.Generic;

namespace chiasma_ef_core.Data.PlateWithPrincipals
{
    public partial class Contact
    {
        public Contact()
        {
            SampleSeries = new HashSet<SampleSeries>();
        }

        public int ContactId { get; set; }
        public string Identifier { get; set; }
        public string CoName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        public ICollection<SampleSeries> SampleSeries { get; set; }
    }
}
