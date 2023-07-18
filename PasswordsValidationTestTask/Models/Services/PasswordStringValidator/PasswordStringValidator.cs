using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordsValidationTestTask.Models.Services
{
    class PasswordStringValidator : IPasswordStringValidator
    {
        private static readonly Regex regex = new Regex("^(.) (\\d*)-(\\d*): (.*)");

        public bool? Validate(string passwordStr)
        {
            var match = regex.Match(passwordStr);
            if (!match.Success) return null;

            var password = match.Groups[4].Value;
            var symbol = match.Groups[1].Value[0];
            var min_rep = int.Parse(match.Groups[2].Value);
            var max_rep = int.Parse(match.Groups[3].Value);

            int rep_amount = password.Count(s => s == symbol);
            return rep_amount >= min_rep && rep_amount <= max_rep;
        }
    }
}
