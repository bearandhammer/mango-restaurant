using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Models.Requests;

namespace MangoRestaurant.Web.Services.Base.Intefaces
{
    public interface IBaseService<TResponseType> : IDisposable
    {
        ResponseDto<TResponseType> ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest<T> apiRequest);
    }
}
