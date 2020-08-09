using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions.Persistence
{
    /// <summary>
    /// Data service responsible for creating/update/deleting entities.
    /// For more information see <see cref="IDomainEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">the type of the entity managed by this repository</typeparam>
    public interface IWriteRepository<in TEntity> where TEntity : IDomainEntity
    {
        #region INSERTS
        /// <summary>
        /// Asynchronously inserts the root entity only.
        /// </summary>
        /// <param name="entity">the root entity to insert</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task</returns>
        Task InsertAsync(TEntity entity, CancellationToken token = default);
        
        /// <summary>
        /// Asynchronously inserts a range of root entities.
        /// For more information see <see cref="InsertAsync"/>
        /// </summary>
        /// <param name="entities">the enumerable of entities to insert</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task</returns>
        Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken token = default);
        #endregion
        
        #region UPDATES
        /// <summary>
        /// Asynchronously updates the root entity only.
        /// </summary>
        /// <param name="entity">the root entity to update</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task</returns>
        Task UpdateAsync(TEntity entity, CancellationToken token = default);
        
        /// <summary>
        /// Asynchronously updates a range of root entities.
        /// For more information see <see cref="UpdateAsync"/>
        /// </summary>
        /// <param name="entities">the enumerable of entities to update</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task</returns>
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken token = default);
        #endregion

        #region MERGES
        /// <summary>
        /// Asynchronously merges the root entity as well as its associated child entities.
        ///   <b>Root entity behaviour</b>:
        ///    - If root entity does not exist in the store, it's inserted.
        ///    - If root entity exists in the store, it's updated.
        ///
        ///   <b>Child entities behaviour</b>:
        ///    - If child entities do not exist in the store, but are within the root entity, they are inserted.
        ///    - If child entities exist on the store, and within the the root entity, they are updated.
        ///    - If child entities exist on the store, and not within the root entity, they are deleted.
        /// </summary>
        /// <param name="entity">the root entity to merge</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task</returns>
        Task MergeAsync(TEntity entity, CancellationToken token = default);

        /// <summary>
        /// Asynchronously merges the root entities and their child entities.
        /// For more information see <see cref="MergeAsync"/>
        /// </summary>
        /// <param name="entities">the enumerable of entities to merge</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task</returns>
        Task MergeRangeAsync(IEnumerable<TEntity> entities, CancellationToken token = default);
        #endregion

        #region DELETES
        /// <summary>
        /// Asynchronously deletes the root entity as well as any cascading child entities and associations.
        /// </summary>
        /// <param name="entity">the root entity to delete</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task</returns>
        Task DeleteAsync(TEntity entity, CancellationToken token = default);
        
        /// <summary>
        /// Asynchronously deletes a range of root entities as well as any cascading child entities and associations.
        /// For more information see <see cref="DeleteAsync"/>
        /// </summary>
        /// <param name="entities">the enumerable of entities to delete</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task</returns>
        Task DeleteAsyncAsync(IEnumerable<TEntity> entities, CancellationToken token = default);
        #endregion
    }
}