using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class AppleFactory : DeviceFactory
    {
        public override Device CreateLaptop()
        {
            return new Laptop("Apple", "MacBook Pro");
        }

        public override Device CreateSmartphone()
        {
            return new Smartphone("Apple", "iPhone 14 Pro");
        }
    }

}
