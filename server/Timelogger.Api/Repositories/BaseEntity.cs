using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api.Repositories
{
    /// <summary>
    /// Defines the base entity of entities.
    /// </summary>
    public class BaseEntity
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
