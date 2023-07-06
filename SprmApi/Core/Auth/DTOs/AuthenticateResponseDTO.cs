namespace SprmApi.Core.Auth.DTOs
{
    /// <summary>
    /// Authentication success data
    /// </summary>
    public class AuthenticateResponseDTO
    {
        /// <summary>
        /// JWT
        /// </summary>
        public string Token { get; set; } = null!;
    }
}
