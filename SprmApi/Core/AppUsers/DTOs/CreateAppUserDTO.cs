using Newtonsoft.Json;

namespace SprmApi.Core.AppUsers.DTOs
{
    /// <summary>
    /// AppUser DTO for AppUser creation
    /// </summary>
    public class CreateAppUserDTO
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        [JsonRequired]
        public string Username { get; set; } = null!;
        /// <summary>
        /// 使用者名稱
        /// </summary>
        [JsonRequired]
        public string Password { get; set; } = null!;

        /// <summary>
        /// 使用者全名
        /// </summary>
        [JsonRequired]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// DTO to entity
        /// </summary>
        /// <returns></returns>
        public AppUser ToEntity()
        {
            return JsonConvert.DeserializeObject<AppUser>(JsonConvert.SerializeObject(this))!;
        }
    }
}
