using Newtonsoft.Json;

namespace SprmApi.Core.Parts.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdatePartVersionDto
    {
        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [JsonRequired]
        public Dictionary<string, string> CustomValues = new();

        /// <summary>
        /// Apply update message to entity
        /// </summary>
        /// <param name="partVersion"></param>
        /// <returns></returns>
        public PartVersion ApplyUpdate(PartVersion partVersion)
        {
            partVersion.Remarks = Remarks;
            partVersion.CustomValues = System.Text.Json.JsonSerializer.SerializeToDocument(CustomValues);
            return partVersion;
        }
    }
}
