using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class Laptop : Device
    {
        private string _brand;
        private string _model;

        public Laptop(string brand, string model)
        {
            _brand = brand;
            _model = model;
        }

        public override string GetModelDetails()
        {
            return $"{_brand} Ноутбук Модель: {_model}";
        }
    }
}
