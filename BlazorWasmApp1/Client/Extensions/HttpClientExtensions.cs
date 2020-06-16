using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using BlazorWasmApp1.Shared.Extensions;
using BlazorWasmApp1.Shared.Models.Common.ApiResult;

using Microsoft.Extensions.Logging;

namespace BlazorWasmApp1.Client.Extensions
{
    public static class HttpClientExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        public static async Task<ApiResultModel<T>> GetAsyncEx<T>(this HttpClient HttpClient, string requestUri, ILogger logger, [CallerMemberName] string callerMemberName = null)
        {
            using (var response = await HttpClient.GetAsync(requestUri))
            {
                logger.LogInformation($"{callerMemberName} response.StatusCode:{response.StatusCode}");
                var json = await response.Content.ReadAsStringAsync();
                logger.LogInformation($"{callerMemberName} response.Content.ReadAsStringAsync();");
                logger.LogInformation($"{callerMemberName} json: {json}");
                var apiResultModel = json.Deserialize<ApiResultModel<T>>();
                logger.LogInformation($"{callerMemberName} json.Deserialize<ApiResultModel<T>>();");
                logger.LogInformation($"{callerMemberName} apiResultModel is null: {(apiResultModel is null)}");
                logger.LogInformation($"{callerMemberName} apiResultModel.Data is null: {(apiResultModel.Data is null)}");
                apiResultModel.SetHttpStatusCode(response.StatusCode);
                logger.LogInformation($"{callerMemberName} apiResultModel.SetHttpStatusCode(response.StatusCode);");
                return apiResultModel;
            }
        }
    }
}
