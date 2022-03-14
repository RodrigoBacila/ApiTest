using Api.Controllers;
using Application.Interfaces;
using Castle.Windsor;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tests.Common;
using Xunit;

namespace Tests.Controllers
{
    public class MathematicalOperationsControllerTests
    {
        private readonly IWindsorContainer container;
        private readonly MathematicalOperationsController controller;

        public MathematicalOperationsControllerTests()
        {
            container = new WindsorContainer();
            container.Install(new BaseInstaller<MathematicalOperationsController>());
            controller = container.Resolve<MathematicalOperationsController>();
        }

        [Fact]
        public async void Addition_Operation_Should_Return_Proper_Values()
        {
            var request = new
            {
                firstValue = 4m,
                secondValue = 9m
            };

            var expectedResult = request.firstValue + request.secondValue;

            container.Resolve<Mock<IMathematicalOperations>>()
                .Setup(service => service.Add(request.firstValue, request.secondValue))
                .Returns(expectedResult);

            var result = controller.Add(request.firstValue, request.secondValue);

            var response = result.Should().BeOfType<OkObjectResult>().Subject;

            response
                .Should()
                .NotBeNull();

            response
                .StatusCode
                .Should()
                .Be(200);

            response
                .Value
                .Should()
                .Be(expectedResult);
        }

        [Fact]
        public async void Subtraction_Operation_Should_Return_Proper_Values()
        {
            var request = new
            {
                firstValue = 4m,
                secondValue = 9m
            };

            var expectedResult = request.firstValue - request.secondValue;

            container.Resolve<Mock<IMathematicalOperations>>()
                .Setup(service => service.Subtract(request.firstValue, request.secondValue))
                .Returns(expectedResult);

            var result = controller.Subtract(request.firstValue, request.secondValue);

            var response = result.Should().BeOfType<OkObjectResult>().Subject;

            response
                .Should()
                .NotBeNull();

            response
                .StatusCode
                .Should()
                .Be(200);

            response
                .Value
                .Should()
                .Be(expectedResult);
        }

        [Fact]
        public async void Division_Operation_Should_Return_Proper_Values()
        {
            var request = new
            {
                firstValue = 4m,
                secondValue = 9m
            };

            var expectedResult = decimal.Divide(request.firstValue, request.secondValue);

            container.Resolve<Mock<IMathematicalOperations>>()
                .Setup(service => service.Divide(request.firstValue, request.secondValue))
                .Returns(expectedResult);

            var result = controller.Divide(request.firstValue, request.secondValue);

            var response = result.Should().BeOfType<OkObjectResult>().Subject;

            response
                .Should()
                .NotBeNull();

            response
                .StatusCode
                .Should()
                .Be(200);

            response
                .Value
                .Should()
                .Be(expectedResult);
        }

        [Fact]
        public async void Multiplication_Operation_Should_Return_Proper_Values()
        {
            var request = new
            {
                firstValue = 4m,
                secondValue = 9m
            };

            var expectedResult = request.firstValue * request.secondValue;

            container.Resolve<Mock<IMathematicalOperations>>()
                .Setup(service => service.Multiply(request.firstValue, request.secondValue))
                .Returns(expectedResult);

            var result = controller.Multiply(request.firstValue, request.secondValue);

            var response = result.Should().BeOfType<OkObjectResult>().Subject;

            response
                .Should()
                .NotBeNull();

            response
                .StatusCode
                .Should()
                .Be(200);

            response
                .Value
                .Should()
                .Be(expectedResult);
        }

        [Fact]
        public async void Division_Operation_Should_Not_Attempt_To_Divide_By_Zero()
        {
            var request = new
            {
                firstValue = 4m,
                secondValue = 0m
            };

            var result = controller.Divide(request.firstValue, request.secondValue);

            var response = result.Should().BeOfType<BadRequestObjectResult>().Subject;

            response
                .Should()
                .NotBeNull();

            response
                .StatusCode
                .Should()
                .Be(400);
        }
    }
}