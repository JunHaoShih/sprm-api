using SprmApi.Common.Dto;
using SprmApi.Core.MakeTypes.Dto;
using SprmApi.Core.ProcessTypes.Dto;
using System.Text.Json;

namespace SprmApi.Core.Processes.Dto
{
    /// <summary>
    /// 製程回傳DTO
    /// </summary>
    public class ProcessDto : BaseReturnDto
    {
        /// <summary>
        /// 料號
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 料件名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 預設進站時間(毫秒)
        /// </summary>
        public int DefaultImportTime { get; set; }

        /// <summary>
        /// 預設出站時間(毫秒)
        /// </summary>
        public int DefaultExportTime { get; set; }

        /// <summary>
        /// 製程類型
        /// </summary>
        public ProcessTypeDto ProcessType { get; set; } = null!;

        /// <summary>
        /// 製造類型
        /// </summary>
        public MakeTypeDto DefaultMakeType { get; set; } = null!;

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static ProcessDto Parse(Process process)
        {
            ProcessDto dto = new ProcessDto
            {
                Number = process.Number,
                Name = process.Name,
                DefaultImportTime = process.DefaultImportTime,
                DefaultExportTime = process.DefaultExportTime,
                ProcessType = ProcessTypeDto.Parse(process.ProcessType!),
                DefaultMakeType = MakeTypeDto.Parse(process.MakeType!),
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(process.CustomValues)!,
            };
            dto.Populate(process);
            return dto;
        }
    }
}
