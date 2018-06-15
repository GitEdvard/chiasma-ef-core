using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using chiasma_ef_core.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System.Diagnostics;
using System;

namespace chiasma_ef_core.UnitTest
{
    [TestFixture]
    class InMemoryContextTests
    {

        private static readonly LoggerFactory MyConsoleLoggerFactory
            = new LoggerFactory(new[] {
                      new ConsoleLoggerProvider((category, level)
                        => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });
        //   public static readonly LoggerFactory MyConsoleLoggerFactory
        //= new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });


        private DbContextOptions<gtdb2_devel_eeContext> GetContextOptions()
        {
            MyConsoleLoggerFactory.AddConsole();
            var dbOptionsBuilder = new DbContextOptionsBuilder<gtdb2_devel_eeContext>();
            dbOptionsBuilder
                .UseInMemoryDatabase("MyTestDb")
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .EnableSensitiveDataLogging(true);
            return dbOptionsBuilder.Options;
        }

        [Test]
        public void AddOnePlate()
        {
            var options = GetContextOptions();

            using (var context = new gtdb2_devel_eeContext(options))
            {
                var plate = new Plate();
                plate.PlateId = 0;
                plate.Identifier = "mytestplate";
                context.Plates.Add(plate);
                context.SaveChanges();
                Assert.AreEqual(1, 1);
            }
        }
        [Test]
        public void AddAnotherPlate()
        {
            var options = GetContextOptions();

            using (var context = new gtdb2_devel_eeContext(options))
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
