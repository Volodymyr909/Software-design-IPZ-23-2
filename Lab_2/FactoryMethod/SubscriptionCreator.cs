using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public abstract class SubscriptionCreator
    {
        public abstract Subscription CreateDomesticSubscription();
        public abstract Subscription CreateEducationalSubscription();
        public abstract Subscription CreatePremiumSubscription();
        public abstract string GetCreatorType();
    }
}
