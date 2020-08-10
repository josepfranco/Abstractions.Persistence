using System;

namespace Abstractions.Persistence
{
    /// <summary>
    /// Marks a class as being a domain entity. An entity always has an internal identifier,
    /// a global unique identifier and audit metadata (see <see cref="IAuditable"/>).
    /// </summary>
    public interface IDomainEntity : IAuditable
    {
        /// <summary>
        /// The internal identifier for this entity. Usually it's automatically generated.
        /// </summary>
        long Id { get; set; }
        
        /// <summary>
        /// The global unique identifier for this entity.
        /// </summary>
        Guid GlobalId { get; set; }
    }
}