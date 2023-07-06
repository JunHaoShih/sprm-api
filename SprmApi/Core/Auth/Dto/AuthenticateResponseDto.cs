namespace SprmApi.Core.Auth.Dto
{
    /// <summary>
    /// Authentication success data
    /// </summary>
    public class AuthenticateResponseDto
    {
        /// <summary>
        /// JWT
        /// </summary>
        public string Token { get; set; } = null!;
    }
}
