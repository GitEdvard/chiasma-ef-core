using chiasma_ef_core.Data;
using System.Linq;
using System;

namespace chiasma_ef_core
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new gtdb2_devel_eeContext();
            var plate = context.Plates.FirstOrDefault();
            Console.WriteLine(plate.Identifier);
            Console.WriteLine("Write any key...");
            Console.ReadLine();
        }
    }
}
