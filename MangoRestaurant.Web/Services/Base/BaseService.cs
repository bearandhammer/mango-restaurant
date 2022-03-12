using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Models.Requests;
using MangoRestaurant.Web.Services.Base.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace MangoRestaurant.Web.Services.Base
{
    public class BaseService : IBaseService
    {
        public BaseService(IHttpClientFactory clientFactoryType)
        {
            HttpClientFactory = clientFactoryType;
        }

        public IHttpClientFactory HttpClientFactory { get; set; }

        // TODO - Adjust
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                HttpClient client = HttpClientFactory.CreateClient("MangoRestaurantAPI");
                client.DefaultRequestHeaders.Clear();

                HttpRequestMessage message = GetConfiguredMessageFromApiRequest(apiRequest);
                HttpResponseMessage apiResponse = await client.SendAsync(message);

                return await DeserializeHttpResponseMessage<T>(apiResponse);
            }
            catch (Exception ex)
            {
                // TODO - refactor and log
                ResponseDto<T> errorDto = new ResponseDto<T>
                {
                    DisplayMessage = "Error",
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };

                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(errorDto));
            }
        }

        private static async Task<T> DeserializeHttpResponseMessage<T>(HttpResponseMessage apiResponse)
        {
            string apiContent = await apiResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(apiContent);
        }

        private static HttpRequestMessage GetConfiguredMessageFromApiRequest(ApiRequest apiRequest)
        {
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);

            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
            }

            switch (apiRequest.ApiType)
            {
                case Utility.ApiHelper.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;

                case Utility.ApiHelper.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;

                case Utility.ApiHelper.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;

                case Utility.ApiHelper.ApiType.GET:
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            return message;
        }
    }
}
