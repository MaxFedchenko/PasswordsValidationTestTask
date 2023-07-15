using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordsValidationTestTask.Models.Services
{
    class PasswordStringValidator : IPasswordStringValidator
    {
        class PasswordInfo
        {
            public char repSymbol { get; init; }
            public int minRep { get; init; }
            public int maxRep { get; init; }
            public string password { get; init; }

            public static PasswordInfo TryParse(string passwordStr)
            {
                passwordStr = passwordStr.Trim();

                var strs = passwordStr.Split(' ', 3);
                string[] rep_limit_strs;
                if (strs.Length != 3 ||
                    strs[0].Length != 1 ||
                    (rep_limit_strs = strs[1].Split('-')).Length != 2 ||
                    !int.TryParse(rep_limit_strs[0], out int min_rep) ||
                    !int.TryParse(rep_limit_strs[1], out int max_rep))
                    return null;

                return new PasswordInfo
                {
                    repSymbol = strs[0][0],
                    minRep = min_rep,
                    maxRep = max_rep,
                    password = strs[2]
                };
            }
        }

        public bool? Validate(string passwordStr)
        {
            var pwd_info = PasswordInfo.TryParse(passwordStr);
            if (pwd_info is null) return null;

            int rep_amount = pwd_info.password.Count(s => s == pwd_info.repSymbol);
            return rep_amount >= pwd_info.minRep && rep_amount <= pwd_info.maxRep;
        }
    }
}
