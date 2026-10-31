using Employees.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Employees.Domain.ValueObjects
{
    public sealed record Email
    {
        public string Mail { get; }

        private Email(string mail)
        {
            Mail = mail;
        }

        public static Email Create(string? value)
        {
            var normalized = value?.Trim().ToLowerInvariant() ?? "";

            if (!Regex.IsMatch(normalized, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new DomainException("Email har ikke et gyldigt format.");

            return new Email(normalized);
        }
    }
}
