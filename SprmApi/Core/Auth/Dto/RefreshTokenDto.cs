namespace SprmApi.Core.Auth.Dto
{
    /// <summary>
    /// 更新Access token DTO
    /// </summary>
    public class RefreshTokenDto
    {
        /// <summary>
        /// Refresh token
        /// </summary>
        public string RefreshToken { get; set; } = null!;
    }
}
