using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CustomCalculator.Tests
{
    public class TestBase
    {
        public TestBase()
        {
            RegisterServices();
        }

        public static IServiceProvider Services { get => _services; set => _services = value; }
        private static IServiceProvider _services;

        private static void RegisterServices()
        {
            var service = new ServiceCollection();
            service.AddCalculator();
            Services = service.BuildServiceProvider();
        }
    }


    public class CalculatorTests : TestBase
    {
        [Fact]
        public void BasicTest_With_Two_Operands()
        {
            ICalculator calc = Services.GetService<ICalculator>();
            calc.Configure("1,2");

            int result = calc.Execute();
            Assert.True(result == 3);
        }

        [Fact]
        public void BasicTest_With_Multiple_Operands()
        {
            ICalculator calc = Services.GetService<ICalculator>();
            calc.Configure("1,2,3");

            int result = calc.Execute();
            Assert.True(result == 6);
        }


        [Fact]
        public void BasicTest_With_NewLine_Delimiter()
        {
            ICalculator calc = Services.GetService<ICalculator>();
            calc.Configure("2\n3");

            int result = calc.Execute();
            Assert.True(result == 5);
        }


        [Fact]
        public void BasicTest_With_BigNumber()
        {
            ICalculator calc = Services.GetService<ICalculator>();
            calc.Configure("2\n3,2000");

            int result = calc.Execute();
            Assert.True(result == 5);
        }

        [Fact]
        public void BasicTest_With_NegativeNumberException()
        {
            ICalculator calc = Services.GetService<ICalculator>();
            calc.Configure("-2\n3,2000");

            Assert.Throws<Exception>(() => calc.Execute());
        }

        [Fact]
        public void BasicTest_With_CustomDelimiter()
        {
            ICalculator calc = Services.GetService<ICalculator>();
            calc.Configure("//;\n1;2,3");

            int result = calc.Execute();
            Assert.True(result == 6);
        }


        [Fact]
        public void BasicTest_With_MultipleCustomDelimiter()
        {
            ICalculator calc = Services.GetService<ICalculator>();
            calc.Configure("//[;][*]\n1;2,3*4");

            int result = calc.Execute();
            Assert.True(result == 10);
        }

    }
}
