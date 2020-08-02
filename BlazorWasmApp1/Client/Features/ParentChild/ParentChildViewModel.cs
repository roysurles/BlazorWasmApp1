using System.Collections.Generic;

namespace BlazorWasmApp1.Client.Features.ParentChild
{
    public class ParentChildViewModel : IParentChildViewModel
    {
        private readonly IParentChildService _parentChildService;

        public ParentChildViewModel(IParentChildService parentChildService) =>
            _parentChildService = parentChildService;

        public IEnumerable<int> GetNumbers() =>
            _parentChildService.GetNumbers();
    }

    public interface IParentChildViewModel
    {
        IEnumerable<int> GetNumbers();
    }
}
