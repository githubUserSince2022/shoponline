using System.Text.RegularExpressions;

namespace shoponline.Pages.LoginPages
{
    public partial class Register
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }

        public string colorFehlermeldung { get; set; }
        public string fehlermeldung { get; set; }

        public string zeichenPassword { get; set; } = "red";
        public string großPassword { get; set; } = "red";
        public string kleinPassword { get; set; } = "red";
        public string zahlPassword { get; set; } = "red";
        public string sonderZeichenPassword { get; set; } = "red";

        private Regex hasNumber = new Regex(@"[0-9]+");
        private Regex hasUpperChar = new Regex(@"[A-Z]+");
        private Regex hasLowerChar = new Regex(@"[a-z]+");
        private Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");


        public void eingabePassWordInput()
        {
            if (hasLowerChar.IsMatch(password))
            {
                kleinPassword = "green";
            }
            else
            {
                kleinPassword = "red";
            }

            if (hasUpperChar.IsMatch(password))
            {
                großPassword = "green";
            }
            else
            {
                großPassword = "red";
            }
            if (hasNumber.IsMatch(password))
            {
                zahlPassword = "green";
            }
            else
            {
                zahlPassword = "red";
            }
            if (hasSymbols.IsMatch(password))
            {
                sonderZeichenPassword = "green";
            }
            else
            {
                sonderZeichenPassword = "red";
            }
            if (password.Length >= 8)
            {
                zeichenPassword = "green";
            }
            else
            {
                zeichenPassword = "red";
            }
        }

        private void validateForm()
        {
            if (checkSamePasswords())
            {
                colorFehlermeldung = "white";
                fehlermeldung = "";
            }
            else
            {
                colorFehlermeldung = "red";
                fehlermeldung = "Beide Passwörter sind nicht gleich!!";
                return;
            }
            if (!checkPasswordFormat())
            {
                colorFehlermeldung = "red";
                return;
            }
            else
            {
                colorFehlermeldung = "white";
            }
            if (checkIfEmailExists())
            {
                fehlermeldung = " Email existiert schon! Bitte versuchen Sie das mit einer anderen Email-Adresse";
                colorFehlermeldung = "red";
                return;
            }

            if (addItem())
            {
                userName = "";
                firstName = "";
                lastName = "";
                email = "";
                password = "";
                confirmPassword = "";
            }
            fehlermeldung = "Benutzer erstellt. Jetzt kannst du dich einloggen";
            colorFehlermeldung = "green";
        }

        private bool checkSamePasswords()
        {
            if (password == confirmPassword)
            {
                return true;
            }
            return false;
        }
        private bool checkPasswordFormat()
        {
            if (!hasLowerChar.IsMatch(password))
            {
                fehlermeldung = "Password should contain at least one lower case letter.";
                return false;
            }
            else if (!hasUpperChar.IsMatch(password))
            {
                fehlermeldung = "Password should contain at least one upper case letter.";
                return false;
            }
            else if (!hasNumber.IsMatch(password))
            {
                fehlermeldung = "Password should contain at least one numeric value.";
                return false;
            }

            else if (!hasSymbols.IsMatch(password))
            {
                fehlermeldung = "Password should contain at least one special case character.";
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool addItem()
        {
            try
            {
                localStorage.SetItem(email + "", password);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        private bool checkIfEmailExists()
        {
            return localStorage.ContainKey(email);
        }
    }
}
