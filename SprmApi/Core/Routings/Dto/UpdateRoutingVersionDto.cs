﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace SprmApi.Core.Routings.Dto
{
    /// <summary>
    /// 更新工藝路徑版本DTO
    /// </summary>
    public class UpdateRoutingVersionDto
    {
        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [JsonRequired]
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// 更新entity資料
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public RoutingVersion ApplyUpdate(RoutingVersion version)
        {
            version.Remarks = Remarks;
            version.CustomValues = JsonSerializer.SerializeToDocument(CustomValues);
            return version;
        }
    }
}
