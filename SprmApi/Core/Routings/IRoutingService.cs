using SprmApi.Common.Paginations;
using SprmApi.Core.Routings.DTOs;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing service interface
    /// </summary>
    public interface IRoutingService
    {
        /// <summary>
        /// Create a new routing
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        Task<RoutingDto> InsertAsync(CreateRoutingDTO createDTO);

        /// <summary>
        /// Get routings by part id
        /// </summary>
        /// <param name="partId">Part id</param>
        /// <param name="input">Offset pagination input</param>
        /// <returns></returns>
        OffsetPagination<RoutingDto> GetByPartIdAsync(long partId, OffsetPaginationInput input);

        /// <summary>
        /// Get routing by id
        /// </summary>
        /// <param name="routingId">Routing id</param>
        /// <returns></returns>
        Task<RoutingDto?> GetByIdAsync(long routingId);

        /// <summary>
        /// Check-in routing
        /// </summary>
        /// <param name="routingId">Routing id</param>
        /// <returns></returns>
        Task<RoutingDto> CheckInAsync(long routingId);

        /// <summary>
        /// Check-out routing
        /// </summary>
        /// <param name="routingId">Routing id</param>
        /// <param name="versionId"></param>
        /// <returns></returns>
        Task<RoutingDto> CheckOutAsync(long routingId, long? versionId = null);

        /// <summary>
        /// Discard current checkout routing
        /// </summary>
        /// <param name="routingId"></param>
        /// <returns></returns>
        Task<RoutingDto> DiscardAsync(long routingId);
    }
}
