namespace SprmAuthentication.Core.Auth.Dto
{
    /// <summary>
    /// ReAuthenticate request for inner service token
    /// </summary>
    public class ReAuthenticateRequest
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; } = null!;
    }
}
