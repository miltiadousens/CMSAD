using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
