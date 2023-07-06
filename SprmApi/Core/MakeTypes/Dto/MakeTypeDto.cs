using SprmApi.Common.Dto;

namespace SprmApi.Core.MakeTypes.Dto
{
    /// <summary>
    /// 製造類型DTO
    /// </summary>
    public class MakeTypeDto : BaseReturnDto
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
        public static MakeTypeDto Parse(MakeType processType)
        {
            var dto = new MakeTypeDto
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
