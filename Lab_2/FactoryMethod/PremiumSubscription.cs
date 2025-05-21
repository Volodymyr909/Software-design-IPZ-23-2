using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class PremiumSubscription : Subscription
    {
        public override decimal MonthlyFee => 20.99m;
        public override int MinimumPeriod => 24;
        public override List<string> Channels => new List<string> { "Преміум фільми", "Спорт", "Ексклюзивний контент" };

        private string _creator;

        public PremiumSubscription(string creator)
        {
            _creator = creator;
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Преміум підписка створена через {_creator}");
            Console.WriteLine($"Місячна плата: {MonthlyFee}$");
            Console.WriteLine($"Мінімальний період: {MinimumPeriod} місяців");
            Console.WriteLine($"Канали: {string.Join(", ", Channels)}");
        }
    }
}
