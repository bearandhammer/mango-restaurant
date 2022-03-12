using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Models.Requests;
using MangoRestaurant.Web.Services.Base.Intefaces;
using Newtonsoft.Json;
using System.Text;

namespace MangoRestaurant.Web.Services.Base
{
    public class BaseService<TResponseType> : IBaseService<TResponseType>
    {
        public ResponseDto<TResponseType> ResponseModel { get; set; }
        public IHttpClientFactory HttpClientFactory { get; set; }

        public BaseService(IHttpClientFactory clientFactoryType)
        {
            ResponseModel = new ResponseDto<TResponseType>();
            HttpClientFactory = clientFactoryType;
        }

        public Task<T> SendAsync<T>(ApiRequest<T> apiRequest)
        {
            throw new NotImplementedException();

            // I need to this of a different way of doing this (after reviewing the course content - it's brutal)
            //try
            //{
            //    HttpClient client = HttpClientFactory.CreateClient("MangoRestaurantAPI");

            //    HttpRequestMessage message = new HttpRequestMessage();

            //    // TODO - Constants!
            //    message.Headers.Add("Accept", "application/json");
            //    message.RequestUri = new Uri(apiRequest.Url);

            //    client.DefaultRequestHeaders.Clear();

            //    if (apiRequest.Data != null)
            //    {
            //        message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
            //    }

            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }

        // TODO - Adjust
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
