using System.Collections.Generic;
using System.Linq;

namespace BlazorWasmApp1.Client.Features.ParentChild
{
    public class ParentChildService : IParentChildService
    {
        public IEnumerable<int> GetNumbers() =>
            Enumerable.Range(1, 5);
    }

    public interface IParentChildService
    {
        IEnumerable<int> GetNumbers();
    }
}

