using MangoRestaurant.Product.API.Models.Dtos.Base;

namespace MangoRestaurant.Product.API.Models.Dtos
{
    public class ResponseDto<TResult> where TResult : BaseDto
    {
        public string DisplayMessage { get; set; } = string.Empty;
        public List<string>? ErrorMessages { get; set; }
        public bool IsSuccess { get; set; } = true;

        public TResult? Result { get; set; }
    }
}
