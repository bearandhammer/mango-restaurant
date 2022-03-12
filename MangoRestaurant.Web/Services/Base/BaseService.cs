using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Models.Requests;
using MangoRestaurant.Web.Services.Base.Intefaces;

namespace MangoRestaurant.Web.Services.Base
{
    public class BaseService<TResponseType> : IBaseService<TResponseType>
    {
        public ResponseDto<TResponseType> ResponseModel { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> SendAsync<T>(ApiRequest<T> apiRequest)
        {
            throw new NotImplementedException();
        }
    }
}
