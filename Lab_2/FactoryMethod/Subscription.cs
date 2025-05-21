using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public abstract class Subscription
    {
        public abstract decimal MonthlyFee { get; }
        public abstract int MinimumPeriod { get; }
        public abstract List<string> Channels { get; }
        public abstract void ShowDetails();
    }
}
