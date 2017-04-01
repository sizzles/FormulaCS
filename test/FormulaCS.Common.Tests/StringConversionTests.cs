using System;
using Xunit;

namespace FormulaCS.Common.Tests
{
    public class StringConversionTests
    {
        [Fact]
        public void ConvertsDateTimeToDoubleUsedByExcel()
        {
            Assert.Equal(42826, StringConversion.ToDouble(DateTime.Parse("2017-04-01")));
            Assert.Equal(new decimal(42826.8807986111), new decimal(StringConversion.ToDouble(DateTime.Parse("2017-04-01 21:08:21"))));
        }
    }
}