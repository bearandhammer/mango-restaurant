using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Models.Requests;

namespace MangoRestaurant.Web.Services.Base.Interfaces
{
    public interface IBaseService : IDisposable
    {
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
