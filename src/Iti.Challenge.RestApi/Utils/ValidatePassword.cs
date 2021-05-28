using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Iti.Challenge.RestApi.Utils
{
    public static class ValidatePassword 
    {
        private const string rgxPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{9,})";

        public static async Task<bool> IsValid(string input)
        {
            return await Task.FromResult(Regex.Match(input, rgxPattern).Success);
        }
    }
}