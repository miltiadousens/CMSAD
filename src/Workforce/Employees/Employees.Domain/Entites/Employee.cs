using Employees.Domain.Exceptions;
using Employees.Domain.ValueObjects;
using Employees.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Employees.Domain.Entites
{
    public class Employee : AggregateRoot
    {
        public Name Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public PhoneNumber PhoneNumber { get; private set; }
        public bool IsActive { get; private set; }

        private Employee() { } // EF Core

        private Employee(Name name, Email email, PhoneNumber phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            IsActive = true;
            
        }

        public static Employee Create(string firstName, string lastName, string email, string phoneNumber)
        {
            var name = Name.Create(firstName, lastName);
            var emailValue = Email.Create(email);
            var phone = PhoneNumber.Create(phoneNumber);
            return new Employee(name, emailValue, phone);
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        
    }
}
