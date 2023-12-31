﻿using SprmApi.Common.Validations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SprmApi.Core.RoutingUsages.Dto
{
    /// <summary>
    /// 建立工藝路徑使用關係的DTO
    /// </summary>
    public class CreateRoutingUsageDto
    {
        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 該使用關係所屬工藝路徑版本的id
        /// </summary>
        [JsonRequired]
        public long RootVersionId { get; set; }

        /// <summary>
        /// 該使用關係所屬的父使用關係id
        /// </summary>
        public long? ParentUsageId { get; set; }

        /// <summary>
        /// 使用關係編號
        /// </summary>
        [JsonRequired]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 製程id
        /// </summary>
        [JsonRequired]
        public long ProcessId { get; set; }

        /// <summary>
        /// 自訂屬性
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// Parse DTO to entity
        /// </summary>
        /// <returns></returns>
        public RoutingUsage ToEntity()
        {
            return new RoutingUsage
            {
                Number = Number,
                Remarks = Remarks,
                RootVersionId = RootVersionId,
                ParentUsageId = ParentUsageId,
                ProcessId = ProcessId,
                CustomValues = JsonSerializer.SerializeToDocument(CustomValues),
            };
        }

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="partUsage"></param>
        /// <returns></returns>
        public static CreateRoutingUsageDto Parse(RoutingUsage partUsage)
        {
            return new CreateRoutingUsageDto
            {
                Remarks = partUsage.Remarks,
                RootVersionId = partUsage.RootVersionId,
                ParentUsageId = partUsage.ParentUsageId,
                Number = partUsage.Number,
                ProcessId = partUsage.ProcessId,
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(partUsage.CustomValues)!,
            };
        }
    }
}
