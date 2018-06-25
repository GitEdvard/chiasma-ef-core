using System;

namespace Hello_IOC
{
    class Shopper
    {
        private ICreditCard _card;

        public Shopper(ICreditCard card)
        {
            _card = card;
        }

        public void Charge()
        {
            Console.WriteLine(_card.Charge());
        }
    }

    public class CreditCard : ICreditCard
    {
        public string Charge()
        {
            return "Charge with default creditcard";
        }
    }

    class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "Charge with MasterCard";
        }
    }
    class Visa : ICreditCard
    {
        public string Charge()
        {
            return "Charge with visa";
        }
    }

    internal interface ICreditCard
    {
        string Charge();
    }
}
