using System.Text.Json;
using SprmCommon.Dto;

namespace SprmAuthentication.Core.AppUsers.Dto
{
    /// <summary>
    /// AppUser data
    /// </summary>
    public class AppUserDto : BaseReturnDto
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// 使用者全名
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// 是否為系統管理員
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        public static AppUserDto Parse(AppUser appUser)
        {
            AppUserDto dto = new AppUserDto
            {
                Username = appUser.Username,
                FullName = appUser.FullName,
                IsAdmin = appUser.IsAdmin,
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(appUser.CustomValues)!,
            };
            dto.Populate(appUser);
            return dto;
        }
    }
}
