using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class XiaomiFactory : DeviceFactory
    {
        public override Device CreateLaptop()
        {
            return new Laptop("Xiaomi", "Mi Notebook");
        }

        public override Device CreateSmartphone()
        {
            return new Smartphone("Xiaomi", "Mi 14 pro");
        }
    }
}
