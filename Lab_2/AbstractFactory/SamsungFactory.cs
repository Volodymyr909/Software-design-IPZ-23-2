using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class SamsungFactory : DeviceFactory
    {
        public override Device CreateLaptop()
        {
            return new Laptop("Samsung", "Galaxy Book");
        }

        public override Device CreateSmartphone()
        {
            return new Smartphone("Samsung", "Galaxy S23 Plus");
        }
    }
}
