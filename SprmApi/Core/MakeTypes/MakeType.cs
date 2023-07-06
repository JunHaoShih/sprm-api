using Microsoft.EntityFrameworkCore;
using SprmApi.Core.Processes;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.MakeTypes
{
    /// <summary>
    /// 製造類型
    /// </summary>
    [Table("make_types", Schema = "sprm")]
    [Comment("製造類型")]
    public class MakeType : CustomizeObject
    {
        /// <summary>
        /// 製程類型對應的製程 (需要include)
        /// </summary>
        public ICollection<Process>? Processes { get; set; }
    }
}
