using StructureMap;

namespace Hello_IOC
{
    class Program
    {
        /// <summary>
        /// See also code for the domain driven design course. There they use
        /// structuremap in order to implement Domain Events. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CreateWithAction();
            CreateWithDefaultConvention();
            CreateWithRegistry();
        }

        private static void CreateWithAction()
        {
            var container = new Container(_ => { _.For<ICreditCard>().Use<Visa>(); });
            var shopper = container.GetInstance<Shopper>();
            shopper.Charge();
        }

        private static void CreateWithDefaultConvention()
        {
            // Make CreditCard public, that made the trick.
            var container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            });
            var shopper = container.GetInstance<Shopper>();
            shopper.Charge();
        }

        private static void CreateWithRegistry()
        {
            var container = new Container(new MyRegistry());
            var shopper = container.GetInstance<Shopper>();
            shopper.Charge();
        }

        class MyRegistry : Registry
        {
            public MyRegistry()
            {
                For<ICreditCard>().Use<MasterCard>();
            }
        }
    }
}
