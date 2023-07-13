using System.Text.Json;
using System.Text.Json.Serialization;
using SprmApi.Common.Validations;

namespace SprmApi.Core.Processes.Dto
{
    /// <summary>
    /// 更新製程DTO
    /// </summary>
    public class UpdateProcessDto
    {
        /// <summary>
        /// 製程編號
        /// </summary>
        [JsonRequired]
        [NumberValidation(MinNumberLength = 2)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 製程名稱
        /// </summary>
        [JsonRequired]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 製程類型id
        /// </summary>
        [JsonRequired]
        public long ProcessTypeId { get; set; }

        /// <summary>
        /// 預設製造類型id
        /// </summary>
        [JsonRequired]
        public long DefaultMakeTypeId { get; set; }

        /// <summary>
        /// 預設進站時間
        /// </summary>
        [JsonRequired]
        public int DefaultImportTime { get; set; }

        /// <summary>
        /// 預設出站時間
        /// </summary>
        [JsonRequired]
        public int DefaultExportTime { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [JsonRequired]
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// Apply update message to entity
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public Process ApplyUpdate(Process process)
        {
            process.Number = Number;
            process.Name = Name;
            process.Remarks = Remarks;
            process.ProcessTypeId = ProcessTypeId;
            process.DefaultMakeTypeId = DefaultMakeTypeId;
            process.DefaultImportTime = DefaultImportTime;
            process.DefaultExportTime = DefaultExportTime;
            process.CustomValues = JsonSerializer.SerializeToDocument(CustomValues);
            return process;
        }
    }
}
