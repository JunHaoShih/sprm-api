using System.Text.Json;
using SprmApi.Common.DTOs;
using SprmApi.Core.MakeTypes.DTOs;
using SprmApi.Core.ProcessTypes.DTOs;

namespace SprmApi.Core.Processes.DTOs
{
    /// <summary>
    /// 製程回傳DTO
    /// </summary>
    public class ProcessDTO : BaseReturnDTO
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
        public ProcessTypeDTO ProcessType { get; set; } = null!;

        /// <summary>
        /// 製造類型
        /// </summary>
        public MakeTypeDTO DefaultMakeType { get; set; } = null!;

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues = new();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static ProcessDTO Parse(Process process)
        {
            ProcessDTO dto = new ProcessDTO
            {
                Number = process.Number,
                Name = process.Name,
                DefaultImportTime = process.DefaultImportTime,
                DefaultExportTime = process.DefaultExportTime,
                ProcessType = ProcessTypeDTO.Parse(process.ProcessType!),
                DefaultMakeType = MakeTypeDTO.Parse(process.MakeType!),
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(process.CustomValues)!,
            };
            dto.Populate(process);
            return dto;
        }
    }
}
