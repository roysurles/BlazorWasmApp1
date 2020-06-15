namespace BlazorWasmApp1.Shared.Models.Common.Enumeration
{
    public interface IEnumerationJson
    {
        object ReadJson(string jsonValue);

        string WriteJson();
    }
}
