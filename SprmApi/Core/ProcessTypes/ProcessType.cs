using Microsoft.EntityFrameworkCore;
using SprmApi.Core.Processes;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.ProcessTypes
{
    /// <summary>
    /// 製程類型
    /// </summary>
    [Table("process_types", Schema = "sprm")]
    [Comment("製程類型")]
    public class ProcessType : CustomizeObject
    {
        /// <summary>
        /// 製程類型對應的製程 (需要include)
        /// </summary>
        public ICollection<Process>? Processes { get; set; }
    }
}
