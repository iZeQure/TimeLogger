using System;
using System.Collections.Generic;
using System.Text;

namespace Timelogger.Models
{
    /// <summary>
    /// Defines the base entity of entities.
    /// </summary>
    public abstract class BaseEntity
    {
        private int _entityId;

        /// <summary>
        /// The Entity unique identifier.
        /// </summary>
        public int EntityId
        {
            get => _entityId;
            set => _entityId = value;
        }
    }
}
