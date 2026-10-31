using Employees.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Employees.Domain.ValueObjects
{
    public sealed class PhoneNumber
    {
        public string TelephoneNumber { get; private set; }

        public PhoneNumber(string phoneNumberValue)
        {
            TelephoneNumber = phoneNumberValue;
            Validate();
        }

        public static PhoneNumber Create(string? value)
        {
            var normalized = value?.Replace(" ", "").Replace("-", "") ?? "";
            return new PhoneNumber(normalized);
        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(TelephoneNumber))
                throw new DomainException("Telefonnummer må ikke være tomt eller kun bestå af mellemrum");
            if (!Regex.IsMatch(TelephoneNumber, @"^\+?[1-9]\d{6,14}$"))
                throw new DomainException("Telefonnummeret skal være af et gyldigt format");
        }
    }
}
