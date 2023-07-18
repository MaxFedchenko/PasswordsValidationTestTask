using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using PasswordsValidationTestTask.Core;
using PasswordsValidationTestTask.Models.Services;

namespace PasswordsValidationTestTask.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private readonly IPasswordStringsProviderService pwdStrProvService;
        private readonly IPasswordStringValidator pwdStrValidService;

        private int? validPwdsAmount;
        public int? ValidPwdsAmount
        {
            get => validPwdsAmount;
            set
            {
                validPwdsAmount = value;
                OnPropertyChanged(nameof(ValidPwdsAmount));
            }
        }

        public ObservableCollection<PasswordsInfoViewModel> PasswordsInfo { get; set; }

        public RelayCommand OpenFileCmd { get; }

        public MainViewModel(IPasswordStringsProviderService pwdStrProvService, IPasswordStringValidator pwdStrValidService)
        {
            this.pwdStrProvService = pwdStrProvService;
            this.pwdStrValidService = pwdStrValidService;

            OpenFileCmd = new RelayCommand(OpenFile);

            PasswordsInfo = new();
        }

        private void OpenFile(object? obj) 
        {
            var strs = pwdStrProvService.GetStrings();

            if (strs is null) return;

            PasswordsInfo.Clear();
            int valid_passwords = 0;

            foreach (var str in strs) 
            {
                bool? is_valid = pwdStrValidService.Validate(str);
                if (is_valid == true) valid_passwords++;

                PasswordsInfo.Add(new (str, 
                    is_valid == true ? "Valid" : (is_valid == false ? "Invalid" : "Wrong format"),
                    is_valid == true ? Brushes.Green : (is_valid == false ? Brushes.Red : Brushes.SandyBrown)));
            }

            ValidPwdsAmount = valid_passwords;
        }
    }
}
