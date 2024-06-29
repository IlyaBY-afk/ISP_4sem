using System.Net.Http.Headers;
using System.Text.Json;
using ISP_MAUI.Interfaces;
using ISP_MAUI.Entities;

namespace ISP_MAUI.Services;

public class RateService : IRateService
{
    private HttpClient _client;
    private readonly int[] _currencyIds = { 431, 451, 456, 426, 462, 429 };

    public RateService()
    {
        _client = new HttpClient();
    }

    public async Task<IEnumerable<Rate>> GetRates(DateTime date)
    {
        HttpRequestMessage httpMessage = new HttpRequestMessage(
            HttpMethod.Get, $"https://www.nbrb.by/api/exrates/rates?ondate={date.ToString($"yyyy-M-dd")}&periodicity=0"
        );

        HttpResponseMessage response = await _client.SendAsync(httpMessage);
        response.EnsureSuccessStatusCode();
        string stringContent = await response.Content.ReadAsStringAsync();


        IEnumerable<Rate>? jsonContent = JsonSerializer.Deserialize<IEnumerable<Rate>>(stringContent);

        jsonContent = jsonContent.Where(x => _currencyIds.Contains(x.Cur_ID));

        return jsonContent!;
    }
}