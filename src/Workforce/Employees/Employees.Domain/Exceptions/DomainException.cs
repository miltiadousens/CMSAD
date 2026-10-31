using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Domain.Exceptions
{
    public class DomainException(string message) : Exception(message);
}
