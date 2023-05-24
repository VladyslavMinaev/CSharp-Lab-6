using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientApp.Services;

public class Communicator
{
    public async Task<T> Post<T>(string url, object body)
    {
        using HttpClient httpClient = new();
        var bodyJson = JsonConvert.SerializeObject(body);
        var requestContent = new StringContent(bodyJson, Encoding.UTF8, MediaTypeNames.Application.Json);

        var response = await httpClient.PostAsync(url, requestContent);
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }

    public async Task<T> Get<T>(string url)
    {
        using HttpClient httpClient = new();

        var response = await httpClient.GetAsync(url);
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }
}