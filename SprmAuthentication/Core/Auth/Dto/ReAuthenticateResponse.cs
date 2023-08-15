namespace SprmAuthentication.Core.Auth.Dto
{
    /// <summary>
    /// ReAuthenticate response
    /// </summary>
    public class ReAuthenticateResponse
    {
        /// <summary>
        /// Innser service token
        /// </summary>
        public string InnerToken { get; set; } = null!;
    }
}
