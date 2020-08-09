using System;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions.Persistence
{
    /// <summary>
    /// Contract for a service responsible for a unit of work or transaction.
    /// </summary>
    public interface IUnitOfWork : IAsyncDisposable
    {
        /// <summary>
        /// Commits all the persistence operations into a single transaction.
        /// </summary>
        /// <param name="whoCommitted">identifier or name of the committer, see <see cref="IAuditable"/></param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task</returns>
        Task CommitAsync(string whoCommitted, CancellationToken token = default);
    }
}