using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TraderLibrary
{
    public class TradeProcessor
    {
        public static async Task<TradeModel[]> LoadTrades(int limit = 300)
        {
            string url = "";

            if (limit <= 300)
            {
                url = $"https://api.bitbay.net/rest/trading/transactions/BTC-PLN?limit={ limit }";
            }
            else
            {

            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    TradeItemModel trade = await response.Content.ReadAsAsync<TradeItemModel>();

                    return trade.Items;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
