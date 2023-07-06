using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// 工藝路徑版本
    /// </summary>
    [Table("routing_versions", Schema = "sprm")]
    [Comment("工藝路徑版本")]
    public class RoutingVersion : IterableObject<Routing>, IDisposable
    {
        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [Required]
        [Column("custom_values")]
        [Comment("自訂屬性值")]
        public JsonDocument CustomValues { get; set; } = null!;

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose custom values
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            CustomValues.Dispose();
        }
    }
}
