using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using chiasma_ef_core.Data;

namespace chiasma_ef_core.UnitTest
{
    [TestFixture]
    class InMemoryContextTests
    {
        [Test]
        public void AddOnePlate()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<gtdb2_devel_eeContext>();
            dbOptionsBuilder.UseInMemoryDatabase("MyTestDb");
            using (var context = new gtdb2_devel_eeContext(dbOptionsBuilder.Options))
            {
                var plate = new Plate();
                plate.PlateId = 0;
                plate.Identifier = "mytestplate";
                context.Plates.Add(plate);
                context.SaveChanges();
            }
        }
        [Test]
        public void AddAnotherPlate()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<gtdb2_devel_eeContext>();
            dbOptionsBuilder.UseInMemoryDatabase("MyTestDb");
            using (var context = new gtdb2_devel_eeContext(dbOptionsBuilder.Options))
            {
                var plate = new Plate();
                plate.PlateId = 1;
                plate.Identifier = "mytestplat2e";
                context.Plates.Add(plate);
                context.SaveChanges();
            }
        }
    }
}
