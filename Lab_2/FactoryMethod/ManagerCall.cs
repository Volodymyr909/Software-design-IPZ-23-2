using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class ManagerCall : SubscriptionCreator
    {
        public override Subscription CreateDomesticSubscription()
        {
            return new DomesticSubscription(GetCreatorType());
        }

        public override Subscription CreateEducationalSubscription()
        {
            return new EducationalSubscription(GetCreatorType());
        }

        public override Subscription CreatePremiumSubscription()
        {
            return new PremiumSubscription(GetCreatorType());
        }

        public override string GetCreatorType()
        {
            return "ManagerCall";
        }
    }
}
