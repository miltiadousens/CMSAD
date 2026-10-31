using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Employees.Domain.Exceptions;

namespace Employees.Domain.ValueObjects
{
    public sealed class Name
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Validate();
        }

        public static Name Create(string firstName, string lastName)
        {
            return new Name(firstName, lastName);
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new DomainException("Fornavn må ikke være tomt eller kun bestå af mellemrum");

            if (string.IsNullOrWhiteSpace(LastName))
                throw new DomainException("Efternavn må ikke være tomt eller kun bestå af mellemrum");
        }
    }
}
