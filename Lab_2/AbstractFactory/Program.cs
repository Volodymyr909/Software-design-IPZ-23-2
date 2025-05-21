using AbstractFactory;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        DeviceFactory appleFactory = new AppleFactory();
        Device appleLaptop = appleFactory.CreateLaptop();
        Device appleSmartphone = appleFactory.CreateSmartphone();

        Console.WriteLine(appleLaptop.GetModelDetails());
        Console.WriteLine(appleSmartphone.GetModelDetails());

        DeviceFactory xiaomiFactory = new XiaomiFactory();
        Device xiaomiLaptop = xiaomiFactory.CreateLaptop();
        Device xiaomiSmartphone = xiaomiFactory.CreateSmartphone();

        Console.WriteLine(xiaomiLaptop.GetModelDetails());
        Console.WriteLine(xiaomiSmartphone.GetModelDetails());

        DeviceFactory samsungFactory = new SamsungFactory();
        Device samsungLaptop = samsungFactory.CreateLaptop();
        Device samsungSmartphone = samsungFactory.CreateSmartphone();

        Console.WriteLine(samsungLaptop.GetModelDetails());
        Console.WriteLine(samsungSmartphone.GetModelDetails());
    }
}
