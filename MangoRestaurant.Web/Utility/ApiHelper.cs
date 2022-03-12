namespace MangoRestaurant.Web.Utility
{
    // TODO - Course uses this static type as a helper (to remove!!!)
    public class ApiHelper
    {
        public static string ProductApiBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
