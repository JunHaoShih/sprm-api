﻿using Newtonsoft.Json;

namespace SprmApi.Core.AppUsers.DTOs
{
    /// <summary>
    /// AppUser data
    /// </summary>
    public class AppUserDTO
    {
        /// <summary>
        /// 使用者id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// 使用者全名
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        public static AppUserDTO Parse(AppUser appUser)
        {
            return JsonConvert.DeserializeObject<AppUserDTO>(JsonConvert.SerializeObject(appUser))!;
        }
    }
}
