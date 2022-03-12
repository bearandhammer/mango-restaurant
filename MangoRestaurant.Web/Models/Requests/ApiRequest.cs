using static MangoRestaurant.Web.Utility.ApiHelper;

namespace MangoRestaurant.Web.Models.Requests
{
    public class ApiRequest<TRequestType>
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; }

        public TRequestType Data { get; set; }

        public string Token { get; set; }
    }
}
