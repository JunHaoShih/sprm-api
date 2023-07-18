using System.Text.Json;
using System.Text.Json.Serialization;

namespace SprmApi.Core.AppUsers.Dto
{
    /// <summary>
    /// AppUser DTO for AppUser creation
    /// </summary>
    public class CreateAppUserDto
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
        /// 是否為系統管理員
        /// </summary>
        [JsonRequired]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// DTO to entity
        /// </summary>
        /// <returns></returns>
        public AppUser ToEntity()
        {
            return new AppUser
            {
                Username = Username,
                Password = Password,
                FullName = FullName,
                IsAdmin = IsAdmin,
                Remarks = Remarks,
                CustomValues = JsonSerializer.SerializeToDocument(CustomValues),
            };
        }
    }
}
