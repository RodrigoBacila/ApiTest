using Application.Interfaces;
using Application.Services;
using Castle.Windsor;
using FluentAssertions;
using System.Threading.Tasks;
using Tests.Common;
using Xunit;

namespace Tests.Services
{
    public class MathematicalOperationsServiceTests
    {
        private readonly IWindsorContainer container;
        private readonly IMathematicalOperations service;

        public MathematicalOperationsServiceTests()
        {
            container = new WindsorContainer();
            container.Install(new BaseInstaller<MathematicalOperations>());
            service = container.Resolve<MathematicalOperations>();
        }

        [Fact(DisplayName = "Addition operation")]
        public void Addition_Should_Return_Proper_Values()
        {
            var request = new
            {
                firstValue = 4m,
                secondValue = 9m
            };

            var expectedResult = decimal.Add(request.firstValue, request.secondValue);

            var result = service.Add(request.firstValue, request.secondValue);

            result
                .Should()
                .Be(expectedResult);
        }

        [Fact(DisplayName = "Subtraction operation")]
        public void Subtraction_Should_Return_Proper_Values()
        {
            var request = new
            {
                firstValue = 4m,
                secondValue = 9m
            };

            var expectedResult = decimal.Subtract(request.firstValue, request.secondValue);

            var result = service.Subtract(request.firstValue, request.secondValue);

            result
                .Should()
                .Be(expectedResult);
        }

        [Fact(DisplayName = "Division operation")]
        public void Division_Should_Return_Proper_Values()
        {
            var request = new
            {
                firstValue = 4m,
                secondValue = 9m
            };

            var expectedResult = decimal.Divide(request.firstValue, request.secondValue);

            var result = service.Divide(request.firstValue, request.secondValue);

            result
                .Should()
                .Be(expectedResult);
        }

        [Fact(DisplayName = "Multiplication operation")]
        public void Multiplication_Should_Return_Proper_Values()
        {
            var request = new
            {
                firstValue = 4m,
                secondValue = 9m
            };

            var expectedResult = decimal.Multiply(request.firstValue, request.secondValue);

            var result = service.Multiply(request.firstValue, request.secondValue);

            result
                .Should()
                .Be(expectedResult);
        }
    }
}
