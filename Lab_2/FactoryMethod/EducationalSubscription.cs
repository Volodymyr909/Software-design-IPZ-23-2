using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    using System;
    using System.Collections.Generic;

    public class EducationalSubscription : Subscription
    {
        public override decimal MonthlyFee => 5.99m;
        public override int MinimumPeriod => 6;
        public override List<string> Channels => new List<string> { "Освіта", "Наука", "Документальні" };

        private string _creator;

        public EducationalSubscription(string creator)
        {
            _creator = creator;
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Освітня підписка створена через {_creator}");
            Console.WriteLine($"Місячна плата: {MonthlyFee}$");
            Console.WriteLine($"Мінімальний період: {MinimumPeriod} місяців");
            Console.WriteLine($"Канали: {string.Join(", ", Channels)}");
        }
    }
}
