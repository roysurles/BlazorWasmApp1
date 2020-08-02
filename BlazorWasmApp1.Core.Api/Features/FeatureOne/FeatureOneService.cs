using System.Collections.Generic;
using System.Linq;

namespace BlazorWasmApp1.Core.Api.Features.FeatureOne
{
    public class FeatureOneService : IFeatureOneService
    {
        public IEnumerable<int> GetNumbers() =>
            Enumerable.Range(1, 5);
    }

    public interface IFeatureOneService
    {
        IEnumerable<int> GetNumbers();
    }
}
