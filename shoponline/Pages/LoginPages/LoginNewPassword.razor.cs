using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace shoponline.Pages.LoginPages
{
    public partial class LoginNewPassword
    {
        public string Fehlermeldung { get; set; }
        public string colorFehlermeldung { get; set; }
        public string newPassword { get; set; }
        public string confirmNewPassword { get; set; }
        public string generatedPassword { get; set; }
        public string hallo { get; set; }
        public bool buttonClicked { get; set; } = false;
        private Regex hasNumber = new Regex(@"[0-9]+");
        private Regex hasUpperChar = new Regex(@"[A-Z]+");
        private Regex hasLowerChar = new Regex(@"[a-z]+");
        private Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

        public void validateForm()
        {
            buttonClicked = false;
            if (checkPasswordFormat())
            {
                Fehlermeldung = "Dein neues Password ist " + confirmNewPassword;
                if (string.IsNullOrEmpty(ForgotPassword.Email) || string.IsNullOrEmpty(ForgotPassword.newPassword))
                {
                    Fehlermeldung = " Email-Adresse nicht bekannt";
                    colorFehlermeldung = "red";
                    return;
                }
                if (ForgotPassword.newPassword == generatedPassword)
                {
                    Fehlermeldung = " Password erfolgreich geändert";
                    colorFehlermeldung = "green";
                    localStorage.SetItem(ForgotPassword.Email, newPassword);
                    buttonClicked = true;

                    //NavigationManager.NavigateTo("/login");  
                }
                else
                {
                    Fehlermeldung = " generiertes Password falsch";
                    colorFehlermeldung = "red";
                    return;
                }
            }
        }
        public bool checkPasswordFormat()
        {

            if (newPassword != confirmNewPassword)
            {
                Fehlermeldung = " New Password and ConfirmPassword must be the same";
                colorFehlermeldung = "red";
                return false;
            }

            if (!hasLowerChar.IsMatch(newPassword))
            {
                Fehlermeldung = "Password should contain at least one lower case letter.";
                colorFehlermeldung = "red";
                return false;
            }
            else if (!hasUpperChar.IsMatch(newPassword))
            {
                Fehlermeldung = "Password should contain at least one upper case letter.";
                colorFehlermeldung = "red";
                return false;
            }
            else if (!hasNumber.IsMatch(newPassword))
            {
                Fehlermeldung = "Password should contain at least one numeric value.";
                colorFehlermeldung = "red";
                return false;
            }

            else if (!hasSymbols.IsMatch(newPassword))
            {
                Fehlermeldung = "Password should contain at least one special case character.";
                colorFehlermeldung = "red";
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
