using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace PasswordsValidationTestTask.Models.Services
{
    class PasswordStringsProviderService : IPasswordStringsProviderService
    {
        public IEnumerable<string> GetStrings()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Text files|*.txt";

            if (dialog.ShowDialog() == true)
                return File.ReadAllLines(dialog.FileName);
            return null;
        }
    }
}
