using System.Linq;

using BlazorWasmApp1.Client.Features.ParentChild;

using FluentAssertions;

using Moq;

using Xunit;

namespace BlazorWasmApp1.UnitTests
{
    public class ParentChildViewModelTests
    {
        [Fact]
        public void GetNumbers_Should_Return_1thru5()
        {
            // Arrange
            var expectedResult = Enumerable.Range(1, 5);
            var svc = new ParentChildService();
            var vm = new ParentChildViewModel(svc);

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
