using System;

namespace Abstractions.Persistence
{
    /// <summary>
    /// Marks a class as being auditable.
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// The name or identifier the entity/system/person that created this data
        /// </summary>
        string CreatedBy { get; set; }
        
        /// <summary>
        /// The name or identifier the entity/system/person that last updated this data
        /// </summary>
        string ModifiedBy { get; set; }
        
        /// <summary>
        /// When this data was created
        /// </summary>
        DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// When this data was last modified
        /// </summary>
        DateTime ModifiedAt { get; set; }
    }
}