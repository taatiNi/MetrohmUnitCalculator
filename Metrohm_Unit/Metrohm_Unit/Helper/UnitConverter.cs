
using Metrohm_Unit.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace Metrohm_Unit.Helper
{
    public class UnitConverter
    {
        private static Dictionary<UnitConverterModel, Func<double, double>> Converts { get; set; }
        static UnitConverter()
        { 
            Converts = new Dictionary<UnitConverterModel, Func<double, double>>();
            Converts.Add(new UnitConverterModel() { From = UnitType.MiliSecond, To = UnitType.Second }, x => x / 1000);
            Converts.Add(new UnitConverterModel() { From = UnitType.Second, To = UnitType.MiliSecond }, x => x * 1000);
        }

        public static double Convert(UnitType from, UnitType to, double value)
        {
            if (from == to)
                return value;
            var unitFunction = Converts.FirstOrDefault(x => x.Key.From == from && x.Key.To == to);
            return unitFunction.Value.Invoke(value);

        }
    }
}
