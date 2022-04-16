using MangoRestaurant.ShoppingCart.API.Models.Dtos.Base;

namespace MangoRestaurant.Product.API.Models.Dtos
{
    /// <summary>
    /// Represents a response wrapper for all results from returned for this API.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public class ResponseDto<TResult>
    {
        /// <summary>
        /// Gets or sets the Display Message.
        /// </summary>
        public string DisplayMessage { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Error Messages tied to this response.
        /// </summary>
        public List<string>? ErrorMessages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this operation was successful.
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Gets or sets the result of this operation.
        /// </summary>
        public TResult? Result { get; set; }
    }
}
