using SprmApi.Core.Auth;

namespace SprmApi.MiddleWares
{
    /// <summary>
    /// Http Header資料，請將此這設為PerLifetimeScope
    /// </summary>
    public class HeaderData
    {
        /// <summary>
        /// Store bearer token
        /// </summary>
        public string Bearer { get; set; } = null!;

        /// <summary>
        /// Store decrypted JWT
        /// </summary>
        public JWTPayload JWTPayload { get; set; } = null!;
    }
}
