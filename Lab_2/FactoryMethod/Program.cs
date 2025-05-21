using FactoryMethod;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Створення підписки через WebSite
        SubscriptionCreator websiteCreator = new WebSite();
        Subscription websiteSubscription = websiteCreator.CreateDomesticSubscription();
        websiteSubscription.ShowDetails();

        // Створення підписки через MobileApp
        SubscriptionCreator mobileAppCreator = new MobileApp();
        Subscription mobileAppSubscription = mobileAppCreator.CreateEducationalSubscription();
        mobileAppSubscription.ShowDetails();

        // Створення підписки через ManagerCall
        SubscriptionCreator managerCallCreator = new ManagerCall();
        Subscription managerCallSubscription = managerCallCreator.CreatePremiumSubscription();
        managerCallSubscription.ShowDetails();
    }
}
