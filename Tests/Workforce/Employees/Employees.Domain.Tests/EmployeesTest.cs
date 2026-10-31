using Employees.Domain.Exceptions;
using Employees.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;



namespace Employees.Domain.Tests
{

    public class PhoneNumberTests
    {
        [Theory]
        [InlineData("12345678", "12345678")]
        [InlineData("1234567", "1234567")]                 // mindste længde: 7 cifre
        [InlineData("123456789012345", "123456789012345")] // største længde: 15 cifre
        [InlineData("+4512345678", "+4512345678")]
        [InlineData("12 34 56 78", "12345678")]
        [InlineData("12-34-56-78", "12345678")]
        [InlineData("+45 12 34 56 78", "+4512345678")]
        public void Create_ShouldNormalizePhoneNumber_WhenPhoneNumberIsValid(string input, string expected)
        {
            var phoneNumber = PhoneNumber.Create(input);

            Assert.Equal(expected, phoneNumber.TelephoneNumber);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("123456")]            // 6 cifre: for kort
        [InlineData("1234567890123456")]  // 16 cifre: for langt
        [InlineData("0123456789")]        // må ikke starte med 0
        [InlineData("12345abc")]
        [InlineData("++4512345678")]
        public void Create_ShouldThrowDomainException_WhenPhoneNumberIsInvalid(string? input)
        {
            Assert.Throws<DomainException>(() => PhoneNumber.Create(input));
        }
    }

    public class NameTests
    {
        [Theory]
        [InlineData("John", "Doe")]
        [InlineData("Jane", "Smith")]
        public void Create_ShouldCreateName_WhenNameIsValid(string firstName, string lastName)
        {
            var name = Name.Create(firstName, lastName);
            Assert.Equal(firstName, name.FirstName);
            Assert.Equal(lastName, name.LastName);
        }
        [Theory]
        [InlineData(null, "Doe")]
        [InlineData("John", null)]
        [InlineData("", "Doe")]
        [InlineData("John", "")]
        [InlineData("   ", "Doe")]
        [InlineData("John", "   ")]
        public void Create_ShouldThrowDomainException_WhenNameIsInvalid(string firstName, string lastName)
        {
            Assert.Throws<DomainException>(() => Name.Create(firstName, lastName));
        }
    }

    public class EmailTests
    {
        [Theory]
        [InlineData("john.doe@example.com")]
        [InlineData("jane.smith@example.com")]
        public void Create_ShouldCreateEmail_WhenEmailIsValid(string email)
        {
            var emailValue = Email.Create(email);
            Assert.Equal(email, emailValue.Mail);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("invalid-email")]
        [InlineData("john.doe@")]
        [InlineData("@example.com")]
        public void Create_ShouldThrowDomainException_WhenEmailIsInvalid(string? email)
        {
            Assert.Throws<DomainException>(() => Email.Create(email));
        }
    }
}
