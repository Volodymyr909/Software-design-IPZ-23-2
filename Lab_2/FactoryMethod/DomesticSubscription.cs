using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    using System;
    using System.Collections.Generic;

    public class DomesticSubscription : Subscription
    {
        public override decimal MonthlyFee => 10.99m;
        public override int MinimumPeriod => 12;
        public override List<string> Channels => new List<string> { "Новини", "Спорт", "Фільми" };

        private string _creator;

        public DomesticSubscription(string creator)
        {
            _creator = creator;
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Домашня підписка створена через {_creator}");
            Console.WriteLine($"Місячна плата: {MonthlyFee}$");
            Console.WriteLine($"Мінімальний період: {MinimumPeriod} місяців");
            Console.WriteLine($"Канали: {string.Join(", ", Channels)}");
        }
    }
}
