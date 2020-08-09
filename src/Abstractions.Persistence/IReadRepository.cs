using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions.Persistence
{
    /// <summary>
    /// The contract for a read-only repository.
    /// For more information see <see cref="IDomainEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">the type of the entity managed by this repository</typeparam>
    public interface IReadRepository<TEntity> where TEntity : IDomainEntity
    {
        /// <summary>
        /// Reads a single entity asynchronously by its internal identifier.
        /// </summary>
        /// <param name="id">the internal identifier</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>the entity instance</returns>
        Task<TEntity> ReadByIdAsync(long id, CancellationToken token = default);
        
        /// <summary>
        /// Reads a single entity asynchronously by its global unique identifier.
        /// </summary>
        /// <param name="globalId">the global unique identifier</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>the entity instance</returns>
        Task<TEntity> ReadByGlobalIdAsync(Guid globalId, CancellationToken token = default);
        
        /// <summary>
        /// Reads all the available entities asynchronously
        /// </summary>
        /// <param name="token">the cancellation token</param>
        /// <returns>enumerable of all the entities</returns>
        Task<IEnumerable<TEntity>> ReadAllAsync(CancellationToken token = default);
    }
}