using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using chiasma_ef_core.Data;

namespace chiasma_ef_core.IntegrationTest
{
    [TestFixture]
    class MiscTests
    {
        //Note: it should only be one instance in application
        private static readonly LoggerFactory MyConsoleLoggerFactory
            = new LoggerFactory(new[] {
                      new ConsoleLoggerProvider((category, level)
                        => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });

        private DbContextOptions<gtdb2_devel_eeContext> GetContextOptions()
        {
            MyConsoleLoggerFactory.AddConsole();
            var dbOptionsBuilder = new DbContextOptionsBuilder<gtdb2_devel_eeContext>();
            var conString = ConfigurationManager.ConnectionStrings["DevDb"].ConnectionString;
            conString = conString.Replace("db_name", "gtdb2_devel_ee");
            dbOptionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(conString);
            return dbOptionsBuilder.Options;
        }

        [Test]
        public void FirstTest()
        {
            var options = GetContextOptions();
            using(var context = new gtdb2_devel_eeContext())
            {
                var plate = context.Plates.FirstOrDefault();
            }

        }
    }
}
