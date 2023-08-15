using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprmCommon.Authentications;

namespace SprmCommon.MiddleWares
{
    /// <summary>
    /// Http Header資料，請將此這設為PerLifetimeScope
    /// </summary>
    public class HeaderData
    {
        /// <summary>
        /// Store bearer token
        /// </summary>
        public string Bearer { get; set; } = null!;

        /// <summary>
        /// Store decrypted JWT
        /// </summary>
        public JwtAccessPayload JWTPayload { get; set; } = null!;
    }
}
