using System.Text.Json;
using System.Text.Json.Serialization;
using SprmApi.Common.Validations;

namespace SprmApi.Core.Processes.Dto
{
    /// <summary>
    /// 建立製程DTO
    /// </summary>
    public class CreateProcessDto
    {
        /// <summary>
        /// Part number
        /// </summary>
        [JsonRequired]
        [NumberValidation(MinNumberLength = 2)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// Part name
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
        public long ProcessTypeId { get; set; }

        /// <summary>
        /// 預設製造類型id
        /// </summary>
        public long DefaultMakeTypeId { get; set; }

        /// <summary>
        /// 預設進站時間(毫秒)
        /// </summary>
        public int DefaultImportTime { get; set; }

        /// <summary>
        /// 預設出站時間(毫秒)
        /// </summary>
        public int DefaultExportTime { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// DTO to entity
        /// </summary>
        /// <returns></returns>
        public Process ToEntity()
        {
            return new Process
            {
                Number = Number,
                Name = Name,
                Remarks = Remarks,
                ProcessTypeId = ProcessTypeId,
                DefaultMakeTypeId = DefaultMakeTypeId,
                DefaultImportTime = DefaultImportTime,
                DefaultExportTime = DefaultExportTime,
                CustomValues = JsonSerializer.SerializeToDocument(CustomValues),
            };
        }
    }
}
