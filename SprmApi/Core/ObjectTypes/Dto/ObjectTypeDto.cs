namespace SprmApi.Core.ObjectTypes.Dto
{
    /// <summary>
    /// 物件類型
    /// </summary>
    public class ObjectTypeDto
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 料號
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 料件名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ObjectTypeDto Parse(ObjectType entity)
        {
            return new ObjectTypeDto { Id = entity.Id, Number = entity.Number, Name = entity.Name };
        }
    }
}
