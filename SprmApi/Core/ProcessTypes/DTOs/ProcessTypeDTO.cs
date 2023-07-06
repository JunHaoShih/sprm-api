using SprmApi.Common.DTOs;
using SprmApi.Core.Customs.DTOs;
using SprmApi.Core.ProcessTypes;

namespace SprmApi.Core.ProcessTypes.DTOs
{
    /// <summary>
    /// 製程類型DTO
    /// </summary>
    public class ProcessTypeDTO : BaseReturnDto
    {
        /// <summary>
        /// 製程類型編號
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 製程類型名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否為系統預設
        /// </summary>
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// 語系顯示
        /// </summary>
        public Dictionary<string, string> Languages { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="processType"></param>
        /// <returns></returns>
        public static ProcessTypeDTO Parse(ProcessType processType)
        {
            var dto = new ProcessTypeDTO
            {
                Number = processType.Number,
                Name = processType.Name,
                Languages = processType.Languages,
                IsSystemDefault = processType.IsSystemDefault,
            };
            dto.Populate(processType);
            return dto;
        }
    }
}
