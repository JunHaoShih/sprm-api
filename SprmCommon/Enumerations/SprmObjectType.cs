namespace SprmCommon.Enumerations
{
    /// <summary>
    /// 物件類別
    /// </summary>
    public enum SprmObjectType
    {
        /// <summary>
        /// 未知(表示錯誤)
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 料件版本
        /// </summary>
        PartVersion = 1,
        /// <summary>
        /// 料件使用關係
        /// </summary>
        PartUsage = 2,
        /// <summary>
        /// 產品途程
        /// </summary>
        Routing = 3,
        /// <summary>
        /// 產品途程版本
        /// </summary>
        RoutingVersion = 4,
        /// <summary>
        /// 製程
        /// </summary>
        Process = 5,
        /// <summary>
        /// 工藝路徑使用關係
        /// </summary>
        RoutingUsage = 6,
        /// <summary>
        /// 自訂屬性
        /// </summary>
        CustomAttribute = 7,
        /// <summary>
        /// 屬性連結
        /// </summary>
        AttributeLink = 8,
        /// <summary>
        /// App使用者
        /// </summary>
        AppUser = 9,
    }
}
