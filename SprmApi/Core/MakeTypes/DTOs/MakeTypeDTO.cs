using SprmApi.Common.DTOs;
using SprmApi.Core.MakeTypes;

namespace SprmApi.Core.MakeTypes.DTOs
{
    /// <summary>
    /// 製造類型DTO
    /// </summary>
    public class MakeTypeDTO : BaseReturnDto
    {
        /// <summary>
        /// 製造類型編號
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 製造類型名稱
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
        public static MakeTypeDTO Parse(MakeType processType)
        {
            var dto = new MakeTypeDTO
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
