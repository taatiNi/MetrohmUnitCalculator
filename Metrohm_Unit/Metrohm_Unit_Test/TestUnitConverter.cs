using Metrohm_Unit.Helper;
using System;
using Xunit;

namespace Metrohm_Unit_Test
{
    public class TestUnitConverter
    {
        [Fact]
        public void Should_convert_second_to_milisecond()
        {
          var result=  UnitConverter.Convert(Metrohm_Unit.ViewModel.UnitType.Second, Metrohm_Unit.ViewModel.UnitType.MiliSecond, 1);
            Assert.Equal(1000, result);
        }
        [Fact]
        public void Should_convert_miliSecond_to_Second()
        {
            var result = UnitConverter.Convert(Metrohm_Unit.ViewModel.UnitType.MiliSecond, Metrohm_Unit.ViewModel.UnitType.Second, 1000);
            Assert.Equal(1, result);
        }
    }
}
