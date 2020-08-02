using System.Linq;

using BlazorWasmApp1.Client.Features.ParentChild;

using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

using Moq;

using Xunit;

namespace BlazorWasmApp1.UnitTests
{
    public class ParentChildViewModelTests : IClassFixture<ServiceCollectionFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public ParentChildViewModelTests(ServiceCollectionFixture serviceCollectionFixture) =>
            _serviceProvider = serviceCollectionFixture.ServiceProvider;

        [Fact]
        public void GetNumbers_Should_Return_1thru5()
        {
            // Arrange
            var expectedResult = Enumerable.Range(1, 5);
            //var svc = _serviceProvider.GetService<IParentChildService>();   // new ParentChildService();
            var vm = _serviceProvider.GetService<IParentChildViewModel>();    // new ParentChildViewModel(svc);

            // Act
            var result = vm.GetNumbers();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetNumbersMoq_Should_Return_6thru10()
        {
            // Arrange
            var expectedResult = Enumerable.Range(6, 10);
            var mockSvc = new Mock<IParentChildService>();
            mockSvc.Setup(m => m.GetNumbers()).Returns(Enumerable.Range(6, 10));
            var vm = new ParentChildViewModel(mockSvc.Object);

            // Act
            var result = vm.GetNumbers();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
