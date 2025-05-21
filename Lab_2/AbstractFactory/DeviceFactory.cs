using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class DeviceFactory
    {
        public abstract Device CreateLaptop();
        public abstract Device CreateSmartphone();
    }
}
