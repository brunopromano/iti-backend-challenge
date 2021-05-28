using System;
using Iti.Challenge.RestApi.Utils;
using Xunit;

namespace Iti.Challenge.Tests.Unit
{
    public class ValidatePasswordTests
    {
        [Fact]
        public async void MustReturnFalseForNullPassword()
        {
            bool result = await ValidatePassword.IsValid("null");
            Assert.False(result);
        }

        [Fact]
        public async void MustReturnFalseForPasswordLessThanNineChars()
        {
            bool result = await ValidatePassword.IsValid("a34kjh2!");
            Assert.False(result);
        }
        
        [Fact]
        public async void MustReturnFalseWhenPasswordHasNoDigit()
        {
            bool result = await ValidatePassword.IsValid("ajf@#!hlk%kc");
            Assert.False(result);
        }
        
        [Fact]
        public async void MustReturnFalseWhenPasswordHasNoLowerCase()
        {
            bool result = await ValidatePassword.IsValid("AB!46IFG9Z");
            Assert.False(result);
        }

        [Fact]
        public async void MustReturnFalseWhenPasswordHasNoUpperCase()
        {
            bool result = await ValidatePassword.IsValid("df@gj87!*ak");
            Assert.False(result);
        }

        [Fact]
        public async void MustReturnFalseWhenPasswordHasNoSpecialChar()
        {
            bool result = await ValidatePassword.IsValid("for4 B0z0");
            Assert.False(result);
        }

        [Fact]
        public async void MustReturnTrueForValidPassword()
        {
            bool result = await ValidatePassword.IsValid("a%p6j7$Xc0");
            Assert.True(result);
        }
    }
}
