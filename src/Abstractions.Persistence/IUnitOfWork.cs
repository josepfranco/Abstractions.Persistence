namespace Abstractions.Persistence
{
    /// <summary>
    /// Contract for a service responsible for a unit of work or transaction.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets a write-only repository instance for a specific entity.
        /// </summary>
        /// <typeparam name="TEntity">the associated entity type</typeparam>
        /// <returns>instance of write-only repository</returns>
        IWriteRepository<TEntity> GetRepository<TEntity>() 
            where TEntity : class, IDomainEntity;

        /// <summary>
        /// Begins a new transaction.
        /// </summary>
        /// <param name="auditOwner">the name/identifier of the owner of the transaction, <see cref="IAuditable"/></param>
        void Begin(string auditOwner);
        
        /// <summary>
        /// Commits the ongoing transaction transaction.
        /// </summary>
        void Commit();
    }
}