using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PasswordsValidationTestTask.ViewModels
{
    class PasswordsInfoViewModel
    {
        public string PwdString { get; set; }
        public string PwdState { get; set; }
        public Brush Color { get; set; }

        public PasswordsInfoViewModel(string PwdString, string PwdState, Brush Color) 
        {
            this.PwdString = PwdString;
            this.PwdState = PwdState;
            this.Color = Color;
        }
    }
}
