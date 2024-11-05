namespace WorkItem.Web.Utility
{
    public class SD
    {
        public static string ItemTrabajoAPIBase { get; set; }

        public const string TokenCookie = "JWTToken";
       
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public enum ContentType
        {
            Json,
            MultipartFormData,
        }
    }
}
